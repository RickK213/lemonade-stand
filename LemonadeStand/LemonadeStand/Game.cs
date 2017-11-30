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
        public Day day;
        List<Player> players;
        List<Supply> gameSupplies;
        public decimal minTemperature;
        public decimal maxTemperature;
        decimal minNumberOfCustomers;
        decimal maxNumberOfCustomers;
        public int minLemonadePrice;
        public int maxLemonadePrice;
        public decimal minLemonsPerPitcher;
        public decimal maxLemonsPerPitcher;
        public decimal minSugarPerPitcher;
        public decimal maxSugarPerPitcher;
        public decimal minIcePerCup;
        public decimal maxIcePerCup;
        decimal numberOfVariableBreaks;
        int temperatureMultiplier;
        int forecastMultiplier;
        int priceMultiplier;
        int cupsPerPitcher;
        int currentDay;
        public Random random;

        //constructor
        public Game()
        {
            random = new Random();
            players = new List<Player>();
            //TO DO: rewrite the line below. It's bad to create objects you don't plan on using
            gameSupplies = new List<Supply>() { new PaperCup(), new Lemon(random), new CupOfSugar(), new IceCube() };
            minTemperature = 50;
            maxTemperature = 100;
            minNumberOfCustomers = 10;
            maxNumberOfCustomers = 100;
            minLemonadePrice = 1;
            maxLemonadePrice = 99;
            minLemonsPerPitcher = 1;
            maxLemonsPerPitcher = 20;
            minSugarPerPitcher = 1;
            maxSugarPerPitcher = 20;
            minIcePerCup = 1;
            maxIcePerCup = 10;
            numberOfVariableBreaks = 4;
            cupsPerPitcher = 8;
            //The multipliers below allow the developer to weigh the effect of Temperature, Forecast & Price on The Number of Customers generated
            temperatureMultiplier = 13;
            forecastMultiplier = 8;
            priceMultiplier = 10;
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

        void AddHumanPlayer(int playerNumber)
        {
            Console.WriteLine("Enter a name for Player {0}", playerNumber);
            string playerName = Console.ReadLine();
            HumanPlayer player = new HumanPlayer(random, playerName);
            players.Add(player);
        }

        void AddComputerPlayer()
        {
            ComputerPlayer player = new ComputerPlayer(random);
            players.Add(player);
        }

        void AddPlayersToGame()
        {

            AddHumanPlayer(1);

            if ( numPlayers == 2 )
            {
                AddHumanPlayer(1);
            }
            else
            {
                AddComputerPlayer();
            }


            for (int i=0; i<numPlayers; i++)
            {
                Console.WriteLine();
            }
        }

        //void AddBundleToPlayerInventory(Player player, SupplyBundle supplyBundle)
        //{
        //    player.money = Math.Round((player.money - supplyBundle.price), 2);
        //    player.dailyExpenses = Math.Round((player.dailyExpenses + supplyBundle.price), 2);
        //    player.totalExpenses = Math.Round((player.totalExpenses + supplyBundle.price), 2);
        //    for (int i=0; i<supplyBundle.quantity; i++)
        //    {
        //        switch(supplyBundle.supply.name)
        //        {
        //            case "Paper Cup":
        //                player.inventory.paperCups.Add(supplyBundle.supply);
        //                break;
        //            case "Lemon":
        //                player.inventory.lemons.Add(new Lemon(random) );
        //                break;
        //            case "Cup of Sugar":
        //                player.inventory.cupsOfSugar.Add(supplyBundle.supply);
        //                break;
        //            case "Ice Cube":
        //                player.inventory.iceCubes.Add(supplyBundle.supply);
        //                break;
        //        }
        //    }
        //}

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

        //void MakePlayerPurchases(Player player, int currentDay)
        //{
        //    int menuSelection = 0;
        //    double cheapestSupplyBundle = GetCheapestSupplyBundle();
        //    while ((menuSelection != 5) && (player.money > cheapestSupplyBundle))
        //    {
        //        UI.DisplayPlayerInventory(player, currentDay, day);
        //        UI.DisplayMenuHeader();
        //        menuSelection = int.Parse(UI.GetValidUserOption("1: Buy Paper Cups\n2: Buy Lemons\n3: Buy Cups of Sugar\n4: Buy Ice Cubes\n5: Done purchasing - Set my recipe!\n", new List<string>() { "1", "2", "3", "4", "5" }));
        //        if (menuSelection != 5)
        //        {
        //            SupplyBundle supplyBundle = UI.GetSupplyBundle(menuSelection, player, random);
        //            AddBundleToPlayerInventory(player, supplyBundle);
        //        }
        //    }
        //    if (player.money < cheapestSupplyBundle)
        //    {
        //        UI.DisplayPlayerInventory(player, currentDay, day);
        //        UI.DisplayBankruptMessage();
        //    }
        //}

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

        decimal AdjustMinBasedOnTemp(decimal dailyMinNumberOfCustomers, decimal numberOfVariableBreaks)
        {
            decimal temperatureSpan = (maxTemperature - minTemperature) / numberOfVariableBreaks;
            if ((day.weather.actualHighTemp >= minTemperature + temperatureSpan * 2) && (day.weather.actualHighTemp < minTemperature + temperatureSpan * 3))
            {
                dailyMinNumberOfCustomers += temperatureMultiplier;
            }
            else if (day.weather.actualHighTemp >= minTemperature + temperatureSpan * 3)
            {
                dailyMinNumberOfCustomers += temperatureMultiplier * 2;
            }

            return dailyMinNumberOfCustomers;
        }

        decimal AdjustMinBasedOnPrice(decimal dailyMinNumberOfCustomers, decimal numberOfVariableBreaks, Player player)
        {
            decimal priceSpan = (maxLemonadePrice - minLemonadePrice) / numberOfVariableBreaks;
            if ((player.recipe.pricePerCup >= minLemonadePrice) && (player.recipe.pricePerCup < minLemonadePrice + priceSpan))
            {
                dailyMinNumberOfCustomers += priceMultiplier * 2;
            }
            else if ( (player.recipe.pricePerCup >= minLemonadePrice + priceSpan) && (player.recipe.pricePerCup < minLemonadePrice + priceSpan*2) )
            {
                dailyMinNumberOfCustomers += priceMultiplier;
            }

            return dailyMinNumberOfCustomers;
        }

        decimal AdjustMinBasedOnForecast(decimal dailyMinNumberOfCustomers)
        {

            if ( day.weather.actualForecast == "Overcast" )
            {
                dailyMinNumberOfCustomers += forecastMultiplier;
            }
            else if ( day.weather.actualForecast == "Sunny & Clear" )
            {
                dailyMinNumberOfCustomers += forecastMultiplier * 2;
            }

            return dailyMinNumberOfCustomers;
        }

        decimal AdjustMaxBasedOnTemp(decimal dailyMaxNumberOfCustomers, decimal numberOfVariableBreaks)
        {
            decimal temperatureSpan = (maxTemperature - minTemperature) / numberOfVariableBreaks;
            if (day.weather.actualHighTemp < minTemperature + temperatureSpan)
            {
                dailyMaxNumberOfCustomers -= temperatureMultiplier * 2;
            }
            else if ((day.weather.actualHighTemp >= minTemperature + temperatureSpan) && (day.weather.actualHighTemp < minTemperature + temperatureSpan * 2))
            {
                dailyMaxNumberOfCustomers -= temperatureMultiplier;
            }

            return dailyMaxNumberOfCustomers;
        }

        decimal AdjustMaxBasedOnPrice(decimal dailyMaxNumberOfCustomers, decimal numberOfVariableBreaks, Player player)
        {
            decimal priceSpan = (maxLemonadePrice - minLemonadePrice) / numberOfVariableBreaks;
            if ((decimal)player.recipe.pricePerCup > minLemonadePrice + priceSpan * 3)
            {
                dailyMaxNumberOfCustomers -= priceMultiplier * 2;
            }
            else if ( (player.recipe.pricePerCup >= minLemonadePrice + priceSpan * 2) && (player.recipe.pricePerCup <= minLemonadePrice + priceSpan * 3)  )
            {
                dailyMaxNumberOfCustomers -= priceMultiplier;
            }

            return dailyMaxNumberOfCustomers;
        }

        decimal AdjustMaxBasedOnForecast(decimal dailyMaxNumberOfCustomers)
        {

            if (day.weather.actualForecast == "Cloudy")
            {
                dailyMaxNumberOfCustomers -= forecastMultiplier;
            }
            else if (day.weather.actualForecast == "Rainy")
            {
                dailyMaxNumberOfCustomers -= forecastMultiplier * 2;
            }

            return dailyMaxNumberOfCustomers;
        }

        int GetNumberOfCustomers(Player player)
        {
            //TO DO: add in player popularity as a determining factor for number of customers
            decimal dailyMinNumberOfCustomers = minNumberOfCustomers;
            decimal dailyMaxNumberOfCustomers = maxNumberOfCustomers;

            dailyMinNumberOfCustomers = AdjustMinBasedOnTemp(dailyMinNumberOfCustomers, numberOfVariableBreaks);
            dailyMaxNumberOfCustomers = AdjustMaxBasedOnTemp(dailyMaxNumberOfCustomers, numberOfVariableBreaks);

            dailyMinNumberOfCustomers = AdjustMinBasedOnForecast(dailyMinNumberOfCustomers);
            dailyMaxNumberOfCustomers = AdjustMaxBasedOnForecast(dailyMaxNumberOfCustomers);

            dailyMinNumberOfCustomers = AdjustMinBasedOnPrice(dailyMinNumberOfCustomers, numberOfVariableBreaks, player);
            dailyMaxNumberOfCustomers = AdjustMaxBasedOnPrice(dailyMaxNumberOfCustomers, numberOfVariableBreaks, player);

            return random.Next(Decimal.ToInt32(dailyMinNumberOfCustomers), Decimal.ToInt32(dailyMaxNumberOfCustomers + 1));
        }

        void RunDailyLemonadeStand(Player player)
        {
            List<Customer> customers = new List<Customer>();
            int numberOfCustomers = GetNumberOfCustomers(player);
            int numberOfPurchases = 0;
            bool isSoldOut = false;
            for ( int i=0; i<numberOfCustomers; i++ )
            {
                customers.Add( new Customer(random) );
            }

            foreach ( Customer customer in customers )
            {
                isSoldOut = player.checkForSoldOut(cupsPerPitcher);
                if (!isSoldOut) {
                    if (customer.MakesPurchase(minLemonadePrice, maxLemonadePrice, minTemperature, maxTemperature, day.weather.actualHighTemp, player.recipe.pricePerCup))
                    {
                        numberOfPurchases++;
                        double moneyMade = (double)Decimal.Divide(player.recipe.pricePerCup, 100);
                        player.money += moneyMade;
                        player.dailyIncome += moneyMade;
                        player.totalIncome += moneyMade;

                        int lemonsUsed = player.recipe.lemonsPerPitcher / cupsPerPitcher;
                        player.inventory.lemons.RemoveRange(0, lemonsUsed);

                        player.inventory.paperCups.RemoveAt(0);

                        int cupsOfSugarUsed = player.recipe.sugarPerPitcher / cupsPerPitcher;
                        player.inventory.cupsOfSugar.RemoveRange(0, cupsOfSugarUsed);

                        int iceCubesUsed = player.recipe.icePerCup;
                        player.inventory.iceCubes.RemoveRange(0, iceCubesUsed);

                    }
                }
            }

            player.dailyProfit = player.dailyIncome - player.dailyExpenses;
            player.totalProfit = player.totalIncome - player.totalExpenses;
            UI.DisplaySalesReport(player, currentDay, day, numberOfPurchases, numberOfCustomers);

            //inventory losses
            //TO DO: calculate lost value
            int numberOfIceCubesLost = player.inventory.iceCubes.Count;
            player.inventory.iceCubes.Clear();

            foreach (Lemon lemon in player.inventory.lemons)
            {
                lemon.daysUntilSpoiled--;
            }

            int numberOfLemonsLost = 0;
            for (int i=0; i<player.inventory.lemons.Count; i++)
            {
                Lemon currentLemon = (Lemon)player.inventory.lemons[i];
                if (currentLemon.daysUntilSpoiled == 0)
                {
                    numberOfLemonsLost++;
                    player.inventory.lemons.RemoveAt(i);
                }
            }

            int cupsOfSugarLost = 0;
            int chanceOfBugsInSugar = random.Next(1,9);
            if (chanceOfBugsInSugar == 1)
            {
                cupsOfSugarLost = player.inventory.cupsOfSugar.Count;
                player.inventory.cupsOfSugar.Clear();
            }

            UI.DisplayDailyInventoryReport(numberOfIceCubesLost, numberOfLemonsLost, cupsOfSugarLost, currentDay, player, isSoldOut);


            //run day:
            //DONE - get number of total customers - random dependent on price, weather and popularity
            //DONE - get number of customers that purchase - random dependent on customer satisfaction
            //get number of satisfied customers - dependent on price, recipe
            //calculate overall popularity based on the day's customer satisfaction
            //DONE - inventory losses - some lemons spoil and all ice melts
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
                currentDay = i + 1;
                day = new Day(random, minTemperature, maxTemperature);
                day.weather.setActualWeather();
                foreach (Player player in players)
                {
                    player.dailyIncome = 0;
                    player.dailyExpenses = 0;
                    double cheapestSupplyBundle = GetCheapestSupplyBundle();
                    player.PurchaseInventory(cheapestSupplyBundle, currentDay, day);
                    //player.SetRecipe();
                    //MakePlayerPurchases(player, currentDay);
                    SetPlayerRecipe(player, currentDay);
                    RunDailyLemonadeStand(player);
                }
            }
            UI.DisplayEndOfSeasonReport(players);
            string doPlayAgain = UI.GetValidUserOption("Would you like to play again?", new List<string>() { "y", "n" });
            if ( doPlayAgain == "y" )
            {
                RunGame();
            }
            else
            {
                return;
            }
        }

    }
}
