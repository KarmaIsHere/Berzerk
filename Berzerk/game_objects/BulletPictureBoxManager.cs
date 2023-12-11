using static Berzerk.game_objects.Entity;

namespace Berzerk.game_objects
{
    internal class BulletPictureBoxManager
    {
        public BulletPictureBoxManager() { }
        public static PictureBox createBulletPictureBox(Player myPlayer)
        {
            PictureBox bulletPictureBox = new()
            {
                BackColor = Color.Yellow,
                Tag = "bulletEntity"
            };
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
            public static PictureBox createBulletPictureBox(Player myPlayer, Form form)
    {
        var bullet = createBulletPictureBox(myPlayer);
        form.Controls.Add(bullet);
        return bullet;
    }
    }
}
