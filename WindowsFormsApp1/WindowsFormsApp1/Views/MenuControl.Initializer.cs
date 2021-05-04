using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1.Views
{
    partial class MenuControl
    {
        private void InitializeComponent()
        {
            var buttons = new PictureBox[]
            {
                startButton = new PictureBox()
                {
                    Image = Resources.start,
                    SizeMode = PictureBoxSizeMode.AutoSize,
                    Location = new Point(590, 462),
                    BackColor = Color.Transparent
                },
                optionsButton = new PictureBox()
                {
                    Image = Resources.options,
                    Location = new Point(590, 662),
                    SizeMode = PictureBoxSizeMode.AutoSize,
                    BackColor = Color.Transparent
                },
                exitButton = new PictureBox()
                {
                    Image = Resources.exit, 
                    SizeMode = PictureBoxSizeMode.AutoSize, 
                    Location = new Point(590, 862),
                    BackColor = Color.Transparent
                }
            };
            optionsButton.Click += optionsButton_Click;
            exitButton.Click += exitButton_Click;
            startButton.Click += startButton_Click;
            Name = "MenuControl";
            BackgroundImage = Resources.bg;
            ResumeLayout(false);
            Dock = DockStyle.Fill;
            foreach (var control in buttons)
                Controls.Add(control);
        }

        private PictureBox optionsButton;
        private PictureBox exitButton;
        private PictureBox startButton;
    }
}