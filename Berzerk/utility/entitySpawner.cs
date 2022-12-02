using Berzerk.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.utility
{
    public class entitySpawner
    {
        public static void spawnEnemies(Form form, ref Enemy? enemy, ref List<Enemy> enemies )
        {
            enemy = new Enemy(form, 300, 321);
            enemies.Add(enemy);

            enemy = new Enemy(form, 500, 245);
            enemies.Add(enemy);

            enemy = new Enemy(form, 700, 100);
            enemies.Add(enemy);

            enemy = new Enemy(form, 600, 123);
            enemies.Add(enemy);


        }
    }
}
