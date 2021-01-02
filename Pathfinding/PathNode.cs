using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public class PathNode
    {
        public Point location;
        public PathNode parentPathNode = null;

        public int gCost = int.MaxValue;
        public int hCost;
        public int fCost;

        public PathNode(Point location)
        {
            this.location = location;
        }

        public PathNode(Point location, int gCost)
        {
            this.location = location;
            this.gCost = gCost;
        }

        public void CalculateFCost()
        {
            fCost = gCost + hCost;
        }
    }
}
