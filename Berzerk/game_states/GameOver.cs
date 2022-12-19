using Berzerk.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Berzerk.game_states
{
    public class GameOver
    {
        private System.Windows.Forms.Label label;

        public GameOver(Form form, bool isVictory, int x, int y)
        {
            label = new System.Windows.Forms.Label();
            if (isVictory)
                label.Text = "You won! Press Enter to restart";
            else label.Text = "Game Over! Press Enter to restart";

            label.Location = new Point(x, y);
            label.BackColor = Color.Red;
            label.Size = new Size(500, 50);
            label.Font = new Font(label.Font.FontFamily, 24);
            label.BringToFront();
            form.Controls.Add(label);
        }

        public void destroyTextBox()
        {
            label.Dispose();
            label = null;
        }
        public bool isEnemyBoxNull()
        {
            if (label == null) return true;
            return false;
        }
    }
}
