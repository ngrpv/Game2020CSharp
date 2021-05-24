using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1.Views
{
    partial class OptionsControl
    {
        private void InitializeComponent()
        {
            trackBar1 = new TrackBar
            {
                Location = new Point(685, 590),
                Size = new Size(550, 500),
                Maximum = 100,
                BackColor = Color.White,
            };
            trackBar1.Value = 50;
            pictureBox2 = new PictureBox
            {
                Image = Resources.options,
               // Location = new Point(12, 19),
                Size = new Size(77, 51),
                Anchor = AnchorStyles.Top,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            trackBarValue = new TextBox
            {
                Location = new Point(250, 90), Size = new Size(100, 20),
                Font = new Font(FontFamily.GenericSansSerif, 22),
                ForeColor = Color.Azure,
                BackColor = Color.Black,
                MaxLength = 100,
            };
            panel1 = new Panel
            {
                BackColor = Color.Transparent,
                Controls = { trackBar1},
                Anchor = AnchorStyles.None,
                Size = new Size(500, 155)
            };
            panel1.Location = new Point(ClientSize.Width / 2 - panel1.Size.Width / 2,
                ClientSize.Height / 2 - panel1.Size.Height / 2);
            backToMenuButton = new PictureBox
            {
                BackColor = Color.Transparent,
                Image = Resources.menu,
                Location = new Point(590, 862),
                Size = new Size(740, 100),
                SizeMode = PictureBoxSizeMode.AutoSize
            };
            trackBar1.Scroll += trackBar1_Scroll;
            backToMenuButton.Click += pictureBox1_Click;

            BackgroundImage = Resources.options_bg;
            Controls.Add(backToMenuButton);
            //Controls.Add(panel1);
            Controls.Add(trackBar1);
            /*((ISupportInitialize) (trackBar1)).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((ISupportInitialize) (backToMenuButton)).EndInit();
            ((ISupportInitialize) (pictureBox2)).EndInit();
            ResumeLayout(false);
            PerformLayout();*/
        }

        private PictureBox pictureBox2;
        private PictureBox backToMenuButton;
        private TextBox trackBarValue;
        private Panel panel1;
        private TrackBar trackBar1;
    }
}