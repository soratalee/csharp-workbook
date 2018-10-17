using System;

namespace TicTacToe
{
    class Program
    {
        public static string playerTurn = "X";

        public static string[][] board = new string[][]
        {
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "}
        };

        public static void Main()
        {
            do
            {
                DrawBoard();
                GetInput();

            } while (!CheckForWin() && !CheckForTie());

            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }

        public static void GetInput()
        {
            //Ternary Operator for taking turns
            playerTurn = (playerTurn == "X") ? "O" : "X";

            Console.WriteLine("Player " + playerTurn);
            Console.WriteLine("Enter Row:");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Column:");
            int column = int.Parse(Console.ReadLine());
            PlaceMark(row, column);
        }

        public static void PlaceMark(int row, int column)
        {
            // your code goes here
            if (playerTurn == "X" && board[row][column] == " ")
            {
                board[row][column] = "X";
                
            }
            else if (playerTurn == "O" && board[row][column] == " ") 
            {
                board[row][column] = "O";

            }
            else 
            {
                Console.WriteLine("Place is already taken! Place your marker somewhere else.");
                if (playerTurn == "X")
                {
                    playerTurn = "O";
                }
                else playerTurn = "X";
            }
        }

        public static bool CheckForWin()
        {
            // your code goes here
            if (HorizontalWin() || VerticalWin() || DiagonalWin())
            {
                Console.WriteLine("Player " + playerTurn + " Won!");
                DrawBoard();
                return true;
            }
            else return false;
        }

        public static bool CheckForTie()
        {
            // your code goes here

            if (
            (
                (board[0][0] != " " && board[0][1] != " " && board[0][2] != " ") &&
                (board[1][0] != " " && board[1][1] != " " && board[1][2] != " ") &&
                (board[2][0] != " " && board[2][1] != " " && board[2][2] != " ")
            )
            && !HorizontalWin() && !VerticalWin() && !DiagonalWin()
            )
            {
                Console.WriteLine("You have tied!");
                DrawBoard();
                return true;
            }
            else return false;
        }

        public static bool HorizontalWin()
        {
            // your code goes here
            return
            (
            (board[0][0] == playerTurn && board[0][1] == playerTurn && board[0][2] == playerTurn) ||
            (board[1][0] == playerTurn && board[1][1] == playerTurn && board[1][2] == playerTurn) ||
            (board[2][0] == playerTurn && board[2][1] == playerTurn && board[2][2] == playerTurn)
            );
        }

        public static bool VerticalWin()
        {
            // your code goes here

            return
            (
            (board[0][0] == playerTurn && board[1][0] == playerTurn && board[2][0] == playerTurn) ||
            (board[0][1] == playerTurn && board[1][1] == playerTurn && board[2][1] == playerTurn) ||
            (board[0][2] == playerTurn && board[1][2] == playerTurn && board[2][2] == playerTurn)
            );
        }

        public static bool DiagonalWin()
        {
            // your code goes here

            return
            (
            (board[0][0] == playerTurn && board[1][1] == playerTurn && board[2][2] == playerTurn) ||
            (board[0][2] == playerTurn && board[1][1] == playerTurn && board[2][0] == playerTurn)
            );
        }

        public static void DrawBoard()
        {
            Console.WriteLine("  0 1 2");
            Console.WriteLine("0 " + String.Join("|", board[0]));
            Console.WriteLine("  -----");
            Console.WriteLine("1 " + String.Join("|", board[1]));
            Console.WriteLine("  -----");
            Console.WriteLine("2 " + String.Join("|", board[2]));
        }
    }
}
