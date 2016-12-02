using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        int lemons;
        int sugar;
        int cups;
        int ice;

        public Dictionary<string, int> inventory = new Dictionary<string, int>();
        public Inventory()
        {
            inventory.Add("lemons", 0);
            inventory.Add("sugar", 0);
            inventory.Add("cups", 0);
            inventory.Add("ice", 0);
        }

        public void DisplayInventory()
        {
            Console.WriteLine("You have {0} lemons.", inventory["lemons"]);
            Console.WriteLine("You have {0} sugar cubes.", inventory["sugar"]);
            Console.WriteLine("You have {0} cups.", inventory["cups"]);
            Console.WriteLine("You have {0} ice cubes.", inventory["ice"]);
        }
        public Dictionary<string, int> GetInventory()
        {
            return inventory;
        }


    }
}
