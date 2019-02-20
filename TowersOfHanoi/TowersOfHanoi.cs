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
            Block one = new Block(1);
            Block two = new Block(2);
            Block three = new Block(3);
            Block four = new Block(4);

            //Instantiate new towers
            Tower A = new Tower("A", new Stack<Block>());
            Tower B = new Tower("B", new Stack<Block>());
            Tower C = new Tower("C", new Stack<Block>());

            //Initial Insert towers into dictionary
            newGame.towers.Add("A", A);
            newGame.towers.Add("B", B);
            newGame.towers.Add("C", C);

            //Insert blocks to Towers
            A.blocks.Push(four);
            A.blocks.Push(three);
            A.blocks.Push(two);
            A.blocks.Push(one);


            //Move pieces
            string consoleMoveFrom;
            string consoleMoveTo;

            while (newGame.checkForWin() == false)
            {
                Console.WriteLine("Enter in tower(A, B, or C) to move FROM:");
                consoleMoveFrom = (Console.ReadLine());

                Console.WriteLine("Enter in tower(A, B, or C) to move TO:");
                consoleMoveTo = (Console.ReadLine());

                if (newGame.isLegal(newGame.towers[consoleMoveFrom], newGame.towers[consoleMoveTo]))
                {
                    newGame.movePiece(newGame.towers[consoleMoveFrom], newGame.towers[consoleMoveTo]);
                }
                else
                {
                    Console.WriteLine("You have entered a wrong move. Please enter in a correct move sequence!");
                }

                //Draw Tower
                newGame.printTowerKeys();
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

        public bool checkForWin()
        {
            if (towers["B"].blocks.Count == 4)
            {
                return true;
            }
            if (towers["C"].blocks.Count == 4)
            {
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

        public void insertToTower()
        {

        }
    }
}