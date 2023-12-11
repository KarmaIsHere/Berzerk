namespace Berzerk.game_objects
{
    public class PlayerPictureBoxManager : IPictureBoxManager
    {
        private PictureBox playerSprite;

        public PlayerPictureBoxManager(Form form, int x, int y)
        {
            GenerateSprite(x, y);
            form.Controls.Add(playerSprite);
        }

        public void GenerateSprite(int x, int y)
        {
            string projectPath = Directory.GetCurrentDirectory();
            string path = projectPath.Replace("bin\\Debug\\net6.0-windows", "Properties\\images\\player.png");

            PictureBox picture = new();
            ((System.ComponentModel.ISupportInitialize)(picture)).BeginInit();

            picture.Location = new System.Drawing.Point(x, y);
            picture.Name = "playerCharacter";
            picture.Tag = "player";
            picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            picture.Load(path);
            playerSprite = picture;
        }

        public PictureBox GetSprite()
        {
            return playerSprite;
        }

        public void Dispose()
        {
            if (playerSprite != null)
            {
                playerSprite.Dispose();
                playerSprite = null;
            }
        }

        public bool IsEnemyBoxNull()
        {
            return playerSprite == null;
        }

        public void RemoveSprite(Form form)
        {
            throw new NotImplementedException();
        }

        public Rectangle GetBounds()
        {
            return playerSprite.Bounds;
        }
    }
}
