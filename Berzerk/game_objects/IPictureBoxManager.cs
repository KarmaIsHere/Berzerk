namespace Berzerk.game_objects
{
    public interface IPictureBoxManager
    {
        void generateSprite(int x, int y);
        void removeSprite(Form form);
        Rectangle getBounds();
        void dispose();
        bool isEnemyBoxNull();
        PictureBox getSprite();
    }
}
