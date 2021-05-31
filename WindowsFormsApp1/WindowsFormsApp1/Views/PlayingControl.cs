using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        private Game game;
        private const int MinBotsGeneratingTime = 300;
        private int BotsGeneratingFrequence = 1000;
        private const int BotsMinSpeed = 5;
        private int botsArrayPointer;

        private bool leftKeyPressed, rightKeyPressed, upKeyPressed, downKeyPressed;

        private float
            steering, //-1 is left, 0 is center, 1 is right
            throttle, //0 is coasting, 1 is full throttle
            brakes; //0 is no brakes, 1 is full brakes

        public PlayingControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            this.game = game;
            game.IsOver = false;
            InitializeGameObjects();
        }

        private void StopPlayer()
        {
            game.StopMusic();
        }

        

        private void InitializeGameObjects()
        {
            DoubleBuffered = true;
            var timer = new Timer {Interval = 5};
            timer.Tick += (_, _) =>
            {
                if (game.IsOver) timer.Stop();
                Invalidate();
            };
            timer.Start();
            var botsFrerquenceIncreasingTimer = new Timer {Interval = 100};
            botsFrerquenceIncreasingTimer.Tick += (_, _) =>
            {
                if (BotsGeneratingFrequence > MinBotsGeneratingTime)
                    BotsGeneratingFrequence -= 1;
            };
            botsFrerquenceIncreasingTimer.Start();


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

            InvokeInThreads(RandomCarGenerate, UpdateCar, CheckCollisions, () => MoveRoad(game.Roads));
        }

        private static void InvokeInThreads(params Action[] actions)
        {
            foreach (var action in actions)
                Task.Run(action);
        }

        public void Freeze()
        {
            game.IsOver = true;
            Thread.Sleep(5);
            BeginInvoke((Action)(StopPlayer));
            var gameOverPanel = new Panel()
            {
                BackgroundImage = Resources.gameovertext,
                Size = new Size(700, 400),
                BackColor = Color.Transparent,
                Location = new(610, 340),
            };
            var toMenuButton = new PictureBox()
            {
                Image = Resources.lil_menu,
                Location = new(200, 321),
                SizeMode = PictureBoxSizeMode.AutoSize
            };
            var restartButton = new PictureBox()
            {
                Image = Resources.lil_again, 
                Location = new(200, 239), 
                SizeMode = PictureBoxSizeMode.AutoSize
            };
            toMenuButton.Click += (_, _) => game.Stop();
            restartButton.Click += (_, _) =>
            {
                Restart();
            };
            gameOverPanel.Controls.Add(toMenuButton);
            gameOverPanel.Controls.Add(restartButton);
            BeginInvoke((Action) (() => Controls.Add(gameOverPanel)));
        }

        public void Stop()
        {
            game.IsOver = true;
            Controls.Clear();
        }

        private static void PaintObject(VisualizeableObject obj, Bitmap img, Graphics g)
        {
            g.DrawImage(img, obj.Location.X, obj.Location.Y, img.Width, img.Height);
        }

        private void Restart()
        {
            game.IsOver = true;
            Controls.Clear();
            game.Start();
            BotsGeneratingFrequence = 1200;
        }

        #region KeysHandler

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
                Freeze();
                //game.Stop();
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

        #endregion


        #region ThreadMethods

        private void UpdateCar()
        {
            while (!game.IsOver)
            {
                Thread.Sleep(5);
                game.Car.Move((int) steering, (int) (throttle + brakes));
            }
        }

        private void MoveRoad(Roads roads)
        {
            while (!game.IsOver)
            {
                Thread.Sleep(10);
                roads.ShiftDown((int) (game.Car.Speed * 0.125));
            }
        }

        private void RandomCarGenerate()
        {
            while (!game.IsOver)
            {
                Thread.Sleep(BotsGeneratingFrequence);
                var car = RandomCarGenerator.GetRandomCar();
                game.Bots[botsArrayPointer] = car;
                if (++botsArrayPointer >= game.Bots.Length) botsArrayPointer = 0;
                Task.Run(() =>
                {
                    while (car.Location.Y < 1500)
                    {
                        Thread.Sleep(20);
                        if (game.Car != null)
                            car.ShiftDown((int) (car.Speed  + BotsMinSpeed + game.Car.Speed));
                    }
                });
            }
        }

        private void CheckCollisions()
        {
            while (!game.IsOver)
            {
                Thread.Sleep(20);
                foreach (var bot in game.Bots.Where(b => b != null))
                {
                    if (game.Car.HitBox.IsCollide(bot.HitBox)) Freeze(); /*game.Stop();*/
                }
            }
        }

        #endregion
    }
}