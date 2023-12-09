using Berzerk.interfaces;
using Berzerk.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Berzerk.game_objects
{
    public class Player : Entity, IPlayer
    {
        //public enum Direction { Up, Down, Left, Right };

        private bool _goUp;
        private bool _goDown;
        private bool _goLeft;
        private bool _goRight;
        private bool _shooting;
        private bool _moving;

        protected Direction _viewDirection;
        private int _playerSpeed;
        private PictureBox _player;
        private int _ammo;
        private int _maxAmmoSize;

        private int xSpeedTick;
        private int ySpeedTick;

        List<Bullet> shotBullets = new List<Bullet>();

        public bool goUp { get => _goUp; set => _goUp = value; }
        public bool goDown { get => _goDown; set => _goDown = value; }
        public bool goLeft { get => _goLeft; set => _goLeft = value; }
        public bool goRight { get => _goRight; set => _goRight = value; }
        public bool shooting { get => _shooting; set => _shooting = value; }
        public bool moving { get => _moving; set => _moving = value; }  
        public int x { get => _player.Left; private set => _player.Left = value; }
        public int y { get => _player.Top; private set => _player.Top = value; }
        public int width { get => _player.Width; set => _player.Width = value;}
        public int height { get => _player.Height; set => _player.Height = value;}
        public int ammo { get => _ammo; set => _ammo = value; } 
        public int maxAmmoSize { get => _maxAmmoSize; set => _maxAmmoSize = value; }

        public Player(Direction viewDirection, int x, int y, Form form)
        {
            _goUp = false;
            _goDown = false;
            _goLeft = false;
            _goRight = false;
            _shooting = false;
            _moving = false;
            _viewDirection = viewDirection;
            _playerSpeed = 2;
            _ammo = 1;
            _maxAmmoSize = 1;

            this._player = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._player)).BeginInit();

            this._player.Load(@"D:\Main\Gallery\code\Berzerk\Berzerk\Properties\images\player.png");   
            this._player.Location = new System.Drawing.Point(x, y);
            this._player.Name = "playerCharacter";
            this._player.Tag = "player";
            this._player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;

            this.x = x;
            this.y = y;

            form.Controls.Add(this._player);
        }
        public void setDirection(Direction direction)
        {
            _viewDirection = direction;
        }
        public Direction getDirection()
        {
            return _viewDirection;
        }
        public override void move(Direction direction)
        {
            setDirection(direction);
            xSpeedTick = 0;
            ySpeedTick = 0;
            switch (direction)
            {
                case Direction.Left:
                    xSpeedTick = -_playerSpeed;
                    break;
                case Direction.Right:
                    xSpeedTick = _playerSpeed;
                    break;
                case Direction.Up:
                    ySpeedTick = -_playerSpeed;
                    break;
                case Direction.Down:
                    ySpeedTick = _playerSpeed;
                    break;
            }
            this.x += xSpeedTick;
            this.y += ySpeedTick;
        }
        public void shoot(Form form)
        {
            _ammo -= 1;
            shotBullets.Add(new Bullet(12));
            shotBullets.Last().spawn(this, form);
        }
        public void reload()
        {
            _ammo = maxAmmoSize;
        }
        public List<Bullet> getShotBullets()
        {
            return shotBullets;
        }
        public void removeBullet(int index)
        {
            shotBullets.RemoveAt(index);
        }

        public void clearBullets()
        {
            shotBullets.Clear();
        }
        public override Rectangle getBounds()
        {
            return _player.Bounds;
        }
        public override void destroy()
        {
            _player.Dispose();
            _player = null;
        }
        public override bool isPictureBoxNull()
        {
            if (_player == null) return true;
            return false;
        }
    }
}
