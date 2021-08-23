using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs_Advanced_Manipulation
{
    public class UndirectedGraph<T> : Graph<T>
    {
        public override void Connect(T parent, T child, int weight)
        {
            base.Connect(parent, child, weight);
            base.Connect(child, parent, weight);
        }
    }
}
