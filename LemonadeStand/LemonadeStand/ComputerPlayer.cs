using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class ComputerPlayer : Player
    {
        //member variables

        //constructor
        public ComputerPlayer(Random random)
        {
            name = "Lemonator 5000";
        }

        //member methods
        public override void PurchaseInventory(double cheapestSupplyBundle, int currentDay, Day da)
        {

        }

        public override void SetRecipe()
        {

        }
    }
}
