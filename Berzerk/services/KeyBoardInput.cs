using Berzerk.game_objects;

namespace Berzerk.services
{
    public class KeyBoardInput
    {
        public void ManageKeyIsDown(KeyEventArgs e, ref Player myPlayer)
        {
            if (e.KeyCode == Keys.Up && myPlayer.Moving == false)
            {
                myPlayer.GoUp = true;
                myPlayer.Moving = true;
            }
            if (e.KeyCode == Keys.Down && myPlayer.Moving == false)
            {
                myPlayer.GoDown = true;
                myPlayer.Moving = true;
            }
            if (e.KeyCode == Keys.Left && myPlayer.Moving == false)
            {
                myPlayer.GoLeft = true;
                myPlayer.Moving = true;
            }
            if (e.KeyCode == Keys.Right && myPlayer.Moving == false)
            {
                myPlayer.GoRight = true;
                myPlayer.Moving = true;
            }
            if (e.KeyCode == Keys.Space && myPlayer.Shooting == false)
            {
                myPlayer.Shooting = true;
            }
        }
        public void ManageKeyIsUp(KeyEventArgs e, ref Player myPlayer)
        {
            if (e.KeyCode == Keys.Up)
            {
                myPlayer.GoUp = false;
                myPlayer.Moving = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                myPlayer.GoDown = false;
                myPlayer.Moving = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                myPlayer.GoLeft = false;
                myPlayer.Moving = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                myPlayer.GoRight = false;
                myPlayer.Moving = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                myPlayer.Shooting = false;
            }
        }
    }
}
