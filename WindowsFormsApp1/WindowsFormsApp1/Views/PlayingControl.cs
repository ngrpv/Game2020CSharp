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
                    PaintObject(road.Obj, Resources.road, g);
                }

                PaintObject(game.Car, Resources.Audi, g);
            };
            var car = new ObjectWithPicture(game.Car);
            car.Picture.Parent = game.roads.MiddleRoad.Picture;


            KeyDown += (_, args) => KeyPressEventHandler(args.KeyCode);
            /*var th = new Thread(delegate()
            {
                RandomCarGenerateInThread();
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(this.Controls.Add()))
                }
            });*/

            // RandomCarGenerateInThread();
            //new Task(() => UpdateCarInThread(car)).Start();
            ///Task.Factory.StartNew(() => { UpdateCarInThread(car); });
            // UpdateCarInThread(car);
            Task.Run(() => { RandomCarGenerateInThread(); });
            //new Task(() => RandomCarGenerateInThread()).Start();
            // new Task(() => MoveRoadInThread(game.roads, game.Car.Speed)).Start();
            //Task.Run(() => { InvalidateFormInThread(20); });

            //InvalidateFormInThread(50);
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
                BeginInvoke((Action) (() => roads.ShiftDown(speed)));

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
                var car = new ObjectWithPicture(RandomCarGenerator.GetRandomCar());
                BeginInvoke((Action) (() => Controls.Add(car.Picture)));
                // Controls.Add(car.Picture);
                BeginInvoke((Action) (() => Controls.SetChildIndex(car.Picture, 0)));

                //Controls.SetChildIndex(car.Picture, 0);
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

        private void InvalidateFormInThread(int ms)
        {
            //Task.Factory.StartNew(() =>
            // {
            while (game.Stage == GameStage.Playing)
            {
                Thread.Sleep(ms);
                //   lock (lockObject)
                {
                    BeginInvoke(new Action(Invalidate));
                }
            }

            // });
        }
    }
}