using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.model
{
    internal class Bullet
    {
        private int x;
        private int y;
        private int bulletSpeed;

        public Bullet(int x, int y, int bulletSpeed)
        {
            this.x = x;
            this.y = y;
            this.bulletSpeed = bulletSpeed;
        }

    }
}
