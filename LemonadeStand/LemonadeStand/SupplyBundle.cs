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
        public string typeOfSupply;

        //constructor
        public SupplyBundle(int quantity, double price, string typeOfSupply)
        {
            this.quantity = quantity;
            this.price = price;
            this.typeOfSupply = typeOfSupply;
        }

        //member methods
    }
}
