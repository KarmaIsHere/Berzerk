using Berzerk.game_objects;
using Berzerk.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.services
{
    public class KeyBoardInput
    {
        public void manageKeyIsDown(KeyEventArgs e, IPlayer myPlayer)
        {
            if (e.KeyCode == Keys.Up && myPlayer.moving == false)
            {
                myPlayer.goUp = true;
                myPlayer.moving = true;
            }
            if (e.KeyCode == Keys.Down && myPlayer.moving == false)
            {
                myPlayer.goDown = true;
                myPlayer.moving = true;
            }
            if (e.KeyCode == Keys.Left && myPlayer.moving == false)
            {
                myPlayer.goLeft = true;
                myPlayer.moving = true;
            }
            if (e.KeyCode == Keys.Right && myPlayer.moving == false)
            {
                myPlayer.goRight = true;
                myPlayer.moving = true;
            }
            if (e.KeyCode == Keys.Space && myPlayer.shooting == false)
            {
                myPlayer.shooting = true;
            }
        }
        public void manageKeyIsUp(KeyEventArgs e, IPlayer myPlayer)
        {
            if (e.KeyCode == Keys.Up)
            {
                myPlayer.goUp = false;
                myPlayer.moving = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                myPlayer.goDown = false;
                myPlayer.moving = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                myPlayer.goLeft = false;
                myPlayer.moving = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                myPlayer.goRight = false;
                myPlayer.moving = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                myPlayer.shooting = false;
            }
        }
    }
}
