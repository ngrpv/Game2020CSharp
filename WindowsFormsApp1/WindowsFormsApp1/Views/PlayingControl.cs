using System;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;

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
        }

        private void pictureBox1_Click_4(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
           // Thread.Sleep(5000);
            base.OnPaint(e);
        }
    }
}