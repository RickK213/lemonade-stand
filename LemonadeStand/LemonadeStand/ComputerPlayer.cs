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

        SupplyBundle getRandomSupplyBundle(string supplyName)
        {

            SupplyBundle chosenBundle;

            Supply supply = new Supply();

            //TO DO: Figure out a better way to do the below stuff. It's bad to create objects you don't need.
            switch (supplyName)
            {
                case "Paper Cup":
                    supply = new PaperCup();
                    break;
                case "Lemon":
                    supply = new Lemon(random);
                    break;
                case "Cup of Sugar":
                    supply = new CupOfSugar();
                    break;
                case "Ice Cube":
                    supply = new IceCube();
                    break;
                default:
                    break;
            }

            int bundleSelection = random.Next(1,4);

            if (bundleSelection == 1)
            {
                //chosenBundle = supply.bundle1;
            }
            else if (bundleSelection == 2)
            {
                //chosenBundle = supply.bundle2;
            }
            else
            {
                //chosenBundle = supply.bundle3;
            }

            //if (money < chosenBundle.price)
            //{
            //    return getRandomSupplyBundle(supplyName);
            //}

            //return chosenBundle;
            return new SupplyBundle(1,1.11,"blah"); //placeholder


        }

        double getCheapestBundle(string supplyName)
        {


            return 0.00;
        }

        public override void PurchaseInventory(double cheapestSupplyBundle, int currentDay, Day day, Store store)
        {

        }

        public override void SetRecipe(int currentDay, Day day, Game game)
        {

        }
    }
}
