using Berzerk.controller;
using Berzerk.model;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Berzerk
{
    public partial class Form1 : Form
    {
        int windowHeight;
        int windowWidth;
        Player myPlayer;
        Bullet? bullet;
        Enemy enemy;
        BulletController bulletController;
        List<Bullet> bulletsList = new List<Bullet>();

        public Form1()
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
            if (myPlayer.goDown && myPlayer.y < 524)
            {
                myPlayer.moveDown();
            }
            if (myPlayer.goLeft && myPlayer.x > 0)
            {
                myPlayer.moveLeft();
            }
            if (myPlayer.goRight && myPlayer.x < 1156)
            {
                myPlayer.moveRight();
            }
            if (myPlayer.shooting && myPlayer.ammo > 0)
            {
                myPlayer.shoot();
                bullet = new Bullet(12, myPlayer, this);
                bulletsList.Add(bullet);
                bulletController.setBulletDirection(ref myPlayer, ref bullet);
                myPlayer.shooting = false;
            }
            foreach (Control entity in this.Controls)
            {
                if (entity is PictureBox && (string)entity.Tag == "bulletEntity")
                {
                    foreach (Bullet bulletBox in this.bulletsList)
                    {
                        Tuple<int, int> move = bullet.moveBullet();
                        entity.Left += move.Item1;
                        entity.Top += move.Item2;
                    }
                    if (entity.Left > windowWidth || entity.Left < 0 || entity.Top < 0 || entity.Top > windowHeight)
                    {
                        deleteBullet(((PictureBox)entity), ref myPlayer, ref bullet);
                        
                    }
                    foreach (Control enemyBox in this.Controls)
                    {
                        if ((string)enemyBox.Tag == "enemy" && enemyBox.Bounds.IntersectsWith(entity.Bounds))
                        {
                            killEnemy(((PictureBox)entity), ((PictureBox)enemyBox), ref myPlayer, ref bullet);
                        }
                    }
                }
            }
        }
        private void killEnemy(PictureBox bulletBox,PictureBox enemyBox, ref Player myPlayer, ref Bullet bullet)
        {
            deleteBullet(bulletBox, ref myPlayer, ref bullet);

            this.Controls.Remove(enemy);
            enemyBox.Dispose();
        }
        private void deleteBullet(PictureBox bulletBox, ref Player myPlayer, ref Bullet bullet)
        {
            this.Controls.Remove(bullet);
            bulletBox.Dispose();
            bullet = null;
            bulletsList.RemoveAt(0);
            myPlayer.reload();
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
                myPlayer.shooting = false;
            }
                
        }

        public void gameRestart()
        {
            windowHeight = this.Height;
            windowWidth = this.Width;

            myPlayer = new Player(false, false, false, false, false, false, Player.Direction.Left, 100, 100, 2, this);
            
            enemy = new Enemy(this, 300, 300);
            enemy = new Enemy(this, 500, 300);
            enemy = new Enemy(this, 700, 500);

            bulletController = new BulletController();

            gameTimer.Start();
        }


    }
}