using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Berzerk.game_objects
{
    public class PlayerPictureBoxManager : IPictureBoxManager
    {
        private PictureBox playerSprite;

        public PlayerPictureBoxManager(Form form, int x, int y)
        {
             generateSprite(x, y);
            form.Controls.Add(playerSprite);
        }

        public void generateSprite(int x, int y)
        {
            string projectPath = Directory.GetCurrentDirectory();
            string path = projectPath.Replace("bin\\Debug\\net6.0-windows", "Properties\\images\\player.png");

            PictureBox picture = new();
            ((System.ComponentModel.ISupportInitialize)(picture)).BeginInit();

            picture.Location = new System.Drawing.Point(x, y);
            picture.Name = "playerCharacter";
            picture.Tag = "player";
            picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            picture.Load(path);
            playerSprite = picture;
        }

        public PictureBox getSprite()
        {
            return playerSprite;
        }

        public void dispose()
        {
            if (playerSprite != null)
            {
                playerSprite.Dispose();
                playerSprite = null;
            }
        }

        public bool isEnemyBoxNull()
        {
            return playerSprite == null;
        }

        public void removeSprite(Form form)
        {
            throw new NotImplementedException();
        }

        public Rectangle getBounds()
        {
            return playerSprite.Bounds;
        }
    }
}
