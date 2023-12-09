using Berzerk.game_objects;
using Berzerk.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.interfaces
{
    public interface IEnemyManager
    {
        int enemyCount { get; }
        List<Enemy> getEnemies();
        void spawnEnemy(Form form, int x, int y);
        void spawnEnemies(Form form, int count, int sceneHeight, int sceneWidth);
        void checkDeadEnemies(ref FlagCheck flagCheck);
    }
}
