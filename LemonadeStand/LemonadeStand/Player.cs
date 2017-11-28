using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        //member variables
        public Inventory inventory;
        public Recipe recipe;
        public double startingMoney = 20.00;
        public double money;
        public string name;
        public double popularity;
        public double dailyProfit;

        //constructor
        public Player(string name)
        {
            this.name = name;
            money = startingMoney;
            inventory = new Inventory();
            recipe = new Recipe();
            popularity = .50;

        }

        //member methods

    }
}
