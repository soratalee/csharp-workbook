using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[] position = { 0, 0 };

            Game newGame = new Game();


        }
    }

    public class Checker
    {
        public string Symbol { get; set; }
        public int[] Position { get; set; }
        public string Color { get; set; }

        public Checker(string color, int[] position)
        {
            this.Color = color;
            this.Position = position;

            int openCircleID = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
            string openCircle = char.ConvertFromUtf32(openCircleID);

            int closedCircleID = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
            string closedCircle = char.ConvertFromUtf32(closedCircleID);


            if (this.Color == "White")
            {
                Symbol = closedCircle;
            }
            else if (this.Color == "Black")
            {
                Symbol = openCircle;
            }
        }
    }

    public class Board
    {
        //multi-dimensional array
        public string[,] Grid { get; set; }
        public List<Checker> Checkers { get; set; }

        public Board()
        {
            Checkers = new List<Checker>();
        }


        public void GenerateCheckers()
        //Instantiate all checkers. They are in list
        {
            for (int i = 1; i < 8; i += 2)
            {
                Checker Check = new Checker("White", new int[] { 0, i });
                Checkers.Add(Check);
            }
            for (int i = 0; i < 8; i += 2)
            {
                Checker Check = new Checker("White", new int[] { 1, i });
                Checkers.Add(Check);
            }
            for (int i = 1; i < 8; i += 2)
            {
                Checker Check = new Checker("White", new int[] { 2, i });
                Checkers.Add(Check);
            }

            for (int i = 0; i < 8; i += 2)
            {
                Checker Check = new Checker("Black", new int[] { 5, i });
                Checkers.Add(Check);
            }
            for (int i = 1; i < 8; i += 2)
            {
                Checker Check = new Checker("Black", new int[] { 6, i });
                Checkers.Add(Check);
            }
            for (int i = 0; i < 8; i += 2)
            {
                Checker Check = new Checker("Black", new int[] { 7, i });
                Checkers.Add(Check);
            }
        }

        //This is used in the DrawBoard method
        // public void PlaceCheckers()
        // {
        //     for (var i = 0; i < Checkers.Count; i++)
        //     {
        //         int[] position = Checkers[i].Position;
        //         Grid[position[0], position[1]] = Checkers[i].Symbol;
        //     }
        // }

        public void DrawBoard()
        {
            string[,] grid = new string[8, 8];

            Console.WriteLine("\t0\t1\t2\t3\t4\t5\t6\t7\t");

            //Same thing as place checkers
            foreach (Checker Check in Checkers)
            {
                int x = Check.Position[0];
                int y = Check.Position[1];
                grid[x, y] = Check.Symbol;
            }
            for (int i = 0; i < 8; i++)
            {
                Console.Write("{0}\t", i);
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("{0}\t", grid[i, j]);
                }
                Console.WriteLine("\n");
            }
        }

        public Checker SelectChecker(int row, int column)
        {
            return Checkers.Find(x => x.Position.SequenceEqual(new List<int> { row, column }));
        }

        public void MoveChecker(int row, int column, string color)
        {
            Checker Check = new Checker(color, new int[] { row, column });
            Checkers.Add(Check);
        }

        public void moveChecker(int row, int column)
        {
            Checkers.Remove(SelectChecker(row, column));
        }

        public bool CheckForWin()
        {
            return Checkers.All(x => x.Color == "white") || !Checkers.Exists(x => x.Color == "white");
        }
    }

    class Game
    {
        public Game()
        {
            Board newBoard = new Board();
            newBoard.GenerateCheckers();
            newBoard.DrawBoard();
            bool endGame = false;
            string moveChecker;
            bool moveCheckerBool = false;
            string color = "Black";

            while (endGame != true)
            {
                string pickup;
                string placement;
                bool proceed = true;


                Console.WriteLine("Enter 'Y' to move a checker. Enter 'N' to remove a checker.");
                moveChecker = Console.ReadLine();

                if (moveChecker == "Y")
                {
                    moveCheckerBool = true;
                }
                else if (moveChecker == "N")
                {
                    moveCheckerBool = false;
                }



                if (moveChecker == "Y" || moveChecker == "N")
                {
                    if (moveCheckerBool == true)
                    {
                        Console.WriteLine("Enter Pickup Row and Column (ex. 1,2):");
                    }
                    else if (moveCheckerBool == false)
                    {
                        Console.WriteLine("Enter Row and Column to remove (ex. 1,2):");
                    }

                    pickup = Console.ReadLine();
                    int[] pickupArray = new int[2];
                    try
                    {
                        pickupArray = Array.ConvertAll(pickup.Split(','), int.Parse);
                    }
                    catch
                    {
                        Console.WriteLine("Please follow the format of the x value followed by a comma and a y value (ex. 0,1)!");
                        proceed = false;
                    }

                    if (pickupArray[0] < 8 && pickupArray[1] < 8 && pickupArray[0] > -1 && pickupArray[1] > -1)
                    {
                        if (proceed == true)
                        {
                            int pickUpRow = pickupArray[0];
                            int pickUpColumn = pickupArray[1];

                            Checker newChecker = newBoard.SelectChecker(pickUpRow, pickUpColumn);
                            if (newChecker == null)
                            {
                                Console.WriteLine("You have selected a checker piece that does not exist! Please enter a correct location of checker.");
                            }
                            else
                            {
                                newBoard.moveChecker(pickUpRow, pickUpColumn);

                                if (moveCheckerBool == true)
                                {
                                    Console.WriteLine("Enter Placement Row and Column (ex. 1,2):");
                                    placement = Console.ReadLine();
                                    int[] placementArray = new int[2];

                                    try
                                    {
                                        placementArray = Array.ConvertAll(placement.Split(','), int.Parse);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please follow the format of the x value followed by a comma and a y value (ex. 0,1)!");
                                    }

                                    int placementRow = placementArray[0];
                                    int placementColumn = placementArray[1];


                                    newBoard.MoveChecker(placementRow, placementColumn, color);
                                }
                                try
                                {
                                    newBoard.DrawBoard();
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    Console.WriteLine("An index was out of range! Please enter integers 0-7.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("The numbers are out of index. Please enter in numbers 0-7 only!");
                        }
                    }
                }

                else
                {
                    Console.WriteLine("Please enter 'Y' or 'N'!");
                }
            }
        }
    }
}