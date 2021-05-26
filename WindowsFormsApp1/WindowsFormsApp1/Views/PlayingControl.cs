using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;
using WindowsFormsApp1.Properties;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;
using Timer = System.Windows.Forms.Timer;


namespace WindowsFormsApp1.Views
{
    public partial class PlayingControl : UserControl, IControl
    {
        public int BotsGeneratingFrequence = 1000;
        private int botsMinSpeed = 5;
        private Game game;
        private int botsArrayPointer;
        private bool leftKeyPressed, rightKeyPressed, upKeyPressed, downKeyPressed;
        
        private float steering, //-1 is left, 0 is center, 1 is right
            throttle, //0 is coasting, 1 is full throttle
            brakes; //0 is no brakes, 1 is full brakes

        public PlayingControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            this.game = game;
            InitializeGameObjects();
        }

        public void InitializeGameObjects()
        {
            DoubleBuffered = true;
            var timer = new Timer {Interval = 50};
            timer.Tick += (_, _) => { Invalidate(); };
            timer.Start();

            Paint += (_, e) =>
            {
                var g = e.Graphics;
                foreach (var road in game.Roads.RoadsArray)
                {
                    PaintObject(road, road.Image, g);
                }

                PaintObject(game.Car, Resources.Audi, g);
                foreach (var car in game.Bots)
                {
                    if (car == null) continue;
                    PaintObject(car, car.Image, g);
                }
            };

            KeyDown += (_, args) => KeyDownEventHandler(args);
            KeyUp += (_, args) => KeyUpEventHandler(args);
            Task.Run(() => { RandomCarGenerateInThread(); });
            Task.Run(() => { UpdateCarInThread(); });
            Task.Run(() => { CheckCollisions(); });
            new Task(() => MoveRoadInThread(game.Roads)).Start();
        }

        private void KeyUpEventHandler(KeyEventArgs args)
        {
            switch (args.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    leftKeyPressed = false;
                    break;
                case Keys.D:
                case Keys.Right:
                    rightKeyPressed = false;
                    break;
                case Keys.W:
                case Keys.Up:
                    upKeyPressed = false;
                    break;
                case Keys.S:
                case Keys.Down:
                    downKeyPressed = false;
                    break;
                default:
                    return;
            }

            ProcessInput();
        }

        private void KeyDownEventHandler(KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Escape)
            {
                game.Stop();
            }

            switch (args.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    leftKeyPressed = true;
                    break;
                case Keys.D:
                case Keys.Right:
                    rightKeyPressed = true;
                    break;
                case Keys.W:
                case Keys.Up:
                    upKeyPressed = true;
                    break;
                case Keys.S:
                case Keys.Down:
                    downKeyPressed = true;
                    break;
                default:
                    return;
            }

            ProcessInput();
        }

        private void ProcessInput()
        {
            if (leftKeyPressed)
                steering = -1;
            else if (rightKeyPressed)
                steering = 1;
            else
                steering = 0;

            throttle = upKeyPressed ? -1 : 0;
            brakes = downKeyPressed ? 1 : 0;
        }


        private static void PaintObject(VisualizeableObject obj, Bitmap img, Graphics g)
        {
            g.DrawImage(img, obj.Location.X, obj.Location.Y, img.Width, img.Height);
        }

        private void UpdateCarInThread()
        {
            while (game.Stage == GameStage.Playing)
            {
                Thread.Sleep(5);
                game.Car.Move((int) steering, (int) (throttle + brakes));
            }
        }

        private void MoveRoadInThread(Roads roads)
        {
            while (game.Stage == GameStage.Playing)
            {
                Thread.Sleep(50);
                roads.ShiftDown((int)(game.Car.Speed*0.7));
            }
        }

        private void RandomCarGenerateInThread()
        {
            while (game.Stage == GameStage.Playing)
            {
                Thread.Sleep(BotsGeneratingFrequence);
                var car = RandomCarGenerator.GetRandomCar();
                game.Bots[botsArrayPointer] = car;
                if (++botsArrayPointer >= game.Bots.Length) botsArrayPointer = 0;
                Task.Run(() =>
                {
                    while (car.Location.Y < 1100)
                    {
                        Thread.Sleep(20);
                        car.ShiftDown((int)(game.Car.Speed*0.65+botsMinSpeed));
                    }
                });
            }
        }

        public void Stop()
        {
            Controls.Clear();
        }

        private void CheckCollisions()
        {
            while (game.Stage == GameStage.Playing)
            {
                Thread.Sleep(20);
                foreach (var bot in game.Bots.Where(b => b != null))
                {
                    if (game.Car.HitBox.IsCollide(bot.HitBox)) game.Stop();
                }
            }
        }
    }
}