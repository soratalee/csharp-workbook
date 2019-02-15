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
            Tower A = new Tower("A");
            Tower B = new Tower("B");
            Tower C = new Tower("C");
            
            //Insert towers into dictionary
            newGame.towers.Add("A", new int[] { });
            newGame.towers.Add("B", new int[] { });
            newGame.towers.Add("C", new int[] { });

            //Insert blocks to Towers
            A.pushToTower(one.weight);
            A.pushToTower(two.weight);
            A.pushToTower(three.weight);
            A.pushToTower(four.weight);

            //Draw Tower
            newGame.printTowerKeys();

        }
    }
    public class Game
    {
        public Dictionary<string, int[]> towers = new Dictionary<string, int[]>();
        
        public void moveBlock()
        {

        }
        public void printTowerKeys()
        {
            foreach (var towerKey in towers.Keys)
            {
                Console.WriteLine("Tower: " + towerKey);
                foreach (var towerName in towers[towerKey])
                {
                    Console.WriteLine(towerName);
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
        public static Stack blocks = new Stack();
        //Constructor for Tower
        public Tower(string towerName)
        {
            this.towerName = towerName;
        }
    }
}
