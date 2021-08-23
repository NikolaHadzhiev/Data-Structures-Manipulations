using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree_Vol_2
{
    public class Tree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; set; }

        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
            }
            else
            {
                Node<T> currentNode = new Node<T>(value);
                Node<T> currentParent = Root;

                while (true)
                {
                    if (currentNode.Value.CompareTo(currentParent.Value) <= 0)
                    {
                        if (currentParent.LeftChild == null)
                        {
                            currentParent.LeftChild = currentNode;
                        }
                        else
                        {
                            currentParent = currentParent.LeftChild;
                        }

                    }

                    else
                    {
                        if (currentParent.RightChild == null)
                        {
                            currentParent.RightChild = currentNode;
                        }
                        else
                        {
                            currentParent = currentParent.RightChild;
                        }
                    }
                }
            }
        }

        public void InOrder()
        {
            InOrder(this.Root);
        }

        private void InOrder(Node<T> nodeValue)
        {
            if (nodeValue != null)
            {
                InOrder(nodeValue.LeftChild);
                Console.WriteLine(nodeValue.Value);
                InOrder(nodeValue.RightChild);
            }
        }

        public bool Contains(T value)
        {
            return Search(Root, value) != null;
        }
        private Node<T> Search(Node<T> currentNode, T value)
        {
            if (currentNode == null)
            {
                return null;
            }
            else
            {

                if (value.CompareTo(Root.Value) == 0)
                {
                    return Root;
                }
                else if (value.CompareTo(Root.Value) < 0)
                {
                    Search(currentNode.LeftChild, value);
                }
                else if (value.CompareTo(Root.Value) > 0)
                {
                    Search(currentNode.RightChild, value);
                }
            }
            return null;
        }
    }
}

