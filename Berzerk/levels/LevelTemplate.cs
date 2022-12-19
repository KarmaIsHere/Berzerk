using Berzerk.game_states;
using Berzerk.helpers;
using Berzerk.game_objects;
using Berzerk.services;
using Berzerk.services.collision;
using Berzerk.services.controller;

namespace Berzerk
{
    public partial class LevelTemplate : Form, IObserver<bool>
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
        private ScoreManager scoreManager;

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
        }
        public void gameRestart(bool isRestart)
        {
            List<Enemy> enemies;
            if (isRestart)
            {
                enemies = enemyManager.getEnemies();
                RestartGame.restart(ref enemies, ref myPlayer, ref gameOver, ref scoreManager);
            }

            enemyManager = new EnemyManager();
            enemyCollision = new EnemyCollision();
            playerCollision = new PlayerCollision();
            bulletController = new BulletController();
            keyBoardInput = new KeyBoardInput();
            gameProperties = new GameProperties();
            flagCheck = new FlagCheck();

            scene = new SceneInfo(this.Height, this.Width);
            scoreManager = new ScoreManager(this, 0,0);

            myPlayer = new Player(Player.Direction.Left, 100, 100, this);

            playerControlls = new PlayerControlls(this);

            enemyManager.spawnEnemies(this, 6, scene.height, scene.width);

            enemyManager.Subscribe(myPlayer);
            enemyManager.Subscribe(scoreManager);
            enemyManager.Subscribe(this);
            playerCollision.Subscribe(this);

            flagCheck = new FlagCheck();

            gameTimer.Start();
        }

        public void setGameOver(bool isWinner)
        {
            gameTimer.Stop();
            gameProperties.isOver = true;
            gameOver = new GameOver(this, gameProperties.isVicotry, scene.centerX, scene.centerY);
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

        public void OnCompleted()
        {
            setGameOver(gameProperties.isVicotry);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(bool value)
        {
            gameProperties.isVicotry = value;
        }
    }
}


