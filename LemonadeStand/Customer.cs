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
        Random customerRandom = new Random();
        public Customer()
        {
            thirst = 0;
            name = "Default name";
            cash = 0;
        }
        public void Randomize()
        {
            thirst = customerRandom.Next(1, 34) + customerRandom.Next(1, 34) + customerRandom.Next(1, 35);
            cash = customerRandom.Next(1, 3) + customerRandom.Next(1, 3) + customerRandom.Next(0, 4);
            string[] firstNames = new string[20] { "Bruce","Ada","Donald","Margaret","Morgan","Hillary","Tony","Mary","Scott","Gina","Jason", "June", "Robert", "Maxine", "Phil", "Alicia", "Simon", "Rose", "Bee", "Christine" };
            string[] lastNames = new string[20] { "Wayne","Lovelace","Thatcher","Johnson","Clinton","Trump","Kenyon","Glick","Basche", "Pedriana", "Hart", "Smith", "Jones", "Grimaldi", "LaMarr", "Stevens", "Freeman", "Jameson", "Forman", "Baletto" };
            string firstName = firstNames[customerRandom.Next(0, 20)];
            string lastName = lastNames[customerRandom.Next(0, 20)];
            name = firstName + " " + lastName;
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
