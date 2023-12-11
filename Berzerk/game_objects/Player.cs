namespace Berzerk.game_objects
{
    public class Player : Entity
    {

        private bool _goUp;
        private bool _goDown;
        private bool _goLeft;
        private bool _goRight;
        private bool _shooting;
        private bool _moving;
        protected Direction _viewDirection;
        private readonly int _playerSpeed;
        private int _ammo;
        private int _maxAmmoSize;
        private int xSpeedTick;
        private int ySpeedTick;
        readonly IPictureBoxManager pictureBoxManager;
        readonly List<Bullet> shotBullets = new();

        public bool GoUp { get => _goUp; set => _goUp = value; }
        public bool GoDown { get => _goDown; set => _goDown = value; }
        public bool GoLeft { get => _goLeft; set => _goLeft = value; }
        public bool GoRight { get => _goRight; set => _goRight = value; }
        public bool Shooting { get => _shooting; set => _shooting = value; }
        public bool Moving { get => _moving; set => _moving = value; }
        public int x { get => pictureBoxManager.GetSprite().Left; private set => pictureBoxManager.GetSprite().Left = value; }
        public int y { get => pictureBoxManager.GetSprite().Top; private set => pictureBoxManager.GetSprite().Top = value; }
        public int Width { get => pictureBoxManager.GetSprite().Width; set => pictureBoxManager.GetSprite().Width = value; }
        public int Height { get => pictureBoxManager.GetSprite().Height; set => pictureBoxManager.GetSprite().Height = value; }
        public int Ammo { get => _ammo; set => _ammo = value; }
        public int MaxAmmoSize { get => _maxAmmoSize; set => _maxAmmoSize = value; }

        public Player(Direction viewDirection, int x, int y, IPictureBoxManager playerPictureBoxManager)
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
            pictureBoxManager = playerPictureBoxManager;
            this.y = y;
            this.x = x;
        }
        public void SetDirection(Direction direction)
        {
            _viewDirection = direction;
        }

        public Direction GetDirection()
        {
            return _viewDirection;
        }

        public override void Move(Direction direction)
        {
            SetDirection(direction);
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
        public void Shoot(Form form)
        {
            _ammo -= 1;
            shotBullets.Add(new Bullet(12));
            shotBullets.Last().Spawn(this, form);
        }
        public void Reload()
        {
            _ammo = MaxAmmoSize;
        }
        public List<Bullet> GetShotBullets()
        {
            return shotBullets;
        }
        public void RemoveBullet(int index)
        {
            shotBullets.RemoveAt(index);
        }

        public void ClearBullets()
        {
            shotBullets.Clear();
        }

        public override void Destroy()
        {
            pictureBoxManager.Dispose();
        }

        public override Rectangle GetBounds()
        {
            return pictureBoxManager.GetBounds();
        }

        public override bool IsPictureBoxNull()
        {
            throw new NotImplementedException();
        }
    }
}
