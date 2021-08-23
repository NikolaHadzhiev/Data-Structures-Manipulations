using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
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
            this.conections = new Dictionary<int, Dictionary<int, int>>(); // parent child
        }

        public void Add(T value)
        {
            this.values.Add(value);
            this.conections.Add(values.Count - 1, new Dictionary<int, int>());
        }

        public virtual void Connect(T parent, T child, int weight = 0)
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

        public List<T> Sort()
        {
            List<T> inOrder = new List<T>();
            Sort(inOrder);
            return inOrder;
        }

        private void Sort(List<T> ordered)
        {
            int indexOfCity = FindFirst();
            if (indexOfCity == -1)
            {
                return;
            }
            ordered.Add(values[indexOfCity]);
            this.conections.Remove(indexOfCity);
            //this.values.RemoveAt(indexOfCity);
            Sort(ordered);
        }
        private int FindFirst()
        {
            foreach (var parent in this.conections.Keys)
            {
                bool isContained = false;
                foreach (Dictionary<int, int> dic in this.conections.Values)
                {
                    if (dic.ContainsKey(parent))
                    {
                        isContained = true;
                    }
                }

                if (!isContained)
                {
                    return parent;
                }
            }
            return -1;
        }
    }
}
}
