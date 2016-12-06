using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        Dictionary<string, double> costs = new Dictionary<string, double>();
        bool chosen;
        public Store()
        {
            costs.Add("lemons", 1.5);
            costs.Add("sugar", 1);
            costs.Add("cups", .5);
            costs.Add("ice", .25);
        }
        public void Buy(Dictionary<string, int> storeInventory, Player player, Inventory inventory)
        {
            DisplayPrices();
            DisplayCash(player.cash);
            GetBuyChoice(storeInventory, player, inventory);
        }
        public void DisplayPrices()
        {
            foreach (KeyValuePair<string, double> kvp in costs)
            {
                Console.WriteLine("{0}: ${1}", kvp.Key, kvp.Value);
            }
        }
        public void DisplayCash(double cash)
        {
            Console.WriteLine("You have ${0}.",cash);
        }
        public void GetBuyChoice (Dictionary<string, int> storeInventory, Player player, Inventory inventory)
        {
            Console.WriteLine("What would you like to buy?");
            string choice = Console.ReadLine().ToLower();
            chosen = false;
            switch (choice)
            {
                case "lemons":
                case "lemon":
                case "l":
                    while (!chosen)
                    {
                        TryToBuy(player, storeInventory, "lemons", inventory);
                    }
                    break;
                case "ice":
                case "i":
                    while (!chosen)
                    {
                        TryToBuy(player, storeInventory, "ice", inventory);
                    }
                    break;
                case "sugar":
                case "s":
                    while (!chosen)
                    {
                        TryToBuy(player, storeInventory, "sugar", inventory);
                    }
                    break;
                case "cups":
                case "cup":
                case "c":
                    while (!chosen)
                    {
                        TryToBuy(player, storeInventory, "cups", inventory);
                    }
                    break;
            }
        }
        public void TryToBuy(Player player, Dictionary<string, int> storeInventory, string toBuy, Inventory inventory)
        {
            int converted;
            DisplayHowManyToBuy(toBuy);
            string number = Console.ReadLine();
            bool result = Int32.TryParse(number, out converted);
            if (result)
            {
                if (converted > 0)
                {
                    double cost = (costs[toBuy] * converted);
                    if (cost <= player.cash)
                    {
                        DisplayYouBought(toBuy, converted);
                        player.AdjustCash(cost*-1);
                        player.AdjustMoneySpentToday(cost);
                        player.AdjustTotalMoneySpent(cost);
                        switch (toBuy)
                        {
                            case "lemons":
                                inventory.AddLemons(converted);
                                break;
                            case "ice":
                                inventory.AddIces(converted);
                                break;
                            case "sugar":
                                inventory.AddSugars(converted);
                                break;
                            case "cups":
                                inventory.AddCups(converted);
                                break;
                        }
                        chosen = true;
                    }
                    else
                    {
                        DisplayYouCantBuy(toBuy, converted);
                        chosen = true;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number greater than zero.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a number greater than zero.");
            }
        }

        public void DisplayHowManyToBuy(string toBuy)
        {
            if (toBuy == "lemons" || toBuy == "cups")
            {
                Console.WriteLine("How many {0} would you like to buy?", toBuy);
            }
            else if (toBuy == "sugar")
            {
                Console.WriteLine("How many sugar cubes would you like to buy?");
            }
            else if (toBuy == "ice")
            {
                Console.WriteLine("How many ice cubes would you like to buy?");
            }
        }
        public void DisplayYouBought(string toBuy, int howMany)
        {
            if (toBuy == "lemons" || toBuy == "cups")
            {
                Console.WriteLine("You buy {0} {1}.", howMany, toBuy);
            }
            else if (toBuy == "sugar")
            {
                Console.WriteLine("You buy {0} sugar cubes.", howMany);
            }
            else if (toBuy == "ice")
            {
                Console.WriteLine("You buy {0} ice cubes.", howMany);
            }
        }
        public void DisplayYouCantBuy(string toBuy, int howMany)
        {
            if (toBuy == "lemons" || toBuy == "cups")
            {
                Console.WriteLine("You don't have enough money to buy {0} {1}.", howMany, toBuy);
            }
            else if (toBuy == "sugar")
            {
                Console.WriteLine("You don't have enough money to buy {0} sugar cubes.", howMany);
            }
            else if (toBuy == "ice")
            {
                Console.WriteLine("You don't have enough money to buy {0} ice cubes.", howMany);
            }
        }
    }
}



