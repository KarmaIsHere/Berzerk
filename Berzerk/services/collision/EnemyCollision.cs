using Berzerk.game_objects;
using Berzerk.helpers;

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
                    if (thisBullet.isPictureBoxNull() == false && thisEnemy.isEnemyBoxNull() == false && thisEnemy.getBounds().IntersectsWith(thisBullet.getBounds()))
                    {
                        flagCheck.enemyShot = true;
                        thisEnemy.die();
                        thisBullet.destroy();
                    }
                }
                if (thisBullet.isPictureBoxNull())
                {
                    myPlayer.reload();
                }
            }
        }
    }
}
