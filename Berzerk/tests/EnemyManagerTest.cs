using Berzerk.helpers;
using Berzerk.services;
using Xunit;

namespace Berzerk.tests
{
    public class EnemyManagerTests
    {
        private EnemyManager enemyManager;

        [Fact]
        public void spawnEnemyShouldAddEnemyToTheList()
        {
            Form form = new Form();
            const int expectedEnemies = 1;
            int x = 100;
            int y = 100;

            EnemyManager enemyManager = new EnemyManager();
            enemyManager.spawnEnemy(form, x, y);

            Assert.Equal(expectedEnemies, enemyManager.enemyCount);
        }

        [Fact]
        public void spawnEnemiesShouldAddNumberOfEnemiesToTheList()
        {
            Form form = new Form();
            const int expectedCount = 5;
            int amountOfEnemies = 5;
            int sceneHeight = 600;
            int sceneWidth = 1000;

            enemyManager = new EnemyManager();
            enemyManager.spawnEnemies(form, amountOfEnemies, sceneHeight, sceneWidth);
            int result = enemyManager.enemies.Count;

            Assert.Equal(expectedCount, result);
        }

        [Fact]
        public void checkDeadEnemiesShouldRemoveDeadEnemiesFromTheList()
        {
            Form form = new Form();
            const int expectedCount = 5;
            int amountOfEnemies = 5;
            int sceneHeight = 600;
            int sceneWidth = 1000;

            enemyManager = new EnemyManager();
            enemyManager.spawnEnemies(form, amountOfEnemies, sceneHeight, sceneWidth);
            int result = enemyManager.enemies.Count;
            bool enemyShot = true;
            FlagCheck flagCheck = new FlagCheck();
            flagCheck.enemyShot = enemyShot;

            enemyManager.checkDeadEnemies(ref flagCheck);

            Assert.False(result == expectedCount);
        }
    }
}
