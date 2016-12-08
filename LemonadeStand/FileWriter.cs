using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class FileWriter
    {
        public void WriteFile(Player player, Inventory inventory, Game game)
        {
            //Write out name, cash, lemons, ice, sugar, cups, total spent, total profit, current day
            Console.WriteLine("Saving game.");
            List<string> textToWrite = new List<string>();
            textToWrite.Add(player.GetName());
            textToWrite.Add(player.GetCash().ToString());
            textToWrite.Add(inventory.GetLemons().ToString());
            textToWrite.Add(inventory.GetIce().ToString());
            textToWrite.Add(inventory.GetSugar().ToString());
            textToWrite.Add(inventory.GetCups().ToString());
            textToWrite.Add(player.GetTotalSpent().ToString());
            textToWrite.Add(player.GetTotalProfit().ToString());
            textToWrite.Add(game.GetCurrentDay().ToString());
            string path = "LemonadeSaveFile.txt";
            string fullPath = System.IO.Path.GetFullPath(path);
            try
            {
                System.IO.File.WriteAllLines(fullPath, textToWrite);
                Console.WriteLine("Game saved.");
            }
            catch
            {
                Console.WriteLine("Error while saving.");

            }

        }
    }
}

