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
        public void manageKeyIsDownShouldGoUp()
        {

            KeyEventArgs e = new KeyEventArgs(Keys.Up);

            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.goUp);
            Assert.True(myPlayer.moving);
        }

        [Fact]
        public void manageKeyIsDownShouldGoDown()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Down);

            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.goDown);
            Assert.True(myPlayer.moving);
        }

        [Fact]
        public void manageKeyIsDownShouldGoLeft()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Left);

            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.goLeft);
            Assert.True(myPlayer.moving);
        }

        [Fact]
        public void manageKeyIsDownShouldGoRight()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Right);

            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.goRight);
            Assert.True(myPlayer.moving);
        }

        [Fact]
        public void manageKeyIsDownShouldShoot()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Space);

            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.shooting);
        }

        [Fact]
        public void manageKeyIsDownShouldNotGoUp()
        {

            KeyEventArgs e = new KeyEventArgs(Keys.Up);

            keyBoardInput.manageKeyIsUp(e, ref myPlayer);

            Assert.False(myPlayer.goUp);
            Assert.False(myPlayer.moving);
        }

        [Fact]
        public void manageKeyIsDownShouldNotGoDown()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Down);

            keyBoardInput.manageKeyIsUp(e, ref myPlayer);

            Assert.False(myPlayer.goDown);
            Assert.False(myPlayer.moving);
        }

        [Fact]
        public void manageKeyIsDownShouldNotGoLeft()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Left);

            keyBoardInput.manageKeyIsUp(e, ref myPlayer);

            Assert.False(myPlayer.goLeft);
            Assert.False(myPlayer.moving);
        }

        [Fact]
        public void manageKeyIsDownShouldNotGoRight()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Right);

            keyBoardInput.manageKeyIsUp(e, ref myPlayer);

            Assert.False(myPlayer.goRight);
            Assert.False(myPlayer.moving);
        }

        [Fact]
        public void manageKeyIsDownShouldNotShoot()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Space);

            keyBoardInput.manageKeyIsUp(e, ref myPlayer);

            Assert.False(myPlayer.shooting);
        }

    }
}
