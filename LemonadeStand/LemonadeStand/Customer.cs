using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        //member variables
        Game game;
        Player player;
        int priceSensitivity;
        int temperatureSensitivity;
        int lemonadeSensitivity;
        bool isPriceSensitive;
        bool isTemperatureSensitive;
        bool lovesLemonade;

        //constructor
        public Customer(Game game, Player player)
        {
            this.game = game;
            this.player = player;
            priceSensitivity = game.random.Next(1,3);
            if(priceSensitivity == 1)
            {
                isPriceSensitive = true;
            }
            temperatureSensitivity = game.random.Next(1,3);
            if (temperatureSensitivity == 1)
            {
                isTemperatureSensitive = true;
            }
            lemonadeSensitivity = game.random.Next(1, 9);
            if (lemonadeSensitivity == 1)
            {
                lovesLemonade = true;
            }

        }

        //member methods
        public bool MakesPurchase()
        {
            int bottomTierOfPrice = ((game.maxLemonadePrice - game.minLemonadePrice) / 3) + game.minLemonadePrice;
            decimal topTierOfTemperature = game.maxTemperature - ((game.maxTemperature - game.minTemperature) / 3);

            if ((game.day.weather.highTemp > topTierOfTemperature) && isTemperatureSensitive)
            {
                return true;
            }
            else if ((player.recipe.pricePerCup < bottomTierOfPrice) && isPriceSensitive)
            {
                return true;
            }
            else if (lovesLemonade)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
