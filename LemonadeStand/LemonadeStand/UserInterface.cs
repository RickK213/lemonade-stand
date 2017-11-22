using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class UserInterface
    {
        // You have 7, 14, or 21 days to make as much money as possible, and you’ve decided to open a lemonade stand! You’ll have complete control over your business, including pricing, quality control, inventory control, and purchasing supplies.Buy your ingredients, set your recipe, and start selling!
        // The first thing you’ll have to worry about is your recipe. At first, go with the default recipe, but try to experiment a little bit and see if you can find a better one. Make sure you buy enough of all your ingredients, or you won’t be able to sell!
        // You’ll also have to deal with the weather, which will play a big part when customers are deciding whether or not to buy your lemonade.Read the weather report every day! When the temperature drops, or the weather turns bad (overcast, cloudy, rain), don’t expect them to buy nearly as much as they would on a hot, hazy day, so buy accordingly.Feel free to set your prices higher on those hot, muggy days too, as you’ll make more profit, even if you sell a bit less lemonade.
        //The other major factor which comes into play is your customer’s satisfaction. As you sell your lemonade, people will decide how much they like or dislike it.  This will make your business more or less popular.If your popularity is low, fewer people will want to buy your lemonade, even if the weather is hot and sunny.But if you’re popularity is high, you’ll do okay, even on a rainy day!
        //At the end of 7, 14, or 21 days you’ll see how much money you made.Play again, and try to beat your high score!

        
        //member variables



        //member methods
        void DisplayTitle()
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

        void DisplayInstructions()
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

        public void GetAnyKeyToContinue(string nextAction, bool doClearAfter)
        {
            Console.WriteLine("\nPress any key to {0}.", nextAction);
            Console.ReadKey();
            if (doClearAfter)
            {
                Console.Clear();
            }
        }

        public void DisplayIntroScreen()
        {
            ResizeConsoleWindow();
            DisplayTitle();
            DisplayInstructions();
            GetAnyKeyToContinue("start playing", true);
        }

        void ResizeConsoleWindow()
        {
            Console.SetWindowSize(Console.LargestWindowWidth-120, Console.LargestWindowHeight-15);
        }

        void DisplayValidOptions(List<string> validOptions)
        {
            Console.Write("Enter ");
            for (int i = 0; i < validOptions.Count; i++)
            {
                Console.Write("'");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(validOptions[i]);
                Console.ResetColor();
                Console.Write("'");
                if (i < validOptions.Count - 1)
                {
                    Console.Write(" or ");
                }
            }
            Console.WriteLine();
        }

        public string GetValidUserOption(string instruction, List<string> validOptions)
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
            return userInput;
        }
    }
}
