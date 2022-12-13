using Berzerk.game_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.services
{
    public class EnemyManager
    {
        List<Enemy> enemies = new List<Enemy>();

        public List<Enemy> getEnemies()
        {
            return enemies;
        }

        public void spawnEnemy(Form form, int x, int y)
        {
            Enemy enemy = new Enemy(form, x, y);
            enemies.Add(enemy);
        }
    }
}
