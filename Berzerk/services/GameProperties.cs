using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.services
{
    public  class GameProperties
    {
        private bool _isOver;
        private bool _isVictory;

        public bool isOver { get { return _isOver; } set { _isOver = value; } }
        public bool isVicotry { get { return _isVictory; } set { _isVictory = value; } }


        public void checkEnemyCount(int enemyCount)
        {
            if (enemyCount == 0)
            {
                _isOver = true;
                _isVictory = true;
            }
        }
    }
}
