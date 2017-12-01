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

        public List<SupplyBundle> paperCupBundles;
        public List<SupplyBundle> lemonBundles;
        public List<SupplyBundle> sugarBundles;
        public List<SupplyBundle> iceCubeBundles;

        List<int> paperCupQuantities;
        List<int> lemonQuantities;
        List<int> sugarQuantities;
        List<int> iceCubeQuantities;

        public List<string> bundleTypes;

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

            bundleTypes = new List<string>() { "Paper Cups", "Lemons", "Cups of Sugar", "Ice Cubes" };

        }

        //member methods

        void SetBundlePrice(List<int> bundleQuantities, List<SupplyBundle> supplyBundleList, int minSupplyPrice, int maxSupplyPrice, int typeIndex)
        {
            foreach (int quantity in bundleQuantities)
            {
                decimal unitPrice = Decimal.Divide(random.Next(minSupplyPrice, maxSupplyPrice + 1), unitDivider);
                double bundlePrice = Math.Round((double)(Decimal.Multiply(unitPrice, quantity)), 2);
                SupplyBundle supplyBundle = new SupplyBundle(quantity, bundlePrice, bundleTypes[typeIndex]);
                supplyBundleList.Add(supplyBundle);
            }
        }

        public void SetDailyBundlePrices()
        {
            SetBundlePrice(paperCupQuantities, paperCupBundles, minPaperCupPrice, maxPaperCupPrice, 0);
            SetBundlePrice(lemonQuantities, lemonBundles, minLemonPrice, maxLemonPrice, 1);
            SetBundlePrice(sugarQuantities, sugarBundles, minSugarPrice, maxSugarPrice, 2);
            SetBundlePrice(iceCubeQuantities, iceCubeBundles, minIceCubePrice, maxIceCubePrice, 3);
        }

        public string getBundleMenuInstructions()
        {
            string bundleMenuInstructions = "";
            for (int i = 0; i < bundleTypes.Count; i++)
            {
                bundleMenuInstructions += (i + 1) + ": Buy " + bundleTypes[i] + "\n";
            }
            bundleMenuInstructions += (bundleTypes.Count + 1) + ": Done purchasing - Set my recipe!\n";

            return bundleMenuInstructions;

        }

        public List<string> getBundleMenuInputOptions()
        {
            List<string> bundleMenuInputOptions = new List<string>();
            for (int i = 0; i < bundleTypes.Count; i++)
            {
                bundleMenuInputOptions.Add((i + 1).ToString());
            }
            bundleMenuInputOptions.Add((bundleTypes.Count + 1).ToString());
            return bundleMenuInputOptions;
        }

        public SupplyBundle GetSupplyBundle(string typeOfBundle, double playerMoney)
        {
            List<SupplyBundle> chosenBundleList = new List<SupplyBundle>();
            switch (typeOfBundle)
            {
                //TO DO: seems like there should be a better way to do this than hard-coding the strings in the switch cases
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

        public double GetCheapestBundlePrice(List<SupplyBundle> bundleList)
        {
            double cheapestBundlePrice = bundleList[0].price;
            foreach (SupplyBundle bundle in bundleList)
            {
                if (bundle.price < cheapestBundlePrice)
                {
                    cheapestBundlePrice = bundle.price;
                }
            }
            return cheapestBundlePrice;
        }

        public double GetCheapestSupplyBundlePrice()
        {
            List<double> cheapestBundlePrices = new List<double>();
            cheapestBundlePrices.Add(GetCheapestBundlePrice(paperCupBundles));
            cheapestBundlePrices.Add(GetCheapestBundlePrice(lemonBundles));
            cheapestBundlePrices.Add(GetCheapestBundlePrice(sugarBundles));
            cheapestBundlePrices.Add(GetCheapestBundlePrice(iceCubeBundles));
            cheapestBundlePrices.Sort();
            return cheapestBundlePrices[0];
        }

    }
}
