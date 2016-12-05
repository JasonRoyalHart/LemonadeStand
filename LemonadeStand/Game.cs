using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LemonadeStand
{
    class Game
    {
        int numberOfDays;
        int currentDay;
        List<Customer> customers = new List<Customer>();
        List<Weather> weatherForecast = new List<Weather>();
        Inventory inventory = new Inventory();
        Store store = new Store();
        Player player = new Player();
        Day day = new Day();
        Weather weather = new Weather();
        bool playing;

        public Game()
        {
            currentDay = 1;
            playing = true;
        }

        public void StartGame()
        {
            PrintWelcomeText();
            GetName(player);
            GetDays();
            SetWeather();
            GameLoop();
            EndGame();
        }

        public void PrintWelcomeText()
        {
            Console.WriteLine("Welcome to Lemonade Stand.");
        }

        public void GetName(Player player)
        {
            Console.WriteLine("What is your name?");
            player.SetName(Console.ReadLine());
        }

        public void GetDays()
        {
            Console.WriteLine("How many days would you like to play for?");
            string playerDays = Console.ReadLine();
            int converted;
            bool result = Int32.TryParse(playerDays, out converted);
            if (result)
            {
                if (converted > 0)
                {
                    numberOfDays = converted;
                    Console.WriteLine("You will play for {0} days.", converted);
                }
                else
                {
                    Console.WriteLine("Please a positive number.");
                    GetDays();
                }
            }
            else
            {
                Console.WriteLine("Please enter a positive number.");
                GetDays();
            }
        }
        public void SetWeather()
        {
            int weatherDays;
            if (numberOfDays < 7)
            {
                weatherDays = 7;
            }
            else
            {
                weatherDays = numberOfDays;
            }
            for (int i = 0; i < weatherDays; i++)
            {
                Weather weather = new Weather();
                weather.Randomize();
                weatherForecast.Add(weather);
            }
        }

        public void GameLoop()
        {
            while (playing)
            {
                Console.WriteLine("Day {0}: Choose buy, inventory, recipe, price, day, weather, help or quit.", currentDay);
                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "buy":
                    case "b":
                        store.Buy(inventory.inventory, player, inventory);
                        break;
                    case "inventory":
                    case "inv":
                    case "i":
                        inventory.DisplayInventory();
                        player.DisplayCash();
                        break;
                    case "recipe":
                    case "r":
                        player.DisplayRecipe();
                        player.GetChangeRecipe();
                        break;
                    case "price":
                    case "p":
                        player.DisplayPrice();
                        player.GetChangePrice();
                        break;
                    case "day":
                    case "d":
                        day.StartDay(inventory, player, this, weatherForecast[0]);
                        day.EndDay(this);
                        break;
                    case "weather":
                    case "w":
                        weather.WeatherCheck(weatherForecast);
                        break;
                    case "quit":
                    case "q":
                        playing = false;
                        break;
                }
            }
        }
        public void DisplayCustomers()
        {
            foreach (Customer customer in customers)
            {
                Console.WriteLine("Name: {0} Thirst: {1} Cash: {2}",customer.GetName(), customer.GetThirst(), customer.GetCash());
            }
        }
        public Customer MakeCustomer()
        {
            Customer customer = new Customer();
            customer.Randomize();
            return customer;
        }
        public int GetCurrentDay()
        {
            return currentDay;
        }
        public void ChangeDay()
        {
            weatherForecast.RemoveAt(0);
            currentDay++;
            if (currentDay == numberOfDays + 1)
            {
                playing = false;
            }
        }
        public void EndGame()
        {
            Console.WriteLine("Game over.");
        }
    }
}
