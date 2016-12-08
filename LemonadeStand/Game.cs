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
        List<Customer> customers;
        List<Weather> weatherForecast;
        Inventory inventory;
        Store store;
        Player player;
        Day day;
        Weather weather;
        FileWriter fileWriter;
        FileReader fileReader = new FileReader();
        bool playing;

        public Game()
        {
            currentDay = 1;
            playing = true;
            customers = new List<Customer>();
            weatherForecast = new List<Weather>();
            inventory = new Inventory();
            store = new Store();
            player = new Player();
            day = new Day();
            weather = new Weather();
            fileWriter = new FileWriter();
        }

        public void StartGame()
        {
            PrintWelcomeText();
            GetName();
            GetDays();
            SetWeather();
            GameLoop();
            EndGame();
        }

        public void PrintWelcomeText()
        {
            Console.WriteLine("Welcome to Lemonade Stand.");
        }

        public void GetName()
        {
            Console.Write("What is your name? ");
            player.SetName(Console.ReadLine());
        }

        public void SetCurrentDay(int day)
        {
            currentDay = day;
        }

        public void GetDays()
        {
            Console.Write("How many days would you like to play for? ");
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
                    Console.WriteLine("Please enter a positive number.");
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
            if (numberOfDays < 14)
            {
                weatherDays = 14;
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
                Console.WriteLine("Day {0}: Choose buy, inventory, recipe, price, day, weather, save, load, or quit.", currentDay);
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
                        day.EndDay(this, player, inventory);
                        break;
                    case "weather":
                    case "w":
                        weather.WeatherCheck(weatherForecast);
                        break;
                    case "save":
                    case "s":
                        fileWriter.WriteFile(player, inventory, this);
                        break;
                    case "load":
                    case "l":
                        fileReader.ReadFile(player, inventory, this);
                        break;
                    case "quit":
                    case "q":
                        playing = false;
                        break;
                }
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
        public void ChangeDay(Player player)
        {
            weatherForecast.RemoveAt(0);
            currentDay++;
            player.ResetMoneySpent();
            if (currentDay == numberOfDays + 1)
            {
                playing = false;
            }
        }
        public void EndGame()
        {
            Console.WriteLine("Game over.");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
