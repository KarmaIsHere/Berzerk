using Berzerk.game_objects;
using Berzerk.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.services.controller
{
    public class PlayerControlls
    {
        Form form;

        public PlayerControlls(Form form)
        {
            this.form = form;
        }

        public void checkPlayerInput(ref Player myPlayer, ref SceneInfo scene)
        {
            if (myPlayer.goUp && myPlayer.y > 0)
            {
                myPlayer.move(Entity.Direction.Up);
            }
            if (myPlayer.goDown && myPlayer.y < scene.height - 100)
            {
                myPlayer.move(Entity.Direction.Down);
            }
            if (myPlayer.goLeft && myPlayer.x > 0)
            {
                myPlayer.move(Entity.Direction.Left);
            }
            if (myPlayer.goRight && myPlayer.x < scene.width - 50)
            {
                myPlayer.move(Entity.Direction.Right);
            }
            if(myPlayer.getShotBullets().Count < 1)
            {
                myPlayer.reload();
            }
            if (myPlayer.shooting && myPlayer.ammo > 0)
            {
                myPlayer.shoot(form);
                myPlayer.shooting = false;
            }
        }
    }
}
