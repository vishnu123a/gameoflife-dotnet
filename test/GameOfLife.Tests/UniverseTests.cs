namespace GameOfLife.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class UniverseTests
    {
        [Test]
        public void GivenALiveCell_WhenACellHasFewerThan2LiveNeighbours_TheCellDies()
        {
            var seed = new[,] {{0, 1, 0}, {0, 1, 0}, {0, 0, 0}};
            var universe = new Universe(seed);

            universe.Tick();

            Assert.AreEqual(0, universe.Cells[0, 1]);
            Assert.AreEqual(0, universe.Cells[1, 1]);
        }

        [Test]
        public void GivenALiveCell_WhenACellHas2LiveNeighbours_TheCellLives()
        {
            var seed = new[,] {{0, 1, 0}, {0, 1, 0}, {0, 1, 0}};
            var universe = new Universe(seed);

            universe.Tick();

            Assert.AreEqual(1, universe.Cells[1, 1]);
        }

        [Test]
        public void GivenALiveCell_WhenACellHas3LiveNeighbours_TheCellLives()
        {
            var seed = new[,] {{0, 1, 0}, {1, 1, 0}, {0, 1, 0}};
            var universe = new Universe(seed);

            universe.Tick();

            Assert.AreEqual(1, universe.Cells[1, 1]);
        }

        [Test]
        public void GivenALiveCell_WhenACellHasMoreThan3LiveNeighbours_TheCellDies()
        {
            var seed = new[,] {{0, 1, 0}, {1, 1, 1}, {0, 1, 0}};
            var universe = new Universe(seed);

            universe.Tick();

            Assert.AreEqual(0, universe.Cells[1, 1]);
        }

        [Test]
        public void GivenADeadCell_WhenACellHasExactly3LiveNeighbours_TheCellLives()
        {
            var seed = new[,] {{0, 1, 0}, {1, 0, 0}, {0, 1, 0}};
            var universe = new Universe(seed);

            universe.Tick();

            Assert.AreEqual(1, universe.Cells[1, 1]);
        }
    }
}
