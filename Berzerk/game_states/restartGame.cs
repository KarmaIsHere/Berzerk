using Berzerk.game_objects;

namespace Berzerk.game_states
{
    public class restartGame
    {
        public static void restart(ref List<Enemy> enemies, ref Player myPlayer, ref GameOver gameOver)
        {
            foreach (Enemy thisEnemy in enemies)
            {
                if (thisEnemy.isEnemyBoxNull() == false) thisEnemy.die();
            }
            enemies.Clear();

            foreach (Bullet thisBullet in myPlayer.getShotBullets())
            {
                if (thisBullet.isPictureBoxNull() == false) thisBullet.destroy();
            }
            myPlayer.clearBullets();

            myPlayer.destroy();
            myPlayer = null;

            gameOver.destroyTextBox();
            gameOver = null;
            
        }
    }
}
