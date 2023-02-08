using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield
{
    public static class Utils
    {
        public static int[] Move(ConsoleKey key, int currentX, int currentY, int axisSize)
        {
            int[] newPosition = { currentX, currentY };

            switch (key)
            {
                case ConsoleKey.UpArrow:

                    if (currentY > 0)
                        newPosition[1]--;

                    break;

                case ConsoleKey.LeftArrow:

                    if (currentX > 0)
                        newPosition[0]--;

                    break;

                case ConsoleKey.RightArrow:

                    if (currentX < axisSize - 1)
                        newPosition[0]++;

                    break;

                case ConsoleKey.DownArrow:

                    if (currentY < axisSize - 1)
                        newPosition[1]++;

                    break;

                default:

                    break;

            }

            return newPosition;
        }

        public static Task SetUpMines(bool[,] board, int minesToSet, int[] currentPosition)
        {
            Random randGenerator = new Random();

            while (minesToSet > 0)
            {
                var randX = randGenerator.Next(board.GetLength(0) - 1);
                var randY = randGenerator.Next(board.GetLength(1) - 1);

                if (!board[randX, randY] && randX != currentPosition[0] && randY != currentPosition[1])
                {
                    board[randX, randY] = true;
                    minesToSet--;
                }
            }

            return Task.CompletedTask;
        }

        public static bool CheckMines(bool[,] board, int[] currentPosition)
        {
            return board[currentPosition[0], currentPosition[1]];
        }

        public static void DisplayUpdate(int[] currentPosition, int currentLives)
        {
            Console.WriteLine($"Current position: {Constants.LetterMapping[currentPosition[0]]}{currentPosition[1]}");
            Console.WriteLine($"Current Lives: {currentLives}");
        }
    }
}
