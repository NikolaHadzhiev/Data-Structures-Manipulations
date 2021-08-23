﻿using System.Collections.Generic;

namespace NormalTree
{
    public class Node<T>
    {
        public T Value { get; set; }
        public List<Node<T>> Children { get; set; }
    }
}
