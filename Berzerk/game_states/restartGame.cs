using Berzerk.game_objects;

namespace Berzerk.game_states
{
    public class RestartGame
    {
        public static void Restart(ref List<Enemy> enemies, ref Player myPlayer, ref GameOver gameOver)
        {
            foreach (Enemy thisEnemy in enemies)
            {
                if (thisEnemy.IsEnemyBoxNull() == false) thisEnemy.Die();
            }
            enemies.Clear();

            foreach (Bullet thisBullet in myPlayer.GetShotBullets())
            {
                if (thisBullet.IsPictureBoxNull() == false) thisBullet.Destroy();
            }
            myPlayer.ClearBullets();

            myPlayer.Destroy();
            myPlayer = null;

            gameOver.DestroyTextBox();
            gameOver = null;

        }
    }
}
