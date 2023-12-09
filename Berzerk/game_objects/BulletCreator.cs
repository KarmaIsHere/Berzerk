using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Berzerk.game_objects.Entity;

namespace Berzerk.game_objects
{
    internal class BulletCreator : IBulletUtility
    {
        public BulletCreator() { }
        public PictureBox createBulletPictureBox(Player myPlayer)
        {
            var bulletPictureBox = new PictureBox();
            bulletPictureBox.BackColor = Color.Yellow;
            bulletPictureBox.Tag = "bulletEntity";
            switch (myPlayer.getDirection())
            {
                case Direction.Up:
                    bulletPictureBox.Size = new Size(5, 20);
                    break;
                case Direction.Down:
                    bulletPictureBox.Size = new Size(5, 20);
                    break;
                case Direction.Left:
                    bulletPictureBox.Size = new Size(20, 5);
                    break;
                case Direction.Right:
                    bulletPictureBox.Size = new Size(20, 5);
                    break;
            }
            return bulletPictureBox;
        }
        public PictureBox createBulletPictureBox(Player myPlayer, Form form)
        {
            var bullet = createBulletPictureBox(myPlayer);
            form.Controls.Add(bullet);
            return bullet;
        }
    }
}
