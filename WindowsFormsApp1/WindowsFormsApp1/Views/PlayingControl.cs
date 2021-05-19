using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;
using WindowsFormsApp1.Properties;

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
            if (this.game != null)
                return;

            this.game = game;
            var road = GetObjectWithPicture(new RoadPattern(new Point(0,0)));
            Controls.Add(road.Picture);
            var car = GetObjectWithPicture(game.Car);
            Controls.Add(car.Picture);
            Controls.SetChildIndex(car.Picture,0);
            KeyPress += (_, args) => game.MoveCar(args.KeyChar);
            Task.Factory.StartNew( () =>
            {
                while (true)
                {
                    Thread.Sleep(1);
                    Visualizator.UpdateLocation(car);
                    BeginInvoke(new Action(Invalidate));
                }
            });
            MoveRoadInThread(new[]{road}, game.Car.Speed);
        }

        private static ObjectWithPicture GetObjectWithPicture(VisualizeableObject obj)
            => new ObjectWithPicture(obj, Visualizator.Initialize(obj));

        private void MoveRoadInThread(ObjectWithPicture[] objectWithPictures, int speed)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(1);
                    foreach (var objectWithPicture in objectWithPictures)
                    {
                        objectWithPicture.Obj.Move(0,speed);
                        Visualizator.UpdateLocation(objectWithPicture);
                    }
                    BeginInvoke(new Action(Invalidate));
                }
            });
        }

        private void pictureBox1_Click_4(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}