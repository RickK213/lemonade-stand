using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        //TO DO: Check to be sure all of these need to be public and maybe move appropriate stuff to other classes
        //member variables
        Database database;
        public Random random;
        int numPlayersInGame;
        public Day day;
        int numDaysInGame;
        int currentDay;
        List<Player> players;
        Store store;
        public int minTemperature;
        public int maxTemperature;
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

        //constructor
        public Game()
        {
            database = new Database();
            random = new Random();
            players = new List<Player>();
            store = new Store(random);
            store.SetDailyBundlePrices();
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
            numPlayersInGame = int.Parse(UI.GetValidUserOption("How many players?", new List<string>() { "1", "2" }));
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
            //TO DO: figure out a way to avoid passing in the Store class to the computer player
            ComputerPlayer player = new ComputerPlayer(random, store);
            players.Add(player);
        }

        void AddPlayersToGame()
        {
            AddHumanPlayer(1);
            if ( numPlayersInGame == 2 )
            {
                AddHumanPlayer(2);
            }
            else
            {
                AddComputerPlayer();
            }
        }

        decimal AdjustMinNumberOfCustomersBasedOnTemp(decimal dailyMinNumberOfCustomers, decimal numberOfVariableBreaks)
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

        decimal AdjustMinNumberOfCustomersBasedOnPrice(decimal dailyMinNumberOfCustomers, decimal numberOfVariableBreaks, int pricePerCup)
        {
            decimal priceSpan = (maxLemonadePrice - minLemonadePrice) / numberOfVariableBreaks;
            if ((pricePerCup >= minLemonadePrice) && (pricePerCup < minLemonadePrice + priceSpan))
            {
                dailyMinNumberOfCustomers += priceMultiplier * 2;
            }
            else if ( (pricePerCup >= minLemonadePrice + priceSpan) && (pricePerCup < minLemonadePrice + priceSpan*2) )
            {
                dailyMinNumberOfCustomers += priceMultiplier;
            }

            return dailyMinNumberOfCustomers;
        }

        decimal AdjustMinNumberOfCustomersBasedOnPrecipitation(decimal dailyMinNumberOfCustomers)
        {

            if ( day.weather.actualPrecipitation == "Overcast" )
            {
                dailyMinNumberOfCustomers += forecastMultiplier;
            }
            else if ( day.weather.actualPrecipitation == "Sunny & Clear" )
            {
                dailyMinNumberOfCustomers += forecastMultiplier * 2;
            }

            return dailyMinNumberOfCustomers;
        }

        decimal AdjustMaxNumberOfCustomersBasedOnTemp(decimal dailyMaxNumberOfCustomers, decimal numberOfVariableBreaks)
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

        decimal AdjustMaxNumberOfCustomersBasedOnPrice(decimal dailyMaxNumberOfCustomers, decimal numberOfVariableBreaks, int pricePerCup)
        {
            decimal priceSpan = (maxLemonadePrice - minLemonadePrice) / numberOfVariableBreaks;
            if ((decimal)pricePerCup > minLemonadePrice + priceSpan * 3)
            {
                dailyMaxNumberOfCustomers -= priceMultiplier * 2;
            }
            else if ( (pricePerCup >= minLemonadePrice + priceSpan * 2) && (pricePerCup <= minLemonadePrice + priceSpan * 3)  )
            {
                dailyMaxNumberOfCustomers -= priceMultiplier;
            }

            return dailyMaxNumberOfCustomers;
        }

        decimal AdjustMaxNumberOfCustomersBasedOnPrecipitation(decimal dailyMaxNumberOfCustomers)
        {

            if (day.weather.actualPrecipitation == "Cloudy")
            {
                dailyMaxNumberOfCustomers -= forecastMultiplier;
            }
            else if (day.weather.actualPrecipitation == "Rainy")
            {
                dailyMaxNumberOfCustomers -= forecastMultiplier * 2;
            }

            return dailyMaxNumberOfCustomers;
        }

        int GetNumberOfCustomers(int pricePerCup)
        {
            //TO DO: add in player popularity as a determining factor for number of customers
            decimal dailyMinNumberOfCustomers = minNumberOfCustomers;
            decimal dailyMaxNumberOfCustomers = maxNumberOfCustomers;

            dailyMinNumberOfCustomers = AdjustMinNumberOfCustomersBasedOnTemp(dailyMinNumberOfCustomers, numberOfVariableBreaks);
            dailyMaxNumberOfCustomers = AdjustMaxNumberOfCustomersBasedOnTemp(dailyMaxNumberOfCustomers, numberOfVariableBreaks);

            dailyMinNumberOfCustomers = AdjustMinNumberOfCustomersBasedOnPrecipitation(dailyMinNumberOfCustomers);
            dailyMaxNumberOfCustomers = AdjustMaxNumberOfCustomersBasedOnPrecipitation(dailyMaxNumberOfCustomers);

            dailyMinNumberOfCustomers = AdjustMinNumberOfCustomersBasedOnPrice(dailyMinNumberOfCustomers, numberOfVariableBreaks, pricePerCup);
            dailyMaxNumberOfCustomers = AdjustMaxNumberOfCustomersBasedOnPrice(dailyMaxNumberOfCustomers, numberOfVariableBreaks, pricePerCup);

            return random.Next(Decimal.ToInt32(dailyMinNumberOfCustomers), Decimal.ToInt32(dailyMaxNumberOfCustomers + 1));
        }

        void RunDailyLemonadeStand(Player player)
        {
            //TO DO: This is a super long method. Break up into helper methods!
            int numberOfPurchases = 0;
            int numberOfCustomers = GetNumberOfCustomers(player.recipe.pricePerCup);
            bool isSoldOut = false;
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < numberOfCustomers; i++)
            {
                customers.Add(new Customer(random));
            }
            foreach (Customer customer in customers)
            {
                isSoldOut = player.checkForSoldOut(cupsPerPitcher);
                if (!isSoldOut)
                {
                    if (customer.MakesPurchase(minLemonadePrice, maxLemonadePrice, minTemperature, maxTemperature, day.weather.actualHighTemp, player.recipe.pricePerCup))
                    {
                        numberOfPurchases++;
                        double moneyMade = (double)Decimal.Divide(player.recipe.pricePerCup, 100);
                        player.moneyAvailable = Math.Round((player.moneyAvailable + moneyMade), 2);
                        player.dailyIncome = Math.Round((player.dailyIncome + moneyMade), 2);
                        player.totalIncome = Math.Round((player.totalIncome + moneyMade), 2);

                        int lemonsUsed = Decimal.ToInt32(Decimal.Divide(player.recipe.lemonsPerPitcher, cupsPerPitcher));
                        player.inventory.lemons.RemoveRange(0, lemonsUsed);

                        player.inventory.paperCups.RemoveAt(0);

                        int cupsOfSugarUsed = Decimal.ToInt32(Decimal.Divide(player.recipe.sugarPerPitcher, cupsPerPitcher));
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
                player.notEnoughSugar = true;
            }

            UI.DisplayDailyInventoryReport(numberOfIceCubesLost, numberOfLemonsLost, cupsOfSugarLost, currentDay, player, isSoldOut);
            //TO DO: get number of satisfied customers - dependent on price, recipe
            //TO DO: calculate overall popularity based on the day's customer satisfaction
        }

        public void RunGame()
        {
            string leaderboard = database.GetLeaderboard();
            UI.DisplayIntroScreen(leaderboard);
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
                    player.notEnoughIce = true;
                    double cheapestSupplyBundle = store.GetCheapestSupplyBundlePrice();
                    player.PurchaseInventory(cheapestSupplyBundle, currentDay, day, store);
                    player.SetRecipe(currentDay, day, this);
                    RunDailyLemonadeStand(player);
                }
            }
            database.SavePlayerScores(players);
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
