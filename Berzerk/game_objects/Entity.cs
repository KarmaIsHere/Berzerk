using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.game_objects
{
    public abstract class Entity
    {
        public enum Direction { Up, Down, Left, Right };
        abstract public void move(Direction direction);
        abstract public void destroy();
        abstract public Rectangle getBounds();
        abstract public bool isPictureBoxNull();
    }
}
