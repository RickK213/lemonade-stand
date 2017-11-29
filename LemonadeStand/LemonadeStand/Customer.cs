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
        int priceSensitivity;
        int temperatureSensitivity;
        int lemonadeSensitivity;
        bool isPriceSensitive;
        bool isTemperatureSensitive;
        bool lovesLemonade;

        //constructor
        public Customer(Random random)
        {
            priceSensitivity = random.Next(1,3);
            if(priceSensitivity == 1)
            {
                isPriceSensitive = true;
            }
            temperatureSensitivity = random.Next(1,3);
            if (temperatureSensitivity == 1)
            {
                isTemperatureSensitive = true;
            }
            lemonadeSensitivity = random.Next(1, 9);
            if (lemonadeSensitivity == 1)
            {
                lovesLemonade = true;
            }
        }

        //member methods
        public bool MakesPurchase(int minLemonadePrice, int maxLemonadePrice, decimal minTemperature, decimal maxTemperature, int highTemp, int pricePerCup)
        {
            int bottomTierOfPrice = ((maxLemonadePrice - minLemonadePrice) / 3) + minLemonadePrice;
            decimal topTierOfTemperature = maxTemperature - ((maxTemperature - minTemperature) / 3);

            if ((highTemp > topTierOfTemperature) && isTemperatureSensitive)
            {
                return true;
            }
            else if ((pricePerCup < bottomTierOfPrice) && isPriceSensitive)
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
