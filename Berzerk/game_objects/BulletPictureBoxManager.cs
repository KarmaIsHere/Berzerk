using static Berzerk.game_objects.Entity;

namespace Berzerk.game_objects
{
    internal class BulletPictureBoxManager
    {
        public BulletPictureBoxManager() { }
        public static PictureBox CreateBulletPictureBox(Player myPlayer)
        {
            PictureBox bulletPictureBox = new()
            {
                BackColor = Color.Yellow,
                Tag = "bulletEntity"
            };
            switch (myPlayer.GetDirection())
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
        public static PictureBox CreateBulletPictureBox(Player myPlayer, Form form)
        {
            var bullet = CreateBulletPictureBox(myPlayer);
            form.Controls.Add(bullet);
            return bullet;
        }
    }
}
