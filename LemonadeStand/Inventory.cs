using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        public List<Lemon> lemonInventory;
        public List<Ice> iceInventory;
        public List<Cup> cupInventory;
        public List<Sugar> sugarInventory;
        public List<Tree> treeInventory;
        Random inventoryRandom = new Random();
        public Dictionary<string, int> inventory = new Dictionary<string, int>();

        public Inventory()
        {
            lemonInventory = new List<Lemon>();
            iceInventory = new List<Ice>();
            cupInventory = new List<Cup>();
            sugarInventory = new List<Sugar>();
            treeInventory = new List<Tree>();
        }

        public void DisplayInventory()
        {
            Console.WriteLine("You have {0} lemons.", lemonInventory.Count());
            Console.WriteLine("You have {0} sugar cubes.", sugarInventory.Count());
            Console.WriteLine("You have {0} cups.", cupInventory.Count());
            Console.WriteLine("You have {0} ice cubes.", iceInventory.Count());
            Console.WriteLine("You have {0} lemon trees.", treeInventory.Count());
        }
        public void UseCup()
        {
            cupInventory.RemoveAt(0);
        }
        public void UseLemon()
        {
            lemonInventory.RemoveAt(0);
        }
        public void UseSugar()
        {
            sugarInventory.RemoveAt(0);
        }
        public void UseIce()
        {
            iceInventory.RemoveAt(0);
        }
        public int GetCups()
        {
            return cupInventory.Count();
        }
        public int GetLemons()
        {
            return lemonInventory.Count();
        }
        public int GetSugar()
        {
            return sugarInventory.Count();
        }
        public int GetIce()
        {
            return iceInventory.Count();
        }
        public void AddLemon(Lemon lemon)
        {
            lemonInventory.Add(lemon);
        }
        public void AddSugar(Sugar sugar)
        {
            sugarInventory.Add(sugar);
        }
        public void AddCup(Cup cup)
        {
            cupInventory.Add(cup);
        }
        public void AddIce(Ice ice)
        {
            iceInventory.Add(ice);
        }
        public void AddTree(Tree tree)
        {
            treeInventory.Add(tree);
        }
        public void ResetLemons()
        {
            lemonInventory.Clear();
        }
        public void ResetIce()
        {
            iceInventory.Clear();
        }
        public void ResetSugar()
        {
            sugarInventory.Clear();
        }
        public void ResetCups()
        {
            cupInventory.Clear();
        }
        public void Reset()
        {
            ResetLemons();
            ResetSugar();
            ResetIce();
            ResetCups();
        }
        public void MeltIce()
        {
            Console.WriteLine("All your ice has melted.");
            ResetIce();
        }
        public void AddLemons(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Lemon addLemon = new Lemon();
                AddLemon(addLemon);
            }
        }
        public void AddIces(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Ice addIce = new Ice();
                AddIce(addIce);
            }
        }
        public void AddCups(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Cup addCup = new Cup();
                AddCup(addCup);
            }
        }
        public void AddSugars(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Sugar addSugar = new Sugar();
                AddSugar(addSugar);
            }
        }
        public void AddTrees(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Tree addTree = new Tree();
                AddTree(addTree);
            }
        }
        public void GrowLemons()
        {
            if (lemonInventory.Count() > 0)
            {
                foreach (Tree tree in treeInventory)
                {
                    int numberOfLemons = inventoryRandom.Next(1, 4);
                    Console.WriteLine("Your lemon tree grew {0} lemons today.",numberOfLemons);
                    AddLemons(numberOfLemons);
                }
            }
        }
    }
}
