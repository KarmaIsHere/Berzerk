using Berzerk.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Berzerk.model
{
    public class TextBox
    {
        private System.Windows.Forms.Label label;

        public TextBox(Form form)
        {
            this.label =  new System.Windows.Forms.Label();
        }

        public void popUpMessageCenter(string text, Form form, int x, int y)
        {

            label.Text = text;
            label.Location = new System.Drawing.Point(x, y);
            label.BackColor = Color.Red;
            label.Size = new System.Drawing.Size(500, 50);
            label.Font = new Font(label.Font.FontFamily, 24);
            label.BringToFront();
            form.Controls.Add(this.label);
        }

        public void popUpGameOver(Form form, int centerX, int centerY)
        {
            popUpMessageCenter("Game Over! Press Enter to restart", form, centerX, centerY);
        }

        public void popUpVictory(Form form, int centerX, int centerY)
        {
            popUpMessageCenter("You won! Press Enter to restart", form, centerX, centerY);
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
