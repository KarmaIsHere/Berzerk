using Berzerk.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Berzerk.game_objects
{
    public class Enemy : Form
    {
        private PictureBox _enemy;
        public int x { get => _enemy.Top; set => _enemy.Top = value; }
        public int y { get => _enemy.Left; set => _enemy.Left = value; }

        public Enemy(Form form, int x, int y)
        {
            this._enemy = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._enemy)).BeginInit();

            this._enemy.Load(@"C:\Users\ACER\source\repos\Berzerk\Berzerk\Properties\images\enemy.png");
            this._enemy.Location = new System.Drawing.Point(x, y);
            this._enemy.Name = "enemy";
            this._enemy.Size = new System.Drawing.Size(26, 47);
            this._enemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._enemy.TabIndex = 0;
            this._enemy.TabStop = false;
            this._enemy.Tag = "enemy";
            form.Controls.Add(this._enemy);
        }

        public void removeEnemyBox(Form form)
        {
            form.Controls.Remove(_enemy);
            _enemy.Dispose();
        }

        public Rectangle getBounds()
        {
            return _enemy.Bounds;
        }
        public void die()
        {
            _enemy.Dispose();
            _enemy = null;
        }
        public bool isEnemyBoxNull()
        {
            if (_enemy == null) return true;
            return false;
        }
    }
}
