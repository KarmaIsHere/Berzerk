﻿using Berzerk.game_objects;
using Berzerk.services;
using Berzerk.services.collision;
using Xunit;

namespace Berzerk.tests.services.collision
{
    public class PlayerCollisionTests
    {
        private Form form;
        private Player myPlayer;
        private IPictureBoxManager playerPictureBoxManager;
        public PlayerCollisionTests()
        {
            form = new Form();
            playerPictureBoxManager = new PlayerPictureBoxManager(form, 100, 100);
            myPlayer = new Player(Player.Direction.Left, 100, 100, playerPictureBoxManager);
        }

        [Fact]
        public void checkEnemyTouchPlayerShouldEnemyTouchPlayer()
        {
            EnemyManager enemyManager = new EnemyManager();
            enemyManager.spawnEnemy(form, 100, 100);
            GameProperties game = new GameProperties();

            PlayerCollision playerCollision = new PlayerCollision();
            playerCollision.checkEnemyTouchPlayer(ref enemyManager, ref myPlayer, ref game);

            Assert.True(game.isOver);
            Assert.False(game.isVicotry);
        }

        [Fact]
        public void checkEnemyTouchPlayerShouldEnemyDoesNotTouchPlayer()
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
