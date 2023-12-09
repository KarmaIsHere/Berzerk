using Berzerk.game_objects;
using Berzerk.helpers;
using Berzerk.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.services.collision
{
    public class EnemyCollision
    {
        public void checkEnemyCollision(IPlayer player, IEnemyManager enemyManager, FlagCheck flagCheck)
        {
            foreach (Bullet thisBullet in player.getShotBullets())
            {
                foreach (IEnemy thisEnemy in enemyManager.getEnemies())
                {
                    if (thisBullet.isPictureBoxNull() == false && !thisEnemy.isEnemyBoxNull() && thisEnemy.getBounds().IntersectsWith(thisBullet.getBounds()))
                    {
                        flagCheck.enemyShot = true;
                        thisEnemy.die();
                        thisBullet.destroy();
                    }
                }
                if (thisBullet.isPictureBoxNull())
                {
                    player.reload();
                }
            }
        }
    }
}
