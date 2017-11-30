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

        public static void DisplayIntroScreen()
        {
            ResizeConsoleWindow();
            DisplayTitle();
            DisplayInstructions();
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

        public static void DisplayPlayerInventory(HumanPlayer player, int currentDay, Day day)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} - PURCHASE YOUR INVENTORY FOR DAY {1}", player.name, currentDay);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nCurrent Inventory=============================");
            Console.ResetColor();
            Console.WriteLine("{0} Paper Cups", player.inventory.paperCups.Count);
            Console.WriteLine("{0} Lemons", player.inventory.lemons.Count);
            Console.WriteLine("{0} Cups of Sugar", player.inventory.cupsOfSugar.Count);
            Console.WriteLine("{0} Ice Cubes", player.inventory.iceCubes.Count);
            DisplayDailyInfo(currentDay, day, player);
        }

        public static void DisplayPlayerRecipe(HumanPlayer player, int currentDay, Day day)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} - SET YOUR PRICE AND RECIPE FOR DAY {1}", player.name, currentDay);
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
        public static void DisplayDailyInfo(int currentDay, Day day, HumanPlayer player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nDaily Information=============================");
            Console.ResetColor();
            Console.WriteLine("Day: {0}", currentDay);
            Console.WriteLine("Money: {0:C2}", player.money);
            Console.WriteLine("Predicted High Temperature: {0}°", day.weather.predictedHighTemp);
            Console.WriteLine("Predicted Precipitation: {0}", day.weather.predictedForecast);
        }

        public static void DisplayPurchaseOptions(Supply supply)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Acquisition: {0}\n", supply.pluralName);
            Console.ResetColor();
            Console.WriteLine("You can buy:");
            Console.WriteLine("1: {0} {1} for {2:C2}", supply.bundle1.quantity, supply.pluralName, supply.bundle1.price);
            Console.WriteLine("2: {0} {1} for {2:C2}", supply.bundle2.quantity, supply.pluralName, supply.bundle2.price);
            Console.WriteLine("3: {0} {1} for {2:C2}", supply.bundle3.quantity, supply.pluralName, supply.bundle3.price);
        }

        public static SupplyBundle GetSupplyBundle(int supplyBundleChoice, HumanPlayer player, Random random)
        {
            SupplyBundle chosenBundle;

            Supply supply = new Supply();

            //TO DO: Figure out a better way to do the below stuff. It's bad to create objects you don't need.
            switch (supplyBundleChoice)
            {
                case 1:
                    supply = new PaperCup();
                    break;
                case 2:
                    supply = new Lemon(random);
                    break;
                case 3:
                    supply = new CupOfSugar();
                    break;
                case 4:
                    supply = new IceCube();
                    break;
                default:
                    break;
            }

            DisplayPurchaseOptions(supply);

            int bundleSelection = int.Parse(UI.GetValidUserOption("", new List<string>() { "1", "2", "3" }));

            if ( bundleSelection == 1 )
            {
                chosenBundle = supply.bundle1;
            }
            else if (bundleSelection == 2)
            {
                chosenBundle = supply.bundle2;
            }
            else
            {
                chosenBundle = supply.bundle3;
            }

            if (player.money<chosenBundle.price)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, you don't have enough money to make this purchase.");
                Console.ResetColor();
                GetAnyKeyToContinue("continue", false);
                return GetSupplyBundle(supplyBundleChoice, player, random);
            }

            return chosenBundle;

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

        public static int GetRecipeValue(int menuSelection, HumanPlayer player, Game game)
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
            Console.WriteLine("You don't have enough money to buy the cheapest supply.");
            Console.ResetColor();
            GetAnyKeyToContinue("set your recipe", false);
        }
        
        public static void DisplaySalesReport(HumanPlayer player, int currentDay, Day day, int numberOfPurchases, int numberOfCustomers)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}'s DAY {1} SALES REPORT", player.name, currentDay);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEnd of Day Report=============================");
            Console.ResetColor();
            Console.WriteLine($"You managed to sell {numberOfPurchases} cups of lemonade to {numberOfCustomers} potential customers.");
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
            Console.WriteLine("Money: {0:C2}", player.money);
            Console.WriteLine("Predicted High Temperature: {0}°", day.weather.predictedHighTemp);
            Console.WriteLine("   Actual High Temperature: {0}°", day.weather.actualHighTemp);
            Console.WriteLine("Predicted Precipitation: {0}", day.weather.predictedForecast);
            Console.WriteLine("   Actual Precipitation: {0}", day.weather.actualForecast);
            GetAnyKeyToContinue("view your inventory report", true);

        }

        public static void DisplayInventoryLosses(int numberOfIceCubesLost, int numberOfLemonsLost, int cupsOfSugarLost)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (numberOfIceCubesLost > 0)
            {
                Console.WriteLine($"Your remaining ice has melted. You lost {numberOfIceCubesLost} cubes.");
            }
            if (numberOfLemonsLost > 0)
            {
                Console.WriteLine($"{numberOfLemonsLost} of your remaining lemons spoiled.");
            }
            if (cupsOfSugarLost > 0)
            {
                Console.WriteLine($"You got bugs in your sugar! You lost {cupsOfSugarLost} cups of sugar.");
            }
            Console.ResetColor();
        }

        public static void DisplaySupplyShortages(HumanPlayer player, int numberOfIceCubesLost, int cupsOfSugarLost, int numberOfLemonsLost)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (player.inventory.paperCups.Count == 0)
            {
                Console.WriteLine("You did not have enough Paper Cups to meet demand");
            }
            if (player.inventory.lemons.Count == 0 && numberOfLemonsLost == 0)
            {
                Console.WriteLine("You did not have enough Lemons to meet demand");
            }
            if (player.inventory.cupsOfSugar.Count == 0 && cupsOfSugarLost == 0 )
            {
                Console.WriteLine("You did not have enough Sugar to meet demand");
            }
            if (numberOfIceCubesLost == 0)
            {
                Console.WriteLine("You did not have enough Ice Cubes to meet demand");
            }
            Console.ResetColor();
        }

        public static void DisplayDailyInventoryReport(int numberOfIceCubesLost, int numberOfLemonsLost, int cupsOfSugarLost, int currentDay, HumanPlayer player, bool isSoldOut)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}'s DAY {1} INVENTORY REPORT", player.name, currentDay);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nSupply Shortages==============================");
            Console.ResetColor();

            if ( isSoldOut )
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

        public static void DisplayEndOfSeasonReport(List<HumanPlayer> players)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("END OF SEASON REPORT\n");
            Console.ResetColor();
            foreach (HumanPlayer player in players)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{player.name}'s Results:");
                Console.WriteLine("==============================================");
                Console.ResetColor();
                Console.WriteLine($"Total Income: {0:C2}", player.totalIncome);
                Console.WriteLine($"Total Expenses: {0:C2}", player.totalExpenses);
                Console.WriteLine($"Total Profit: {0:C2}", player.totalProfit);
                //Liquidated Inventory Value (add unit cost of lost inventory to player's total)
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
