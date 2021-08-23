using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree_Advanced_Manipulation
{
    public class Tree<T>
    {
        public T Value { get; set; }

        public IList<Tree<T>> Children { get; }

        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;

            this.Children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.Children.Add(child);
            }
        }

        public void Print(int indent = 0)
        {
            Console.Write(new string(' ', 2 * indent));

            Console.WriteLine(this.Value);

            foreach (var child in this.Children)
            {
                child.Print(indent + 1);
            }
        }

        public void DFS(Action<T> action)
        {
            DFS(this, action);
        }
        private void DFS(Tree<T> node, Action<T> action)
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

        public void BFS(Action<T> action)
        {
            BFS(this, action);
        }
        private void BFS(Tree<T> node, Action<T> action)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                Tree<T> queueNode = queue.Dequeue();
                action.Invoke(queueNode.Value);

                foreach (var child in queueNode.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public IEnumerable<T> OrderDFS()
        {
            List<T> order = new List<T>();

            this.OrderDFS(this, order);
            return order;
        }

        private void OrderDFS(Tree<T> tree, List<T> order)
        {
            foreach (var child in tree.Children)
            {
                this.OrderDFS(child, order);
            }
            order.Add(tree.Value);
        }

        public IEnumerable<T> OrderBFS()
        {
            var queue = new Queue<Tree<T>>();
            var order = new List<T>();
            this.OrderBFS(queue, order);
            return order;
        }

        private IEnumerable<T> OrderBFS(Queue<Tree<T>> treeQueue, List<T> order)
        {
            treeQueue.Enqueue(this);

            while (treeQueue.Count > 0)
            {
                var current = treeQueue.Dequeue();
                order.Add(current.Value);
                foreach (var child in current.Children)
                {
                    treeQueue.Enqueue(child);
                }
            }
            return order;
        }
    }
}
