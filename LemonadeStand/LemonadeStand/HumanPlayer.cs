using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class HumanPlayer : Player
    {
        //member variables
        public Inventory inventory;
        public Recipe recipe;
        public double startingMoney;
        public double money;
        public string name;
        public double popularity;
        public double dailyIncome;
        public double dailyExpenses;
        public double dailyProfit;
        public double totalIncome;
        public double totalExpenses;
        public double totalProfit;

        //constructor
        public HumanPlayer(string name)
        {
            this.name = name;
            startingMoney = 20.00;
            money = startingMoney;
            inventory = new Inventory();
            recipe = new Recipe();
            popularity = .50;


        }

        //member methods
        public bool checkForSoldOut(int cupsPerPitcher)
        {
            bool soldOut = false;
            if (inventory.lemons.Count < recipe.lemonsPerPitcher / cupsPerPitcher)
            {
                soldOut = true;
            }
            if (inventory.paperCups.Count == 0)
            {
                soldOut = true;
            }
            if (inventory.iceCubes.Count < recipe.icePerCup)
            {
                soldOut = true;
            }
            if (inventory.cupsOfSugar.Count < recipe.sugarPerPitcher / cupsPerPitcher)
            {
                soldOut = true;
            }

            return soldOut;
        }

    }
}
