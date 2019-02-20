using System;
using System.Collections;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Instantiate new game
            Game newGame = new Game();

            //Instantiate new towers
            Tower A = new Tower("A", new Stack<Block>());
            Tower B = new Tower("B", new Stack<Block>());
            Tower C = new Tower("C", new Stack<Block>());

            //Initial Insert towers into dictionary
            newGame.towers.Add("A", A);
            newGame.towers.Add("B", B);
            newGame.towers.Add("C", C);

            //User input for how many disks
            Console.WriteLine("Enter in how many disks you want in the game (3 - 10):");

            int diskNumber = 0;

            const int maxRetries = 5;

            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    diskNumber = Convert.ToInt16(Console.ReadLine());
                    if (diskNumber < 3 || diskNumber > 10)
                    {
                        throw new ArgumentException("Please enter only numbers 3 through 10!");
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter an integer 3-10!");
                }
            }

            if (diskNumber < 3 || diskNumber > 10)
            {
                Console.WriteLine("You have entered an invalid number. Defaulting to three disks.");
                diskNumber = 3;
            }
            Console.WriteLine("You have chosen to play with {0} disks.", diskNumber);

            if (diskNumber >= 3)
            {
                Block one = new Block(1);
                A.blocks.Push(one);
                Block two = new Block(2);
                A.blocks.Push(two);
                Block three = new Block(3);
                A.blocks.Push(three);
            }
            if (diskNumber >= 4)
            {
                Block four = new Block(4);
                A.blocks.Push(four);
            }
            if (diskNumber >= 5)
            {
                Block five = new Block(5);
                A.blocks.Push(five);
            }
            if (diskNumber >= 6)
            {
                Block six = new Block(6);
                A.blocks.Push(six);
            }
            if (diskNumber >= 7)
            {
                Block seven = new Block(7);
                A.blocks.Push(seven);
            }
            if (diskNumber >= 8)
            {
                Block eight = new Block(8);
                A.blocks.Push(eight);
            }
            if (diskNumber >= 9)
            {
                Block nine = new Block(9);
                A.blocks.Push(nine);
            }
            if (diskNumber >= 10)
            {
                Block ten = new Block(10);
                A.blocks.Push(ten);
            }

            //Move pieces
            string consoleMoveFrom = "";
            string consoleMoveTo = "";

            int turnsPlayed = 0;
            //Game loop
            while (newGame.checkForWin(turnsPlayed) == false)
            {
                try
                {
                    Console.WriteLine("Enter in tower(A, B, or C) to move FROM:");
                    consoleMoveFrom = (Console.ReadLine().ToUpper());

                    Console.WriteLine("Enter in tower(A, B, or C) to move TO:");
                    consoleMoveTo = (Console.ReadLine().ToUpper());

                    if (newGame.isLegal(newGame.towers[consoleMoveFrom], newGame.towers[consoleMoveTo]))
                    {
                        newGame.movePiece(newGame.towers[consoleMoveFrom], newGame.towers[consoleMoveTo]);
                        turnsPlayed++;
                    }
                    else
                    {
                        Console.WriteLine("You have entered a wrong move. Please enter in a correct move sequence!");
                    }
                    //Draw Tower
                    newGame.printTowerKeys();
                }
                catch
                {
                    Console.WriteLine("You have entered an invalid Tower. Please enter values A, B, or C for tower.");
                }


            }

        }
    }
    public class Game
    {
        public Dictionary<string, Tower> towers = new Dictionary<string, Tower>();

        public void printTowerKeys()
        {
            foreach (KeyValuePair<string, Tower> tower in this.towers)
            {
                Console.WriteLine("Tower: " + tower.Key);
                foreach (Block block in tower.Value.blocks)
                {
                    Console.WriteLine(block.weight);
                }
            }
        }

        public void movePiece(Tower moveFrom, Tower moveTo)
        {
            moveTo.blocks.Push(moveFrom.blocks.Peek());
            moveFrom.blocks.Pop();

        }

        public bool isLegal(Tower moveFrom, Tower moveTo)
        {
            Block popOff = moveFrom.blocks.Peek();
            Block pushOn;
            if (moveTo.blocks.Count > 0)
            {
                pushOn = moveTo.blocks.Peek();
            }
            else
                pushOn = null;


            if (pushOn == null)
            {
                return true;
            }
            else if (popOff.weight < pushOn.weight)
            {
                return true;
            }
            else return false;
        }

        //Checking for win conditions
        public bool checkForWin(int turnsPlayed)
        {
            if (towers["A"].blocks.Count == 0 && towers["B"].blocks.Count == 0)
            {
                Console.WriteLine("Congratulations! You have won! You have finished this in {0} turns.", turnsPlayed);
                return true;
            }
            if (towers["A"].blocks.Count == 0 && towers["C"].blocks.Count == 0)
            {
                Console.WriteLine("Congratulations! You have won! You have finished this in {0} turns.", turnsPlayed);
                return true;
            }
            else return false;
        }
    }

    public class Block
    {
        //Constructor for Block
        public Block(int weight)
        {
            //Visual representation of weights
            this.weight = weight;
        }
        public int weight { get; private set; }
    }

    public class Tower
    {
        public string towerName;
        public Stack<Block> blocks = new Stack<Block>();
        //Constructor for Tower
        public Tower(string towerName, Stack<Block> Blocks)
        {
            this.towerName = towerName;
            this.blocks = Blocks;
        }
    }
}