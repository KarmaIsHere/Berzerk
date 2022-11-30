using Berzerk.model;

namespace Berzerk
{
    public partial class Form1 : Form
    {
        int playerSpeed = 2;
        int bulletSpeed = 3;
        Player myPlayer;

        public Form1()
        {
            myPlayer = new Player();
            InitializeComponent();
            gameRestart();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (myPlayer.goUp == true && player.Top > 0)
            {
                myPlayer.moveUp();
            }
            if (myPlayer.goDown == true && player.Bottom < 524)
            {
                myPlayer.moveDown();
            }
            if (myPlayer.goLeft == true && player.Left > 0)
            {
                myPlayer.moveLeft();
            }
            if (myPlayer.goRight == true && player.Right < 1156)
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

                switch (myPlayer.getDirection())
                {
                    case Player.Direction.Up:
                        spawnBullet(-30, player.Width / 2);
                        break;
                    case Player.Direction.Down:
                        spawnBullet(60, player.Width / 2);
                        break;
                    case Player.Direction.Left:
                        spawnBullet(player.Height / 2 , -30);
                        break;
                    case Player.Direction.Right:
                        spawnBullet(player.Height / 2 , 30);
                        break;
                }
            }
        }

        private void spawnBullet(int X, int Y)
        {
            bullet.Top = myPlayer.x + X;
            bullet.Left = myPlayer.y + Y;
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