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
            Block one = new Block(1, 1);
            Block two = new Block(2, 2);
            Block three = new Block(3, 3);
            Block four = new Block(4, 4);
            Tower A = new Tower("A");
            Tower B = new Tower("B");
            Tower C = new Tower("C");
            Tower.blocks.Push(one);
            Tower.blocks.Push(two);
            Tower.blocks.Push(three);
            Tower.blocks.Push(four);

            printBlocks();
        }
    }
    public class Block
    {
        //Constructor for Block
        public Block(int weight, int blockNumber)
        {
            this.weight = weight;
            this.blockNumber = blockNumber;
        }
        public int weight { get; private set; }
        public int blockNumber { get; private set; }

    }

    public class Tower
    {
        public string towerName;
        public static Stack blocks = new Stack();
        //Constructor for Tower
        public Tower(string towerName)
        {
            this.towerName = towerName;
        }
        public string printBlocks()
        {
            string result = "";
            foreach (var blockName in blocks)
            {
                result += Convert.ToString(blockName);
            }
            return result;
        }
    }

    public class Game
    {
        public Dictionary<string, Tower> towers = new Dictionary<string, Tower>();

    }
}
