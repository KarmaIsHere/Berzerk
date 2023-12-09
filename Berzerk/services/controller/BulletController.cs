using Berzerk.game_objects;
using Berzerk.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.services.controller
{
    public class BulletController
    {
        int index;
        int indexSave;
        public void checkDestroyedBullets(IPlayer player)
        {
            int index = 0;
            int indexSave = -1;
            foreach (Bullet bullet in player.getShotBullets())
            {
                if (bullet.isPictureBoxNull())
                {
                    indexSave = index;
                }
                index++;
            }
            if (indexSave != -1) player.removeBullet(indexSave);
        }
    }
}
