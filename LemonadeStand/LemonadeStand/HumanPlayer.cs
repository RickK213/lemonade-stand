﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class HumanPlayer : Player
    {
        //member variables

        //constructor
        public HumanPlayer(Random random, string name)
        {
            this.name = name;
            startingMoney = 20.00;
            money = startingMoney;
            inventory = new Inventory();
            recipe = new Recipe();
            popularity = .50;
            this.random = random;
        }

        //member methods

        void AddBundleToInventory(SupplyBundle supplyBundle)
        {
            money = Math.Round((money - supplyBundle.price), 2);
            dailyExpenses = Math.Round((dailyExpenses + supplyBundle.price), 2);
            totalExpenses = Math.Round((totalExpenses + supplyBundle.price), 2);
            for (int i = 0; i < supplyBundle.quantity; i++)
            {
                switch (supplyBundle.supply.name)
                {
                    case "Paper Cup":
                        inventory.paperCups.Add(supplyBundle.supply);
                        break;
                    case "Lemon":
                        inventory.lemons.Add(new Lemon(random));
                        break;
                    case "Cup of Sugar":
                        inventory.cupsOfSugar.Add(supplyBundle.supply);
                        break;
                    case "Ice Cube":
                        inventory.iceCubes.Add(supplyBundle.supply);
                        break;
                }
            }
        }




        public override void PurchaseInventory(double cheapestSupplyBundle, int currentDay, Day day)
        {
            int menuSelection = 0;
            while ((menuSelection != 5) && (money > cheapestSupplyBundle))
            {
                UI.DisplayPlayerInventory(this, currentDay, day);
                UI.DisplayMenuHeader();
                menuSelection = int.Parse(UI.GetValidUserOption("1: Buy Paper Cups\n2: Buy Lemons\n3: Buy Cups of Sugar\n4: Buy Ice Cubes\n5: Done purchasing - Set my recipe!\n", new List<string>() { "1", "2", "3", "4", "5" }));
                if (menuSelection != 5)
                {
                    SupplyBundle supplyBundle = UI.GetSupplyBundle(menuSelection, this, random);
                    AddBundleToInventory(supplyBundle);
                }
            }
            if (money < cheapestSupplyBundle)
            {
                UI.DisplayPlayerInventory(this, currentDay, day);
                UI.DisplayBankruptMessage();
            }
        }

        void SetPlayerRecipeVariable(int menuSelection, int playerInput)
        {
            switch (menuSelection)
            {
                case 1:
                    recipe.pricePerCup = playerInput;
                    break;
                case 2:
                    recipe.lemonsPerPitcher = playerInput;
                    break;
                case 3:
                    recipe.sugarPerPitcher = playerInput;
                    break;
                case 4:
                    recipe.icePerCup = playerInput;
                    break;
                default:
                    break;
            }
        }

        public override void SetRecipe(int currentDay, Day day, Game game)
        {
            int menuSelection = 0;
            while (menuSelection != 5)
            {
                UI.DisplayPlayerRecipe(this, currentDay, day);
                UI.DisplayMenuHeader();
                menuSelection = int.Parse(UI.GetValidUserOption("1: Change Price per Cup\n2: Change Lemons per Pitcher\n3: Change Sugar per Pitcher\n4: Change Ice per Cup\n5: Done with Recipe - Let's start selling!\n", new List<string>() { "1", "2", "3", "4", "5" }));
                if (menuSelection != 5)
                {
                    int playerInput = UI.GetRecipeValue(menuSelection, this, game); //the 2nd 'this' is a Game reference
                    SetPlayerRecipeVariable(menuSelection, playerInput);
                }
            }
        }

    }
}
