using System;
using System.Collections.Generic;

namespace OperationDojima
{
    public class Program
    {
        public static UndirectedGraph<Location> graph;
        public static void Main(string[] args)
        {
            Location[] arr = {
                //Your locations here
            };
            GraphNode<Location>[] nodes = new GraphNode<Location>[arr.Length];

            for(int i = 0; i < arr.Length; i++) //Populate Graph Node array
            {
                nodes[i] = new GraphNode<Location>(arr[i].ChangeForm());
            }
            graph = new UndirectedGraph<Location>(nodes);

            List<List<GraphNode<Location>>> output = MidPointMethods.NeighborMidPoints();
            foreach(var locations in output)
            {
                foreach(var location in locations)
                {
                    Console.WriteLine(location); 
                }
            }
            List<Location> totals = MidPointMethods.AveragedMidPoints(output);
            foreach(var total in totals)
            {
                Console.WriteLine(total);
            }
            Console.WriteLine(MidPointMethods.FinalMidPoint(totals));
            Console.ReadLine();
        }
    }
}