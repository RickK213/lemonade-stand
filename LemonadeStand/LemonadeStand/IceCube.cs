using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class IceCube : Supply
    {
        //member variables

        //constructor
        public IceCube()
        {
            name = "Ice Cube";
            pluralName = "Ice Cubes";
            bundle1 = new SupplyBundle(100, .87, this);
            bundle2 = new SupplyBundle(250, 2.07, this);
            bundle3 = new SupplyBundle(500, 3.85, this);
            supplyBundles.Add(bundle1);
            supplyBundles.Add(bundle2);
            supplyBundles.Add(bundle3);
        }

        //member methods

    }
}
