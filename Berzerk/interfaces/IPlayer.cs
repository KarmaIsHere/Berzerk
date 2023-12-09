using Berzerk.game_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Berzerk.game_objects.Entity;

namespace Berzerk.interfaces
{
    public interface IPlayer
    {
        bool goUp { get; set; }
        bool goDown { get; set; }
        bool goLeft { get; set; }
        bool goRight { get; set; }
        bool shooting { get; set; }
        bool moving { get; set; }
        int x { get; }
        int y { get; }
        int width { get; set; }
        int height { get; set; }
        int ammo { get; set; }
        int maxAmmoSize { get; set; }
        void setDirection(Direction direction);
        Direction getDirection();
        void move(Direction direction);
        void shoot(Form form);
        void reload();
        List<Bullet> getShotBullets();
        void removeBullet(int index);
        void clearBullets();
        Rectangle getBounds();
        void destroy();
        bool isPictureBoxNull();
    }
}
