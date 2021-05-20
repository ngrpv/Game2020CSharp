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
            var roads = new Roads();
            foreach (var road in roads.RoadsArray)
                Controls.Add(road.Picture);
            var car = new ObjectWithPicture(game.Car);
            Controls.Add(car.Picture);
            Controls.SetChildIndex(car.Picture,0);
            KeyPress += (_, args) => game.MoveCar(args.KeyChar);
            Task.Factory.StartNew( () =>
            {
                while (true)
                {
                    Thread.Sleep(5);
                    car.UpdateLocation();
                    BeginInvoke(new Action(Invalidate));
                }
            });
            MoveRoadInThread(roads, game.Car.Speed);
        }


        private void MoveRoadInThread(Roads roads, int speed)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(20);
                    roads.ShiftDown(speed);
                    BeginInvoke(new Action(Invalidate));
                }
            });
        }
    }
}