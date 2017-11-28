using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Weather
    {
        //member variables
        public int highTemp;
        public List<string> forecastVariables = new List<string>() { "Sunny & Clear", "Overcast", "Cloudy", "Rainy" };
        public string forecast;
        
        //constructor
        public Weather(Game game)
        {
            highTemp = game.random.Next(Decimal.ToInt32(game.minTemperature), Decimal.ToInt32(game.maxTemperature+1));
            int forecastIndex = game.random.Next(0,forecastVariables.Count);
            forecast = forecastVariables[forecastIndex];
        }

        //member methods
    }
}
