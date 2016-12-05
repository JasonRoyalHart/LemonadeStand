using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Pitcher
    {
        int full;
        int sweetness;

        public Pitcher(Player player)
        {
            full = 0;
            sweetness = 0;
            for (int sugar = 0; sugar < player.recipe["sugar"]; sugar++)
            {
                sweetness += 10;
            }
            for (int lemons = 0; lemons < player.recipe["lemons"]; lemons++)
            {
                sweetness -= 25;
            }
            for (int ice = 0; ice < player.recipe["ice"]; ice++)
            {
                sweetness -= 1;
            }
        }
        public int GetSweetness()
        {
            return sweetness;
        }
        public int GetFull()
        {
            return full;
        }
        public void AdjustFull(int amount)
        {
            full += amount;
        }
        public void FillPitcher(Inventory inventory, Player player)
        {
            full = 100;
            inventory.inventory["lemons"] -= player.recipe["lemons"];
            inventory.inventory["sugar"] -= player.recipe["sugar"];
            inventory.inventory["ice"] -= player.recipe["ice"];
            Console.WriteLine("You make a fresh pitcher of lemonade.");
        }
    }
}
