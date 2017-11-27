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

        //constructor
        public Game()
        {
            players = new List<Player>();
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
            player.money -= supplyBundle.price;
            for (int i=0; i<supplyBundle.quantity; i++)
            {
                if (supplyBundle.supply.name == "Paper Cup")
                {
                    player.inventory.paperCups.Add(supplyBundle.supply);
                }
                else if (supplyBundle.supply.name == "Lemon")
                {
                    player.inventory.lemons.Add(supplyBundle.supply);
                }
                else if (supplyBundle.supply.name == "Cup of Sugar")
                {
                    player.inventory.cupsOfSugar.Add(supplyBundle.supply);
                }
                else if (supplyBundle.supply.name == "Ice Cubes")
                {
                    player.inventory.iceCubes.Add(supplyBundle.supply);
                }

            }
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
                //display day number and current money
                int currentDay = i + 1;
                day = new Day();
                foreach (Player player in players)
                {
                    int inventoryPurchaseChoice = 0;
                    while (inventoryPurchaseChoice !=5)
                    {
                        UI.DisplayPlayerInventory(player, currentDay, day);
                        UI.DisplayMenuHeader();
                        inventoryPurchaseChoice = int.Parse(UI.GetValidUserOption("1: Buy Paper Cups\n2: Buy Lemons\n3: Buy Cups of Sugar\n4: Buy Ice Cubes\n5: Done purchasing - Set my recipe!", new List<string>() { "1", "2", "3", "4", "5" }));
                        if (inventoryPurchaseChoice != 5)
                        {
                            SupplyBundle supplyBundle = UI.GetSupplyBundle(inventoryPurchaseChoice);
                            AddBundleToPlayerInventory(player, supplyBundle);
                            Console.WriteLine("You Selected:");
                            Console.WriteLine("{0} {1} for ${2}", supplyBundle.quantity, supplyBundle.supply.pluralName, supplyBundle.price);
                        }
                    }
                    Console.WriteLine("You're done purchasing, yo.");
                }
                //display high temperature (50-95 degrees) & rain forecast
                //each player buys inventory
                //each player sets price/quality control
                //run day:
                //inventory losses - some lemons spoil and all ice melts
                //get number of total customers - random dependent on price, weather and customer satisfaction
                //If the weather is bad, and your price is high, don't expect too many (maybe 15-25).  But if the weather is hot and clear, and your prices are reasonable, you can expect about 50-75 customers.
                //get number of customers that purchase - random dependent on customer satisfaction
                //get number of satisfied customers - dependent on price, recipe
                //calculate overall popularity based on the day's customer satisfaction
                //end of day report
                Console.ReadKey();
            }
            //end of season report:
            //Total Income
            //Total Expenses
            //Liquidated Inventory Value
            //Net Profit/Loss

        }

    }
}
