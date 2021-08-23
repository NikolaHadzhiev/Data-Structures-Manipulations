using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree_Vol_2
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }
        public Node(T value, Node<T> left = null, Node<T> right = null)
        {
            Value = value;
            LeftChild = left;
            RightChild = right;
        }
    }
}
