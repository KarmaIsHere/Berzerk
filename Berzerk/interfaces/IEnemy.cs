using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.interfaces
{
    public interface IEnemy
    {
        int x { get; set; }
        int y { get; set; }

        void removeEnemyBox(Form form);
        Rectangle getBounds();
        void die();
        bool isEnemyBoxNull();
    }
}
