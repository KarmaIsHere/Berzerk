using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.game_objects
{
    public class PlayerPictureBoxManager
    {
        private PictureBox _playerPictureBox;

        public PlayerPictureBoxManager(int x, int y)
        {
            _playerPictureBox = createPlayerPictureBox(x, y);
        }

        public PictureBox createPlayerPictureBox(int x, int y)
        {
            string projectPath = Directory.GetCurrentDirectory();
            string path = projectPath.Replace("bin\\Debug\\net6.0-windows", "Properties\\images\\player.png");

            PictureBox picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(picture)).BeginInit();

            picture.Location = new System.Drawing.Point(x, y);
            picture.Name = "playerCharacter";
            picture.Tag = "player";
            picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            picture.Load(path);
            return picture;
        }

        public PictureBox getPlayerPictureBox()
        {
            return _playerPictureBox;
        }
    }
}
