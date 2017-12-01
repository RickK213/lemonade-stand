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
        public List<string> precipitationVariables = new List<string>() { "Sunny & Clear", "Overcast", "Cloudy", "Rainy" };
        public string predictedPrecipitation;
        public string actualPrecipitation;
        int predictedPrecipitationIndex;
        Random random;
        
        //constructor
        public Weather(Random random, decimal minTemperature, decimal maxTemperature)
        {
            this.random = random;
            predictedHighTemp = random.Next(Decimal.ToInt32(minTemperature), Decimal.ToInt32(maxTemperature+1));
            predictedPrecipitationIndex = random.Next(0,precipitationVariables.Count);
            predictedPrecipitation = precipitationVariables[predictedPrecipitationIndex];
        }

        //member methods
        public void setActualWeather()
        {
            int temperatureDifference = random.Next(-10,11);
            actualHighTemp = predictedHighTemp + temperatureDifference;

            //TO DO: Rewrite below so that precipitation moves up or down by 1 in the index...more realistic
            int forecastIndexDifference = random.Next(0,precipitationVariables.Count);
            int actualForecastIndex = predictedPrecipitationIndex + forecastIndexDifference;
            if (actualForecastIndex > precipitationVariables.Count-1)
            {
                actualForecastIndex -= precipitationVariables.Count; 
            }
            actualPrecipitation = precipitationVariables[actualForecastIndex];
        }

    }
}
