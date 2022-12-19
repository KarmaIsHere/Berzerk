using Berzerk.game_objects;
using Berzerk.helpers;
using Berzerk.services.collision;
using Berzerk.services.controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Berzerk.tests
{
        [TestClass]
        public class EnemyCollisionTests
        {
            [TestMethod]
            public void TestCheckEnemyCollision()
            {
                // Arrange
                Player myPlayer = new Player(Entity.Direction.Left, 0,0, new Form());
                EnemyManager enemyManager = new EnemyManager();
                FlagCheck flagCheck = new FlagCheck();
                EnemyCollision enemyCollision = new EnemyCollision();

                // Add a bullet to the player's list of shot bullets
                myPlayer.addShotBullet(new Bullet());

                // Add an enemy to the enemy manager's list of enemies
                enemyManager.spawnEnemy(new Enemy());

                // Set the bounds of the bullet and enemy to intersect
                myPlayer.getShotBullets()[0].setBounds(new Rectangle(0, 0, 10, 10));
                enemyManager.getEnemies()[0].setBounds(new Rectangle(0, 0, 10, 10));

                // Act
                enemyCollision.checkEnemyCollision(ref myPlayer, ref enemyManager, ref flagCheck);

                // Assert
                Assert.IsTrue(flagCheck.enemyShot);
                Assert.AreEqual(0, myPlayer.getShotBullets().Count);
                Assert.AreEqual(0, enemyManager.getEnemies().Count);
            }
        }
    
}
