﻿using Berzerk.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Berzerk.model
{
    public class Player : Form
    {
        public enum Direction { Up, Down, Left, Right };

        private bool _goUp;
        private bool _goDown;
        private bool _goLeft;
        private bool _goRight;
        private bool _shooting;
        private bool _moving;

        private Direction _viewDirection;
        private int _playerSpeed;
        private PictureBox _player;
        private int _width;
        private int _height;
        private int _ammo;
        private int _maxAmmoSize;

        public bool goUp { get => _goUp; set => _goUp = value; }
        public bool goDown { get => _goDown; set => _goDown = value; }
        public bool goLeft { get => _goLeft; set => _goLeft = value; }
        public bool goRight { get => _goRight; set => _goRight = value; }
        public bool shooting { get => _shooting; set => _shooting = value; }
        public bool moving { get => _moving; set => _moving = value; }  
        public int x { get => _player.Top; set => _player.Top = value; }
        public int y { get => _player.Left; set => _player.Left = value; }
        public int width { get => _width; set => _width = value;}
        public int height { get => _height; set => _height = value;}
        public int ammo { get => _ammo; set => _ammo = value; } 
        public int maxAmmoSize { get => _maxAmmoSize; set => _maxAmmoSize = value; }

        public Player(bool goUp, bool goDown, bool goLeft, bool goRight, bool shooting, bool moving, Direction viewDirection, int x, int y, int playerSpeed, Form form)
        {
            _goUp = goUp;
            _goDown = goDown;
            _goLeft = goLeft;
            _goRight = goRight;
            _shooting = shooting;
            _moving = moving;
            _viewDirection = viewDirection;
            _playerSpeed = playerSpeed;
            _ammo = 1;
            _maxAmmoSize = 1;

            this._player = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._player)).BeginInit();
            // 
            // player
            // 
            this._player.Load(@"D:\Main\Gallery\code\Berzerk\Berzerk\Properties\images\player.png");
            //this._player.ImageLocation = @"C:\Users\ACER\Source\Repos\KarmaIsHere\Berzerk\Berzerk\Properties\images\player.png";
            this._player.Location = new System.Drawing.Point(x, y);
            this._player.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._player.Name = "player";
            this._player.Size = new System.Drawing.Size(18, 53);
            this._player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._player.TabIndex = 0;
            this._player.TabStop = false;
            //this._player.BackColor = Color.White;

            this.x = x;
            this.y = y;
            this._width = this._player.Width;
            this._height = this._player.Height;

            form.Controls.Add(this._player);
        }

        public void setDirection(Direction direction)
        {
            _viewDirection = direction;
        }

        public Direction getDirection()
        {
            return _viewDirection;
        }

        public void moveUp()
        {
            
            _player.Top -= _playerSpeed;
            setDirection(Player.Direction.Up);
        }

        public void moveDown()
        {
            _player.Top += _playerSpeed;
            setDirection(Player.Direction.Down);
        }

        public void moveLeft()
        {
            _player.Left -= _playerSpeed;
            setDirection(Player.Direction.Left);
        }

        public void moveRight()
        {
            _player.Left += _playerSpeed;
            setDirection(Player.Direction.Right);
        }

        internal void shoot()
        {
            _ammo -= 1;
        }

        internal void reload()
        {
            _ammo = maxAmmoSize;
        }
    }
}
