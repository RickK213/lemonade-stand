using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class ComputerPlayer : Player
    {
        //member variables
        Store store;

        //constructor
        //TO DO: Don't pass in the whole store...find out what you actually need from store.
        public ComputerPlayer(Random random, Store store)
        {
            name = "Lemonator 5000";
            this.store = store;
            this.random = random;
        }

        //member methods
        void PurchaseSupplyBundle(List<Supply> supplyInventory, List<SupplyBundle> supplyBundle, string typeOfSupply, bool notEnoughSupply)
        {
            if (notEnoughSupply)
            {
                double cheapestBundlePrice = store.GetCheapestBundlePrice(supplyBundle);
                if (moneyAvailable > cheapestBundlePrice)
                {
                    bool purchaseMade = false;
                    while (!purchaseMade)
                    {
                        //TO DO: figure out why the commented out line below doesn't work! I keep getting and "index out of range" error
                        //int selectedOption = random.Next(0, (supplyBundle.Count + 1));
                        int selectedOption = random.Next(0, (supplyBundle.Count));
                        if (moneyAvailable > supplyBundle[selectedOption].price)
                        {
                            moneyAvailable = Math.Round((moneyAvailable - supplyBundle[selectedOption].price), 2);
                            dailyExpenses = Math.Round((dailyExpenses + supplyBundle[selectedOption].price), 2);
                            totalExpenses = Math.Round((totalExpenses + supplyBundle[selectedOption].price), 2);
                            purchaseMade = true;
                            for (int i = 0; i < supplyBundle[selectedOption].quantity; i++)
                            {
                                switch (typeOfSupply)
                                {
                                    case "Paper Cups":
                                        supplyInventory.Add(new PaperCup());
                                        break;
                                    case "Lemons":
                                        supplyInventory.Add(new Lemon(random));
                                        break;
                                    case "Cups of Sugar":
                                        supplyInventory.Add(new CupOfSugar());
                                        break;
                                    case "Ice Cubes":
                                        supplyInventory.Add(new IceCube());
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public override void PurchaseInventory(double cheapestSupplyBundle, int currentDay, Day day, Store store)
        {
            PurchaseSupplyBundle(inventory.paperCups, store.paperCupBundles, store.paperCupBundles[0].typeOfSupply, notEnoughCups);
            PurchaseSupplyBundle(inventory.lemons, store.lemonBundles, store.lemonBundles[0].typeOfSupply, notEnoughLemons);
            PurchaseSupplyBundle(inventory.cupsOfSugar, store.sugarBundles, store.sugarBundles[0].typeOfSupply, notEnoughSugar);
            PurchaseSupplyBundle(inventory.iceCubes, store.iceCubeBundles, store.iceCubeBundles[0].typeOfSupply, notEnoughIce);
            UI.DisplayPlayerInventory(this, currentDay, day);
            UI.GetAnyKeyToContinue("continue", true);
        }

        public override void SetRecipe(int currentDay, Day day, Game game)
        {
            recipe.pricePerCup = random.Next(game.minLemonadePrice, game.maxLemonadePrice);
            recipe.lemonsPerPitcher = random.Next(Decimal.ToInt32(game.minLemonsPerPitcher), Decimal.ToInt32(game.maxLemonsPerPitcher));
            recipe.sugarPerPitcher = random.Next(Decimal.ToInt32(game.minSugarPerPitcher), Decimal.ToInt32(game.maxSugarPerPitcher));
            recipe.icePerCup = random.Next(Decimal.ToInt32(game.minIcePerCup), Decimal.ToInt32(game.maxIcePerCup));
            UI.DisplayPlayerRecipe(this, currentDay, day);
            UI.GetAnyKeyToContinue("continue", true);
        }
    }
}
