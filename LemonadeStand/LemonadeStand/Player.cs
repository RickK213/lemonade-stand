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
        public double moneyAvailable;
        public string name;
        public double popularity;
        public double dailyIncome;
        public double dailyExpenses;
        public double dailyProfit;
        public double totalIncome;
        public double totalExpenses;
        public double totalProfit;
        public Random random;
        public bool notEnoughCups;
        public bool notEnoughLemons;
        public bool notEnoughSugar;
        public bool notEnoughIce;

        //constructor
        public Player()
        {
            inventory = new Inventory();
            recipe = new Recipe();
            startingMoney = 20.00;
            moneyAvailable = startingMoney;
            popularity = .50;
            notEnoughCups = true;
            notEnoughLemons = true;
            notEnoughSugar = true;
            notEnoughIce = true;
        }

        //member methods
        public abstract void PurchaseInventory(double cheapestSupplyBundle, int currentDay, Day day, Store store);
        public abstract void SetRecipe(int currentDay, Day day, Game game);

        public void AddBundleToInventory(SupplyBundle supplyBundle)
        {
            moneyAvailable = Math.Round((moneyAvailable - supplyBundle.price), 2);
            dailyExpenses = Math.Round((dailyExpenses + supplyBundle.price), 2);
            totalExpenses = Math.Round((totalExpenses + supplyBundle.price), 2);
            for (int i = 0; i < supplyBundle.quantity; i++)
            {
                //TO DO: seems like there should be a better way to do this than hard-coding the strings in the switch cases
                switch (supplyBundle.typeOfSupply)
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
            bool isSoldOut = false;
            decimal lemonsPerCup = Decimal.Divide(recipe.lemonsPerPitcher, cupsPerPitcher);

            if (inventory.lemons.Count < lemonsPerCup )
            {
                isSoldOut = true;
                notEnoughLemons = true;
            }
            else
            {
                notEnoughLemons = false;
            }

            if (inventory.paperCups.Count == 0)
            {
                isSoldOut = true;
                notEnoughCups = true;
            }
            else
            {
                notEnoughCups = false;
            }

            if (inventory.iceCubes.Count < recipe.icePerCup)
            {
                isSoldOut = true;
                notEnoughIce = true;
            }
            else
            { 
                notEnoughIce = false;
            }

            decimal sugarPerCup = Decimal.Divide(recipe.sugarPerPitcher, cupsPerPitcher);

            if (inventory.cupsOfSugar.Count < sugarPerCup )
            {
                isSoldOut = true;
                notEnoughSugar = true;
            }
            else
            {
                notEnoughSugar = false;
            }

            return isSoldOut;
        }

    }
}
