using Berzerk.model;
using System.Security.Cryptography.X509Certificates;

namespace Berzerk
{
    public partial class Form1 : Form
    {
        Player myPlayer;
        List<Bullet> bulletsList = new List<Bullet>();

        public Form1()
        {
            InitializeComponent();
            myPlayer = new Player(false, false, false, false, false, false, Player.Direction.Left, 100, 100, 2, this);
            gameRestart();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (myPlayer.goUp && old_player.Top > 0)
            {
                myPlayer.moveUp();
            }
            if (myPlayer.goDown && old_player.Bottom < 524)
            {
                myPlayer.moveDown();
            }
            if (myPlayer.goLeft && old_player.Left > 0)
            {
                myPlayer.moveLeft();
            }
            if (myPlayer.goRight && old_player.Right < 1156)
            {
                myPlayer.moveRight();
            }
            if (myPlayer.shooting && myPlayer.canShoot)
            {
                Bullet bullet = Bullet.GetBullet(7, myPlayer, this);
                bulletsList.Add(bullet);
                bullet.setDirection(myPlayer.getDirection());
                switch (myPlayer.getDirection())
                {
                    case Player.Direction.Up:
                        bullet.setDirection(Bullet.Direction.Up);
                        bullet.spawnBullet(new Tuple<int, int>(-30, myPlayer.width / 2), myPlayer);
                        break;
                    case Player.Direction.Down:
                        bullet.setDirection(Bullet.Direction.Down);
                        bullet.spawnBullet(new Tuple<int, int>(60, myPlayer.width / 2), myPlayer);
                        break;
                    case Player.Direction.Left:
                        bullet.setDirection(Bullet.Direction.Left);
                        bullet.spawnBullet(new Tuple<int, int>(myPlayer.height / 2, -30), myPlayer);
                        break;
                    case Player.Direction.Right:
                        bullet.setDirection(Bullet.Direction.Right);
                        bullet.spawnBullet(new Tuple<int, int>(myPlayer.height / 2, 30), myPlayer);
                        break;
                }
                myPlayer.canShoot = false;
            }
            foreach (Control entity in this.Controls)
            {
                if (entity is PictureBox && (string)entity.Tag == "bullet")
                {
                    Tuple<int, int> move = new Tuple<int, int>(0, 0);
                    foreach (Bullet bullet in this.bulletsList)
                    {
                        move = bullet.moveBullet();
                        entity.Left += move.Item1;
                        entity.Top += move.Item2;
                    }

                    if (entity.Left > 1160)
                    {
                        deleteBullet(((PictureBox)entity));
                    }
                }
            }
        }
        private void deleteBullet(PictureBox bullet)
        {
            this.Controls.Remove(bullet);
            bullet.Dispose();
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
                
            }
                
        }

        public void gameRestart()
        {
            gameTimer.Start();
        }


    }
}