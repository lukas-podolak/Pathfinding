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
        public Point location = Point.Empty;
        public Point parentNodeLocation = Point.Empty;

        public PathNode parentPathNode = null;

        public int gCost = int.MaxValue;
        public int hCost;
        public int fCost;

        // N - NULL     C - CLOSE   O - OPEN    B - BARRIER
        // S - START    E - END
        public char tag = 'N';

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
