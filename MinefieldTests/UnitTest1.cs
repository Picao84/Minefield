using Minefield;

namespace MinefieldTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(ConsoleKey.UpArrow, 0, 0, 5)]
        [TestCase(ConsoleKey.LeftArrow, 0, 2, 5)]
        [TestCase(ConsoleKey.RightArrow, 3, 4, 5)]
        [TestCase(ConsoleKey.DownArrow, 3, 4, 5)]
        public void TestMove(ConsoleKey key, int currentX, int currentY, int axisSize)
        {
            var result = Utils.Move(key, currentX, currentY, axisSize);

            Assert.True(result[0] >= 0 && result[1] >= 0 && result[0] < axisSize && result[1] < axisSize);
        }

        [Test]
        [TestCase(new int[] { 4, 0 })]
        public void TestLetterMapping(int[] currentPosition)
        {
            Assert.True(currentPosition[0] < Constants.LetterMapping.Length);
        }

        [Test, Timeout(2000)]
        [TestCase(10, 10, 10, new int[] { 0, 0 })]
        [TestCase(5, 5, 10, new int[] { 0, 0 })]
        public void TestSetMines(int boardXLenght, int boardYLenght, int minesToSet, int[] currentPosition)
        {
            var board = new bool[boardXLenght, boardYLenght];

            Utils.SetUpMines(board, minesToSet, currentPosition);

            Assert.True(board.Cast<bool>().Count(x => x == true) == minesToSet);
        }
    }
}