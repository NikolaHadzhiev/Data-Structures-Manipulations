using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs_Advanced_Manipulation
{
    public class Graph<T>
    {
        private List<T> values;

        private Dictionary<int, Dictionary<int, int>> connections;

        public Graph()
        {
            this.values = new List<T>();
            this.connections = new Dictionary<int, Dictionary<int, int>>();
        }

        public int ConnectedComponentsCount { get; private set; }

        public virtual void Add(T value)
        {
            this.values.Add(value);
            this.connections.Add(this.values.Count - 1, new Dictionary<int, int>());
        }

        public virtual void Connect(T parent, T child, int weight)
        {
            int parentIndex = this.values.IndexOf(parent);
            int childIndex = this.values.IndexOf(child);

            this.connections[parentIndex][childIndex] = weight;
        }

        public virtual void DFS(Action<T> action)
        {
            bool[] visited = new bool[this.values.Count];

            foreach (var item in this.connections)
            {
                if (!visited[item.Key])
                {
                    this.ConnectedComponentsCount++;
                }

                this.DFS(item.Key, visited, action);
            }
        }

        public virtual void BFS(Action<T> action)
        {
            bool[] visited = new bool[this.values.Count];

            foreach (var item in this.connections)
            {
                if (!visited[item.Key])
                {
                    this.ConnectedComponentsCount++;
                }

                this.BFS(item.Key, visited, action);
            }
        }

        public virtual List<T> TopologicalSort()
        {
            Stack<int> sortedNotes = new Stack<int>();
            bool[] visited = new bool[this.values.Count];

            foreach (var node in this.connections)
            {
                this.TopologicalSort(node.Key, sortedNotes, visited);
            }

            List<T> topologicallySortedNodes = new List<T>();

            while (sortedNotes.Count > 0)
            {
                topologicallySortedNodes.Add(this.values[sortedNotes.Pop()]);
            }

            return topologicallySortedNodes;
        }

        private void TopologicalSort(int current, Stack<int> sortedNodes, bool[] visited)
        {
            if (!visited[current])
            {
                visited[current] = true;

                foreach (var child in this.connections[current])
                {
                    this.TopologicalSort(child.Key, sortedNodes, visited);
                }

                sortedNodes.Push(current);
            }
        }

        private void BFS(int currentNodeIndex, bool[] visited, Action<T> action)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(currentNodeIndex);

            while (queue.Count > 0)
            {
                currentNodeIndex = queue.Dequeue();

                if (!visited[currentNodeIndex])
                {
                    visited[currentNodeIndex] = true;

                    action.Invoke(this.values[currentNodeIndex]);

                    foreach (var child in this.connections[currentNodeIndex])
                    {
                        queue.Enqueue(child.Key);
                    }
                }
            }
        }

        private void DFS(int currentNodeIndex, bool[] visited, Action<T> action)
        {
            if (!visited[currentNodeIndex])
            {
                visited[currentNodeIndex] = true;

                foreach (var child in this.connections[currentNodeIndex])
                {
                    this.DFS(child.Key, visited, action);
                }

                action.Invoke(this.values[currentNodeIndex]);
            }
        }
    }
}
