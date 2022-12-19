using Berzerk.game_objects;
using Berzerk.helpers;
using Berzerk.services.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.services.collision
{
    public class EnemyCollision 
    {
        public void checkEnemyCollision(ref Player myPlayer, ref EnemyManager enemyManager, ref FlagCheck flagCheck)
        {
            foreach (Bullet thisBullet in myPlayer.getShotBullets())
            {
                foreach (Enemy thisEnemy in enemyManager.getEnemies())
                {
                    if (thisBullet.isPictureBoxNull() == false && thisEnemy.isPictureBoxNull() == false && thisEnemy.getBounds().IntersectsWith(thisBullet.getBounds()))
                    {
                        flagCheck.enemyShot = true;
                        thisEnemy.destroy();
                        thisBullet.destroy();
                    }
                }
            }
        }
    }
}
