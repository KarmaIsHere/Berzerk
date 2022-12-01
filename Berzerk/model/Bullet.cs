using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Berzerk.model.Player;

namespace Berzerk.model
{
    public class Bullet : Form
    {
        public enum Direction { Up, Down, Left, Right };
        //private int _x;
        //private int _y;
        protected int _bulletSpeed;
        protected PictureBox _bullet;
        protected Direction _viewDirection;


        public Bullet(int bulletSpeed, Player myPlayer, Form form)
        {
            this._bulletSpeed = bulletSpeed;

            this._bullet = new System.Windows.Forms.PictureBox();

            this._bullet.BackColor = System.Drawing.Color.Yellow;
            this._bullet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._bullet.Name = "bullet";
            this._bullet.Tag = "bulletEntity";
            this._bullet.Size = new System.Drawing.Size(11, 13);
            this._bullet.TabIndex = 1;
            this._bullet.TabStop = false;
            this._bullet.Location = new System.Drawing.Point(0, 0);

            form.Controls.Add(this._bullet);
        }

        public void setDirection(Direction direction)
        {
            this._viewDirection = direction;
        }

        public Direction getDirection()
        {
            return this._viewDirection;
        }
        public void spawnBullet(Tuple<int, int> coordinates, Player myPlayer)
        {
            this._bullet.Top = myPlayer.x + coordinates.Item1;
            this._bullet.Left = myPlayer.y + coordinates.Item2;
        }

        public Tuple<int, int> setSpawnCoordinates(Player myPlayer)
        {
            return new Tuple<int, int>(-30, 0);
        }

        public void setCanShoot(Player myPlayer)
        {
            myPlayer.shooting = false;
        }

        public Tuple<int,int> moveBullet()
        {
            Tuple<int, int> result = new Tuple<int, int>(0, 0);
            switch (getDirection())
            {
                case Direction.Up:
                    return new Tuple<int, int>(0, -5);
                    break;
                case Direction.Down:
                    return new Tuple<int, int>(0, 5);
                    break;
                case Direction.Left:
                    return new Tuple<int, int>(-5, 0);
                    break;
                case Direction.Right:
                    return new Tuple<int, int>(5, 0);
                    break;
                default:
                    return new Tuple<int, int>(0, 0);
                    break;
            }
        }
    }
}
