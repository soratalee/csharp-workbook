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
            int row = 0;
            int column = 0;
            //Try function in case of invalid input
            try
            {
                row = Convert.ToInt32((Console.ReadLine()));
                //Test for only 0, 1, or 2 inputs for Row
                if (test1(row))
                {
                    Console.WriteLine("Enter Column:");

                    column = Convert.ToInt32((Console.ReadLine()));
                    
                    //Test for only 0, 1, or 2 inputs for Column
                    if (test2(column))
                    {
                        //if Both test1 and test2 run through, PlaceMark will be set
                        PlaceMark(row, column);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement or Column! Please enter 0, 1, or 2 only.");
                        if (playerTurn == "X")
                        {
                            playerTurn = "O";
                        }
                        else playerTurn = "X";
                    }
                }
                else
                {
                    Console.WriteLine("Invalid placement for Row! Please enter 0, 1, or 2 only.");
                    if (playerTurn == "X")
                    {
                        playerTurn = "O";
                    }
                    else playerTurn = "X";
                }
            }
            //catch function to notify user of bad input
            catch
            {
                //resets the playerTurn
                if (playerTurn == "X")
                {
                    playerTurn = "O";
                }
                else playerTurn = "X";
                Console.WriteLine("Invalid placement! Please enter 0, 1, or 2 only.");
            }
        }
        public static void PlaceMark(int row, int column)
        {
            //If PlayerTurn is an X and the location is valid, set the PlaceMark
            if (playerTurn == "X" && board[row][column] == " ")
            {
                board[row][column] = "X";

            }
            //If PlayerTurn is an O and the location is valid, set the PlaceMark
            else if (playerTurn == "O" && board[row][column] == " ")
            {
                board[row][column] = "O";

            }
            else
            {
                //If PlaceMark is already taken, notify user and reset PlayerTurn
                Console.WriteLine("Place is already taken! Place your marker somewhere else.");
                if (playerTurn == "X")
                {
                    playerTurn = "O";
                } else {
                    playerTurn = "X";
                }
            }
        }

        public static bool CheckForWin()
        {
            // If player wins any direction
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
            //Check for tie. If all spaces are taken and there is no win condition met
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
            //Win Condition for Horizontal
            return
            (
            (board[0][0] == playerTurn && board[0][1] == playerTurn && board[0][2] == playerTurn) ||
            (board[1][0] == playerTurn && board[1][1] == playerTurn && board[1][2] == playerTurn) ||
            (board[2][0] == playerTurn && board[2][1] == playerTurn && board[2][2] == playerTurn)
            );
        }

        public static bool VerticalWin()
        {
            //Win Condition for Veritcal
            return
            (
            (board[0][0] == playerTurn && board[1][0] == playerTurn && board[2][0] == playerTurn) ||
            (board[0][1] == playerTurn && board[1][1] == playerTurn && board[2][1] == playerTurn) ||
            (board[0][2] == playerTurn && board[1][2] == playerTurn && board[2][2] == playerTurn)
            );
        }

        public static bool DiagonalWin()
        {
            //Win Condition for Diagonal
            return
            (
            (board[0][0] == playerTurn && board[1][1] == playerTurn && board[2][2] == playerTurn) ||
            (board[0][2] == playerTurn && board[1][1] == playerTurn && board[2][0] == playerTurn)
            );
        }

        public static void DrawBoard()
        {
            //Board visual display
            Console.WriteLine("  0 1 2");
            Console.WriteLine("0 " + String.Join("|", board[0]));
            Console.WriteLine("  -----");
            Console.WriteLine("1 " + String.Join("|", board[1]));
            Console.WriteLine("  -----");
            Console.WriteLine("2 " + String.Join("|", board[2]));
        }

        public static bool test1(int row)
        {
            //Test for valid Row number
            if (row == 0 || row == 1 || row == 2)
                return true;
            else return false;
        }
        public static bool test2(int column)
        {
            //Test for valid Column number
            if (column == 0 || column == 1 || column == 2)
                return true;
            else return false;
        }
    }
}