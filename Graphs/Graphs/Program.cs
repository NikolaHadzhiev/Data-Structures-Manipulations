using System;
using System.Collections.Generic;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> cities = new Graph<string>();
            //cities.Add("Stara Zagora");

            cities.Add("Plovdiv");
            cities.Add("Asenovgrad");
            cities.Add("Sofia");
            cities.Add("Burgas");
            cities.Add("Varna");
            cities.Add("Ruse");

            cities.Connect("Plovdiv", "Asenovgrad");
            cities.Connect("Sofia", "Plovdiv");
            cities.Connect("Asenovgrad", "Burgas");
            cities.Connect("Plovdiv", "Burgas");
            cities.Connect("Burgas", "Ruse");
            cities.Connect("Burgas", "Varna");
            cities.Connect("Varna", "Ruse");
            cities.Connect("Sofia", "Varna");
            //cities.Connect("Asenovgrad", "Stara Zagora");
            //cities.Connect("Stara Zagora", "Ruse");

            List<string> citiesList = new List<string>();
            citiesList = cities.Sort();

            foreach (var city in citiesList)
            {
                Console.WriteLine(city);
            }

        }
    }
}
}
