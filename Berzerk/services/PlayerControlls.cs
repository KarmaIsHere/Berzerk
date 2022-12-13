using Berzerk.game_objects;
using Berzerk.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.services
{
    public class PlayerControlls
    {
        public void checkPlayerInput(ref Player myPlayer, ref SceneInfo scene)
        {
            if (myPlayer.goUp && myPlayer.y > 0)
            {
                myPlayer.moveUp();
            }
            if (myPlayer.goDown && myPlayer.y < scene.height)
            {
                myPlayer.moveDown();
            }
            if (myPlayer.goLeft && myPlayer.x > 0)
            {
                myPlayer.moveLeft();
            }
            if (myPlayer.goRight && myPlayer.x < scene.width)
            {
                myPlayer.moveRight();
            }
            if (myPlayer.shooting && myPlayer.ammo > 0)
            {
                myPlayer.shoot();
                bullet.spawnBullet(myPlayer, this, myPlayer.getDirection());
                bullets.Add(bullet);
                myPlayer.shooting = false;
            }
        }
    }
}
