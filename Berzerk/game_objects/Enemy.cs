using Berzerk.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Berzerk.game_objects
{
    public class Enemy : Form
    {
        private EnemyPictureBoxManager _spriteManager;

        public Enemy(Form form, int x, int y)
        {
            _spriteManager = new EnemyPictureBoxManager(form, x, y);
        }

        public void removeEnemyBox(Form form)
        {
            _spriteManager.removeSprite(form);
        }

        public Rectangle getBounds()
        {
            return _spriteManager.getBounds();
        }

        public void die()
        {
            _spriteManager.dispose();
        }
        public bool isEnemyBoxNull()
        {
            return _spriteManager.isEnemyBoxNull();
        }
    }
}
