using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views
{
    partial class PlayingControl
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
        
        private void InitializeComponent()
        {
            Dock = DockStyle.Fill;
        }

       // private PictureBox carPicture;
    }
}