using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1.Views
{
    partial class MenuControl
    {
        //private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }*/
        private void InitializeComponent()
        {
            var buttons = new PictureBox[]
            {
                startButton = new PictureBox() {Image = Resources.start,SizeMode = PictureBoxSizeMode.AutoSize, Location = new Point(590,462), BackColor = Color.Transparent},
                optionsButton = new PictureBox() {Image = Resources.options1,Location = new Point(590,662), SizeMode = PictureBoxSizeMode.AutoSize,BackColor = Color.Transparent},
                exitButton = new PictureBox() {Image = Resources.exit, SizeMode = PictureBoxSizeMode.AutoSize, Location = new Point(590, 862),BackColor = Color.Transparent}
            };
            
            // SuspendLayout();
            optionsButton.Click += optionsButton_Click;
           // optionsButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            startButton.Click += startButton_Click;

            Name = "MenuControl";
            BackgroundImage = Resources.bg;
            ResumeLayout(false);

            BackgroundImage = Resources.bg;
            Dock = DockStyle.Fill;
            Controls.Add(startButton);
            Controls.Add(optionsButton);
            Controls.Add(exitButton);


        }

        private PictureBox optionsButton;
        private PictureBox exitButton;
        private PictureBox startButton;
    }
}