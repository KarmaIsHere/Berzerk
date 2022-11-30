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
            this.player = new System.Windows.Forms.PictureBox();
            this.enemy = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.bullet = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bullet)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.Image = ((System.Drawing.Image)(resources.GetObject("player.Image")));
            this.player.Location = new System.Drawing.Point(850, 378);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(18, 53);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // enemy
            // 
            this.enemy.Image = ((System.Drawing.Image)(resources.GetObject("enemy.Image")));
            this.enemy.Location = new System.Drawing.Point(283, 272);
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
            // bullet
            // 
            this.bullet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bullet.Location = new System.Drawing.Point(1076, 362);
            this.bullet.Name = "bullet";
            this.bullet.Size = new System.Drawing.Size(10, 10);
            this.bullet.TabIndex = 1;
            this.bullet.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1176, 578);
            this.Controls.Add(this.bullet);
            this.Controls.Add(this.player);
            this.Controls.Add(this.enemy);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bullet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox player;
        private PictureBox enemy;
        private System.Windows.Forms.Timer gameTimer;
        private PictureBox bullet;
    }
}