using Berzerk.game_objects;
using Berzerk.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.game_states
{
    public class RestartGame
    {
        public static void restart(ref List<Enemy> enemies, ref Player myPlayer, ref GameOver gameOver, ref ScoreManager scoreManager)
        {
            foreach (Enemy thisEnemy in enemies)
            {
                if (thisEnemy.isPictureBoxNull() == false) thisEnemy.destroy();
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

            scoreManager.destroyTextBox();
            scoreManager = null;
            
        }
    }
}
