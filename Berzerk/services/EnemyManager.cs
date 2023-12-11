using Berzerk.game_objects;
using Berzerk.helpers;

namespace Berzerk.services
{
    public class EnemyManager
    {
        private int _enemyCount = 0;
        public int EnemyCount { get { return _enemyCount; } }
        public List<Enemy> enemies;

        public EnemyManager() { enemies = new List<Enemy>(); }
        public List<Enemy> GetEnemies()
        {
            return enemies;
        }

        public void SpawnEnemy(Form form, int x, int y)
        {
            Enemy enemy = new Enemy(form, x, y);
            enemies.Add(enemy);
            _enemyCount++;
        }

        public void SpawnEnemies(Form form, int count, int sceneHeight, int sceneWidth)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < count; i++)
            {
                SpawnEnemy(form, random.Next(200, sceneWidth - 200), random.Next(200, sceneHeight - 300));
            }
        }

        public void CheckDeadEnemies(ref FlagCheck flagCheck)
        {
            int enemyIndexSave = 0;
            int enemyIndex = 0;
            if (flagCheck.enemyShot)
            {
                foreach (Enemy thisEnemy in enemies)
                {
                    if (thisEnemy.IsEnemyBoxNull())
                    {
                        flagCheck.enemyShot = false;
                        enemyIndexSave = enemyIndex;
                    }
                    enemyIndex++;
                }
                enemies.RemoveAt(enemyIndexSave);
                _enemyCount--;
            }
        }
    }
}
