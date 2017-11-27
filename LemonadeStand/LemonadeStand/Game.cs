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

        //constructor
        public Game()
        {
            players = new List<Player>();
            gameSupplies = new List<Supply>() { new PaperCup(), new Lemon(), new CupOfSugar(), new IceCube() };
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
                day = new Day();
                foreach (Player player in players)
                {
                    int inventoryPurchaseChoice = 0;
                    double cheapestSupplyBundle = GetCheapestSupplyBundle();

                    //purchase loop
                    while ( (inventoryPurchaseChoice !=5) && (player.money>cheapestSupplyBundle) )
                    {
                        UI.DisplayPlayerInventory(player, currentDay, day);
                        UI.DisplayMenuHeader();
                        inventoryPurchaseChoice = int.Parse(UI.GetValidUserOption("1: Buy Paper Cups\n2: Buy Lemons\n3: Buy Cups of Sugar\n4: Buy Ice Cubes\n5: Done purchasing - Set my recipe!\n", new List<string>() { "1", "2", "3", "4", "5" }));
                        if (inventoryPurchaseChoice != 5)
                        {
                            SupplyBundle supplyBundle = UI.GetSupplyBundle(inventoryPurchaseChoice, player);
                            AddBundleToPlayerInventory(player, supplyBundle);
                        }
                    }
                    if ( player.money<cheapestSupplyBundle )
                    {
                        UI.DisplayPlayerInventory(player, currentDay, day);
                        UI.DisplayBankruptMessage();
                    }
                    //Set Daily Recipe
                    Console.Clear();
                    Console.WriteLine("Set your recipe.");

                }
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
