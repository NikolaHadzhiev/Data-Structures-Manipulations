using System;
using System.Collections.Generic;
using System.Text;

namespace GraphProgram
{
    public class Graph<T>
    {
        private List<T> values;
        private Dictionary<int, Dictionary<int, int>> conections;

        public int ConectedComponentsCount { get; private set; } = 0;
        public bool IsTreferced { get; set; } = false;

        public Graph()
        {
            this.values = new List<T>();
            this.conections = new Dictionary<int, Dictionary<int, int>>();
        }

        public void Add(T value)
        {
            this.values.Add(value);
            this.conections.Add(values.Count - 1, new Dictionary<int, int>());
        }

        public virtual void Connect(T parent, T child, int weight)
        {
            int parentIndex = this.values.IndexOf(parent);
            int childIndex = this.values.IndexOf(child);

            this.conections[parentIndex][childIndex] = weight;
        }

        public void DFS(Action<T> action)
        {
            bool[] visited = new bool[this.values.Count];

            foreach (var item in this.conections)
            {
                //connected items
                if (!visited[item.Key])
                {
                    this.ConectedComponentsCount++;
                }
                this.DFS(item.Key, visited, action);
            }
        }
        private void DFS(int currentNodeIndex, bool[] visited, Action<T> action)
        {
            if (!visited[currentNodeIndex])
            {
                visited[currentNodeIndex] = true;

                foreach (var child in this.conections[currentNodeIndex])
                {
                    this.DFS(child.Key, visited, action);
                }

                action.Invoke(this.values[currentNodeIndex]);
            }
        }

        public virtual void BFS(int key, Action<T> action)
        {
            bool[] visited = new bool[this.values.Count];

            foreach (var item in this.conections)
            {
                //connected items
                if (!visited[item.Key])
                {
                    this.ConectedComponentsCount++;
                }
                this.BFS(item.Key, visited, action);
            }
        }
        private void BFS(int currentNodeIndex, bool[] visited, Action<T> action)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(currentNodeIndex);

            while (queue.Count > 0)
            {
                int currentNode = queue.Dequeue();
                if (!visited[currentNodeIndex])
                {
                    visited[currentNodeIndex] = true;

                    action.Invoke(this.values[currentNode]);

                    foreach (var child in this.conections[currentNode])
                    {
                        queue.Enqueue(child.Key);
                    }
                }
            }
        }

        public virtual List<T> TopologicalSort()
        {

            return null;
        }
    }

}

