using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views
{
    partial class MenuControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(125, 43);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(157, 36);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Начать игру";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Location = new System.Drawing.Point(125, 85);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(157, 36);
            this.optionsButton.TabIndex = 1;
            this.optionsButton.Text = "Настройки";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(125, 127);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(157, 36);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(319, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.startButton);
            this.Name = "MenuControl";
            this.Size = new System.Drawing.Size(463, 215);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button exitButton;

        private System.Windows.Forms.Button startButton;

        #endregion
    }
}