using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.model
{
    public class Player
    {
        public enum Direction { Up, Down, Left, Right };

        private bool _goUp;
        private bool _goDown;
        private bool _goLeft;
        private bool _goRight;
        private bool _shooting;
        private bool _moving;
        private Direction _viewDirection;
        private int _x;
        private int _y;
        private int _playerSpeed;

        public bool goUp { get => _goUp; set => _goUp = value; }
        public bool goDown { get => _goDown; set => _goDown = value; }
        public bool goLeft { get => _goLeft; set => _goLeft = value; }
        public bool goRight { get => _goRight; set => _goRight = value; }
        public bool shooting { get => _shooting; set => _shooting = value; }
        public bool moving { get => _moving; set => _moving = value; }
        public int x { get => _x; set => _x = value; }
        public int y { get => _y; set => _y = value; }
        public void setDirection(Direction direction)
        {
            _viewDirection = direction;
        }

        public Direction getDirection()
        {
            return _viewDirection;
        }

        public void moveUp()
        {
            player.Top -= _playerSpeed;
            setDirection(Player.Direction.Up);
        }

        public void moveDown()
        {
            player.Top += _playerSpeed;
            setDirection(Player.Direction.Down);
        }

        public void moveLeft()
        {
            player.Left -= playerSpeed;
            setDirection(Player.Direction.Left);
        }

        public void moveRight()
        {
            player.Left += playerSpeed;
            setDirection(Player.Direction.Right);
        }



    }
}
