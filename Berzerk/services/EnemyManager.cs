using Berzerk.game_objects;
using Berzerk.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.services
{
    public class EnemyManager
    {
        private int _enemyCount = 0;
        public int enemyCount { get { return _enemyCount; } }
        public List<Enemy> enemies;

        public EnemyManager() { enemies = new List<Enemy>(); }
        public List<Enemy> getEnemies()
        {
            return enemies;
        }

        public void spawnEnemy(Form form, int x, int y)
        {
            Enemy enemy = new Enemy(form, x, y);
            enemies.Add(enemy);
            _enemyCount++;
        }

        public void spawnEnemies(Form form, int count, int sceneHeight, int sceneWidth)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < count; i++)
            {
                spawnEnemy(form, random.Next(200, sceneWidth - 200), random.Next(200, sceneHeight - 300));
            }
        }

        public void checkDeadEnemies(ref FlagCheck flagCheck)
        {
            int enemyIndexSave = 0;
            int enemyIndex = 0;
            if (flagCheck.enemyShot)
            {
                foreach (Enemy thisEnemy in enemies)
                {
                    if (thisEnemy.isEnemyBoxNull())
                    {
                        flagCheck.enemyShot = false;
                        enemyIndexSave = enemyIndex;
                    }
                    enemyIndex++;
                }
                enemies.RemoveAt(enemyIndexSave);
                _enemyCount--;
                enemyIndexSave = 0;
                enemyIndex = 0;
            }
        }
    }
}
