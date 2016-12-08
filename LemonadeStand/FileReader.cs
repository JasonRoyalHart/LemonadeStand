using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LemonadeStand
{
    class FileReader
    {
        public void ReadFile(Player player, Inventory inventory, Game game)
        {
            string line;
            string path = "LemonadeSaveFile.txt";
            string fullPath = System.IO.Path.GetFullPath(path);
            List<string> textToRead = new List<string>();
            try {
                System.IO.StreamReader file = new System.IO.StreamReader(fullPath);
                if ((line = file.ReadLine()) != null)
                {
                    player.SetName(line);
                }
                if ((line = file.ReadLine()) != null)
                {
                    player.SetCash(Convert.ToDouble(line));
                }
                inventory.Reset();
                if ((line = file.ReadLine()) != null)
                {
                    //lemons
                    inventory.AddLemons(Int32.Parse(line));
                }
                if ((line = file.ReadLine()) != null)
                {
                    //ice
                    inventory.AddIces(Int32.Parse(line));
                }
                if ((line = file.ReadLine()) != null)
                {
                    //sugar
                    inventory.AddSugars(Int32.Parse(line));
                }
                if ((line = file.ReadLine()) != null)
                {
                    //cups
                    inventory.AddCups(Int32.Parse(line));
                }
                if ((line = file.ReadLine()) != null)
                {
                    //total spent
                    player.SetTotalSpent(Convert.ToDouble(line));
                }
                if ((line = file.ReadLine()) != null)
                {
                    //total profit
                    player.SetTotalProfit(Int32.Parse(line));
                }
                if ((line = file.ReadLine()) != null)
                {
                    //current day
                    game.SetCurrentDay(Int32.Parse(line));
                }
                Console.WriteLine("Game loaded.");
                file.Close();
            }
            catch
            {
                Console.WriteLine("Error trying to load file.");
            }
        }
    }
}
