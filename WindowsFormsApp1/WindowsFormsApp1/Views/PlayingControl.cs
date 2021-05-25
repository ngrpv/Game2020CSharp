using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using WindowsFormsApp1.Domain;
using WindowsFormsApp1.Properties;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;
using Timer = System.Windows.Forms.Timer;


namespace WindowsFormsApp1.Views
{
    public partial class PlayingControl : UserControl, IControl
    {
        private Game game;
        private int temp = 0;
        
        bool leftKeyPressed = false, rightKeyPressed = false;
        bool upKeyPressed = false, downKeyPressed = false;
        
        float steering = 0; //-1 is left, 0 is center, 1 is right
        float throttle = 0; //0 is coasting, 1 is full throttle
        float brakes = 0; //0 is no brakes, 1 is full brakes

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
            var timer = new Timer();
            timer.Interval = 50;
            timer.Tick += (sender, args) =>
            {
                Invalidate();
            };
            timer.Start();

            Paint += (o, e) =>
            {
                var g = e.Graphics;
                foreach (var road in game.roads.RoadsArray)
                {
                    PaintObject(road, road.Image, g);
                }
                PaintObject(game.Car, Resources.Audi, g);
                foreach (var car in game.Bots)
                {
                    if(car == null) continue;
                    PaintObject(car, car.Image, g);
                }
            };

            KeyDown += (_, args) => KeyDownEventHandler(_,args);
            KeyUp += (_, args) => KeyUpEventHandler(_, args);
            Task.Run(() => { RandomCarGenerateInThread(); });
            Task.Run(() => { UpdateCarInThread();});
            Task.Run(() => { CheckCollisions(); });
             new Task(() => MoveRoadInThread(game.roads, game.Car.Speed)).Start();

        }

        private void KeyUpEventHandler(object sender, KeyEventArgs args)
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

        private void KeyDownEventHandler(object sender, KeyEventArgs args)
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
        

        private void PaintObject(VisualizeableObject obj, Bitmap img, Graphics g)
        {
            g.DrawImage(img, obj.Location.X, obj.Location.Y, img.Width, img.Height);
        }

        private void UpdateCarInThread()
        {
            while (game.Stage == GameStage.Playing)
            {
                Thread.Sleep(5);
                game.Car.Move((int)steering, (int)(throttle+brakes));
                //  car.UpdatePictureLocation();
            }
        }

        private void MoveRoadInThread(Roads roads, int speed)
        {
            //Task.Factory.StartNew(() =>
            // {
            while (game.Stage == GameStage.Playing)
            {
                Thread.Sleep(50);
                roads.ShiftDown((int)game.Car.Speed);

                //roads.ShiftDown(speed);
            }

            // });
        }

        private void RandomCarGenerateInThread()
        {
            //Task.Factory.StartNew(() =>
            //{
            while (game.Stage == GameStage.Playing)
            {
                Thread.Sleep(3000);
                var car = RandomCarGenerator.GetRandomCar();
                game.Bots[temp] = car;
                if (++temp > game.Bots.Length - 1) temp = 0;
                car.ShiftDownByTimer(50, 10);
            }

            //});
        }

        public void Stop()
        {
            //game.Stop();
            Controls.Clear();
        }

        private void KeyPressEventHandler(char keyChar)
        {
            if (keyChar == (char)Keys.Escape)
            {
                game.Stop();
            }
            else game.MoveCar(keyChar);
        }

        private void CheckCollisions()
        {
            while (game.Stage == GameStage.Playing)
            {
                Thread.Sleep(20);
                foreach (var bot in game.Bots.Where(b=>b!=null))
                {
                    if (game.Car.HitBox.IsCollide(bot.HitBox)) game.Stop();
                }
            }
        }
    }
}