using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OperationDojima
{
    public class UndirectedGraph<T> : ICollection<GraphNode<T>>
    {
        public HashSet<GraphNode<T>> nodes { get; }

        int ICollection<GraphNode<T>>.Count => nodes.Count;

        public bool IsReadOnly => false;

        IEnumerator numerator;

        public UndirectedGraph(params GraphNode<T>[] n)
        {
            nodes = new HashSet<GraphNode<T>>();
            for (int i = 0; i < n.Count(); i++)
            {
                nodes.Add(n.ElementAt(i));
            }
            foreach (GraphNode<T> node in nodes)
            {
                GraphNode<T>[] filtered = Array.FindAll(n, s => !s.Equals(node));
                node.SetNeighbors(filtered);
            }
            numerator = nodes.GetEnumerator();
        }

        public void Add(GraphNode<T> item)
        {
            nodes.Add(item);
        }

        public void Clear()
        {
            nodes.Clear();
        }

        public bool Contains(GraphNode<T> item)
        {
            return nodes.Contains(item);
        }

        public void CopyTo(GraphNode<T>[] array, int arrayIndex)
        {
            for(int i = 0; i < nodes.Count; i++)
            {
                array[i] = nodes.ElementAt(arrayIndex + i);
            }
        }

        public bool Remove(GraphNode<T> item)
        {
            return nodes.Remove(item);
        }

        public IEnumerator<GraphNode<T>> GetEnumerator()
        {
            return nodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return numerator;
        }

        public int IndexOf(GraphNode<T> item)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes.ElementAt(i).Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public override string ToString()
        {
            string output = "";
            foreach (GraphNode<T> node in nodes)
            {
                output += node;
            }
            return output;
        }
    }
}