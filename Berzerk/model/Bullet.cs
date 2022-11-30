using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.model
{
    internal class Bullet : Form
    {
        //private int _x;
        //private int _y;
        private int _bulletSpeed;
        private PictureBox _bullet;



        public Bullet(int bulletSpeed, Player myPlayer, Form form)
        {
            this._bulletSpeed = bulletSpeed;

            this._bullet = new System.Windows.Forms.PictureBox();

            this._bullet.BackColor = System.Drawing.Color.Yellow;
            this._bullet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._bullet.Name = "bullet";
            this._bullet.Size = new System.Drawing.Size(11, 13);
            this._bullet.TabIndex = 1;
            this._bullet.TabStop = false;
            this._bullet.Location =  new System.Drawing.Point(0,0);
            
            form.Controls.Add(this._bullet);
        }

        public void spawnBullet(Tuple<int, int> coordinates, Player myPlayer)
        {
            _bullet.Top = myPlayer.x + coordinates.Item1;
            _bullet.Left = myPlayer.y + coordinates.Item2;
        }

        public Tuple<int, int> setSpawnCoordinates(Player myPlayer)
        {
            return new Tuple<int, int>(-30, 0);
        }

    }
}
