using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Store
    {
        //member variables
        Random random;

        List<SupplyBundle> paperCupBundles;
        List<SupplyBundle> lemonBundles;
        List<SupplyBundle> sugarBundles;
        List<SupplyBundle> iceCubeBundles;

        List<int> paperCupQuantities;
        List<int> lemonQuantities;
        List<int> sugarQuantities;
        List<int> iceCubeQuantities;

        public List<string> bundleContents;

        int minPaperCupPrice = 20;
        int maxPaperCupPrice = 40;

        int minLemonPrice = 40;
        int maxLemonPrice = 80;

        int minSugarPrice = 70;
        int maxSugarPrice = 90;

        int minIceCubePrice = 7;
        int maxIceCubePrice = 10;

        int unitDivider = 1000;

        //constructor
        public Store(Random random)
        {
            this.random = random;
            paperCupQuantities = new List<int>() { 25, 50, 100 };
            lemonQuantities = new List<int>() { 10, 30, 75 };
            sugarQuantities = new List<int>() { 8, 20, 48 };
            iceCubeQuantities = new List<int>() { 100, 250, 500 };

            paperCupBundles = new List<SupplyBundle>();
            lemonBundles = new List<SupplyBundle>();
            sugarBundles = new List<SupplyBundle>();
            iceCubeBundles = new List<SupplyBundle>();

            bundleContents = new List<string>() { "Paper Cups", "Lemons", "Cups of Sugar", "Ice Cubes" };

        }

        //member methods

        public void SetDailyBundlePrices()
        {
            
            //TO DO: these foreach loops are all similar...write a method?
            foreach (int quantity in paperCupQuantities)
            {
                decimal paperCupUnitPrice = Decimal.Divide(random.Next(minPaperCupPrice, maxPaperCupPrice + 1), unitDivider);
                double paperCupBundlePrice = Math.Round((double)(paperCupUnitPrice * quantity), 2);
                SupplyBundle supplyBundle = new SupplyBundle(quantity, paperCupBundlePrice, bundleContents[0]);
                paperCupBundles.Add(supplyBundle);
            }

            foreach (int quantity in lemonQuantities)
            {
                decimal lemonUnitPrice = Decimal.Divide(random.Next(minLemonPrice, maxLemonPrice + 1), unitDivider);
                double lemonBundlePrice = Math.Round((double)(lemonUnitPrice * quantity), 2);
                lemonBundles.Add(new SupplyBundle(quantity, lemonBundlePrice, bundleContents[1]));
            }

            foreach (int quantity in sugarQuantities)
            {
                decimal sugarUnitPrice = Decimal.Divide(random.Next(minSugarPrice, maxSugarPrice + 1), unitDivider);
                double sugarBundlePrice = Math.Round((double)(sugarUnitPrice * quantity), 2);
                sugarBundles.Add(new SupplyBundle(quantity, sugarBundlePrice, bundleContents[2]));
            }

            foreach (int quantity in iceCubeQuantities)
            {
                decimal iceCubeUnitPrice = Decimal.Divide(random.Next(minIceCubePrice, maxIceCubePrice + 1), unitDivider);
                double iceCubeBundlePrice = Math.Round((double)(iceCubeUnitPrice * quantity), 2);
                iceCubeBundles.Add(new SupplyBundle(quantity, iceCubeBundlePrice, bundleContents[3]));
            }
        }


        //public static SupplyBundle GetSupplyBundle(int supplyBundleChoice, Player player, Random random, Store store)
        //{
        //    SupplyBundle chosenBundle;

        //    string supplyContents = store.bundleContents[supplyBundleChoice-1];

        //    List < SupplyBundle > = store.GetSupplyBundleList(supplyContents);

        //    DisplayPurchaseOptions(supplyContents, player.money);

        //    int bundleSelection = int.Parse(UI.GetValidUserOption("", new List<string>() { "1", "2", "3" }));

        //    if ( bundleSelection == 1 )
        //    {
        //        chosenBundle = supply.bundle1;
        //    }
        //    else if (bundleSelection == 2)
        //    {
        //        chosenBundle = supply.bundle2;
        //    }
        //    else
        //    {
        //        chosenBundle = supply.bundle3;
        //    }

        //    if (player.money<chosenBundle.price)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("Sorry, you don't have enough money to make this purchase.");
        //        Console.ResetColor();
        //        GetAnyKeyToContinue("continue", false);
        //        return GetSupplyBundle(supplyBundleChoice, player, random);
        //    }

        //    return chosenBundle;

        //}

        public string getBundleMenuInstructions()
        {
            string bundleMenuInstructions = "";
            for (int i = 0; i < bundleContents.Count; i++)
            {
                bundleMenuInstructions += (i + 1) + ": Buy " + bundleContents[i] + "\n";
            }
            bundleMenuInstructions += (bundleContents.Count + 1) + ": Done purchasing - Set my recipe!\n";

            return bundleMenuInstructions;

        }

        public List<string> getBundleMenuInputOptions()
        {
            List<string> bundleMenuInputOptions = new List<string>();
            for (int i = 0; i < bundleContents.Count; i++)
            {
                bundleMenuInputOptions.Add((i + 1).ToString());
            }
            bundleMenuInputOptions.Add((bundleContents.Count + 1).ToString());
            return bundleMenuInputOptions;
        }

        public SupplyBundle GetSupplyBundle(string bundleContents, double playerMoney)
        {
            List<SupplyBundle> chosenBundleList = new List<SupplyBundle>();
            switch (bundleContents)
            {
                case "Paper Cups":
                    chosenBundleList = paperCupBundles;
                    break;
                case "Lemons":
                    chosenBundleList = lemonBundles;
                    break;
                case "Cups of Sugar":
                    chosenBundleList = sugarBundles;
                    break;
                case "Ice Cubes":
                    chosenBundleList = iceCubeBundles;
                    break;
            }

            UI.DisplayBundlePurchaseOptions(chosenBundleList, playerMoney);
            List<string> validOptions = new List<string>();
            for ( int i=0; i<chosenBundleList.Count; i++ )
            {
                validOptions.Add( (i+1).ToString() );
            }
            int bundleSelection = int.Parse(UI.GetValidUserOption("", validOptions));

            SupplyBundle chosenBundle = chosenBundleList[bundleSelection-1];

            return chosenBundle;

        }

        public double GetCheapestSupplyBundlePrice()
        {
            double cheapestSupplyBundlePrice = paperCupBundles[0].price;

            //TO DO: these foreach loops are all similar...write a method?
            foreach (SupplyBundle paperCupBundle in paperCupBundles)
            {
                if (paperCupBundle.price < cheapestSupplyBundlePrice)
                {
                    cheapestSupplyBundlePrice = paperCupBundle.price;
                }
            }

            foreach (SupplyBundle lemonBundle in lemonBundles)
            {
                if (lemonBundle.price < cheapestSupplyBundlePrice)
                {
                    cheapestSupplyBundlePrice = lemonBundle.price;
                }
            }

            foreach (SupplyBundle sugarBundle in sugarBundles)
            {
                if (sugarBundle.price < cheapestSupplyBundlePrice)
                {
                    cheapestSupplyBundlePrice = sugarBundle.price;
                }
            }

            foreach (SupplyBundle iceCubeBundle in iceCubeBundles)
            {
                if (iceCubeBundle.price < cheapestSupplyBundlePrice)
                {
                    cheapestSupplyBundlePrice = iceCubeBundle.price;
                }
            }

            return cheapestSupplyBundlePrice;
        }

    }
}
