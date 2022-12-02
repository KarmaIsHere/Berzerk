using Berzerk.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Berzerk.model
{
    public static class TextBox
    {
        public static void popUpMessageCenter(string text, Form form, int x, int y)
        {
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            textBox.Text = text;
            textBox.Location = new System.Drawing.Point(x, y);
            form.Controls.Add(textBox);
        }
    }
}
