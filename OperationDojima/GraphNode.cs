using System.Collections.Generic;
using System.Linq;

namespace OperationDojima
{
    public class GraphNode<T>
    {
        public T value { get; set; }
        public HashSet<GraphNode<T>> neighbors { get; set; }

        public GraphNode(T v)
        {
            value = v;
            neighbors = new HashSet<GraphNode<T>>();
        }

        public void SetNeighbors(params GraphNode<T>[] n)
        {
            for (int i = 0; i < n.Count(); i++)
            {
                neighbors.Add(n.ElementAt(i));
            }
        }
        public override bool Equals(object obj)
        {
            if (!(obj is GraphNode<T>))
            {
                return false;
            }
            return value.Equals((obj as GraphNode<T>).value);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"Graph Node Value: {value}";
        }
    }
}