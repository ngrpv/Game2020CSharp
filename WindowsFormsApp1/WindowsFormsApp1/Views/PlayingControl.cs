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
            carPicture = Vizualizator.Initialize(game.Car);
            roadObj = new RoadPattern();
            road = Vizualizator.Initialize(roadObj);
            Controls.Add(carPicture);
            Controls.Add(road);
            
            KeyPress += (sender, args) =>
            { 
                game.MoveCar(args.KeyChar);
            };
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(1);
                    Vizualizator.UpdateLocation(carPicture, game.Car);
                    BeginInvoke(new Action(() => Invalidate()));
                }
            });
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(1);
                    Vizualizator.UpdateLocation(road, roadObj);
                    BeginInvoke(new Action(() => Invalidate()));
                }
            });
        }
        



        private void pictureBox1_Click_4(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}