int[,] board = new int[3, 3];
int firstPlayer = 1;
int secondPlayer = 2;
int currentPlayer = firstPlayer;
int moves = 0;

while (true)
{
    DrawBoard(board);

    Console.WriteLine($"Player {currentPlayer}, enter a number from 1 to 9:");

    int move = int.Parse(Console.ReadLine());

    if (move < 1 || move > 9)
    {
        Console.WriteLine("Invalid move! Enter a number from 1 to 9.");
        Thread.Sleep(1500);
        continue;
    }

    int column = (move - 1) % 3;
    int row = (move - 1) / 3;

    if (board[column, row] != 0)
    {
        Console.WriteLine("Board cell not empty!");
        Thread.Sleep(1500);
        continue;
    }

    board[column, row] = currentPlayer;
    moves++;

    if (CheckWins(board, currentPlayer))
    {
        DrawBoard(board);
        Console.WriteLine($"Player {currentPlayer} wins!");
        break;
    }

    if (moves == 9)
    {
        DrawBoard(board);
        Console.WriteLine("It's a draw!");
        break;
    }

    currentPlayer = currentPlayer == firstPlayer ? secondPlayer : firstPlayer;
}

static void DrawBoard(int[,] board)
{
    Console.Clear();
    Console.WriteLine("-------------");
    for (int row = 0; row < board.GetLength(1); row++)
    {
        Console.Write("| ");
        for (int column = 0; column < board.GetLength(0); column++)
        {
            if (board[column, row] == 0)
            {
                Console.Write("  | ");
            }
            else if (board[column, row] == 1)
            {
                Console.Write("X | ");
            }
            else if (board[column, row] == 2)
            {
                Console.Write("O | ");
            }
        }
        Console.WriteLine();
        Console.WriteLine("-------------");
    }
}

static bool CheckWins(int[,] board, int player)
{
    // Check rows and columns for a win
    for (int i = 0; i < 3; i++)
    {
        if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
            return true;

        if (board[0, i] == player && board[1, i] == player && board[2, i] == player)
            return true;
    }

    // Check diagonals for a win
    if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
        return true;

    if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
        return true;

    return false;
}