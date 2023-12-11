using Berzerk.game_objects;

namespace Berzerk.services.controller
{
    public class BulletController
    {
        int index;
        int indexSave;
        public void checkDestroyedBullets(ref Player player)
        {
            int index = 0;
            int indexSave = -1;
            foreach (Bullet bullet in player.GetShotBullets())
            {
                if (bullet.IsPictureBoxNull())
                {
                    indexSave = index;
                }
                index++;
            }
            if (indexSave != -1) player.RemoveBullet(indexSave);
        }
    }
}
