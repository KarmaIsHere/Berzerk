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
        protected int _bulletBoxSpeed;
        protected PictureBox _bulletBox;
        protected Direction _viewDirection;


        public Bullet(int bulletSpeed, Player myPlayer, Form form)
        {
            this._bulletBoxSpeed = bulletSpeed;

            this._bulletBox = new System.Windows.Forms.PictureBox();

            this._bulletBox.BackColor = System.Drawing.Color.Yellow;
            this._bulletBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._bulletBox.Name = "bullet";
            this._bulletBox.Tag = "bulletEntity";
            this._bulletBox.Size = new System.Drawing.Size(20, 5);
            this._bulletBox.TabIndex = 1;
            this._bulletBox.TabStop = false;
            this._bulletBox.Location = new System.Drawing.Point(0, 0);

            form.Controls.Add(this._bulletBox);
        }

        public void setDirection(Direction direction)
        {
            this._viewDirection = direction;
            if (direction == Direction.Up || direction == Direction.Down) makeBulletVertical();
        }

        public Direction getDirection()
        {
            return this._viewDirection;
        }
        public void spawnBullet(Tuple<int, int> coordinates, Player myPlayer)
        {
            this._bulletBox.Top = myPlayer.x + coordinates.Item1;
            this._bulletBox.Left = myPlayer.y + coordinates.Item2;
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
                    return new Tuple<int, int>(0, -_bulletBoxSpeed);
                    break;
                case Direction.Down:
                    return new Tuple<int, int>(0, _bulletBoxSpeed);
                    break;
                case Direction.Left:
                    return new Tuple<int, int>(-_bulletBoxSpeed, 0);
                    break;
                case Direction.Right:
                    return new Tuple<int, int>(_bulletBoxSpeed, 0);
                    break;
                default:
                    return new Tuple<int, int>(0, 0);
                    break;
            }
        }

        public void makeBulletVertical()
        {
            this._bulletBox.Size = new System.Drawing.Size(5, 20);
        }
    }
}
