using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class Node<T> where T : IComparable
    {
        public Node()
        {

        }

        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public Node<T> Perant { get; set; }
    }
}
