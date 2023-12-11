namespace Berzerk.helpers
{
    public class SceneInfo
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        public int CenterX { get; private set; }
        public int CenterY { get; private set; }

        public SceneInfo(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            CenterX = width / 2;
            CenterY = height / 2;
        }
    }
}
