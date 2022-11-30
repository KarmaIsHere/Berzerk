using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.model
{
    internal class Bullet : Form
    {
        private int _x;
        private int _y;
        private int _bulletSpeed;
        private PictureBox bullet;

        public Bullet(int bulletSpeed)
        {
            this._bulletSpeed = bulletSpeed;
        }
        public void spawnBullet(int X, int Y, Player myPlayer)
        {
            bullet.Top = myPlayer.x + X;
            bullet.Left = myPlayer.y + Y;
        }
    }
}
