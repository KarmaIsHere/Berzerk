using Berzerk.game_states;
using Berzerk.helpers;
using Berzerk.game_objects;
using Berzerk.services;
using Berzerk.services.collision;
using Berzerk.services.controller;
using System.Net.Http.Headers;

namespace Berzerk
{
    public partial class LevelTemplate : Form
    {
        private Player myPlayer;
        private PlayerControlls playerControlls;
        private SceneInfo scene;
        private EnemyManager enemyManager;
        private KeyBoardInput keyBoardInput;
        private PlayerCollision playerCollision;
        private EnemyCollision enemyCollision;
        private GameProperties gameProperties;
        private FlagCheck flagCheck;
        private BulletController bulletController;
        private GameOver gameOver;
        private IPictureBoxManager playerPictureBoxManager;
        private const int PLAYER_X_COORDINATES = 100;
        private const int PLAYER_Y_COORDINATES = 100;
        public LevelTemplate()
        {
            InitializeComponent();
            gameRestart(false);
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            playerControlls.checkPlayerInput(ref myPlayer, ref scene);

            playerCollision.checkEnemyTouchPlayer(ref enemyManager, ref myPlayer, ref gameProperties);

            enemyCollision.checkEnemyCollision(ref myPlayer, ref enemyManager, ref flagCheck);

            enemyManager.checkDeadEnemies(ref flagCheck);

            gameProperties.checkEnemyCount(enemyManager.enemyCount);

            bulletController.checkDestroyedBullets(ref myPlayer);

            if (gameProperties.isOver) setGameOver(gameProperties.isVicotry);
        }
        public void gameRestart(bool isRestart)
        {
            List<Enemy> enemies;
            if (isRestart)
            {
                enemies = enemyManager.getEnemies();
                restartGame.restart(ref enemies, ref myPlayer, ref gameOver);
            }

            enemyManager = new EnemyManager();
            keyBoardInput = new KeyBoardInput();
            playerCollision = new PlayerCollision();
            enemyCollision = new EnemyCollision();
            gameProperties = new GameProperties();
            flagCheck = new FlagCheck();
            bulletController = new BulletController();

            scene = new SceneInfo(this.Height, this.Width);
            playerPictureBoxManager = new PlayerPictureBoxManager(this, PLAYER_X_COORDINATES, PLAYER_Y_COORDINATES);
            myPlayer = new Player(Player.Direction.Left, PLAYER_X_COORDINATES, PLAYER_Y_COORDINATES, playerPictureBoxManager);
            playerControlls = new PlayerControlls(this);

            enemyManager.spawnEnemies(this,3, scene.height, scene.width);

            flagCheck = new FlagCheck();

            gameTimer.Start();
        }

        public void setGameOver(bool isWinner)
        {
            gameTimer.Stop();
            gameProperties.isOver = true;
            gameOver = new GameOver(this, gameProperties.isVicotry, 5, scene.centerY);
        }
        private void keyIsDown(object sender, KeyEventArgs e)
        {
            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            if (e.KeyCode == Keys.Enter && gameProperties.isOver)
            {
                gameProperties.isOver = false;
                gameRestart(true);
            }
        }
        private void keyIsUp(object sender, KeyEventArgs e)
        {
            keyBoardInput.manageKeyIsUp(e, ref myPlayer);
        }
    }
}


