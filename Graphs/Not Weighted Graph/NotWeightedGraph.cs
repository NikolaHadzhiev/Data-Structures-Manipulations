using System;
using System.Collections.Generic;
using System.Text;

namespace GraphProgram
{
    public class NotWeightedGraph<T> : Graph<T>
    {
        public override void Connect(T parent, T child, int weight = 0)
        {
            base.Connect(parent, child, weight);
            base.Connect(child, parent, weight);
        }
    }
}
