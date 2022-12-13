using Berzerk.game_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.game_states
{
    public class restartGame
    {
        public static void restart(ref List<Enemy> enemies, ref List<Bullet> bullets, ref Player myPlayer, ref Berzerk.game_objects.TextBox textBoxClass)
        {
            foreach (Enemy thisEnemy in enemies)
            {
                if (thisEnemy.isEnemyBoxNull() == false) thisEnemy.die();
            }
            enemies.Clear();

            foreach (Bullet thisBullet in bullets)
            {
                if (thisBullet.isBulletBoxNull() == false) thisBullet.destroyBullet();
            }
            bullets.Clear();

            myPlayer.die();
            myPlayer = null;
            textBoxClass.destroyTextBox();
            textBoxClass = null;
        }
    }
}
