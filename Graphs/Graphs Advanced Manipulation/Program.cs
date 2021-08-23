using System;

namespace Graphs_Advanced_Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            //GarbageDemo();
            //return;
            NotWeightedGraph<string> cities = new NotWeightedGraph<string>();

            cities.Add("Sofia");
            cities.Add("Ruse");
            cities.Add("Burgas");
            cities.Add("Varna");
            cities.Add("Plovdiv");
            cities.Add("Asenovgrad");
            cities.Add("Stara Zagora");

            cities.Connect("Sofia", "Plovdiv");
            cities.Connect("Plovdiv", "Asenovgrad");
            cities.Connect("Asenovgrad", "Burgas");
            cities.Connect("Asenovgrad", "Stara Zagora");
            cities.Connect("Plovdiv", "Burgas");
            cities.Connect("Burgas", "Varna");
            cities.Connect("Sofia", "Varna");
            cities.Connect("Burgas", "Ruse");
            cities.Connect("Varna", "Ruse");
            cities.Connect("Stara Zagora", "Ruse");

            //cities.DFS(city => Console.WriteLine(city));

            // Sofia, Plovdiv, Asenovgrad, Burgas, Varna, Ruse
            cities.TopologicalSort().ForEach(Console.WriteLine);
        }

        static void GarbageDemo()
        {
            NotWeightedGraph<int> cities = new NotWeightedGraph<int>();

            cities.Add(7);
            cities.Add(19);
            cities.Add(21);
            cities.Add(14);
            cities.Add(1);
            cities.Add(12);
            cities.Add(31);
            cities.Add(23);
            cities.Add(6);

            cities.Connect(7, 19);
            cities.Connect(7, 21);
            cities.Connect(7, 14);
            cities.Connect(19, 1);
            cities.Connect(19, 12);
            cities.Connect(19, 31);
            cities.Connect(19, 21);
            cities.Connect(1, 7);
            cities.Connect(31, 21);
            cities.Connect(21, 14);
            cities.Connect(23, 21);
            cities.Connect(14, 23);
            cities.Connect(14, 6);

            cities.BFS(Console.WriteLine);
        }

    }
}
