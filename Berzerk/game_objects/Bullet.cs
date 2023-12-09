using Berzerk.helpers;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Berzerk.game_objects.Bullet;
using static Berzerk.game_objects.Player;
using static System.Formats.Asn1.AsnWriter;

namespace Berzerk.game_objects
{
    public class Bullet : Entity
    {
        protected int _bulletSpeed;
        protected PictureBox _bullet;
        protected Direction _viewDirection;
        System.Windows.Forms.Timer bulletTimer;
        private IBulletUtility bulletUtility = new BulletCreator();
        public int x { get => _bullet.Left; private set => _bullet.Left = value; }
        public int y { get => _bullet.Top; private set => _bullet.Top = value; }

        private int _xSpeedTick = 0;
        private int _ySpeedTick = 0;

        public Bullet(int bulletSpeed)
        {
            this._bulletSpeed = bulletSpeed;
        }

        public void spawn(Player myPlayer, Form form)
        {
            this._bullet = bulletUtility.createBulletPictureBox(myPlayer, form);
            setDirection(myPlayer.getDirection());
            switch (_viewDirection)
            {
                case Direction.Up:
                    y = -30 + myPlayer.y;
                    x = myPlayer.width / 2 + myPlayer.x;
                    _ySpeedTick = -_bulletSpeed;
                    break;

                case Direction.Down:
                    y = 60 + myPlayer.y;
                    x = myPlayer.width / 2 + myPlayer.x;
                    _ySpeedTick = _bulletSpeed;
                    break;

                case Direction.Left:
                    y = myPlayer.height/ 2 + myPlayer.y;
                    x = -30 + myPlayer.x;
                    _xSpeedTick = -_bulletSpeed;
                    break;

                case Direction.Right:
                    y = myPlayer.height / 2 + myPlayer.y;
                    x = 30 + myPlayer.x;
                    _xSpeedTick = _bulletSpeed;
                    break;
            }
            createBulletTimer();
        }

        public void makeVertical()
        {
            this._bullet.Size = new System.Drawing.Size(5, 20);
        }
        public void setDirection(Direction direction)
        {
            this._viewDirection = direction;
        }
        public Direction getDirection()
        {
            return this._viewDirection;
        }
        private void createBulletTimer()
        {
            bulletTimer = new System.Windows.Forms.Timer();
            bulletTimer.Interval = _bulletSpeed;
            bulletTimer.Tick += new EventHandler(bulletMoveTick);
            bulletTimer.Start();
        }
        public void bulletMoveTick(object sender, EventArgs e)
        {
            move(_viewDirection);           
            if (x > 1192 || x < 0 || y < 0 || y > 617)
            {
                destroy();
            }
        }
        public override void move(Direction direction)
        {
            this.x += _xSpeedTick;
            this.y += _ySpeedTick;
        }
        public override void destroy()
        {
            bulletTimer.Stop();
            bulletTimer.Dispose();
            _bullet.Dispose();
            bulletTimer = null;
            _bullet = null;
        }
        public override Rectangle getBounds()
        {
            return _bullet.Bounds;
        }
        public override bool isPictureBoxNull()
        {
            if (_bullet == null) return true;
            return false;
        }
        

    }
}
