using System;

namespace Tree_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();

            tree.Add(17);
            tree.Add(9, 17);
            tree.Add(25, 17);
            tree.Add(3, 9);
            tree.Add(11, 9);
            tree.Add(20, 25);
            tree.Add(31, 25);

            tree.DFS(Console.WriteLine);
        }
    }
}
