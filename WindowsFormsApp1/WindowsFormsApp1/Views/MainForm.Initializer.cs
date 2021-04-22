using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;
        
        private OptionsControl optionsControl1;
        private MenuControl menuControl;
        private PlayingControl playingControl;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            menuControl = new MenuControl(){ Dock = DockStyle.Fill };
            optionsControl1 = new OptionsControl(){Dock = DockStyle.Fill,Visible = false};
            var table = new TableLayoutPanel();
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            table.Dock = DockStyle.Fill;
            table.Controls.Add(menuControl,0,0);
            table.Controls.Add(optionsControl1,0,0);
            Controls.Add(table);
        }

        /*#region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            

            this.menuControl1 = new MenuControl()
            {
                Name = "menuControl1",
                Dock = DockStyle.Top
            };
            this.optionsControl1 = new WindowsFormsApp1.Views.OptionsControl();
            this.SuspendLayout();
            var size = new Size(500, 300);
            // 
            // menuControl1
            // 
           // CreateControl(menuControl1, "menuControl1", new Point(400,94), size);
          //  this.menuControl1.TabIndex = 0;
         //   this.menuControl1.Load += new System.EventHandler(this.menuControl1_Load);
            // 
            // optionsControl1
            // 
            /*CreateControl(optionsControl1, "optionsControl1", new Point(500,55), size);
            this.optionsControl1.TabIndex = 1;
            this.optionsControl1.Visible = false;#1#
            // 
            // MainForm
            // 
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
          //  this.Controls.Add(this.optionsControl1);
            //this.Controls.Add(this.menuControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

            var table = new TableLayoutPanel();
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            //table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            //table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            table.Dock = DockStyle.Fill;
            table.Controls.Add(new Panel(), 0,0);
            table.Controls.Add(menuControl1, 0,1);
            table.Controls.Add(new Panel(), 0,3);
            Controls.Add(table);
        }

        private void CreateControl(Control control, string name, Point location, Size size)
        {
            control.Location = location;
            control.Name = name;
            control.Size = size;
        }

        private WindowsFormsApp1.Views.OptionsControl optionsControl1;

        private WindowsFormsApp1.Views.MenuControl menuControl1;

        #endregion*/
    }
}