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

        //constructor
        public Customer(Game game, Player player)
        {
            this.game = game;
            this.player = player;
        }

        //member methods
        public bool MakesPurchase()
        {
            int minRange = 0;
            int maxRange = 8;
            if ( game.day.weather.highTemp > (game.maxTemperature-game.minTemperature/2 + game.minTemperature) )
            {
                maxRange -= 2;
            }
            if ( player.recipe.pricePerCup < (game.maxLemonadePrice-game.minLemonadePrice/2 + game.minLemonadePrice) )
            {
                maxRange -= 2;
            }
            int doesPurchase = game.random.Next(minRange,maxRange);
            if ( doesPurchase == 1 )
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
