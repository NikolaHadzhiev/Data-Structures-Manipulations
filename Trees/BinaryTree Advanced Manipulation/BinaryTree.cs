using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree_Advanced_Manipulation
{
    public class BinaryTree<T>
    {
        public T Value { get; private set; }
        public BinaryTree<T> LeftNode { get; private set; }
        public BinaryTree<T> RightNode { get; private set; }

        public BinaryTree(T value, BinaryTree<T> leftNode = null, BinaryTree<T> rightNode = null)
        {
            this.Value = value;
            this.LeftNode = leftNode;
            this.RightNode = rightNode;
        }
        public void PreOrder(Action<T> action)
        {
            this.PreOrder(this, action);
        }

        private void PreOrder(BinaryTree<T> nodeValue, Action<T> action)
        {
            if (nodeValue != null)
            {
                action.Invoke(nodeValue.Value);
                PreOrder(nodeValue.LeftNode, action);
                PreOrder(nodeValue.RightNode, action);
            }
        }
        public void InOrder(Action<T> action)
        {
            this.InOrder(this, action);
        }
        private void InOrder(BinaryTree<T> nodeValue, Action<T> action)
        {
            if (nodeValue != null)
            {
                InOrder(nodeValue.LeftNode, action);
                action.Invoke(nodeValue.Value);
                InOrder(nodeValue.RightNode, action);

            }
        }

        public void PostOrder(Action<T> action)
        {
            this.PostOrder(this, action);
        }
        private void PostOrder(BinaryTree<T> nodeValue, Action<T> action)
        {
            if (nodeValue != null)
            {
                PostOrder(nodeValue.LeftNode, action);
                PostOrder(nodeValue.RightNode, action);
                action.Invoke(nodeValue.Value);

            }
        }

        public void PrintIndentedPreOrder(int indent = 0)
        {
            Console.WriteLine(new string(' ', indent) + this.Value);

            if (this.LeftNode != null)
            {

                this.LeftNode.PrintIndentedPreOrder(indent + 2);

            }

            if (this.RightNode != null)
            {

                this.RightNode.PrintIndentedPreOrder(indent + 2);

            }
        }

        public void EachInOrder(Action<T> action)
        {
            if (this.LeftNode != null)
            {

                this.LeftNode.EachInOrder(action);

            }
            action(this.Value);

            if (this.RightNode != null)
            {

                this.RightNode.EachInOrder(action);

            }

        }
    }
}
