using Berzerk.game_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.services.collision
{
    public class PlayerCollision
    {
        public void checkEnemyTouchPlayer(ref EnemyManager enemyManager,ref Player myPlayer, ref GameProperties game)
        {
            foreach (Enemy enemy in enemyManager.getEnemies())
            {
                if (enemy.isEnemyBoxNull() == false && enemy.getBounds().IntersectsWith(myPlayer.getBounds()))
                {
                    game.IsOver = true;
                }
            }
        }

    }
}
