using Berzerk.helpers;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Berzerk.model.Bullet;
using static Berzerk.model.Player;
using static System.Formats.Asn1.AsnWriter;

namespace Berzerk.model
{
    public class Bullet
    {
        protected int _bulletSpeed;
        protected PictureBox _bullet;
        protected Direction _viewDirection;
        System.Windows.Forms.Timer bulletTimer;
        public int x { get => _bullet.Left; private set => _bullet.Left = value; }
        public int y { get => _bullet.Top; private set => _bullet.Top = value; }


        public Bullet(int bulletSpeed)
        {
            this._bulletSpeed = bulletSpeed;
        }

        public void setDirection(Direction direction)
        {
            this._viewDirection = direction;
        }

        public Direction getDirection()
        {
            return this._viewDirection;
        }
        public void spawnBullet(Player myPlayer, Form form, Direction direction)
        {
            _bullet = new System.Windows.Forms.PictureBox();
            _bullet.BackColor = System.Drawing.Color.Yellow;
            _bullet.Tag = "bulletEntity";
            setDirection(direction);

            if (_viewDirection == Direction.Up || _viewDirection == Direction.Down) makeBulletVertical();
            else _bullet.Size = new System.Drawing.Size(20, 5);

            switch (_viewDirection)
            {
                case Direction.Up:
                    y = -30 + myPlayer.y;
                    x = myPlayer.width / 2 + myPlayer.x;
                    break;
                case Direction.Down:
                    y = 60 + myPlayer.y;
                    x = myPlayer.width / 2 + myPlayer.x; ;
                    break;
                case Direction.Left:
                    y = myPlayer.height / 2 + myPlayer.y; ;
                    x = -30 + myPlayer.x;
                    break;
                case Direction.Right:
                    y = myPlayer.height / 2 + myPlayer.y; ;
                    x = 30 + myPlayer.x;
                    break;
            }

            //_bullet.Left = myPlayer.x + coordinates.Item1;
            //_bullet.Top = myPlayer.y + coordinates.Item2;


            form.Controls.Add(this._bullet);
            bulletTimer = new System.Windows.Forms.Timer();
            bulletTimer.Interval = _bulletSpeed;
            bulletTimer.Tick += new EventHandler(bulletMoveTick);
            bulletTimer.Start();
            
        }
        public void bulletMoveTick(object sender, EventArgs e)
        {
                moveBullet();           
            if (x > 1192 || x < 0 || y < 0 || y > 617)
            {
                bulletTimer.Stop();
                bulletTimer.Dispose();
                _bullet.Dispose();
                bulletTimer = null;
                _bullet = null;
            }
        }

        public void moveBullet()
        {
            switch (getDirection())
            {
                case Direction.Up:
                    moveCoordinates(0, -_bulletSpeed);
                    break;
                case Direction.Down:
                    moveCoordinates(0, _bulletSpeed);
                    break;
                case Direction.Left:
                    moveCoordinates(-_bulletSpeed, 0);
                    break;
                case Direction.Right:
                    moveCoordinates(_bulletSpeed, 0);
                    break;
                default:
                    moveCoordinates(0, 0);
                    break;
            }
        }
        private void moveCoordinates(int x, int y)
        {
            this.x += x;
            this.y += y; 
        }

        public void makeBulletVertical()
        {
            this._bullet.Size = new System.Drawing.Size(5, 20);
        }
        public Rectangle getBounds()
        {
            return _bullet.Bounds;
        }
        public bool isBulletBoxNull()
        {
            if (_bullet == null) return true;
            return false;
        }

    }
}
