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
        public List<string> forecastVariables = new List<string>() { "Sunny & Clear", "Hazy", "Overcast", "Cloudy", "Rainy" };
        public string forecast;
        
        //constructor
        public Weather()
        {
            highTemp = UI.random.Next(50,95);
            int forecastIndex = UI.random.Next(0,forecastVariables.Count);
            forecast = forecastVariables[forecastIndex];
        }

        //member methods
    }
}
