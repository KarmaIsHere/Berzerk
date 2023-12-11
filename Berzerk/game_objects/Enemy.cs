namespace Berzerk.game_objects
{
    public class Enemy : Form
    {
        private readonly EnemyPictureBoxManager _spriteManager;

        public Enemy(Form form, int x, int y)
        {
            _spriteManager = new EnemyPictureBoxManager(form, x, y);
        }

        public void RemoveEnemyBox(Form form)
        {
            _spriteManager.RemoveSprite(form);
        }

        public Rectangle GetBounds()
        {
            return _spriteManager.GetBounds();
        }

        public void Die()
        {
            _spriteManager.Dispose();
        }
        public bool IsEnemyBoxNull()
        {
            return _spriteManager.IsEnemyBoxNull();
        }
    }
}
