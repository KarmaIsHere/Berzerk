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
        private PictureBox enemySprite;

        public EnemyPictureBoxManager(Form form, int x, int y)
        {
            string projectPath = Directory.GetCurrentDirectory();
            string path = projectPath.Replace("bin\\Debug\\net6.0-windows", "Properties\\images\\enemy.png");
            enemySprite = new PictureBox();
            enemySprite.Load(path);
            enemySprite.Location = new Point(x, y);
            enemySprite.Size = new Size(26, 47);
            enemySprite.SizeMode = PictureBoxSizeMode.AutoSize;
            enemySprite.TabIndex = 0;
            enemySprite.TabStop = false;
            enemySprite.Tag = "enemy";
            form.Controls.Add(enemySprite);
        }

        public void removeEnemySprite(Form form)
        {
            form.Controls.Remove(enemySprite);
            enemySprite.Dispose();
        }

        public Rectangle getBounds()
        {
            return enemySprite.Bounds;
        }

        public void dispose()
        {
            if (enemySprite != null)
            {
                enemySprite.Dispose();
                enemySprite = null;
            }
        }

        public bool isEnemyBoxNull()
        {
            return enemySprite == null ? true : false;
        }
    }
}
