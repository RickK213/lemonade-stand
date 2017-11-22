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
        UserInterface ui;

        //constructor
        public Game()
        {
            ui = new UserInterface();
            players = new List<Player>();
        }

        //member methods
        void SetUpGame()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("LET'S SET UP SOME GAME OPTIONS!\n");
            Console.ResetColor();
            numPlayers = int.Parse(ui.GetValidUserOption("How many players?", new List<string>() { "1", "2" }));
            numDaysInGame = int.Parse(ui.GetValidUserOption("How many days would you like to play for?", new List<string>() { "7", "14", "30" }));
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

        public void RunGame()
        {
            ui.DisplayIntroScreen();
            SetUpGame();
            AddPlayersToGame();
            //game loop
            for (int i=0; i<numDaysInGame; i++)
            {

            }

        }

    }
}
