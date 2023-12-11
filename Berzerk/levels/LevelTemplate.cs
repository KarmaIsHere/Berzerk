using Berzerk.game_objects;
using Berzerk.game_states;
using Berzerk.helpers;
using Berzerk.services;
using Berzerk.services.collision;
using Berzerk.services.controller;

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
            GameRestart(false);
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            playerControlls.checkPlayerInput(ref myPlayer, ref scene);

            playerCollision.CheckEnemyTouchPlayer(ref enemyManager, ref myPlayer, ref gameProperties);

            enemyCollision.CheckEnemyCollision(ref myPlayer, ref enemyManager, ref flagCheck);

            enemyManager.CheckDeadEnemies(ref flagCheck);

            gameProperties.checkEnemyCount(enemyManager.EnemyCount);

            bulletController.checkDestroyedBullets(ref myPlayer);

            if (gameProperties.IsOver) SetGameOver(gameProperties.IsVicotry);
        }
        public void GameRestart(bool isRestart)
        {
            List<Enemy> enemies;
            if (isRestart)
            {
                enemies = enemyManager.GetEnemies();
                RestartGame.Restart(ref enemies, ref myPlayer, ref gameOver);
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

            enemyManager.SpawnEnemies(this, 3, scene.Height, scene.Width);

            flagCheck = new FlagCheck();

            gameTimer.Start();
        }

        public void SetGameOver(bool isWinner)
        {
            gameTimer.Stop();
            gameProperties.IsOver = true;
            gameOver = new GameOver(this, gameProperties.IsVicotry, 5, scene.CenterY);
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            keyBoardInput.ManageKeyIsDown(e, ref myPlayer);

            if (e.KeyCode == Keys.Enter && gameProperties.IsOver)
            {
                gameProperties.IsOver = false;
                GameRestart(true);
            }
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            keyBoardInput.ManageKeyIsUp(e, ref myPlayer);
        }
    }
}


