using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;


namespace WindowsFormsApp1.Views
{
    public partial class PlayingControl : UserControl, IControl
    {
        private Game game;
        private readonly Object lockObject;

        public PlayingControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            /*if (this.game != null)
                return;*/
            this.game = game;
            InitializeGameObjects();
        }

        public void InitializeGameObjects()
        {
            foreach (var road in game.roads.RoadsArray)
                Controls.Add(road.Picture);
            var car = new ObjectWithPicture(game.Car);
            Controls.Add(car.Picture);
            Controls.SetChildIndex(car.Picture, 0);

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
            new Task(() => UpdateCarInThread(car)).Start();
            ///Task.Factory.StartNew(() => { UpdateCarInThread(car); });
            // UpdateCarInThread(car);
            new Task(() => RandomCarGenerateInThread()).Start();
            new Task(() => MoveRoadInThread(game.roads, game.Car.Speed)).Start();
            InvalidateFormInThread(50);
        }

        private void UpdateCarInThread(ObjectWithPicture car)
        {
            while (game.Stage == GameStage.Playing)
            {
                Thread.Sleep(5);
                car.UpdatePictureLocation();
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
                //BeginInvoke(Controls.Add(car.Picture));
                Controls.Add(car.Picture);
                Controls.SetChildIndex(car.Picture, 0);
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
            Task.Factory.StartNew(() =>
            {
                while (game.Stage == GameStage.Playing)
                {
                    Thread.Sleep(ms);
                 //   lock (lockObject)
                    {
                        BeginInvoke(new Action(Invalidate));
                    }
                }
            });
        }
    }
}