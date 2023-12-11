using Berzerk.game_objects;
using Berzerk.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Berzerk.tests.services
{
    public class KeyBoardInputTests
    {
        private Form form;
        private Player myPlayer;
        private IPictureBoxManager playerPictureBoxManager;
        private KeyBoardInput keyBoardInput;
        public KeyBoardInputTests()
        {
            form = new Form();
            playerPictureBoxManager = new PlayerPictureBoxManager(form, 100, 100);
            myPlayer = new Player(Player.Direction.Left, 100, 100, playerPictureBoxManager);
            keyBoardInput = new KeyBoardInput();
        }
        [Fact]
        public void TestManageKeyIsDown_UpPressed_PlayerGoesUp()
        {

            KeyEventArgs e = new KeyEventArgs(Keys.Up);

            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.goUp);
            Assert.True(myPlayer.moving);
        }

        [Fact]
        public void TestManageKeyIsDown_DownPressed_PlayerGoesDown()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Down);

            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.goDown);
            Assert.True(myPlayer.moving);
        }

        [Fact]
        public void TestManageKeyIsDown_LeftPressed_PlayerGoesLeft()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Left);

            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.goLeft);
            Assert.True(myPlayer.moving);
        }

        [Fact]
        public void TestManageKeyIsDown_RightPressed_PlayerGoesRight()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Right);

            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.goRight);
            Assert.True(myPlayer.moving);
        }

        [Fact]
        public void TestManageKeyIsDown_SpacePressed_PlayerShoots()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Space);

            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.shooting);
        }

        [Fact]
        public void TestManageKeyIsDown_SpacePressedWhenAlreadyShooting_PlayerDoesNotShootAgain()
        {
            myPlayer.shooting = true;

            KeyEventArgs e = new KeyEventArgs(Keys.Space);

            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.shooting);
        }

    }
}
