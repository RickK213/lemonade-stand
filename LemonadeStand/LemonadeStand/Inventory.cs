﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory
    {
        //member variables
        public List<Supply> paperCups;
        public List<Supply> lemons;
        public List<Supply> cupsOfSugar;
        public List<Supply> iceCubes;

        //constructor
        public Inventory()
        {
            paperCups = new List<Supply>();
            lemons = new List<Supply>();
            cupsOfSugar = new List<Supply>();
            iceCubes = new List<Supply>();
        }

        //member methods
        void AddSupply(Supply supply, List<Supply> list)
        {

        }

    }
}
