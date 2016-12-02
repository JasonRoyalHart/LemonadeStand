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
        List<Customer> customers = new List<Customer>();
        Inventory inventory = new Inventory();
        Store store = new Store();
        Player player = new Player();
        Day day = new Day();

        public Game()
        {

        }

        public void StartGame()
        {
            PrintWelcomeText();
            GameLoop();
        }

        public void PrintWelcomeText()
        {
            Console.WriteLine("Welcome to Lemonade Stand.");
        }

        public void GameLoop()
        {
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("Choose buy, inventory, recipe, price, day, help or quit.");
                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "buy":
                    case "b":
                        store.Buy(inventory.inventory, player);
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
                        day.StartDay(inventory, player);
                        break;
                    case "quit":
                    case "q":
                        playing = false;
                        break;
                }
            }
        }

        public void MakeCustomers(int numberOfCustomers)
        {
            for (int i = 0; i < numberOfCustomers; i++)
            {
                Customer customer = MakeCustomer();
                customers.Add(customer);
                Thread.Sleep(20);
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
//            Console.WriteLine("Made customer named {0} with thirst {1}.",customer.GetName(),customer.GetThirst());
            return customer;
        }
    }
}
