﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        //member variables
        int numDaysInGame;
        Day day;

        //constructor
        public Game()
        {

        }

        //member methods
        public void RunGame()
        {
            UI.ResizeConsoleWindow();
            UI.DisplayIntroScreen();
        }

    }
}
