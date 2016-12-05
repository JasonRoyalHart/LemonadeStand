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
        public void WeatherReport(List<Weather> weatherForecast)
        {
            Console.WriteLine("Today's weather:");
            DisplayWeather(weatherForecast[0]);
            bool display = false;
            foreach (Weather weather in weatherForecast)
            {
                if (!display)
                {
                    display = true;
                }
                else
                {
                    Console.WriteLine("\nThe next day's weather:");
                    DisplayWeather(weather);
                }
            }
        }
        public void DisplayWeather(Weather weather)
        {
            Console.WriteLine("Temperature: {0}", weather.GetTemperature());
            Console.WriteLine("Cloudiness: {0}", weather.GetCloudiness());
            Console.WriteLine("Chance of Rain: {0}", weather.GetRain());
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
       
