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
        public int predictedHighTemp;
        public int actualHighTemp;
        public List<string> forecastVariables = new List<string>() { "Sunny & Clear", "Overcast", "Cloudy", "Rainy" };
        public string predictedForecast;
        public string actualForecast;
        int predictedForecastIndex;
        Random random;
        
        //constructor
        //SOLID NOTE: originaly I passed in the whole game object. That's bad. Now I only pass in the relevant information.
        public Weather(Random random, decimal minTemperature, decimal maxTemperature)
        {
            this.random = random;
            predictedHighTemp = random.Next(Decimal.ToInt32(minTemperature), Decimal.ToInt32(maxTemperature+1));
            predictedForecastIndex = random.Next(0,forecastVariables.Count);
            predictedForecast = forecastVariables[predictedForecastIndex];
        }

        //member methods
        public void setActualWeather()
        {
            int temperatureDifference = random.Next(-10,11);
            actualHighTemp = predictedHighTemp + temperatureDifference;

            int forecastIndexDifference = random.Next(0,forecastVariables.Count);
            int actualForecastIndex = predictedForecastIndex + forecastIndexDifference;
            if (actualForecastIndex > forecastVariables.Count-1)
            {
                actualForecastIndex -= forecastVariables.Count; 
            }
            actualForecast = forecastVariables[actualForecastIndex];
        }

    }
}
