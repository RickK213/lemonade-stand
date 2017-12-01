using System;
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

        public override void PurchaseInventory(double cheapestSupplyBundle, int currentDay, Day day, Store store)
        {
            int menuSelection = 0;
            while ((menuSelection != 5) && (money > cheapestSupplyBundle))
            {
                UI.DisplayPlayerInventory(this, currentDay, day);
                UI.DisplayMenuHeader();

                string bundleMenuInstructions = store.getBundleMenuInstructions();
                List<string> bundleMenuInputOptions = store.getBundleMenuInputOptions();

                menuSelection = int.Parse(UI.GetValidUserOption(bundleMenuInstructions, bundleMenuInputOptions));
                if (menuSelection != store.bundleContents.Count + 1)
                {
                    string bundleContents = store.bundleContents[menuSelection-1];
                    SupplyBundle supplyBundle = store.GetSupplyBundle(bundleContents, money);
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
