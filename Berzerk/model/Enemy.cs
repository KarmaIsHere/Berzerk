using Berzerk.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Berzerk.model
{
    public class Enemy : Form
    {
        private PictureBox _enemy;

        public Enemy(Form form, int x, int y)
        {
            this._enemy = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._enemy)).BeginInit();

            this._enemy.Load(@"D:\Main\Gallery\code\Berzerk\Berzerk\Properties\images\enemy.png");
            this._enemy.Location = new System.Drawing.Point(x, y);
            this._enemy.Name = "enemy";
            this._enemy.Size = new System.Drawing.Size(26, 47);
            this._enemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._enemy.TabIndex = 0;
            this._enemy.TabStop = false;
            this._enemy.Tag = "enemy";
            form.Controls.Add(this._enemy);
        }
    }
}
