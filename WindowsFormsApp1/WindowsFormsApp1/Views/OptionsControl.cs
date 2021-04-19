using System;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Views
{
    public partial class OptionsControl : UserControl
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
            game.SetVolume(this.trackBar1.Value);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.ChangeStage(GameStage.NotStarted);
        }
    }
}