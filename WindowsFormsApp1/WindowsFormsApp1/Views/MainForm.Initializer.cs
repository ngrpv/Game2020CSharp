﻿using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
            //StartPosition = FormStartPosition.WindowsDefaultLocation;
            FormBorderStyle = FormBorderStyle.None;
            
            WindowState = FormWindowState.Maximized;
            menuControl = new MenuControl(){ Dock = DockStyle.Fill };
            optionsControl1 = new OptionsControl(){Dock = DockStyle.Fill,Visible = false};
            playingControl = new PlayingControl(){Dock = DockStyle.Fill, Visible = false};
            var table = new TableLayoutPanel();
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            table.Dock = DockStyle.Fill;
            Controls.Add(menuControl);
            Controls.Add(optionsControl1);
            Controls.Add(playingControl);
            
            //Controls.Add(table);
        }
        
    }
}