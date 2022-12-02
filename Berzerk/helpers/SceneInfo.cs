using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerk.helpers
{
    internal class SceneInfo
    {
        public int height { get; private set; }
        public int width { get; private set; }

        public int centerX { get; private set; }
        public int centerY { get; private set; }

        public SceneInfo(int height, int width)
        {
            this.height = height;
            this.width = width;
            centerX = width / 2;
            centerY = height / 2;
        }
    }
}
