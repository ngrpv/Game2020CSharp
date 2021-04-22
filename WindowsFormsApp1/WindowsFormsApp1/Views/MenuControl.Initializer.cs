using System.Drawing;
using System.Windows.Forms;

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
            var buttons = new[]
            {
                startButton = new Button() {Text = @"Start Game", Dock = DockStyle.Fill},
                optionsButton = new Button() {Text = @"Options", Dock = DockStyle.Fill,},
                exitButton = new Button() {Text = @"Exit", Dock = DockStyle.Fill}
            };
            
            // SuspendLayout();
            optionsButton.Click += optionsButton_Click;
            optionsButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;

            Name = "MenuControl";
            ResumeLayout(false);

            var innerTable = new TableLayoutPanel
            {
                Anchor = AnchorStyles.None,
                Size = new Size(300, 200)
            };
            innerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            for (var i = 0; i < buttons.Length; i++)
            {
                innerTable.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
                innerTable.Controls.Add(buttons[i], 0, i);
            }
            
            var outerTable = new TableLayoutPanel();
            outerTable.Controls.Add(innerTable);
            outerTable.Dock = DockStyle.Fill;
            Controls.Add(outerTable);
        }

        private Button optionsButton;
        private Button exitButton;
        private Button startButton;
    }
}