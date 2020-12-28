using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public class AStar
    {
        private const int MOVE_STRAIGHT_COST = 10;
        private const int MOVE_DIAGONAL_COST = 14;

        private List<PathNode> openList;
        private List<PathNode> closedList;
        private Form1 form1;

        public AStar(Form1 form)
        {
            form1 = form;
        }

        public List<PathNode> FindPath()
        {
            PathNode startNode = new PathNode(Points.startPoint);
            PathNode endNode = new PathNode(Points.endPoint);

            openList = new List<PathNode> { startNode };
            closedList = new List<PathNode>();

            startNode.gCost = 0;
            startNode.hCost = CalculateDistanceCost(Points.startPoint, Points.endPoint);
            startNode.CalculateFCost();

            while (openList.Count > 0)
            {
                PathNode currentNode = GetLowestFCostNode(openList);

                if (currentNode.location == endNode.location)
                {
                    endNode = currentNode;
                    return CalcularePath(endNode);
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                foreach (PathNode neighbourNode in GetNeighbourList(currentNode))
                {
                    if (closedList.Contains(neighbourNode))
                        continue;

                    int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode.location, neighbourNode.location);
                    if (tentativeGCost < neighbourNode.gCost)
                    {
                        neighbourNode.parentPathNode = currentNode;
                        neighbourNode.gCost = tentativeGCost;
                        neighbourNode.hCost = CalculateDistanceCost(neighbourNode.location, Points.endPoint);
                        neighbourNode.CalculateFCost();

                        if (!openList.Contains(neighbourNode))
                        {
                            openList.Add(neighbourNode);
                            form1.nodeInArea[currentNode.location.X, currentNode.location.Y].BackColor = Color.Green;
                        }
                    }
                }

                form1.nodeInArea[currentNode.location.X, currentNode.location.Y].BackColor = Color.Red;
            }

            return null;
        }

        private List<PathNode> CalcularePath (PathNode finalNode)
        {
            List<PathNode> path = new List<PathNode>() { finalNode };
            PathNode currentNode = finalNode;

            while (currentNode.parentPathNode != null)
            {
                form1.nodeInArea[currentNode.location.X, currentNode.location.Y].BackColor = Color.Magenta;
                path.Add(currentNode.parentPathNode);
                currentNode = currentNode.parentPathNode;
            }

            path.Reverse();
            return path;
        }

        private List<PathNode> GetNeighbourList(PathNode currentNode)
        {
            List<PathNode> neighbourList = new List<PathNode>();

            if (currentNode.location.X - 1 >= 0)
            {
                neighbourList.Add(new PathNode(new Point(currentNode.location.X - 1, currentNode.location.Y)));
                if (currentNode.location.Y - 1 >= 0)
                    neighbourList.Add(new PathNode(new Point(currentNode.location.X - 1, currentNode.location.Y - 1)));
                if (currentNode.location.Y + 1 < form1.areaSize)
                    neighbourList.Add(new PathNode(new Point(currentNode.location.X - 1, currentNode.location.Y + 1)));
            }
            if (currentNode.location.X + 1 < form1.areaSize)
            {
                neighbourList.Add(new PathNode(new Point(currentNode.location.X + 1, currentNode.location.Y)));
                if (currentNode.location.Y - 1 >= 0)
                    neighbourList.Add(new PathNode(new Point(currentNode.location.X + 1, currentNode.location.Y - 1)));
                if (currentNode.location.Y + 1 < form1.areaSize)
                    neighbourList.Add(new PathNode(new Point(currentNode.location.X + 1, currentNode.location.Y + 1)));
            }
            if (currentNode.location.Y - 1 >= 0)
                neighbourList.Add(new PathNode(new Point(currentNode.location.X, currentNode.location.Y - 1)));
            if (currentNode.location.Y + 1 < form1.areaSize)
                neighbourList.Add(new PathNode(new Point(currentNode.location.X, currentNode.location.Y + 1)));

            return neighbourList;
        }

        private int CalculateDistanceCost(Point pathNodeAPosition, Point pathNodeBPosition)
        {
            int xDistance = Math.Abs(pathNodeAPosition.X - pathNodeBPosition.X);
            int yDistance = Math.Abs(pathNodeAPosition.Y - pathNodeBPosition.Y);
            int remaining = Math.Abs(xDistance - yDistance);
            return MOVE_DIAGONAL_COST * Math.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
        }

        private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
        {
            PathNode lowestFCostNode = pathNodeList[0];
            for (int i = 0; i < pathNodeList.Count; i++)
            {
                if (pathNodeList[i].fCost < lowestFCostNode.fCost)
                    lowestFCostNode = pathNodeList[i];
            }
            return lowestFCostNode;
        }
    }
}
