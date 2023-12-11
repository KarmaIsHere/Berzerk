using Berzerk.game_objects;
using Berzerk.services.collision;
using Berzerk.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Berzerk.tests.services.collision
{
    public class PlayerCollisionTests
    {
        [Fact]
        public void TestCheckEnemyTouchPlayer_NoEnemies()
        {
            EnemyManager enemyManager = new EnemyManager();
            Player myPlayer = new Player();
            GameProperties game = new GameProperties();

            PlayerCollision playerCollision = new PlayerCollision();
            playerCollision.checkEnemyTouchPlayer(ref enemyManager, ref myPlayer, ref game);

            Assert.False(game.isOver);
            Assert.False(game.isVicotry);
        }

        [Fact]
        public void TestCheckEnemyTouchPlayer_EnemyTouchesPlayer()
        {
            EnemyManager enemyManager = new EnemyManager();
            Enemy enemy = new Enemy();
            enemyManager.spawnEnemy(enemy);

            Player myPlayer = new Player();
            GameProperties game = new GameProperties();

            PlayerCollision playerCollision = new PlayerCollision();
            playerCollision.checkEnemyTouchPlayer(ref enemyManager, ref myPlayer, ref game);

            Assert.True(game.isOver);
            Assert.False(game.isVicotry);
        }

        [Fact]
        public void TestCheckEnemyTouchPlayer_EnemyDoesNotTouchPlayer()
        {
            EnemyManager enemyManager = new EnemyManager();
            Enemy enemy = new Enemy();
            enemy.setPosition(new Point(200, 200));
            enemyManager.spawnEnemy(enemy);

            Player myPlayer = new Player();
            myPlayer.setPosition(new Point(400, 400));
            GameProperties game = new GameProperties();

            PlayerCollision playerCollision = new PlayerCollision();
            playerCollision.checkEnemyTouchPlayer(ref enemyManager, ref myPlayer, ref game);

            Assert.False(game.isOver);
            Assert.False(game.isVicotry);
        }
    }
}
