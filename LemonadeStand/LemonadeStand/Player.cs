using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Player
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
        public Random random;

        //constructor
        public Player()
        {

        }

        //member methods
        public abstract void PurchaseInventory(double cheapestSupplyBundle, int currentDay, Day day, Store store);
        public abstract void SetRecipe(int currentDay, Day day, Game game);

        public void AddBundleToInventory(SupplyBundle supplyBundle)
        {
            money = Math.Round((money - supplyBundle.price), 2);
            dailyExpenses = Math.Round((dailyExpenses + supplyBundle.price), 2);
            totalExpenses = Math.Round((totalExpenses + supplyBundle.price), 2);
            for (int i = 0; i < supplyBundle.quantity; i++)
            {
                switch (supplyBundle.contents)
                {
                    case "Paper Cups":
                        inventory.paperCups.Add( new PaperCup() );
                        break;
                    case "Lemons":
                        inventory.lemons.Add( new Lemon(random) );
                        break;
                    case "Cups of Sugar":
                        inventory.cupsOfSugar.Add( new CupOfSugar() );
                        break;
                    case "Ice Cubes":
                        inventory.iceCubes.Add( new IceCube() );
                        break;
                }
            }
        }



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
