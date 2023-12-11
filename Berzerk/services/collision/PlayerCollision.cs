using Berzerk.game_objects;

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
                    game.isOver = true;
                    game.isVicotry = false;
                }
            }
        }

    }
}
