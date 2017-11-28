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


        //member methods
        public static void DisplayTitle()
        {
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

        public static void DisplayPlayerInventory(Player player, int currentDay, Day day)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} - PURCHASE YOUR INVENTORY", player.name);
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
            Console.WriteLine("{0} - SET YOUR PRICE AND RECIPE", player.name);
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
            Console.WriteLine("Money: {0:C2}", player.money);
            Console.WriteLine("High Temperature: {0}°", day.weather.highTemp);
            Console.WriteLine("Weather Forecast: {0}", day.weather.forecast);
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

        public static SupplyBundle GetSupplyBundle(int supplyBundleChoice, Player player)
        {
            SupplyBundle chosenBundle;

            Supply supply = new Supply();

            switch (supplyBundleChoice)
            {
                case 1:
                    supply = new PaperCup();
                    break;
                case 2:
                    supply = new Lemon();
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
                return GetSupplyBundle(supplyBundleChoice, player);
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

        public static int GetRecipeValue(int menuSelection, Player player, Game game)
        {
        Console.Clear();
            switch (menuSelection)
            {
                case 1:
                    Console.WriteLine("Your current Price per Cup is {0} Cents.", player.recipe.pricePerCup);
                    return GetUserIntegerInRange("Enter your new Price per Cup in Cents (1-100):", Decimal.ToInt32(game.minLemonadePrice), Decimal.ToInt32(game.maxLemonadePrice));
                case 2:
                    Console.WriteLine("Your current Lemons per Pitcher is {0} Lemons.", player.recipe.lemonsPerPitcher);
                    return GetUserIntegerInRange("Enter your new Lemons per Pitcher (1-20):", Decimal.ToInt32(game.minLemonsPerPitcher), Decimal.ToInt32(game.maxLemonsPerPitcher));
                case 3:
                    Console.WriteLine("Your current Sugar per Pitcher is {0} Cups.", player.recipe.sugarPerPitcher);
                    return GetUserIntegerInRange("Enter your new cups of Sugar per Pitcher (0-20):", Decimal.ToInt32(game.minSugarPerPitcher), Decimal.ToInt32(game.maxSugarPerPitcher));
                case 4:
                    Console.WriteLine("Your current Ice per Cup is {0} Cubes.", player.recipe.icePerCup);
                    return GetUserIntegerInRange("Enter your new cubes of Ice per Cup (0-10):", Decimal.ToInt32(game.minIcePerCup), Decimal.ToInt32(game.maxIcePerCup));
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

    }
}
