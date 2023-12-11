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
        public void ManageKeyIsDownShouldGoUp()
        {

            KeyEventArgs e = new KeyEventArgs(Keys.Up);

            keyBoardInput.ManageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.GoUp);
            Assert.True(myPlayer.Moving);
        }

        [Fact]
        public void ManageKeyIsDownShouldGoDown()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Down);

            keyBoardInput.ManageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.GoDown);
            Assert.True(myPlayer.Moving);
        }

        [Fact]
        public void ManageKeyIsDownShouldGoLeft()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Left);

            keyBoardInput.ManageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.GoLeft);
            Assert.True(myPlayer.Moving);
        }

        [Fact]
        public void ManageKeyIsDownShouldGoRight()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Right);

            keyBoardInput.ManageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.GoRight);
            Assert.True(myPlayer.Moving);
        }

        [Fact]
        public void ManageKeyIsDownShouldShoot()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Space);

            keyBoardInput.ManageKeyIsDown(e, ref myPlayer);

            Assert.True(myPlayer.Shooting);
        }

        [Fact]
        public void ManageKeyIsDownShouldNotGoUp()
        {

            KeyEventArgs e = new KeyEventArgs(Keys.Up);

            keyBoardInput.ManageKeyIsUp(e, ref myPlayer);

            Assert.False(myPlayer.GoUp);
            Assert.False(myPlayer.Moving);
        }

        [Fact]
        public void ManageKeyIsDownShouldNotGoDown()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Down);

            keyBoardInput.ManageKeyIsUp(e, ref myPlayer);

            Assert.False(myPlayer.GoDown);
            Assert.False(myPlayer.Moving);
        }

        [Fact]
        public void ManageKeyIsDownShouldNotGoLeft()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Left);

            keyBoardInput.ManageKeyIsUp(e, ref myPlayer);

            Assert.False(myPlayer.GoLeft);
            Assert.False(myPlayer.Moving);
        }

        [Fact]
        public void ManageKeyIsDownShouldNotGoRight()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Right);

            keyBoardInput.ManageKeyIsUp(e, ref myPlayer);

            Assert.False(myPlayer.GoRight);
            Assert.False(myPlayer.Moving);
        }

        [Fact]
        public void ManageKeyIsDownShouldNotShoot()
        {
            KeyEventArgs e = new KeyEventArgs(Keys.Space);

            keyBoardInput.ManageKeyIsUp(e, ref myPlayer);

            Assert.False(myPlayer.Shooting);
        }

    }
}
