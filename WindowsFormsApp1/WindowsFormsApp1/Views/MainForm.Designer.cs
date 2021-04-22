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

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuControl1 = new WindowsFormsApp1.Views.MenuControl();
            this.optionsControl1 = new WindowsFormsApp1.Views.OptionsControl();
            this.SuspendLayout();
            // 
            // menuControl1
            // 
            this.menuControl1.Location = new System.Drawing.Point(152, 94);
            this.menuControl1.Name = "menuControl1";
            this.menuControl1.Size = new System.Drawing.Size(441, 219);
            this.menuControl1.TabIndex = 0;
            this.menuControl1.Load += new System.EventHandler(this.menuControl1_Load);
            // 
            // optionsControl1
            // 
            this.optionsControl1.Location = new System.Drawing.Point(110, 55);
            this.optionsControl1.Name = "optionsControl1";
            this.optionsControl1.Size = new System.Drawing.Size(557, 346);
            this.optionsControl1.TabIndex = 1;
            this.optionsControl1.Visible = false;
            // 
            // MainForm
            // 
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.optionsControl1);
            this.Controls.Add(this.menuControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
        }

        private WindowsFormsApp1.Views.OptionsControl optionsControl1;

        private WindowsFormsApp1.Views.MenuControl menuControl1;

        #endregion
    }
}