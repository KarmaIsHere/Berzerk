using Berzerk.game_objects;
using Berzerk.helpers;

namespace Berzerk.services.collision
{
    public class EnemyCollision
    {
        public void CheckEnemyCollision(ref Player myPlayer, ref EnemyManager enemyManager, ref FlagCheck flagCheck)
        {
            foreach (Bullet thisBullet in myPlayer.GetShotBullets())
            {
                foreach (Enemy thisEnemy in enemyManager.GetEnemies())
                {
                    if (thisBullet.IsPictureBoxNull() == false && thisEnemy.IsEnemyBoxNull() == false && thisEnemy.GetBounds().IntersectsWith(thisBullet.GetBounds()))
                    {
                        flagCheck.enemyShot = true;
                        thisEnemy.Die();
                        thisBullet.Destroy();
                    }
                }
                if (thisBullet.IsPictureBoxNull())
                {
                    myPlayer.Reload();
                }
            }
        }
    }
}
