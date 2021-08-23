using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private Node<T> Root { get; set; }

        public int Count { get; private set; } = 0;

        public void Insert(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (Count == 0)
            {
                this.Root = newNode;
            }
            else
            {
                Node<T> currentItem = this.Root;
                Node<T> parent = null;
                while (true)
                {
                    parent = currentItem;
                    if (item.CompareTo(currentItem.Value) < 0)
                    {
                        currentItem = currentItem.Left;
                        if (currentItem == null)
                        {
                            newNode.Perant = parent;
                            parent.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        currentItem = currentItem.Right;
                        if (currentItem == null)
                        {
                            newNode.Perant = parent;
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }

            this.Count++;
        }

        public Node<T> Search(T value)
        {
            Node<T> currentNode = this.Root;
            while (currentNode != null)
            {
                if (value.CompareTo(currentNode.Value) < 0)
                {
                    currentNode = currentNode.Left;
                }
                else if (value.CompareTo(currentNode.Value) > 0)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    return currentNode;
                }
            }
            return null;
        }

        public bool Contains(T value)
        {
            if (Search(value) != null)
            {
                return true;
            }

            return false;
        }

        public Node<T> GetMin()
        {
            Node<T> currentNode = this.Root;

            while (currentNode.Left != null)
            {
                currentNode = currentNode.Left;
            }

            return currentNode;
        }

        public void Remove(T value)
        {
            this.Count--;
            Remove(value, this.Root, false);
        }
        private void Remove(T value, Node<T> currentNode, bool chieldIsFromLeft)
        {
            if (currentNode != null)
            {
                if (value.CompareTo(currentNode.Value) == 0)
                {
                    if (currentNode.Left == null && currentNode.Right == null)
                    {
                        if (chieldIsFromLeft)
                        {
                            currentNode.Perant.Left = null;
                        }
                        else
                        {
                            currentNode.Perant.Right = null;
                        }
                    }
                }
                else if (value.CompareTo(currentNode.Value) < 0)
                {
                    Remove(value, currentNode.Left, true);
                }
                else
                {
                    Remove(value, currentNode.Right, false);
                }
            }
        }

        public Node<T> GetMax()
        {
            Node<T> currentNode = this.Root;

            while (currentNode.Right != null)
            {
                currentNode = currentNode.Right;
            }

            return currentNode;
        }

        public void PreOrder()
        {
            PreOrder(Root);
        }
        private void PreOrder(Node<T> node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Value);
                PreOrder(node.Left);
                PreOrder(node.Right);
            }
        }

        public void InOrder()
        {
            InOrder(this.Root);
        }
        private void InOrder(Node<T> node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                Console.WriteLine(node.Value);
                InOrder(node.Right);
            }
        }
    }
}
