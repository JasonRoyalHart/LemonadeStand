using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LemonadeStand
{
    class Day
    {
        Random dayRandom = new Random();
        double dailyIncome;
        bool isRaining;

        public void StartDay(Inventory inventory, Player player, Game game, Weather weather)
        {
            Console.WriteLine("You start day {0}.", game.GetCurrentDay());
            bool dayNotOver = true;
            bool outOfLemonade = false;
            bool outOfCups = false;
            int timePeriod = 1;
            Pitcher pitcher = new Pitcher(player);
            dailyIncome = 0;
            if (dayRandom.Next(0,100) <= weather.GetRain())
            {
                isRaining = true;
                Console.WriteLine("It is raining.");
            }
            else
            {
                isRaining = false;
            }
            if (CheckRecipe(inventory, player))
            {
                pitcher.FillPitcher(inventory, player);
            }
            else
            {
                Console.WriteLine("You can't sell any lemonade today.");
                outOfLemonade = true;
                dayNotOver = false;
            }
            if (inventory.GetCups() < 1)
            {
                Console.WriteLine("You're out of cups! You can't sell any lemonade today.");
                dayNotOver = false;
            }
            while (timePeriod <= 16 && dayNotOver)
            {
                if (pitcher.GetFull() == 0)
                {
                    if (CheckRecipe(inventory, player))
                    {
                        pitcher.FillPitcher(inventory, player);
                    }
                    else
                    {
                        Console.WriteLine("You can't sell any more lemonade today.");
                        outOfLemonade = true;
                        dayNotOver = false;
                    }
                }
                if (inventory.GetCups() < 1)
                {
                    outOfCups = true;
                    Console.WriteLine("You've run out of cups. You can't sell any more lemonade today.");
                    dayNotOver = false;
                }
                if (!outOfLemonade && !outOfCups)
                {
                    Thread.Sleep(3000);
                    DisplayTime(timePeriod);
                    if (dayRandom.Next(0, 100) <= weather.GetRain())
                    {
                        isRaining = true;
                        Console.WriteLine("It is raining.");
                    }
                    else
                    {
                        if (isRaining)
                        {
                            Console.WriteLine("It has stopped raining.");
                        }
                        isRaining = false;
                    }
                    CheckForCustomer(player, pitcher, inventory, weather);

                }
                timePeriod++;


            }
            Console.WriteLine("Day {0} is complete.",game.GetCurrentDay());
            Console.WriteLine("You had a total income of {0}",dailyIncome);



        }

        public bool CheckRecipe(Inventory inventory, Player player)
        {
            if (CheckLemons(inventory, player) && CheckSugar(inventory, player) && CheckIce(inventory, player)) {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckLemons(Inventory inventory, Player player)
        {
            if (player.recipe["lemons"] < inventory.lemonInventory.Count())
            {
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough lemons to make a pitcher!");
                return false;
            }
        }
        public bool CheckSugar(Inventory inventory, Player player)
        {
            if (player.recipe["sugar"] < inventory.sugarInventory.Count())
            {
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough sugar to make a pitcher!");
                return false;
            }
        }
        public bool CheckIce(Inventory inventory, Player player)
        {
            if (player.recipe["ice"] < inventory.iceInventory.Count())
            {
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough ice to make a pitcher!");
                return false;
            }
        }


        public void CheckForCustomer(Player player, Pitcher pitcher, Inventory inventory, Weather weather)
        {
            Thread.Sleep(20);
            int chance = dayRandom.Next(0, 100);
            if (chance <= 90 && !isRaining)
            {
                Customer customer = new Customer();
                customer.Randomize();
                Console.WriteLine("{0} walks by your stand.", customer.GetName());
                if (customer.WillBuy(player, weather))
                {
                    player.cash += player.price;
                    pitcher.AdjustFull(-10);
                    inventory.UseCup();
                    dailyIncome += player.price;                    
                    Console.WriteLine("You made ${0} and your pitcher is {1}% full.", player.price, pitcher.GetFull());
                    Console.WriteLine("Current money: ${0}. Current number of cups: {1}", player.GetCash(), inventory.GetCups());
                }
            }
            else
            {
                Console.WriteLine("There are no customers right now.");
            }
        }
        public void DisplayTime(int timePeriod)
        {
            int hour = 8 + timePeriod / 4;
            int minutes = (timePeriod - ((hour-8) * 4))*15;
            string amPm;
            if (hour < 12)
            {
                amPm = "AM";
            }
            else
            {
                amPm = "PM";
            }
            if (hour > 12)
            {
                hour = hour - 12;
            }
            if (minutes == 0)
            {
                Console.WriteLine("Current time: {0}:00 {1}", hour, amPm);
            }
            else
            {
                Console.WriteLine("Current time: {0}:{1} {2}", hour, minutes, amPm);
            }
    }
        public void EndDay (Game game)
        {
            game.ChangeDay();
        }
        }
}
