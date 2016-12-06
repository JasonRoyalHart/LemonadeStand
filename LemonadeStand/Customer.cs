using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LemonadeStand
{
    class Customer
    {
        int thirst;
        string name;
        int cash;
        int sweetness;
        Random customerRandom = new Random();
        public Customer()
        {
            thirst = 0;
            name = "Default name";
            cash = 0;
            sweetness = 0;
        }
        public void Randomize()
        {
            thirst = customerRandom.Next(10, 34) + customerRandom.Next(10, 34) + customerRandom.Next(10, 35);
            sweetness = customerRandom.Next(1, 34) + customerRandom.Next(1, 34) + customerRandom.Next(1, 35);
            cash = customerRandom.Next(1, 3) + customerRandom.Next(1, 3) + customerRandom.Next(0, 4);
            string[] firstNames = new string[30] {"Bernie","Barbara","George","Tina","Homer","Marge","Ned","Catelyn","Bill","Grace", "Bruce","Ada","Donald","Margaret","Morgan","Hillary","Tony","Mary","Scott","Gina","Jason", "June", "Robert", "Maxine", "Phil", "Alicia", "Simon", "Rose", "Bee", "Christine" };
            string[] lastNames = new string[30] {"Sanders","Bush","Turner","Washington","Simpson","Flanders","Stark","Lannister","Hopper","Sands","Wayne","Lovelace","Thatcher","Johnson","Clinton","Trump","Kenyon","Glick","Basche", "Pedriana", "Hart", "Smith", "Jones", "Grimaldi", "LaMarr", "Stevens", "Freeman", "Jameson", "Forman", "Baletto" };
            string firstName = firstNames[customerRandom.Next(0, 30)];
            string lastName = lastNames[customerRandom.Next(0, 30)];
            name = firstName + " " + lastName;
        }
        public bool WillBuy(Player player, Weather weather)
        {
            double costThreshold = cash / 3;
            double afterTemp = 1+ ((weather.GetTemperature() - 84.0)/100.0);
            costThreshold = costThreshold * afterTemp;
            if (player.GetPrice() > costThreshold)
            {
                Console.WriteLine("{0} says, 'Your lemonade is too expensive.'", name);
                return false;
            }
            else
            {
                Thread.Sleep(20);
                int buyRoll = customerRandom.Next(1,100);
                double cheapPrice = 1;
                if (player.GetPrice() < cash/6)
                {
                    Console.WriteLine("{0} says, 'How cheap!'",name);
                    cheapPrice = 1 + (cash / 6);
                }
                if (buyRoll <= (thirst*afterTemp*cheapPrice))
                {
                    Console.WriteLine("{0} says, 'I'll take one lemonade please.'", name);
                    return true;
                }
                else
                {
                    Console.WriteLine("{0} says, 'I'm just not thirsty enough to buy a lemonade right now.'\n",name);
                    return false;
                }
            }

        }
        public string GetName()
        {
            return name;
        }
        public int GetThirst()
        {
            return thirst;
        }
        public int GetCash()
        {
            return cash;
        }
    }
 
}
