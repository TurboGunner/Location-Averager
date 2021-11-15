using System.Collections.Generic;
using System.Linq;
using static OperationDojima.Program;

namespace OperationDojima
{
    public class MidPointMethods
    {
        public static List<List<GraphNode<Location>>> NeighborMidPoints()
        {
            var output = new List<List<GraphNode<Location>>>();
            for (int i = 0; i < graph.nodes.Count(); i++)
            {
                var start = graph.nodes.ElementAt(i);
                List<GraphNode<Location>> addList = new List<GraphNode<Location>>();
                for (int j = 0; j < start.neighbors.Count(); j++)
                {
                    addList.Add(new GraphNode<Location>(Formulas.MidPoint(start.value, start.neighbors.ElementAt(j).value)));
                }
                output.Add(addList);
            }
            return output;
        }

        public static List<Location> AveragedMidPoints(List<List<GraphNode<Location>>> nestedList)
        {
            List<Location> output = new List<Location>();
            foreach(List<GraphNode<Location>> list in nestedList)
            {
                double la = 0, lo = 0;
                foreach(GraphNode<Location> node in list)
                {
                    la += node.value.la;
                    lo += node.value.lo;
                }
                la /= list.Count();
                lo /= list.Count();
                output.Add(new Location(la, lo, "Average of Location: "));
            }
            return output;
        }

        public static Location FinalMidPoint(List<Location> list)
        {
            double la = 0, lo = 0;
            foreach(Location location in list)
            {
                la += location.la;
                lo += location.lo;
            }
            la /= list.Count();
            lo /= list.Count();
            return new Location(la, lo, "Final Output: ");
        }
    }
}