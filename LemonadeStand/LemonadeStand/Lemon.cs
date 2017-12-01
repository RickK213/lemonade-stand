using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Lemon : Supply
    {
        //member variables
        public int daysUntilSpoiled;

        //constructor
        public Lemon(Random random)
        {
            name = "Lemon";
            pluralName = "Lemons";
            daysUntilSpoiled = random.Next(2, 6);
        }

        //member methods

    }
}
