using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree_Advanced_Manipulation
{
    public class Node<T>
    {
        public T Value { get; set; }
        public List<Node<T>> Children { get; set; }
    }
}
