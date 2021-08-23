using System;

namespace BinaryTree_Advanced_Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>(17
                , new BinaryTree<int>(9, new BinaryTree<int>(3), new BinaryTree<int>(11))
                , new BinaryTree<int>(25, new BinaryTree<int>(20), new BinaryTree<int>(13)));

            binaryTree.PreOrder(Console.WriteLine);
            binaryTree.InOrder(Console.WriteLine);
            binaryTree.PostOrder(Console.WriteLine);
            binaryTree.PrintIndentedPreOrder();

        }
    }
}
