using Berzerk.game_objects;

namespace Berzerk.services.collision
{
    public class PlayerCollision
    {
        public void CheckEnemyTouchPlayer(ref EnemyManager enemyManager, ref Player myPlayer, ref GameProperties game)
        {
            foreach (Enemy enemy in enemyManager.GetEnemies())
            {
                if (enemy.IsEnemyBoxNull() == false && enemy.GetBounds().IntersectsWith(myPlayer.GetBounds()))
                {
                    game.IsOver = true;
                    game.IsVicotry = false;
                }
            }
        }

    }
}
