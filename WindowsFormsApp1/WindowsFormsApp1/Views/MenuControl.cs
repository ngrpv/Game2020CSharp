using System;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Views
{
    public partial class MenuControl : UserControl
    {
        private Game game;
        public MenuControl()
        {
            InitializeComponent();
        }
        
        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            
        }
        
        private void optionsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            game.ChangeStage(GameStage.Options);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


       
    }
}