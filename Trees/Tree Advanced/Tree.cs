using System;
using System.Collections.Generic;
using System.Text;

namespace Tree_Advanced
{
    public class Tree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public int Count { get; private set; } = 0;

        public void Add(T value)
        {
            Node<T> newNode = new Node<T> { Value = value };

            if (this.Count == 0)
            {
                this.Root = newNode;
            }
            else
            {
                this.Root.Children.Add(newNode);
            }

            this.Count++;
        }

        public void Add(T value, T parent)
        {
            Node<T> newNode = new Node<T> { Value = value };

            if (this.Count == 0)
            {
                this.Root = new Node<T> { Value = parent };
                this.Root.Children.Add(newNode);
            }
            else
            {
                Node<T> parentNode = this.FindNode(this.Root, parent);

                if (parentNode != null)
                {
                    parentNode.Children.Add(newNode);
                }
            }

            this.Count++;
        }

        public Node<T> FindNode(T value)
        {
            return this.FindNode(this.Root, value);
        }

        private Node<T> FindNode(Node<T> currentNode, T value)
        {
            if (currentNode != null && currentNode.Value.Equals(value))
            {
                return currentNode;
            }
            else if (currentNode != null)
            {
                foreach (var child in currentNode.Children)
                {
                    Node<T> childNode = FindNode(child, value);

                    if (childNode != null)
                    {
                        return childNode;
                    }
                }
            }

            return null;
        }

        public void DFS(Action<T> action)
        {
            this.DFS(this.Root, action);
        }

        private void DFS(Node<T> nodeValue, Action<T> action)
        {
            if (nodeValue != null)
            {
                action.Invoke(nodeValue.Value);

                foreach (var child in nodeValue.Children)
                {
                    this.DFS(child, action);
                }
            }
        }
    }
}
