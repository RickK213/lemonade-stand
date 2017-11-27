using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Supply
    {
        //member variables
        public string name;
        public string pluralName;
        public SupplyBundle bundle1;
        public SupplyBundle bundle2;
        public SupplyBundle bundle3;
        public List<SupplyBundle> supplyBundles;

        //constructor
        public Supply()
        {
            supplyBundles = new List<SupplyBundle>();
        }

        //member methods


    }
}
