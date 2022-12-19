using Berzerk.game_objects;
using Berzerk.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.services
{
    public class EnemyManager : IObservable<int>, IDisposable
    {
        private int _enemyCount = 0;
        private int _enemiesSpawned = 0;
        
        List<IObserver<int>> scoreWatchers = new();
        List<IObserver<bool>> enemyCountWatchers = new();
        public int enemyCount { get { return _enemyCount; } }
        List<Enemy> enemies = new List<Enemy>();

        public List<Enemy> getEnemies()
        {
            return enemies;
        }

        public void spawnEnemy(Form form, int x, int y)
        {
            Enemy enemy = new Enemy(form, x, y);
            enemies.Add(enemy);
            _enemyCount++;
            _enemiesSpawned++;
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
            int gotScrore = 0;
            if (flagCheck.enemyShot)
            {
                foreach (Enemy thisEnemy in enemies)
                {
                    if (thisEnemy.isPictureBoxNull())
                    {
                        flagCheck.enemyShot = false;
                        enemyIndexSave = enemyIndex;
                    }
                    enemyIndex++;
                }
                gotScrore = enemies.ElementAt(enemyIndexSave).scoreWorth;
                enemies.RemoveAt(enemyIndexSave);
                _enemyCount--;
                enemyIndexSave = 0;
                enemyIndex = 0;

                Notify(gotScrore);
            }
        }
        public IDisposable Subscribe(IObserver<int> observer)
        {
            scoreWatchers.Add(observer);
            return this;
        }
        public void Dispose() => throw new NotImplementedException();

        public void Notify(int gotScore)
        {
            if (_enemyCount == 0)
            {
                scoreWatchers.ForEach(x => x.OnCompleted());
                return;
            }
            scoreWatchers.ForEach(x => x.OnNext(gotScore));
        }
    }
}
