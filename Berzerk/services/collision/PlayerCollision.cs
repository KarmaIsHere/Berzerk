using Berzerk.game_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.services.collision
{
    public class PlayerCollision : IObservable<bool>, IDisposable
    {
        List<IObserver<bool>> watchers = new();
        public void checkEnemyTouchPlayer(ref EnemyManager enemyManager,ref Player myPlayer, ref GameProperties game)
        {
            foreach (Enemy enemy in enemyManager.getEnemies())
            {
                if (enemy.isPictureBoxNull() == false && enemy.getBounds().IntersectsWith(myPlayer.getBounds()))
                {
                    game.isOver = true;
                    game.isVicotry = false;
                    Notify(game.isVicotry);
                }
            }
        }

        public void Notify(bool isVictory)
        {
            watchers.ForEach(x => x.OnNext(isVictory));
                watchers.ForEach(x => x.OnCompleted());
        }
        public IDisposable Subscribe(IObserver<bool> observer)
        {
            watchers.Add(observer);
            return this;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
