using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.game_objects
{
    public class PlayerPictureBoxManager
    {
        private const string PATH_TO_PNG = @"C:\Users\Namai\source\repos\Berzerk\Berzerk\Properties\images\player.png";

        private PictureBox _playerPictureBox;

        public PlayerPictureBoxManager(int x, int y)
        {
            _playerPictureBox = createPlayerPictureBox(x, y);
        }

        public PictureBox createPlayerPictureBox(int x, int y)
        {
            PictureBox picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(picture)).BeginInit();

            picture.Location = new System.Drawing.Point(x, y);
            picture.Name = "playerCharacter";
            picture.Tag = "player";
            picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            picture.Load(PATH_TO_PNG);
            return picture;
        }

        public PictureBox getPlayerPictureBox()
        {
            return _playerPictureBox;
        }
    }
}
