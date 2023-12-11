using Xunit;
using Berzerk.game_objects;
using Berzerk.helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Berzerk.services;

namespace Berzerk.tests
{
    public class EnemyManagerTests
    {
        private EnemyManager enemyManager;

        [Fact]
        public void spawnEnemyShouldAddEnemyToTheList()
        {
            Form form = new Form();
            int x = 100;
            int y = 100;

            EnemyManager enemyManager = new EnemyManager();
            enemyManager.spawnEnemy(form, x, y);

            Assert.Equal(1, enemyManager.enemyCount);
        }

        [Fact]
        public void spawnEnemiesShouldAddNumberOfEnemiesToTheList()
        {
            Form form = new Form();
            int count = 5;
            int sceneHeight = 600;
            int sceneWidth = 1000;

            enemyManager = new EnemyManager();
            enemyManager.spawnEnemies(form, count, sceneHeight, sceneWidth);

            Assert.Equal(count, enemyManager.enemies.Count);
        }

        [Fact]
        public void checkDeadEnemiesShouldRemoveDeadEnemiesFromTheList()
        {
            Form form = new Form();
            int count = 5;
            int sceneHeight = 600;
            int sceneWidth = 1000;

            enemyManager = new EnemyManager();
            enemyManager.spawnEnemies(form, count, sceneHeight, sceneWidth);

            bool enemyShot = true;
            FlagCheck flagCheck = new FlagCheck();
            flagCheck.enemyShot = enemyShot;

            enemyManager.checkDeadEnemies(ref flagCheck);

            Assert.False(enemyManager.enemies.Count == count);
        }
    }
}
