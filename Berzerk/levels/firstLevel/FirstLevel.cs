using Berzerk.helpers;
using Berzerk.model;
using TextBox = Berzerk.model.TextBox;

namespace Berzerk
{
    public partial class FirstLevel : Form
    {
        Player myPlayer;
        Bullet? bullet;
        Enemy? enemy;
        SceneInfo scene;
        FlagCheck flagCheck;
        List<Bullet> bullets = new List<Bullet>();
        List<Enemy> enemies = new List<Enemy>();
        int enemyIndexSave;
        int enemyIndex;

        public FirstLevel()
        {
            InitializeComponent();
            gameRestart();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (myPlayer.goUp && myPlayer.y > 0)
            {
                myPlayer.moveUp();
            }
            if (myPlayer.goDown && myPlayer.y < scene.height)
            {
                myPlayer.moveDown();
            }
            if (myPlayer.goLeft && myPlayer.x > 0)
            {
                myPlayer.moveLeft();
            }
            if (myPlayer.goRight && myPlayer.x < scene.width)
            {
                myPlayer.moveRight();
            }
            if (myPlayer.shooting && myPlayer.ammo > 0)
            {
                myPlayer.shoot();
                
                bullet.spawnBullet(myPlayer, this, myPlayer.getDirection());
                bullets.Add(bullet);
                myPlayer.shooting = false;
            }
            foreach (Enemy thisEnemy in enemies)
            {
                if (thisEnemy.isEnemyBoxNull() == false && thisEnemy.getBounds().IntersectsWith(myPlayer.getBounds()))
                {
                    gameOver();
                }
            }
            foreach (Bullet thisBullet in bullets)
            {
                
                foreach (Enemy thisEnemy in enemies)
                {
                    if (thisBullet.isBulletBoxNull() == false && thisEnemy.isEnemyBoxNull() == false && thisEnemy.getBounds().IntersectsWith(thisBullet.getBounds()))
                    {
                        flagCheck.enemyShot = true;
                        thisEnemy.die();
                    }
                    
                }
                if (thisBullet.isBulletBoxNull())
                {
                    myPlayer.reload();
                }
            }
            
            if (flagCheck.enemyShot)
            {
                
                foreach (Enemy thisEnemy in enemies)
                {
                    
                    if (thisEnemy.isEnemyBoxNull())
                    {
                        flagCheck.enemyShot = false;
                        enemyIndexSave = enemyIndex;
                    }
                    enemyIndex++;
                }
                enemies.RemoveAt(enemyIndexSave);
                enemyIndexSave = 0;
                enemyIndex = 0;
            }
            
        }
        public void gameRestart()
        {
            scene = new SceneInfo(this.Height, this.Width);

            myPlayer = new Player(false, false, false, false, false, false, Player.Direction.Left, 100, 100, 2, this);

            bullet = new Bullet(12);

            enemy = new Enemy(this, 300, 300);
            enemies.Add(enemy);
            enemy = new Enemy(this, 500, 300);
            enemies.Add(enemy);
            enemy = new Enemy(this, 700, 500);
            enemies.Add(enemy);

            flagCheck = new FlagCheck();
            enemyIndexSave = 0;
            enemyIndex = 0;

        gameTimer.Start();
        }

        public void gameOver()
        {
            gameTimer.Stop();
            TextBox.popUpMessageCenter("Game Over", this, scene.centerX, scene.centerY);
        }
        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && myPlayer.moving == false)
            {
                myPlayer.goUp = true;
                myPlayer.moving = true;
            }
            if (e.KeyCode == Keys.Down && myPlayer.moving == false)
            {
                myPlayer.goDown = true;
                myPlayer.moving = true;
            }
            if (e.KeyCode == Keys.Left && myPlayer.moving == false)
            {
                myPlayer.goLeft = true;
                myPlayer.moving = true;
            }
            if (e.KeyCode == Keys.Right && myPlayer.moving == false)
            {
                myPlayer.goRight = true;
                myPlayer.moving = true;
            }
            if (e.KeyCode == Keys.Space && myPlayer.shooting == false)
            {
                myPlayer.shooting = true;
            }
        }
        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                myPlayer.goUp = false;
                myPlayer.moving = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                myPlayer.goDown = false;
                myPlayer.moving = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                myPlayer.goLeft = false;
                myPlayer.moving = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                myPlayer.goRight = false;
                myPlayer.moving = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                myPlayer.shooting = false;
            }
        }
    }
}


