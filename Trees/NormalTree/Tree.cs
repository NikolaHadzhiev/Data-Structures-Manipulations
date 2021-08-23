using System;
using System.Collections.Generic;

namespace NormalTree
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; }

        public int Count { get; private set; } = 0;

        public void Add(T value)
        {
            if (this.Count == 0)
            {
                this.Root = new Node<T>()
                {
                    Value = value,
                    Children = new List<Node<T>>()
                };
            }
            else
            {

            }
            this.Count++;
        }


        public void DFS(Action<T> action)
        {
            DFS(Root, action);
        }
        private void DFS(Node<T> node, Action<T> action)
        {
            action.Invoke(node.Value);

            if (node.Children.Count > 0)
            {
                foreach (var child in node.Children)
                {
                    DFS(child, action);
                }
            }
        }

    }
}
