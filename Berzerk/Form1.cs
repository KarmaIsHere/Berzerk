using Berzerk.model;

namespace Berzerk
{
    public partial class Form1 : Form
    {
        Player myPlayer;

        public Form1()
        {
            InitializeComponent();
            myPlayer = new Player(false, false, false, false, false, false, Player.Direction.Left, 100, 100, 2, this);
            gameRestart();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (myPlayer.goUp == true && old_player.Top > 0)
            {
                myPlayer.moveUp();
            }
            if (myPlayer.goDown == true && old_player.Bottom < 524)
            {
                myPlayer.moveDown();
            }
            if (myPlayer.goLeft == true && old_player.Left > 0)
            {
                myPlayer.moveLeft();
            }
            if (myPlayer.goRight == true && old_player.Right < 1156)
            {
                myPlayer.moveRight();
            }

        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && myPlayer.moving == false)
            {
                myPlayer.goUp = true;
                myPlayer.moving = true;
            }
            if(e.KeyCode == Keys.Down && myPlayer.moving == false)
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
                Bullet bullet = new Bullet(3);

                switch (myPlayer.getDirection())
                {
                    case Player.Direction.Up:
                        bullet.spawnBullet(-30, old_player.Width / 2, myPlayer);
                        break;
                    case Player.Direction.Down:
                        bullet.spawnBullet(60, old_player.Width / 2, myPlayer);
                        break;
                    case Player.Direction.Left:
                        bullet.spawnBullet(old_player.Height / 2 , -30, myPlayer);
                        break;
                    case Player.Direction.Right:
                        bullet.spawnBullet(old_player.Height / 2 , 30, myPlayer);
                        break;
                }
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

        public void gameRestart()
        {
            gameTimer.Start();
        }


    }
}