using Berzerk.game_objects;
using Berzerk.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.services.collision
{
    public class PlayerCollision
    {
        public void checkEnemyTouchPlayer(IEnemyManager enemyManager,IPlayer myPlayer, ref GameProperties game)
        {
            foreach (Enemy enemy in enemyManager.getEnemies())
            {
                if (enemy.isEnemyBoxNull() == false && enemy.getBounds().IntersectsWith(myPlayer.getBounds()))
                {
                    game.isOver = true;
                    game.isVicotry = false;
                }
            }
        }

    }
}
