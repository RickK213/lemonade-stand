using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        //member variables
        int numDaysInGame;
        int numPlayers;
        Day day;
        List<Player> players;
        List<Supply> gameSupplies;
        public decimal minTemperature;
        public decimal maxTemperature;
        decimal minNumberOfCustomers;
        decimal maxNumberOfCustomers;
        public decimal minLemonadePrice;
        public decimal maxLemonadePrice;
        public decimal minLemonsPerPitcher;
        public decimal maxLemonsPerPitcher;
        public decimal minSugarPerPitcher;
        public decimal maxSugarPerPitcher;
        public decimal minIcePerCup;
        public decimal maxIcePerCup;
        public Random random;

        //constructor
        public Game()
        {
            players = new List<Player>();
            gameSupplies = new List<Supply>() { new PaperCup(), new Lemon(), new CupOfSugar(), new IceCube() };
            minTemperature = 50;
            maxTemperature = 100;
            minNumberOfCustomers = 10;
            maxNumberOfCustomers = 100;
            minLemonadePrice = 1;
            maxLemonadePrice = 100;
            minLemonsPerPitcher = 1;
            minLemonsPerPitcher = 20;
            minSugarPerPitcher = 0;
            maxSugarPerPitcher = 20;
            minIcePerCup = 0;
            maxIcePerCup = 10;
            random = new Random();
    }

    //member methods
    void SetUpGame()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("LET'S SET UP SOME GAME OPTIONS!\n");
            Console.ResetColor();
            numPlayers = int.Parse(UI.GetValidUserOption("How many players?", new List<string>() { "1", "2" }));
            numDaysInGame = int.Parse(UI.GetValidUserOption("How many days would you like to play for?", new List<string>() { "7", "14", "30" }));
        }

        void AddPlayersToGame()
        {
            for (int i=0; i<numPlayers; i++)
            {
                Console.WriteLine("Enter a name for Player " + (i + 1) );
                string playerName = Console.ReadLine();
                Player player = new Player(playerName);
                players.Add(player);
                Console.WriteLine();
            }
        }

        void AddBundleToPlayerInventory(Player player, SupplyBundle supplyBundle)
        {
            player.money = Math.Round( (player.money-supplyBundle.price), 2);
            for (int i=0; i<supplyBundle.quantity; i++)
            {
                switch(supplyBundle.supply.name)
                {
                    case "Paper Cup":
                        player.inventory.paperCups.Add(supplyBundle.supply);
                        break;
                    case "Lemon":
                        player.inventory.lemons.Add(supplyBundle.supply);
                        break;
                    case "Cup of Sugar":
                        player.inventory.cupsOfSugar.Add(supplyBundle.supply);
                        break;
                    case "Ice Cube":
                        player.inventory.iceCubes.Add(supplyBundle.supply);
                        break;
                }
            }
        }

        double GetCheapestBundle(Supply supply)
        {
            List<double> bundlePrices = new List<double>();
            bundlePrices.Add(supply.bundle1.price);
            bundlePrices.Sort();
            return bundlePrices[0];
        }

        double GetCheapestSupplyBundle()
        {
            List<double> cheapestBundles = new List<double>();
            foreach ( Supply supply in gameSupplies )
            {
                double cheapestBundle = GetCheapestBundle(supply);
                cheapestBundles.Add(cheapestBundle);
            }
            cheapestBundles.Sort();
            return cheapestBundles[0];
        }

        void MakePlayerPurchases(Player player, int currentDay)
        {
            int menuSelection = 0;
            double cheapestSupplyBundle = GetCheapestSupplyBundle();
            while ((menuSelection != 5) && (player.money > cheapestSupplyBundle))
            {
                UI.DisplayPlayerInventory(player, currentDay, day);
                UI.DisplayMenuHeader();
                menuSelection = int.Parse(UI.GetValidUserOption("1: Buy Paper Cups\n2: Buy Lemons\n3: Buy Cups of Sugar\n4: Buy Ice Cubes\n5: Done purchasing - Set my recipe!\n", new List<string>() { "1", "2", "3", "4", "5" }));
                if (menuSelection != 5)
                {
                    SupplyBundle supplyBundle = UI.GetSupplyBundle(menuSelection, player);
                    AddBundleToPlayerInventory(player, supplyBundle);
                }
            }
            if (player.money < cheapestSupplyBundle)
            {
                UI.DisplayPlayerInventory(player, currentDay, day);
                UI.DisplayBankruptMessage();
            }
        }

        void SetPlayerRecipeVariable(int menuSelection, int playerInput, Player player)
        {
            switch(menuSelection)
            {
                case 1:
                    player.recipe.pricePerCup = playerInput;
                    break;
                case 2:
                    player.recipe.lemonsPerPitcher = playerInput;
                    break;
                case 3:
                    player.recipe.sugarPerPitcher = playerInput;
                    break;
                case 4:
                    player.recipe.icePerCup = playerInput;
                    break;
                default:
                    break;

            }
        }

        void SetPlayerRecipe(Player player, int currentDay)
        {
            int menuSelection = 0;
            while ( menuSelection != 5 )
            {
                UI.DisplayPlayerRecipe(player, currentDay, day);
                UI.DisplayMenuHeader();
                menuSelection = int.Parse(UI.GetValidUserOption("1: Change Price per Cup\n2: Change Lemons per Pitcher\n3: Change Sugar per Pitcher\n4: Change Ice per Cup\n5: Done with Recipe - Let's start selling!\n", new List<string>() { "1", "2", "3", "4", "5" }));
                if (menuSelection != 5)
                {
                    int playerInput = UI.GetRecipeValue(menuSelection, player, this);
                    SetPlayerRecipeVariable(menuSelection, playerInput, player);
                }
            }
        }

        int GetNumberOfCustomers()
        {
            decimal dailyMinNumberOfCustomers = minNumberOfCustomers;
            decimal dailyMaxNumberOfCustomers = maxNumberOfCustomers;
            decimal numberOfSpans = 4;

            //To determine Max/Min number of customers:
            //1. Temperature determines initial max/min - DONE
            //2. High price lowers max/min, Low Price raises max/min
            //3. Bad forecast lowers max/min, Good forecast raises max/min
            //4. Randomize number of customers based on max/min

            decimal customerNumberSpan = (maxNumberOfCustomers - minNumberOfCustomers) / numberOfSpans;
            decimal temperatureSpan = (maxTemperature - minTemperature) / numberOfSpans;
            decimal priceSpan = (maxLemonadePrice - minLemonadePrice) / numberOfSpans;

            if (day.weather.highTemp < minTemperature + temperatureSpan)
            {
                dailyMaxNumberOfCustomers -= customerNumberSpan * 3;
            }
            else if ((day.weather.highTemp >= minTemperature + temperatureSpan) && (day.weather.highTemp < minTemperature + temperatureSpan * 2))
            {
                dailyMaxNumberOfCustomers -= customerNumberSpan * 2;
            }
            else if ((day.weather.highTemp >= minTemperature + temperatureSpan * 2) && (day.weather.highTemp < minTemperature + temperatureSpan * 3))
            {
                dailyMinNumberOfCustomers += customerNumberSpan * 2;
            }
            else
            {
                dailyMinNumberOfCustomers += customerNumberSpan * 3;
            }

            Console.WriteLine("minimum number of customers: {0}", dailyMinNumberOfCustomers);
            Console.WriteLine("maximum number of customers: {0}", dailyMaxNumberOfCustomers);
            Console.ReadKey();

            return random.Next(Decimal.ToInt32(dailyMinNumberOfCustomers), Decimal.ToInt32(dailyMaxNumberOfCustomers + 1));


        }

        void RunDailyLemonadeStand(Player player, Day day)
        {
            player.dailyProfit = 0;
            List<Customer> customers = new List<Customer>();
            int numberOfCustomers = GetNumberOfCustomers();


            //run day:
            //get number of total customers - random dependent on price, weather and popularity
            //If the weather is bad, and your price is high, don't expect too many (maybe 15-25).  But if the weather is hot and clear, and your prices are reasonable, you can expect about 50-75 customers.
            //get number of customers that purchase - random dependent on customer satisfaction
            //get number of satisfied customers - dependent on price, recipe
            //calculate overall popularity based on the day's customer satisfaction
            //inventory losses - some lemons spoil and all ice melts
        }

        public void RunGame()
        {
            UI.DisplayIntroScreen();
            SetUpGame();
            AddPlayersToGame();
            //game loop
            for (int i=0; i<numDaysInGame; i++)
            {
                //every day:
                int currentDay = i + 1;
                day = new Day(this);
                foreach (Player player in players)
                {
                    MakePlayerPurchases(player, currentDay);
                    SetPlayerRecipe(player, currentDay);
                    RunDailyLemonadeStand(player, day);
                    //end of day report
                }
            }
            //end of season report:
            //Total Income (end of game money - player.startingMoney)
            //Total Expenses (money spent on inventory)
            //Liquidated Inventory Value (add unit cost of lost inventory to player's total)
            //Net Profit/Loss ???

        }

    }
}
