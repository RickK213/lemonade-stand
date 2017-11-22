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
        }

        //member methods
        void SetUpGame()
        {
            Console.WriteLine("Let's set up the game!");
            numPlayers = int.Parse(ui.GetValidUserOption("How many players?", new List<string>() { "1", "2" }));
            numDaysInGame = int.Parse(ui.GetValidUserOption("How many days would you like to play for?", new List<string>() { "7", "14", "30" }));
        }

        void AddPlayersToGame()
        {
            for (int i=0; i<numPlayers; i++)
            {
                Player player = new Player();
                players.Add(player);
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
