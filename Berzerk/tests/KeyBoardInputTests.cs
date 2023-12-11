using Berzerk.game_objects;
using Berzerk.services;
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

            Assert.True(myPlayer.GoUp);
            Assert.True(myPlayer.Moving);
        }

        [Fact]
        public void manageKeyIsDownShouldGoDown()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Down);

            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.GoDown);
            Assert.True(myPlayer.Moving);
        }

        [Fact]
        public void manageKeyIsDownShouldGoLeft()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Left);

            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.GoLeft);
            Assert.True(myPlayer.Moving);
        }

        [Fact]
        public void manageKeyIsDownShouldGoRight()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Right);

            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.GoRight);
            Assert.True(myPlayer.Moving);
        }

        [Fact]
        public void manageKeyIsDownShouldShoot()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Space);

            keyBoardInput.manageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.Shooting);
        }

        [Fact]
        public void manageKeyIsDownShouldNotGoUp()
        {

            KeyEventArgs e = new KeyEventArgs(Keys.Up);

            keyBoardInput.manageKeyIsUp(e, ref myPlayer);

            Assert.False(myPlayer.GoUp);
            Assert.False(myPlayer.Moving);
        }

        [Fact]
        public void manageKeyIsDownShouldNotGoDown()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Down);

            keyBoardInput.manageKeyIsUp(e, ref myPlayer);

            Assert.False(myPlayer.GoDown);
            Assert.False(myPlayer.Moving);
        }

        [Fact]
        public void manageKeyIsDownShouldNotGoLeft()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Left);

            keyBoardInput.manageKeyIsUp(e, ref myPlayer);

            Assert.False(myPlayer.GoLeft);
            Assert.False(myPlayer.Moving);
        }

        [Fact]
        public void manageKeyIsDownShouldNotGoRight()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Right);

            keyBoardInput.manageKeyIsUp(e, ref myPlayer);

            Assert.False(myPlayer.GoRight);
            Assert.False(myPlayer.Moving);
        }

        [Fact]
        public void manageKeyIsDownShouldNotShoot()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Space);

            keyBoardInput.manageKeyIsUp(e, ref myPlayer);

            Assert.False(myPlayer.Shooting);
        }

    }
}
