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
        static void DisplayTitle()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"                      WELCOME TO:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@".____                                            .___      ");
            Console.WriteLine(@"|    |    ____   _____   ____   ____ _____     __| _/____  ");
            Console.WriteLine(@"|    |  _/ __ \ /     \ /  _ \ /    \\__  \   / __ |/ __ \ ");
            Console.WriteLine(@"|    |__\  ___/|  Y Y  (  <_> )   |  \/ __ \_/ /_/ \  ___/ ");
            Console.WriteLine(@"|_______|\____||__|_|  /\____/|___|__(______/\_____|\____>");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"            _________ __                     .___          ");
            Console.WriteLine(@"           /   _____//  |______    ____    __| _/          ");
            Console.WriteLine(@"           \_____  \\   __\__  \  /    \  / __ |           ");
            Console.WriteLine(@"           /        \|  |  / __ \|   |  \/ /_/ |           ");
            Console.WriteLine(@"          /_______  /|__| (____  /___|  /\____ |           ");
            Console.WriteLine(@"                  \/           \/     \/      \/           ");
            Console.ResetColor();
        }

        static void DisplayInstructions()
        {
            Console.WriteLine("\nYou have 7, 14, or 21 days to make as much money as possible, and you’ve decided");
            Console.WriteLine("to open a lemonade stand! You’ll have complete control over your business,");
            Console.WriteLine("including pricing, quality control, inventory control, and purchasing supplies.");
            Console.WriteLine("Buy your ingredients, set your recipe, and start selling!");
            Console.WriteLine("\nThe first thing you’ll have to worry about is your recipe. At first, go with the default recipe,");
            Console.WriteLine("but try to experiment a little bit and see if you can find a better one. Make sure you buy enough of");
            Console.WriteLine("all your ingredients, or you won’t be able to sell!");
            Console.WriteLine("\nYou’ll also have to deal with the weather, which will play a big part when customers are deciding whether");
            Console.WriteLine("or not to buy your lemonade.Read the weather report every day! When the temperature drops, or the weather turns bad");
            Console.WriteLine("(overcast, cloudy, rain), don’t expect them to buy nearly as much as they would on a hot, hazy day, so buy accordingly.");
            Console.WriteLine("Feel free to set your prices higher on those hot, muggy days too, as you’ll make more profit, even if you sell a bit less lemonade.");
            Console.WriteLine("\nThe other major factor which comes into play is your customer’s satisfaction. As you sell your lemonade, people will decide");
            Console.WriteLine("how much they like or dislike it.  This will make your business more or less popular.If your popularity is low, fewer people");
            Console.WriteLine("will want to buy your lemonade, even if the weather is hot and sunny.But if you’re popularity is high, you’ll do okay, even on a rainy day!");
            Console.WriteLine("\nAt the end of 7, 14, or 21 days you’ll see how much money you made.Play again, and try to beat your high score!");
        }

        public static void GetAnyKeyToContinue()
        {
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        public static void DisplayIntroScreen()
        {
            DisplayTitle();
            DisplayInstructions();
            GetAnyKeyToContinue();
        }

        public static void ResizeConsoleWindow()
        {
            Console.SetWindowSize(Console.LargestWindowWidth-25, Console.LargestWindowHeight-15);
        }
    }
}
