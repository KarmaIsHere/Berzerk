namespace Berzerk.game_objects
{
    public interface IPictureBoxManager
    {
        void GenerateSprite(int x, int y);
        void RemoveSprite(Form form);
        Rectangle GetBounds();
        void Dispose();
        bool IsEnemyBoxNull();
        PictureBox GetSprite();
    }
}
