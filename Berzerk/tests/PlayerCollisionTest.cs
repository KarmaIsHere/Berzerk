using Berzerk.game_objects;
using Berzerk.services.collision;
using Berzerk.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Windows.Forms;

namespace Berzerk.tests.services.collision
{
    public class PlayerCollisionTests
    {
        private Form form;
        private Player myPlayer;
        private IPictureBoxManager playerPictureBoxManager;
        public PlayerCollisionTests() {
            form = new Form();
            playerPictureBoxManager = new PlayerPictureBoxManager(form, 100, 100);
            myPlayer = new Player(Player.Direction.Left, 100, 100, playerPictureBoxManager);
        }   
        [Fact]
        public void TestCheckEnemyTouchPlayer_NoEnemies()
        {
            EnemyManager enemyManager = new EnemyManager();
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
            enemyManager.spawnEnemy(form,100,100);

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
            enemyManager.spawnEnemy(form, 200, 200);
            GameProperties game = new GameProperties();

            PlayerCollision playerCollision = new PlayerCollision();
            playerCollision.checkEnemyTouchPlayer(ref enemyManager, ref myPlayer, ref game);

            Assert.False(game.isOver);
            Assert.False(game.isVicotry);
        }
    }
}
