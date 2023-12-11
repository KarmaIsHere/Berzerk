using Berzerk.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Berzerk.game_objects
{
    public class EnemyPictureBoxManager
    {
        private PictureBox _enemyPictureBox;

        public EnemyPictureBoxManager(Form form, int x, int y)
        {
            string projectPath = Directory.GetCurrentDirectory();
            string path = projectPath.Replace("bin\\Debug\\net6.0-windows", "Properties\\images\\enemy.png");
            _enemyPictureBox = new PictureBox();
            _enemyPictureBox.Load(path);
            _enemyPictureBox.Location = new Point(x, y);
            _enemyPictureBox.Size = new Size(26, 47);
            _enemyPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            _enemyPictureBox.TabIndex = 0;
            _enemyPictureBox.TabStop = false;
            _enemyPictureBox.Tag = "enemy";
            form.Controls.Add(_enemyPictureBox);
        }

        public void removeEnemySprite(Form form)
        {
            form.Controls.Remove(_enemyPictureBox);
            _enemyPictureBox.Dispose();
        }

        public Rectangle getBounds()
        {
            return _enemyPictureBox.Bounds;
        }

        public void dispose()
        {
            if (_enemyPictureBox != null)
            {
                _enemyPictureBox.Dispose();
                _enemyPictureBox = null;
            }
        }

        public bool isEnemyBoxNull()
        {
            return _enemyPictureBox == null ? true : false;
        }
    }
}
