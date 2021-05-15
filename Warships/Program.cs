using System;
using System.Linq;

namespace Warships
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] field = new char[n][];
            int[] attacks = Array.ConvertAll(Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);

            int destroyedShips = 0;

            //  < first player.
            //  > second player

            for (int i = 0; i < n; i++)
            {
                field[i] = Console.ReadLine().Where(ch => !char.IsWhiteSpace(ch)).ToArray();
            }

            int playerOneShips = CountShips(field, '<');
            int playerTwoShips = CountShips(field, '>');

            for (int i = 0; i < attacks.Length - 1; i += 2)
            {
                try
                {
                    int row = attacks[i];
                    int col = attacks[i + 1];

                    if (field[row][col] == '#')
                    {
                        Explode(field, row, col);
                        
                        int buf = playerOneShips;
                        playerOneShips = CountShips(field, '<');
                        destroyedShips += buf - playerOneShips;
                        
                        buf = playerTwoShips;
                        playerTwoShips = CountShips(field, '>');
                        destroyedShips += buf - playerTwoShips;
                    }
                    else if (field[row][col] == '>')
                    {
                        field[row][col] = 'X';
                        playerTwoShips--;
                        destroyedShips++;
                    }
                    else if (field[row][col] == '<')
                    {
                        field[row][col] = 'X';
                        playerOneShips--;
                        destroyedShips++;
                    }
                }
                catch (Exception)
                {
                    continue;
                }


                if (playerOneShips == 0 || playerTwoShips == 0)
                {
                    break;
                }
            }

            PrintOutput(playerOneShips, playerTwoShips, destroyedShips);
        }

        private static void PrintOutput(int playerOneShips, int playerTwoShips, int destroyedShips)
        {
            if (playerOneShips == 0)
            {
                PrintWinMessage("Two", destroyedShips);
            }
            else if (playerTwoShips == 0)
            {
                PrintWinMessage("One", destroyedShips);
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
        }

        private static void PrintWinMessage(string player, int destroyedShips)
        {
            Console.WriteLine($"Player {player} has won the game! {destroyedShips} ships have been sunk in the battle.");
        }

        private static void Explode(char[][] field, int row, int col)
        {
            int n = field.Length;

            if (row - 1 >= 0 && row + 1 < n && col - 1 >= 0 && col + 1 < n)
            {
                field[row - 1][col] = 'X';
                field[row - 1][col + 1] = 'X';
                field[row][col + 1] = 'X';
                field[row + 1][col + 1] = 'X';
                field[row + 1][col] = 'X';
                field[row + 1][col - 1] = 'X';
                field[row][col - 1] = 'X';
                field[row - 1][col - 1] = 'X';
            }
            else if (row - 1 < 0 && col - 1 >= 0 && col + 1 < n)
            {
                field[row][col + 1] = 'X';
                field[row + 1][col + 1] = 'X';
                field[row + 1][col] = 'X';
                field[row + 1][col - 1] = 'X';
                field[row][col - 1] = 'X';
            }
            else if (row + 1 == n && col - 1 >= 0 && col + 1 < n)
            {
                field[row][col - 1] = 'X';
                field[row - 1][col - 1] = 'X';
                field[row - 1][col] = 'X';
                field[row - 1][col + 1] = 'X';
                field[row][col + 1] = 'X';
            }
            else if (col - 1 < 0 && row - 1 >= 0 && row + 1 < n)
            {
                field[row - 1][col] = 'X';
                field[row - 1][col + 1] = 'X';
                field[row][col + 1] = 'X';
                field[row + 1][col + 1] = 'X';
                field[row + 1][col] = 'X';
            }
            else if (col + 1 == n && row - 1 >= 0 && row + 1 < n)
            {
                field[row + 1][col] = 'X';
                field[row + 1][col - 1] = 'X';
                field[row][col - 1] = 'X';
                field[row - 1][col - 1] = 'X';
                field[row - 1][col] = 'X';
            }
            else if (row == 0 && col == 0)
            {
                field[row][col + 1] = 'X';
                field[row + 1][col + 1] = 'X';
                field[row + 1][col] = 'X';
            }
            else if (row == 0 && col == n - 1)
            {
                field[row + 1][col] = 'X';
                field[row + 1][col - 1] = 'X';
                field[row][col - 1] = 'X';
            }
            else if (row == n - 1 && col == n - 1)
            {
                field[row][col - 1] = 'X';
                field[row - 1][col - 1] = 'X';
                field[row - 1][col] = 'X';
            }
            else if (row == n - 1 && col == 0)
            {
                field[row - 1][col] = 'X';
                field[row - 1][col + 1] = 'X';
                field[row][col + 1] = 'X';
            }
        }

        private static int CountShips(char[][] field, char ship)
        {
            int count = 0;
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field.Length; j++)
                {
                    if (field[i][j] == ship)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
