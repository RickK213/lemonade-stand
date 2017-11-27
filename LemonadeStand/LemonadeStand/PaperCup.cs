using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class PaperCup : Supply
    {
        //member variables

        //constructor
        public PaperCup()
        {
            name = "Paper Cup";
            pluralName = "Paper Cups";
            bundle1 = new SupplyBundle(25, .85, this);
            bundle2 = new SupplyBundle(50, 1.54, this);
            bundle3 = new SupplyBundle(100, 2.96, this);
            supplyBundles.Add(bundle1);
            supplyBundles.Add(bundle2);
            supplyBundles.Add(bundle3);
        }

        //member methods

    }
}
