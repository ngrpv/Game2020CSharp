using System;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Views
{
    public partial class OptionsControl :  UserControl, IControl
    {
        private Game game;
        public OptionsControl()
        {
            InitializeComponent();
        }
        
        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           // game.options.Volume = this.trackBar1.Value%2 == 0?0:1;
            trackBarValue.Text = trackBar1.Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            game.ChangeStage(GameStage.NotStarted);
        }
    }
}