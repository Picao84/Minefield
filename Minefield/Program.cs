// See https://aka.ms/new-console-template for more information

using Minefield;

const int MAX_LIVES = 3;
const float MINE_PERCENTAGE = 0.33f;
int AxisSize = 0;

int[] currentPosition = { AxisSize / 2, 0 };

int currentLives = MAX_LIVES;

bool[,] board = new bool[AxisSize,AxisSize];

/* Main Thread begins here */

Console.WriteLine("What is the board Axis Size?");

while (AxisSize <= 0)
{
    var answer = Console.ReadLine();
    var valid = int.TryParse(answer, out AxisSize);

    if (!valid)
    {
        Console.WriteLine("Invalid value");
    }
    else
    {
        board = new bool[AxisSize, AxisSize];
        currentPosition[0] = AxisSize / 2;
    }
}

await Utils.SetUpMines(board, (int)(board.Length * MINE_PERCENTAGE), currentPosition);

Utils.DisplayUpdate(currentPosition, currentLives);

while(currentLives > 0 && currentPosition[1] < AxisSize - 1)
{
    var key = Console.ReadKey();
    var newPositon = Utils.Move(key.Key, currentPosition[0], currentPosition[1], AxisSize);

    if (newPositon[0] != currentPosition[0] || newPositon[1] != currentPosition[1])
    {
        currentPosition[0] = newPositon[0];
        currentPosition[1] = newPositon[1];

        if (Utils.CheckMines(board, currentPosition))
        {
            Console.WriteLine("You hit a mine!");
            currentLives--;
        }

        Utils.DisplayUpdate(currentPosition, currentLives);
    }
}

if(currentLives == 0)
{
    Console.WriteLine("Game Over!");
}
else
{
    Console.WriteLine("You Won!");
}

/* Main Thread ends here */
