using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;
using WindowsFormsApp1.Properties;
using Timer = System.Windows.Forms.Timer;


namespace WindowsFormsApp1.Views
{
    public partial class PlayingControl : UserControl, IControl
    {
        private Game game;
        private int temp = 0;

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


            KeyDown += (_, args) => KeyPressEventHandler(args.KeyCode);
            Task.Run(() => { RandomCarGenerateInThread(); });
             new Task(() => MoveRoadInThread(game.roads, game.Car.Speed)).Start();

        }

        private void PaintObject(VisualizeableObject obj, Bitmap img, Graphics g)
        {
            g.DrawImage(img, obj.Location.X, obj.Location.Y, img.Width, img.Height);
        }

        private void UpdateCarInThread(ObjectWithPicture car)
        {
            while (game.Stage == GameStage.Playing)
            {
                Thread.Sleep(5);
                BeginInvoke((Action) (() => car.UpdatePictureLocation()));
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
                roads.ShiftDown(speed);

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

        private void KeyPressEventHandler(Keys keyCode)
        {
            if (keyCode == Keys.Escape)
            {
                game.Stop();
            }
            else game.MoveCar(keyCode);
        }
    }
}