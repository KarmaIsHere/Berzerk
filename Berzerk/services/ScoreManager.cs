using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Berzerk.services
{
    public class ScoreManager : IObserver<int>
    {
        private System.Windows.Forms.Label scoreLabel;
        private int score;

        public ScoreManager(Form form, int x, int y)
        {
            scoreLabel = new System.Windows.Forms.Label();
            scoreLabel.Text = "Score: ";

            scoreLabel.Location = new Point(x, y);
            scoreLabel.BackColor = Color.Gray;
            scoreLabel.Size = new Size(500, 50);
            scoreLabel.Font = new Font(scoreLabel.Font.FontFamily, 24);
            scoreLabel.BringToFront();
            form.Controls.Add(scoreLabel);
        }

        public void update(int scoreToAdd)
        {
            score += scoreToAdd;
            scoreLabel.Text = $"Score: {score}";
        }
        public void destroyTextBox()
        {
            scoreLabel.Dispose();
            scoreLabel = null;
        }
        public bool isPictureBoxNull()
        {
            if (scoreLabel == null) return true;
            return false;
        }

        public void OnCompleted()
        {
            scoreLabel.BackColor = Color.Green;
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(int value)
        {
            update(value);
        }
    }
}
