using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.game_objects
{
    internal interface IBulletUtility
    {
        PictureBox createBulletPictureBox(Player myPlayer, Form form);
    }
}
