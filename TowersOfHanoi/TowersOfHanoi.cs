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
            
            //Insert towers into dictionary
            newGame.towers.Add("A", A);
            newGame.towers.Add("B", B);
            newGame.towers.Add("C", C);

            //Insert blocks to Towers
            A.blocks.Push(one);
            A.blocks.Push(two);
            A.blocks.Push(three);
            A.blocks.Push(four);

            //Draw Tower
            newGame.printTowerKeys();

        }
    }
    public class Game
    {
        public Dictionary<string, Tower> towers = new Dictionary<string, Tower>();
        
        public void moveBlock()
        {

        }
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
    }
    public class Block
    {
        //Constructor for Block
        public Block(int weight)
        {
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