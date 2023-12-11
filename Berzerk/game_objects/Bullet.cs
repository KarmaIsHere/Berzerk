namespace Berzerk.game_objects
{
    public class Bullet : Entity
    {
        protected int _bulletSpeed;
        protected PictureBox _bullet;
        protected Direction _viewDirection;
        System.Windows.Forms.Timer bulletTimer;
        private readonly BulletPictureBoxManager bulletManager = new();
        public int x { get => _bullet.Left; private set => _bullet.Left = value; }
        public int y { get => _bullet.Top; private set => _bullet.Top = value; }

        private int _xSpeedTick = 0;
        private int _ySpeedTick = 0;

        public Bullet(int bulletSpeed)
        {
            this._bulletSpeed = bulletSpeed;
        }

        public void Spawn(Player myPlayer, Form form)
        {
            this._bullet = BulletPictureBoxManager.CreateBulletPictureBox(myPlayer, form);
            SetDirection(myPlayer.GetDirection());
            switch (_viewDirection)
            {
                case Direction.Up:
                    y = -30 + myPlayer.y;
                    x = myPlayer.Width / 2 + myPlayer.x;
                    _ySpeedTick = -_bulletSpeed;
                    break;

                case Direction.Down:
                    y = 60 + myPlayer.y;
                    x = myPlayer.Width / 2 + myPlayer.x;
                    _ySpeedTick = _bulletSpeed;
                    break;

                case Direction.Left:
                    y = myPlayer.Height / 2 + myPlayer.y;
                    x = -30 + myPlayer.x;
                    _xSpeedTick = -_bulletSpeed;
                    break;

                case Direction.Right:
                    y = myPlayer.Height / 2 + myPlayer.y;
                    x = 30 + myPlayer.x;
                    _xSpeedTick = _bulletSpeed;
                    break;
            }
            CreateBulletTimer();
        }

        public void MakeVertical()
        {
            this._bullet.Size = new System.Drawing.Size(5, 20);
        }
        public void SetDirection(Direction direction)
        {
            this._viewDirection = direction;
        }
        public Direction GetDirection()
        {
            return this._viewDirection;
        }
        private void CreateBulletTimer()
        {
            bulletTimer = new System.Windows.Forms.Timer
            {
                Interval = _bulletSpeed
            };
            bulletTimer.Tick += new EventHandler(BulletMoveTick);
            bulletTimer.Start();
        }
        public void BulletMoveTick(object sender, EventArgs e)
        {
            Move(_viewDirection);
            if (x > 1192 || x < 0 || y < 0 || y > 617)
            {
                Destroy();
            }
        }
        public override void Move(Direction direction)
        {
            this.x += _xSpeedTick;
            this.y += _ySpeedTick;
        }
        public override void Destroy()
        {
            bulletTimer.Stop();
            bulletTimer.Dispose();
            _bullet.Dispose();
            bulletTimer = null;
            _bullet = null;
        }
        public override Rectangle GetBounds()
        {
            return _bullet.Bounds;
        }
        public override bool IsPictureBoxNull()
        {
            return _bullet == null;
        }


    }
}
