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

            Console.WriteLine("Enter in tower(A, B, or C) to move FROM:");
            consoleMoveFrom = (Console.ReadLine());
            
            Console.WriteLine("Enter in tower(A, B, or C) to move TO:");
            consoleMoveTo = (Console.ReadLine());

            newGame.movePiece(consoleMoveFrom, consoleMoveTo);
            //Draw Tower
            newGame.printTowerKeys();
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
    }
    
    public class Block
    {
        //Constructor for Block
        public Block(int weight)
        {
            //Visual representation of weights
            if (weight == 1)
            {
               this.weight =  "1.    O";
            };
            if (weight == 2)
            {
               this.weight =  "2.   OOO";
            };
            if (weight == 3)
            {
               this.weight =  "3.  OOOOO";
            };
            if (weight == 4)
            {
               this.weight =  "4. OOOOOOO";
            };
        }
        public string weight { get; private set; }
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