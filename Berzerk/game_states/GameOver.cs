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
            label.Size = new Size(1500, 50);
            label.Font = new Font(label.Font.FontFamily, 24);
            label.BringToFront();
            form.Controls.Add(label);
        }
        public void DestroyTextBox()
        {
            label.Dispose();
            label = null;
        }
    }
}
