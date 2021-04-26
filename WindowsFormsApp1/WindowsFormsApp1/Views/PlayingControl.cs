using System;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Views
{
    public partial class PlayingControl : UserControl
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Car_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void pictureBox1_Click_3(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void PlayingControl_Load(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void pictureBox1_Click_4(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}