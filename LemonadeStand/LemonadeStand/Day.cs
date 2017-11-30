using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Day
    {
        //member varialbes
        public Weather weather;

        //constructor
        public Day(Random random, decimal minTemperature, decimal maxTemperature)
        {
            weather = new Weather(random, minTemperature, maxTemperature);
        }

        //member methods

    }
}
