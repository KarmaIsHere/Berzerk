using Berzerk.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.controller
{
    internal class BulletController
    {
        public void setBulletDirection(ref Player player, ref Bullet bullet)
        {
            switch (player.getDirection())
            {
                case Player.Direction.Up:
                    bullet.setDirection(Bullet.Direction.Up);
                    bullet.spawnBullet(new Tuple<int, int>(-30, player.width / 2), player);
                    break;
                case Player.Direction.Down:
                    bullet.setDirection(Bullet.Direction.Down);
                    bullet.spawnBullet(new Tuple<int, int>(60, player.width / 2), player);
                    break;
                case Player.Direction.Left:
                    bullet.setDirection(Bullet.Direction.Left);
                    bullet.spawnBullet(new Tuple<int, int>(player.height / 2, -30), player);
                    break;
                case Player.Direction.Right:
                    bullet.setDirection(Bullet.Direction.Right);
                    bullet.spawnBullet(new Tuple<int, int>(player.height / 2, 30), player);
                    break;
            }
        }
    }
}
