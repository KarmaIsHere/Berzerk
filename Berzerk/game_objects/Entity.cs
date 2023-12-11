namespace Berzerk.game_objects
{
    public abstract class Entity
    {
        public enum Direction { Up, Down, Left, Right };
        abstract public void Move(Direction direction);
        abstract public void Destroy();
        abstract public Rectangle GetBounds();
        abstract public bool IsPictureBoxNull();
    }
}
