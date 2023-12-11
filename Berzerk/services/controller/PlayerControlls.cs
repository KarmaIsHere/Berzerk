using Berzerk.game_objects;
using Berzerk.helpers;

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
            if (myPlayer.GoUp && myPlayer.y > 0)
            {
                myPlayer.Move(Entity.Direction.Up);
            }
            if (myPlayer.GoDown && myPlayer.y < scene.Height - 100)
            {
                myPlayer.Move(Entity.Direction.Down);
            }
            if (myPlayer.GoLeft && myPlayer.x > 0)
            {
                myPlayer.Move(Entity.Direction.Left);
            }
            if (myPlayer.GoRight && myPlayer.x < scene.Width - 50)
            {
                myPlayer.Move(Entity.Direction.Right);
            }
            if (myPlayer.GetShotBullets().Count < 1)
            {
                myPlayer.Reload();
            }
            if (myPlayer.Shooting && myPlayer.Ammo > 0)
            {
                myPlayer.Shoot(form);
                myPlayer.Shooting = false;
            }
        }
    }
}
