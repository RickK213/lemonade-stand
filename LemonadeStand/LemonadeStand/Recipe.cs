using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        //member variables
        public int pricePerCup;
        public int lemonsPerPitcher;
        public int sugarPerPitcher;
        public int icePerCup;

        //constructor
        public Recipe()
        {
            pricePerCup = 25;
            lemonsPerPitcher = 4;
            sugarPerPitcher = 4;
            icePerCup = 4;
        }

        //member methods
    }
}
