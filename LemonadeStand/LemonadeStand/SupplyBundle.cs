using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class SupplyBundle
    {
        //member variables
        public int quantity;
        public double price;
        public Supply supply;

        //constructor
        public SupplyBundle(int quantity, double price, Supply supply)
        {
            this.quantity = quantity;
            this.price = price;
            this.supply = supply;
        }

        //member methods
    }
}
