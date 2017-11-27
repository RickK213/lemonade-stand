using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class CupOfSugar : Supply
    {
        //member variables

        //constructor
        public CupOfSugar()
        {
            name = "Cup of Sugar";
            pluralName = "Cups of Sugar";
            bundle1 = new SupplyBundle(8, .65, this);
            bundle2 = new SupplyBundle(20, 1.60, this);
            bundle3 = new SupplyBundle(48, 3.37, this);
            supplyBundles.Add(bundle1);
            supplyBundles.Add(bundle2);
            supplyBundles.Add(bundle3);
        }

        //member methods

    }
}
