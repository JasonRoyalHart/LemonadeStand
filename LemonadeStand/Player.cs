using System;
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

        public Player()
        {
            cash = 10;
        }
        public double GetCash()
        {
            return cash;
        }
        public void DisplayCash()
        {
            Console.WriteLine("You have ${0}.",cash);
        }
    }

}
