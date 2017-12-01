using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public static class UI
    {
        // You have 7, 14, or 21 days to make as much money as possible, and you’ve decided to open a lemonade stand! You’ll have complete control over your business, including pricing, quality control, inventory control, and purchasing supplies.Buy your ingredients, set your recipe, and start selling!
        // The first thing you’ll have to worry about is your recipe. At first, go with the default recipe, but try to experiment a little bit and see if you can find a better one. Make sure you buy enough of all your ingredients, or you won’t be able to sell!
        // You’ll also have to deal with the weather, which will play a big part when customers are deciding whether or not to buy your lemonade.Read the weather report every day! When the temperature drops, or the weather turns bad (overcast, cloudy, rain), don’t expect them to buy nearly as much as they would on a hot, hazy day, so buy accordingly.Feel free to set your prices higher on those hot, muggy days too, as you’ll make more profit, even if you sell a bit less lemonade.
        //The other major factor which comes into play is your customer’s satisfaction. As you sell your lemonade, people will decide how much they like or dislike it.  This will make your business more or less popular.If your popularity is low, fewer people will want to buy your lemonade, even if the weather is hot and sunny.But if you’re popularity is high, you’ll do okay, even on a rainy day!
        //At the end of 7, 14, or 21 days you’ll see how much money you made.Play again, and try to beat your high score!


        //member variables
        //DON'T WRITE ANY MEMBER VARIABLES!! STATIC CLASSES SHOULD NOT HAVE MEMBER VARIABLES!!!


        //member methods
        public static void DisplayTitle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"                      WELCOME TO:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@".____                                            .___      ");
            Console.WriteLine(@"|    |    ____   _____   ____   ____ _____     __| _/____  ");
            Console.WriteLine(@"|    |  _/ __ \ /     \ /  _ \ /    \\__  \   / __ |/ __ \ ");
            Console.WriteLine(@"|    |__\  ___/|  Y Y  (  <_> )   |  \/ __ \_/ /_/ \  ___/ ");
            Console.WriteLine(@"|_______ \___  >__|_|  /\____/|___|  (____  /\____ |\___  >");
            Console.WriteLine(@"        \/   \/      \/            \/     \/      \/    \/ ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"          _________ __                     .___            ");
            Console.WriteLine(@"         /   _____//  |______    ____    __| _/            ");
            Console.WriteLine(@"         \_____  \\   __\__  \  /    \  / __ |             ");
            Console.WriteLine(@"         /        \|  |  / __ \|   |  \/ /_/ |             ");
            Console.WriteLine(@"        /_______  /|__| (____  /___|  /\____ |             ");
            Console.WriteLine(@"                \/           \/     \/      \/             ");
            Console.ResetColor();
        }

        public static void DisplayInstructions()
        {
            Console.WriteLine("\nYou have 7, 14, or 21 days to make as much money as possible, and you’ve decided");
            Console.WriteLine("to open a lemonade stand! You’ll have complete control over your business,");
            Console.WriteLine("including pricing, quality control, inventory control, and purchasing supplies.");
            Console.WriteLine("Buy your ingredients, set your recipe, and start selling!");
            Console.WriteLine("\nThe first thing you’ll have to worry about is your recipe. At first, go with the");
            Console.WriteLine("default recipe, but try to experiment a little bit and see if you can find a");
            Console.WriteLine("better one. Make sure you buy enough of all your ingredients, or you won’t be");
            Console.WriteLine("able to sell!");
            Console.WriteLine("\nYou’ll also have to deal with the weather, which will play a big part when customers");
            Console.WriteLine("are deciding whether or not to buy your lemonade.Read the weather report every day!");
            Console.WriteLine("When the temperature drops, or the weather turns bad (overcast, cloudy, rain), don’t");
            Console.WriteLine("expect them to buy nearly as much as they would on a hot, hazy day, so buy accordingly.");
            Console.WriteLine("Feel free to set your prices higher on those hot, muggy days too, as you’ll make more");
            Console.WriteLine("profit, even if you sell a bit less lemonade.");
            Console.WriteLine("\nThe other major factor which comes into play is your customer’s satisfaction.");
            Console.WriteLine("As you sell your lemonade, people will decide how much they like or dislike it.");
            Console.WriteLine("This will make your business more or less popular. If your popularity is low, fewer");
            Console.WriteLine("people will want to buy your lemonade, even if the weather is hot and sunny.");
            Console.WriteLine("But if you’re popularity is high, you’ll do okay, even on a rainy day!");
            Console.WriteLine("\nAt the end of 7, 14, or 21 days you’ll see how much money you made.");
            Console.WriteLine("Play again, and try to beat your high score!");
            Console.WriteLine();
        }

        public static void GetAnyKeyToContinue(string nextAction, bool doClearAfter)
        {
            Console.WriteLine("\nPress any key to {0}.", nextAction);
            Console.ReadKey();
            if (doClearAfter)
            {
                Console.Clear();
            }
        }

        public static void DisplayIntroScreen(string leaderboard)
        {
            ResizeConsoleWindow();
            DisplayTitle();
            DisplayInstructions();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(leaderboard);
            Console.ResetColor();
            GetAnyKeyToContinue("start playing", true);
        }

        public static void ResizeConsoleWindow()
        {
            Console.SetWindowSize(Console.LargestWindowWidth-120, Console.LargestWindowHeight-15);
        }

        public static void DisplayValidOptions(List<string> validOptions)
        {
            Console.Write("Enter ");
            for (int i = 0; i < validOptions.Count; i++)
            {
                if (i == validOptions.Count - 1)
                {
                    Console.Write(" or ");
                }
                Console.Write("'");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(validOptions[i]);
                Console.ResetColor();
                Console.Write("'");
                if (i < validOptions.Count - 2)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }

        public static string GetValidUserOption(string instruction, List<string> validOptions)
        {
            Console.WriteLine(instruction);
            DisplayValidOptions(validOptions);
            string userInput = Console.ReadLine();
            if (!validOptions.Contains(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("'{0}' is an invalid option. Please read the instructions.", userInput);
                Console.ResetColor();
                return GetValidUserOption(instruction, validOptions);
            }
            Console.WriteLine();
            return userInput;
        }

        public static void DisplayPlayerInventory(Player player, int currentDay, Day day)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} - INVENTORY FOR DAY {1}", player.name, currentDay);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nCurrent Inventory=============================");
            Console.ResetColor();
            Console.WriteLine("{0} Paper Cups", player.inventory.paperCups.Count);
            Console.WriteLine("{0} Lemons", player.inventory.lemons.Count);
            Console.WriteLine("{0} Cups of Sugar", player.inventory.cupsOfSugar.Count);
            Console.WriteLine("{0} Ice Cubes", player.inventory.iceCubes.Count);
            DisplayDailyInfo(currentDay, day, player);
        }

        public static void DisplayPlayerRecipe(Player player, int currentDay, Day day)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} - PRICE AND RECIPE FOR DAY {1}", player.name, currentDay);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nCurrent Price/Recipe==========================");
            Console.ResetColor();
            Console.WriteLine("     Price per Cup: {0} Cents", player.recipe.pricePerCup);
            Console.WriteLine("Lemons per Pitcher: {0} Lemons", player.recipe.lemonsPerPitcher);
            Console.WriteLine(" Sugar per Pitcher: {0} Cups", player.recipe.sugarPerPitcher);
            Console.WriteLine("       Ice per Cup: {0} Cubes", player.recipe.icePerCup);
            Console.ResetColor();
            DisplayDailyInfo(currentDay, day, player);
        }

        public static void DisplayMenuHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nMenu Options==================================");
            Console.ResetColor();
        }
        public static void DisplayDailyInfo(int currentDay, Day day, Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nDaily Information=============================");
            Console.ResetColor();
            Console.WriteLine("Day: {0}", currentDay);
            Console.WriteLine("Money: {0:C2}", player.moneyAvailable);
            Console.WriteLine("Predicted High Temperature: {0}°", day.weather.predictedHighTemp);
            Console.WriteLine("Predicted Precipitation: {0}", day.weather.predictedPrecipitation);
        }

        public static void DisplayBundlePurchaseOptions(List<SupplyBundle> supplyBundleList, double playerMoney)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Acquisition: {0}", supplyBundleList[0].typeOfSupply);
            Console.ResetColor();
            Console.WriteLine("Funds available: {0:C2}\n", playerMoney);
            Console.WriteLine("You can buy:");
            for ( int i=0; i<supplyBundleList.Count; i++ )
            {
                Console.WriteLine( (i + 1) + ": {0} {1} for {2:C2}", supplyBundleList[i].quantity, supplyBundleList[i].typeOfSupply, supplyBundleList[i].price);
            }
        }

        public static int GetUserIntegerInRange(string instruction, int min, int max)
        {
            Console.WriteLine(instruction);
            string userSelection = Console.ReadLine();
            int userSelectionNumber;
            if (!int.TryParse(userSelection, out userSelectionNumber) || !(userSelectionNumber >= min) || !(userSelectionNumber <= max))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, that is not a valid number. Please enter a number between {0} and {1}.", min, max);
                Console.ResetColor();
                return GetUserIntegerInRange(instruction, min, max);
            }
            else
            {
                return userSelectionNumber;
            }
        }

        public static int GetRecipeValue(int menuSelection, Player player, Game game)
        {
        Console.Clear();
            switch (menuSelection)
            {
                case 1:
                    Console.WriteLine("Your current Price per Cup is {0} Cents.", player.recipe.pricePerCup);
                    return GetUserIntegerInRange("Enter your new Price per Cup in Cents (" + game.minLemonadePrice + "-" + game.maxLemonadePrice + "):", Decimal.ToInt32(game.minLemonadePrice), Decimal.ToInt32(game.maxLemonadePrice));
                case 2:
                    Console.WriteLine("Your current Lemons per Pitcher is {0} Lemons.", player.recipe.lemonsPerPitcher);
                    return GetUserIntegerInRange("Enter your new Lemons per Pitcher (" + game.minLemonsPerPitcher + "-" + game.maxLemonsPerPitcher + "):", Decimal.ToInt32(game.minLemonsPerPitcher), Decimal.ToInt32(game.maxLemonsPerPitcher));
                case 3:
                    Console.WriteLine("Your current Sugar per Pitcher is {0} Cups.", player.recipe.sugarPerPitcher);
                    return GetUserIntegerInRange("Enter your new cups of Sugar per Pitcher (" + game.minSugarPerPitcher + "-" + game.maxSugarPerPitcher + "):", Decimal.ToInt32(game.minSugarPerPitcher), Decimal.ToInt32(game.maxSugarPerPitcher));
                case 4:
                    Console.WriteLine("Your current Ice per Cup is {0} Cubes.", player.recipe.icePerCup);
                    return GetUserIntegerInRange("Enter your new cubes of Ice per Cup (" + game.minIcePerCup + "-" + game.maxIcePerCup + "):", Decimal.ToInt32(game.minIcePerCup), Decimal.ToInt32(game.maxIcePerCup));
                default:
                    return 0;
            }
        }

        public static void DisplayBankruptMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou don't have enough money to buy the cheapest supply.");
            Console.ResetColor();
            GetAnyKeyToContinue("set your recipe", false);
        }
        
        public static void DisplaySalesReport(Player player, int currentDay, Day day, int numberOfPurchases, int numberOfCustomers)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}'s DAY {1} SALES REPORT", player.name, currentDay);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEnd of Day Report=============================");
            Console.ResetColor();
            Console.WriteLine($"{numberOfPurchases} cups of lemonade were sold to {numberOfCustomers} potential customers.");
            Console.WriteLine("Daily Income: {0:C2}", player.dailyIncome);
            Console.WriteLine("Daily Expenses: {0:C2}", player.dailyExpenses);
            if ( player.dailyProfit > 0 )
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("Daily Profit: {0:C2}", player.dailyProfit);
            if (player.totalProfit > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("Total Profit To Date: {0:C2}", player.totalProfit);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nDaily Information=============================");
            Console.ResetColor();
            Console.WriteLine("Day: {0}", currentDay);
            Console.WriteLine("Money: {0:C2}", player.moneyAvailable);
            Console.WriteLine("Predicted High Temperature: {0}°", day.weather.predictedHighTemp);
            Console.WriteLine("   Actual High Temperature: {0}°", day.weather.actualHighTemp);
            Console.WriteLine("Predicted Precipitation: {0}", day.weather.predictedPrecipitation);
            Console.WriteLine("   Actual Precipitation: {0}", day.weather.actualPrecipitation);
            GetAnyKeyToContinue("view inventory report", true);

        }

        public static void DisplayInventoryLosses(int numberOfIceCubesLost, int numberOfLemonsLost, int cupsOfSugarLost)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (numberOfIceCubesLost > 0)
            {
                Console.WriteLine($"All remaining ice has melted. {numberOfIceCubesLost} cubes were lost.");
            }
            if (numberOfLemonsLost > 0)
            {
                Console.WriteLine($"{numberOfLemonsLost} of remaining lemons spoiled.");
            }
            if (cupsOfSugarLost > 0)
            {
                Console.WriteLine($"Bugs found in sugar! {cupsOfSugarLost} cups of sugar were lost.");
            }
            Console.ResetColor();
        }

        //TO DO: fix this so that it takes into account number of lemons & sugar is less than what recipe requires.
        public static void DisplaySupplyShortages(Player player, int numberOfIceCubesLost, int cupsOfSugarLost, int numberOfLemonsLost)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (player.notEnoughCups)
            {
                Console.WriteLine("Not enough Paper Cups to meet demand");
            }
            if (player.notEnoughLemons)
            {
                Console.WriteLine("Not enough Lemons to meet demand");
            }
            if (player.notEnoughSugar )
            {
                Console.WriteLine("Not enough Sugar to meet demand");
            }
            if (player.notEnoughIce)
            {
                Console.WriteLine("Not enough Ice Cubes to meet demand");
            }
            Console.ResetColor();
        }

        public static void DisplayDailyInventoryReport(int numberOfIceCubesLost, int numberOfLemonsLost, int cupsOfSugarLost, int currentDay, Player player, bool isSoldOut)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}'s DAY {1} INVENTORY REPORT", player.name, currentDay);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nSupply Shortages==============================");
            Console.ResetColor();

            if ( player.notEnoughCups || player.notEnoughIce || player.notEnoughLemons || player.notEnoughSugar)
            {
                DisplaySupplyShortages(player, numberOfIceCubesLost, cupsOfSugarLost, numberOfLemonsLost);
            }
            else
            {
                Console.WriteLine("No supply shortages to report.");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nInventory Losses==============================");
            Console.ResetColor();
            if (numberOfIceCubesLost > 0 || numberOfLemonsLost > 0 || cupsOfSugarLost > 0)
            {
                    DisplayInventoryLosses(numberOfIceCubesLost, numberOfLemonsLost, cupsOfSugarLost);
            }
            else
            {
                Console.WriteLine("No inventory losses to report.");
            }

            GetAnyKeyToContinue("continue", true);
        }

        public static void DisplayEndOfSeasonReport(List<Player> players)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("END OF SEASON REPORT\n");
            Console.ResetColor();
            foreach (Player player in players)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{player.name}'s Results:");
                Console.WriteLine("==============================================");
                Console.ResetColor();
                Console.WriteLine("Total Income: {0:C2}", player.totalIncome);
                Console.WriteLine("Total Expenses: {0:C2}", player.totalExpenses);
                Console.WriteLine("Total Profit: {0:C2}", player.totalProfit);
                //TO DO: Calculate liquidated Inventory Value (add unit cost of lost inventory to player's total)
                Console.WriteLine();
            }
            if (players[0].totalProfit == players[1].totalProfit)
            {
                Console.WriteLine($"{players[0].name} and {players[1].name} have tied!");
            }
            else if (players[0].totalProfit > players[1].totalProfit)
            {
                Console.WriteLine($"{players[0].name} has defeated {players[1].name}!");
            }
            else
            {
                Console.WriteLine($"{players[1].name} has defeated {players[0].name}!");
            }
        }

    }
}
