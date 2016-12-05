﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        string name;
        public double cash;
        public Dictionary<string, int> recipe = new Dictionary<string, int>();
        public double price;

        public Player()
        {
            cash = 100;
            price = .1;
            recipe.Add("lemons", 1);
            recipe.Add("sugar", 1);
            recipe.Add("ice", 1);
        }
        public double GetCash()
        {
            return cash;
        }
        public void AdjustCash(double amount)
        {
            cash += amount;
        }
        public double GetPrice()
        {
            return price;
        }
        public void DisplayCash()
        {
            Console.WriteLine("You have ${0}.",cash);
        }
        public void SetName(string playerName)
        {
            name = playerName;
        }
        public void DisplayRecipe ()
        {
            Console.WriteLine("In each pitcher of lemonade, you currently put:");
            Console.WriteLine("{0} lemons.", recipe["lemons"]);
            Console.WriteLine("{0} sugar cubes.", recipe["sugar"]);
            Console.WriteLine("{0} ice cubes.", recipe["ice"]);
        }
        public void GetChangeRecipe()
        {
            Console.WriteLine("Do you want to change your recipe?");
            string change = Console.ReadLine();
            switch (change)
            {
                case "yes":
                case "ye":
                case "y":
                    ChangeRecipe();
                    break;
                case "no":
                case "n":
                    Console.WriteLine("Ok. You keep your recipe as it is.");
                    break;
                default:
                    Console.WriteLine("Please answer yes or no.");
                    GetChangeRecipe();
                    break;



            }
        }
        public void ChangeRecipe()
        {
            ChangeItem("lemons");
            ChangeItem("sugar");
            ChangeItem("ice");
        }
        public void ChangeItem(string item)
        {
            int converted;
            Console.WriteLine("How many {0} would you like to put in a pitcher?", item);
            string howMany = Console.ReadLine();
            bool result = Int32.TryParse(howMany, out converted);
            if (result)
            {
                if (converted >= 0)
                {
                    recipe[item] = converted;
                    Console.WriteLine("You now put {0} {1} in a pitcher of lemonade.", converted, item);
                }
                else
                {
                    Console.WriteLine("Please enter 0 or a positive number.");
                    ChangeItem(item);
                }
            }
            else
            {
                Console.WriteLine("Please enter 0 or a positive number.");
                ChangeItem(item);
            }
        }
        public void DisplayPrice()
        {
            Console.WriteLine("You currently charge ${0} for a cup of lemonade.", price);
        }

        public void GetChangePrice()
        {
            double converted;
            Console.WriteLine("Enter your new price.");
            string newPrice = Console.ReadLine();
            bool result = Double.TryParse(newPrice, out converted);
            
            if (result)
            {
                if (converted > 0)
                {
                    Console.WriteLine("You now charge ${0} for a cup of lemonade.",converted);
                    price = converted;
                }
                else
                {
                    Console.WriteLine("Please enter a number higher than 0.");
                    GetChangePrice();
                }
            }
            else
            {
                Console.WriteLine("Please enter a number higher than 0.");
                GetChangePrice();
            }
        }

    }

}
