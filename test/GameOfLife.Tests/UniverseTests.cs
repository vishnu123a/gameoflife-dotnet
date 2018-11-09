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
        public void GivenALiveCell_WhenACellHas2Or3LiveNeighbours_TheCellLives()
        {
        }

        [Test]
        public void GivenALiveCell_WhenACellHasMoreThan3LiveNeighbours_TheCellDies()
        {
        }

        [Test]
        public void GivenADeadCell_WhenACellHasExactly3LiveNeighbours_TheCellLives()
        {
        }
    }
}
