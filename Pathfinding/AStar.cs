using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pathfinding
{
    public class AStar
    {
        private const int MOVE_STRAIGHT_COST = 10;
        private const int MOVE_DIAGONAL_COST = 14;

        private List<PathNode> openList;
        //private List<int> openListFCost = new List<int>();
        private List<PathNode> closedList;
        private Form1 form1;

        public AStar(Form1 form)
        {
            form1 = form;
        }

        public List<PathNode> FindPath(bool showAnim)
        {
            PathNode startNode = new PathNode(Points.startPoint);
            PathNode endNode = new PathNode(Points.endPoint);

            openList = new List<PathNode> { startNode };
            closedList = new List<PathNode>();

            startNode.gCost = 0;
            startNode.hCost = CalculateDistanceCost(Points.startPoint, Points.endPoint);
            startNode.CalculateFCost();
            //.Add(startNode.fCost);

            while (openList.Count > 0)
            {
                Console.WriteLine("OL: " + openList.Count.ToString() + " CL: " + closedList.Count.ToString());
                PathNode currentNode = GetLowestFCostNode(openList);
                //form1.nodeInArea[currentNode.location.X, currentNode.location.Y].BackColor = Color.Yellow;

                if (currentNode.location == endNode.location)
                {
                    endNode = currentNode;
                    form1.stopwatch.Stop();
                    form1.timer.Stop();

                    if (!form1.lblRunTime.InvokeRequired)
                        form1.lblRunTime.Text = form1.stopwatch.Elapsed.ToString();
                    else
                        form1.lblRunTime.Invoke((MethodInvoker)delegate
                        {
                            form1.lblRunTime.Text = form1.stopwatch.Elapsed.ToString();
                        });

                    return CalcularePath(endNode);
                }

                openList.Remove(currentNode);
                //openList.Clear();
                //if (openList.Count > 5000)
                //   openList.RemoveRange(0, openList.Count/2);
                closedList.Add(currentNode);
                if (showAnim)
                    form1.nodeInArea[currentNode.location.X, currentNode.location.Y].BackColor = Color.Red;

                foreach (PathNode neighbourNode in GetNeighbourList(currentNode))
                {
                    if (form1.nodeInArea[neighbourNode.location.X, neighbourNode.location.Y].BackColor == Color.Black)
                        continue;

                    if (form1.nodeInArea[neighbourNode.location.X, neighbourNode.location.Y].BackColor == Color.Red)
                        continue;

                    int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode.location, neighbourNode.location);
                    if (tentativeGCost <= neighbourNode.gCost)
                    {
                        neighbourNode.parentPathNode = currentNode;
                        neighbourNode.gCost = tentativeGCost;
                        neighbourNode.hCost = CalculateDistanceCost(neighbourNode.location, Points.endPoint);
                        neighbourNode.CalculateFCost();

                        if (!openList.Contains(neighbourNode))
                        {
                            openList.Add(neighbourNode);
                            if (showAnim)
                                form1.nodeInArea[neighbourNode.location.X, neighbourNode.location.Y].BackColor = Color.Green;
                        }
                    }
                }
                //openList.Sort((x, y) => x.fCost.CompareTo(y.fCost));
            }
            form1.stopwatch.Stop();
            form1.timer.Stop();

            if (!form1.lblRunTime.InvokeRequired)
                form1.lblRunTime.Text = form1.stopwatch.Elapsed.ToString();
            else
                form1.lblRunTime.Invoke((MethodInvoker)delegate
                {
                    form1.lblRunTime.Text = form1.stopwatch.Elapsed.ToString();
                });

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

            form1.nodeInArea[currentNode.location.X, currentNode.location.Y].BackColor = Color.Magenta;
            path.Reverse();
            return path;
        }

        private List<PathNode> GetNeighbourList(PathNode currentNode)
        {
            List<PathNode> neighbourList = new List<PathNode>();

            if (currentNode.location.X - 1 >= 0)
            {
                // LEFT
                neighbourList.Add(new PathNode(new Point(currentNode.location.X - 1, currentNode.location.Y), currentNode.gCost + 10));
                // LEFT DOWN
                if (currentNode.location.Y - 1 >= 0) 
                    neighbourList.Add(new PathNode(new Point(currentNode.location.X - 1, currentNode.location.Y - 1), currentNode.gCost + 14));
                // LEFT UP
                if (currentNode.location.Y + 1 < form1.areaSize)
                    neighbourList.Add(new PathNode(new Point(currentNode.location.X - 1, currentNode.location.Y + 1), currentNode.gCost + 14));
            }
            if (currentNode.location.X + 1 < form1.areaSize)
            {
                // RIGHT
                neighbourList.Add(new PathNode(new Point(currentNode.location.X + 1, currentNode.location.Y), currentNode.gCost + 10));
                // RIGHT DOWN
                if (currentNode.location.Y - 1 >= 0)
                    neighbourList.Add(new PathNode(new Point(currentNode.location.X + 1, currentNode.location.Y - 1), currentNode.gCost + 14));
                // RIGHT UP
                if (currentNode.location.Y + 1 < form1.areaSize)
                    neighbourList.Add(new PathNode(new Point(currentNode.location.X + 1, currentNode.location.Y + 1), currentNode.gCost + 14));
            }
            // DOWN
            if (currentNode.location.Y - 1 >= 0)
                neighbourList.Add(new PathNode(new Point(currentNode.location.X, currentNode.location.Y - 1), currentNode.gCost + 10));
            // UP
            if (currentNode.location.Y + 1 < form1.areaSize)
                neighbourList.Add(new PathNode(new Point(currentNode.location.X, currentNode.location.Y + 1), currentNode.gCost + 10));

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
