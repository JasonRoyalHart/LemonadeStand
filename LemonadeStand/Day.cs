using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        public void StartDay(Inventory inventory, Player player)
        {
            Console.WriteLine("You start your day.");
            bool dayNotOver = true;
            int pitcherFull;
            while (dayNotOver)
            {
                if (MakePitcher(inventory, player))
                {
                    pitcherFull = 100;
                    Console.WriteLine("You make a fresh pitcher of lemonade.");
                    dayNotOver = false;
                }
                else
                {
                    Console.WriteLine("You can't sell any lemonade today.");
                    dayNotOver = false;
                }

            }
        }
        public bool MakePitcher(Inventory inventory, Player player)
        {
            return CheckRecipe(inventory, player);
        }
        public bool CheckRecipe(Inventory inventory, Player player)
        {
            if (CheckItem(inventory, player, "lemons") && CheckItem(inventory, player, "sugar") && CheckItem(inventory, player, "ice")) {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckItem(Inventory inventory, Player player, string item)
        {
            if (inventory.inventory[item] < player.recipe[item])
            {
                Console.WriteLine("You don't have enough {0} to make a pitcher!", item);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
