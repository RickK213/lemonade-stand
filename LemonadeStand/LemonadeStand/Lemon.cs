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
            bundle1 = new SupplyBundle(10, .99, this);
            bundle2 = new SupplyBundle(30, 2.03, this);
            bundle3 = new SupplyBundle(75, 4.13, this);
            supplyBundles.Add(bundle1);
            supplyBundles.Add(bundle2);
            supplyBundles.Add(bundle3);
            daysUntilSpoiled = random.Next(2, 6);
        }

        //member methods

    }
}
