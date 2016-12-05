using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LemonadeStand
{
    class Weather
    {
        int temperature;
        int cloudiness;
        int rainLevel;
        Random weatherRandom = new Random();
        public void Randomize()
        {
            Thread.Sleep(20);
            temperature = 60 + weatherRandom.Next(0, 16) + weatherRandom.Next(0, 16) + weatherRandom.Next(0, 16);
            Thread.Sleep(20);
            cloudiness = weatherRandom.Next(0, 101);
            Thread.Sleep(20);
            int rainChance = weatherRandom.Next(1, 101);
            if (rainChance < 50)
            {
                rainLevel = 0;
            }
            else
            {
                Thread.Sleep(20);
                rainLevel = weatherRandom.Next(0, 101);
            }
        }
        public void DisplayTodaysWeather(List<Weather> weatherForecast)
        {
            Console.WriteLine("Today's weather:");
            DisplayWeather(weatherForecast[0]);
        }
        public void WeatherReport(List<Weather> weatherForecast)
        {
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("\nDay {0}'s weather:",i+1);
                DisplayWeather(weatherForecast[i]);
            }
            
           
        }
        public void DisplayWeather(Weather weather)
        {
            Console.WriteLine("Temperature: {0}", weather.GetTemperature());
            Console.WriteLine("Cloudiness: {0}", weather.GetCloudiness());
            Console.WriteLine("Chance of Rain: {0}", weather.GetRain());
        }
        public void WeatherCheck(List<Weather> weatherForecast)
        {
            Console.WriteLine("Do you want to see a forecast for one day or one week?");
            string weatherChoice = Console.ReadLine().ToLower();
            switch (weatherChoice)
            {
                case "day":
                    DisplayTodaysWeather(weatherForecast);
                    break;
                case "week":
                    WeatherReport(weatherForecast);
                    break;
                default:
                    Console.WriteLine("Please enter day or week.");
                    WeatherCheck(weatherForecast);
                    break;
            }
        }
        public int GetTemperature()
        {
            return temperature;
        }
        public int GetCloudiness()
        {
            return cloudiness;
        }
        public int GetRain()
        {
            return rainLevel;
        }
    }
}
       
