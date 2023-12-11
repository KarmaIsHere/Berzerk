namespace Berzerk.services
{
    public class GameProperties
    {
        public bool IsOver { get; set; }
        public bool IsVicotry { get; set; }


        public void checkEnemyCount(int enemyCount)
        {
            if (enemyCount == 0)
            {
                IsOver = true;
                IsVicotry = true;
            }
        }
    }
}
