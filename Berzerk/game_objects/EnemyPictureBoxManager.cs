﻿namespace Berzerk.game_objects
{
    public class EnemyPictureBoxManager : IPictureBoxManager
    {
        private PictureBox enemySprite;

        public EnemyPictureBoxManager(Form form, int x, int y)
        {
            GenerateSprite(x, y);
            form.Controls.Add(enemySprite);
        }

        public void GenerateSprite(int x, int y)
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
        }

        public void RemoveSprite(Form form)
        {
            form.Controls.Remove(enemySprite);
            enemySprite.Dispose();
        }

        public Rectangle GetBounds()
        {
            return enemySprite.Bounds;
        }

        public void Dispose()
        {
            if (enemySprite != null)
            {
                enemySprite.Dispose();
                enemySprite = null;
            }
        }

        public bool IsEnemyBoxNull()
        {
            return enemySprite == null;
        }

        public PictureBox GetSprite()
        {
            return enemySprite;
        }
    }
}
