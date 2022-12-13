using Berzerk.game_states;
using Berzerk.helpers;
using Berzerk.game_objects;
using Berzerk.utility;
using TextBox = Berzerk.game_objects.TextBox;
using Berzerk.services;
using Berzerk.services.collision;

namespace Berzerk
{
    public partial class FirstLevel : Form
    {
        Player myPlayer;
        PlayerControlls playerControlls = new PlayerControlls();
        SceneInfo scene;
        EnemyManager enemyManager = new EnemyManager();
        KeyBoardInput keyBoardInput = new KeyBoardInput();
        PlayerCollision playerCollision = new PlayerCollision();
        EnemyCollision enemyCollision = new EnemyCollision();
        GameProperties gameProperties = new GameProperties();

        Enemy? enemy;
        
        FlagCheck flagCheck;
        Bullet bullet;
        List<Bullet> bullets = new List<Bullet>();
        int enemyIndexSave;
        int enemyIndex;
        bool isGameOver;
        TextBox textBoxClass;

        public FirstLevel()
        {
            InitializeComponent();
            gameRestart(false);
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            playerControlls.checkPlayerInput(ref myPlayer, ref scene);

            playerCollision.checkEnemyTouchPlayer(ref enemyManager, ref myPlayer, ref gameProperties);

            //this is next
            foreach (Bullet thisBullet in bullets)
            {
                foreach (Enemy thisEnemy in enemyManager.getEnemies())
                {
                    if (thisBullet.isBulletBoxNull() == false && thisEnemy.isEnemyBoxNull() == false && thisEnemy.getBounds().IntersectsWith(thisBullet.getBounds()))
                    {
                        flagCheck.enemyShot = true;
                        thisEnemy.die();
                        thisBullet.destroyBullet();
                    }
                }
                if (thisBullet.isBulletBoxNull())
                {
                    myPlayer.reload();
                }
            }
            
            if (flagCheck.enemyShot)
            {
                foreach (Enemy thisEnemy in enemyManager.getEnemies())
                {
                    
                    if (thisEnemy.isEnemyBoxNull())
                    {
                        flagCheck.enemyShot = false;
                        enemyIndexSave = enemyIndex;
                    }
                    enemyIndex++;
                }
                enemyManager.getEnemies().RemoveAt(enemyIndexSave);
                enemyIndexSave = 0;
                enemyIndex = 0;
            }

            if (enemyManager.getEnemies().Count == 0) gameOver(true);
        }
        public void gameRestart(bool isRestart)
        {
            List<Enemy> enemies;
            if (isRestart)
            {
                enemies = enemyManager.getEnemies();
                restartGame.restart(ref enemies, ref bullets, ref myPlayer, ref textBoxClass);
            }
            
            scene = new SceneInfo(this.Height, this.Width);

            myPlayer = new Player(Player.Direction.Left, 100, 100, 2, this);

            bullet = new Bullet(12);

            enemyManager.spawnEnemy(this, 300, 300);

            textBoxClass = new TextBox(this);

            flagCheck = new FlagCheck();
            enemyIndexSave = 0;
            enemyIndex = 0;

        gameTimer.Start();
        }

        public void gameOver(bool isWinner)
        {
            gameTimer.Stop();
            isGameOver = true;
            if (isWinner) 
                textBoxClass.popUpVictory(this, scene.centerX, scene.centerY);
            else 
                textBoxClass.popUpGameOver(this, scene.centerX, scene.centerY);

        }
        private void keyIsDown(object sender, KeyEventArgs e)
        {
            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            if (e.KeyCode == Keys.Enter && isGameOver)
            {
                isGameOver = false;
                gameRestart(true);
            }
        }
        private void keyIsUp(object sender, KeyEventArgs e)
        {
            keyBoardInput.manageKeyIsUp(e, ref myPlayer);
        }
    }
}


