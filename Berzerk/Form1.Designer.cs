namespace Berzerk
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.old_player = new System.Windows.Forms.PictureBox();
            this.enemy = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.old_bullet = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.old_player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.old_bullet)).BeginInit();
            this.SuspendLayout();
            // 
            // old_player
            // 
            this.old_player.Image = ((System.Drawing.Image)(resources.GetObject("old_player.Image")));
            this.old_player.Location = new System.Drawing.Point(952, 462);
            this.old_player.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.old_player.Name = "old_player";
            this.old_player.Size = new System.Drawing.Size(18, 53);
            this.old_player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.old_player.TabIndex = 0;
            this.old_player.TabStop = false;
            // 
            // enemy
            // 
            this.enemy.Image = ((System.Drawing.Image)(resources.GetObject("enemy.Image")));
            this.enemy.Location = new System.Drawing.Point(323, 363);
            this.enemy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.enemy.Name = "enemy";
            this.enemy.Size = new System.Drawing.Size(26, 47);
            this.enemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.enemy.TabIndex = 0;
            this.enemy.TabStop = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimerEvent);
            // 
            // old_bullet
            // 
            this.old_bullet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.old_bullet.Location = new System.Drawing.Point(1230, 483);
            this.old_bullet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.old_bullet.Name = "old_bullet";
            this.old_bullet.Size = new System.Drawing.Size(11, 13);
            this.old_bullet.TabIndex = 1;
            this.old_bullet.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1344, 771);
            this.Controls.Add(this.old_bullet);
            this.Controls.Add(this.old_player);
            this.Controls.Add(this.enemy);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.old_player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.old_bullet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox old_player;
        private PictureBox enemy;
        private System.Windows.Forms.Timer gameTimer;
        private PictureBox old_bullet;
    }
}