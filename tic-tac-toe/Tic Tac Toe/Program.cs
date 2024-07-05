namespace Tictactoe
{
    class Tictactoe
    {
        private const int BoardSize = 9;
        private const char Player1Marker = 'X';
        private const char Player2Marker = 'O';
        private static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static int currentPlayer = 1;
        private static int choice;
        private static int gameStatus = 0; // Status 0 = game is playing, 1 = win, 2 = draw

        static void Main()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1: X and player 2: O");
                Console.WriteLine(currentPlayer % 2 == 0 ? "Player 2's turn" : "Player 1's turn");

                DispalyBoard();

                choice = GetValidChoice();
                MarkChoice();

                gameStatus = CheckWin();
            } while (gameStatus == 0);

            Console.Clear();
            DispalyBoard();
            Console.WriteLine();
            DisplayResult();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        private static void DispalyBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);
            Console.WriteLine("     |     |      ");
        }

        private static int GetValidChoice()
        {
            int choice;
            while (true)
            {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9 && board[choice] != Player1Marker && board[choice] != Player2Marker)
                {
                    return choice;
                }
                Console.WriteLine("Invalid input. Please enter a valid choice (1-9) that is not already marked.");
            }
        }

        private static void MarkChoice()
        {
            board[choice] = currentPlayer % 2 == 0 ? Player2Marker : Player1Marker;
            currentPlayer++;
        }

        private static int CheckWin()
        {
            if (IsWinningCondition())
            {
                return 1;
            }
            if (IsBoardFull())
            {
                return -1;
            }

            return 0;
        }

        private static bool IsWinningCondition()
        {
            int[,] windConditions = new int[,]{
                {1,2,3}, {4,5,6}, {7,8,9},
                {1,4,7}, {2,5,8}, {3,6,9},
                {1,5,9}, {3,5,7}
            };

            for (int i = 0; i < windConditions.GetLength(0); i++)
            {
                if (board[windConditions[i, 0]] == board[windConditions[i, 1]] && board[windConditions[i, 1]] == board[windConditions[i, 2]])
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsBoardFull()
        {
            for (int i = 1; i <= BoardSize; i++)
            {
                if (board[i] != Player1Marker && board[i] != Player2Marker)
                {
                    return false;
                }
            }
            return true;
        }

        private static void DisplayResult()
        {
            if (gameStatus == 1)
            {
                Console.WriteLine($"Player {(currentPlayer % 2) + 1} won");
            }
            else
            {
                Console.WriteLine("The game is a draw!");
            }
        }
    }

}
