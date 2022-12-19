using Berzerk.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Berzerk.game_objects.Entity;

namespace Berzerk.game_objects
{
    public class Enemy : Entity
    {
        private PictureBox _enemy;
        private int x { get => _enemy.Top; set => _enemy.Top = value; }
        private int y { get => _enemy.Left; set => _enemy.Left = value; }

        private int _speed;
        private int _xSpeedTick;
        private int _ySpeedTick;
        private int _scoreWorth;

        public int scoreWorth { get => _scoreWorth; set => _scoreWorth = value; }

        protected Direction _viewDirection;
        private Random rand;
        System.Windows.Forms.Timer enemyTimer;

        public Enemy(Form form, int x, int y)
        {
            _speed = 1;
            this._enemy = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._enemy)).BeginInit();

            this._enemy.Load(@"D:\Main\Gallery\code\Berzerk\Berzerk\Properties\images\enemy.png");
            this._enemy.Location = new Point(x, y);
            this._enemy.Name = "enemy";
            this._enemy.Size = new Size(26, 47);
            this._enemy.SizeMode = PictureBoxSizeMode.AutoSize;
            this._enemy.TabIndex = 0;
            this._enemy.TabStop = false;
            this._enemy.Tag = "enemy";
            form.Controls.Add(this._enemy);
            _scoreWorth = 100;

            rand = new Random(Guid.NewGuid().GetHashCode());
        }
        public void tryToMove()
        {
            /*if (rand.Next(1, 4) == 1)*/ move((Direction)rand.Next(Enum.GetNames(typeof(Direction)).Length));
        }
        public override void move(Direction direction)
        {
            _xSpeedTick = 0;
            _ySpeedTick = 0;

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            
            switch (direction)
            {
                case Direction.Left:
                    _xSpeedTick = -_speed;
                    break;
                case Direction.Right:
                    _xSpeedTick = _speed;
                    break;
                case Direction.Up:
                    _ySpeedTick = -_speed;
                    break;
                case Direction.Down:
                    _ySpeedTick = _speed;
                    break;
            }
            createTimer();
            
        }

        private void createTimer()
        {
            enemyTimer = new System.Windows.Forms.Timer();
            enemyTimer.Interval = _speed;
            enemyTimer.Tick += new EventHandler(enemyMoveTick);
            enemyTimer.Start();
        }

        public void enemyMoveTick(object sernder, EventArgs e)
        {
            if (x < 1192 && x > 0 && y > 0 && y < 617)
            {
                move();
            }
        }

        public void move()
        {
            this.x += _xSpeedTick;
            this.y += _ySpeedTick;
        }

        public void removePictureBox(Form form)
        {
            form.Controls.Remove(_enemy);
            _enemy.Dispose();
        }

        public override Rectangle getBounds()
        {
            return _enemy.Bounds;
        }
        public override void destroy()
        {
            _enemy.Dispose();
            _enemy = null;
        }
        public override bool isPictureBoxNull()
        {
            if (_enemy == null) return true;
            return false;
        }
    }
}
