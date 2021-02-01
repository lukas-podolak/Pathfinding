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
    public class AStarV2
    {
        private const int MOVE_STRAIGHT_COST = 10;
        private const int MOVE_DIAGONAL_COST = 14;

        private List<Point> openList;
        private List<Point> closedList;
        private Form1 form1;

        public AStarV2(Form1 form)
        {
            form1 = form;
        }

        public List<Point> FindPath(bool showAnim)
        {
            //  startNode = form1.nodeArea[Points.startPoint.X, Points.startPoint.Y];
            //  endNode = form1.nodeArea[Points.endPoint.X, Points.endPoint.Y];

            openList = new List<Point> { Points.startPoint };
            closedList = new List<Point>();

            form1.nodeArea[Points.startPoint.X, Points.startPoint.Y].gCost = 0;
            form1.nodeArea[Points.startPoint.X, Points.startPoint.Y].hCost = CalculateDistanceCost(Points.startPoint, Points.endPoint);
            form1.nodeArea[Points.startPoint.X, Points.startPoint.Y].CalculateFCost();

            while (openList.Count > 0)
            {

                /*LOG*/ Console.WriteLine("OL: " + openList.Count.ToString() + " CL: " + closedList.Count.ToString());
                
                Point currentNodeLocation = GetLowestFCostNode(openList);

                if (form1.nodeArea[currentNodeLocation.X,currentNodeLocation.Y].location == form1.nodeArea[Points.endPoint.X, Points.endPoint.Y].location)
                {
                    form1.nodeArea[Points.endPoint.X, Points.endPoint.Y] = form1.nodeArea[currentNodeLocation.X, currentNodeLocation.Y];
                    form1.stopwatch.Stop();
                    form1.timer.Stop();

                    if (!form1.lblRunTime.InvokeRequired)
                        form1.lblRunTime.Text = form1.stopwatch.Elapsed.ToString();
                    else
                        form1.lblRunTime.Invoke((MethodInvoker)delegate
                        {
                            form1.lblRunTime.Text = form1.stopwatch.Elapsed.ToString();
                        });

                    return CalcularePath(form1.nodeArea[Points.endPoint.X, Points.endPoint.Y]);
                }

                // Revrite Lists
                openList.Remove(currentNodeLocation);
                closedList.Add(currentNodeLocation);

                if (showAnim)
                {
                    form1.nodeArea[currentNodeLocation.X, currentNodeLocation.Y].tag = 'C';
                    form1.nodeInArea[currentNodeLocation.X, currentNodeLocation.Y].BackColor = Color.Red;
                }

                foreach (Point neighbourNode in GetNeighbourList(form1.nodeArea[currentNodeLocation.X, currentNodeLocation.Y]))
                {
                    if (form1.nodeArea[neighbourNode.X, neighbourNode.Y].tag == 'B')
                        continue;

                    if (form1.nodeArea[neighbourNode.X, neighbourNode.Y].tag == 'C')
                        continue;

                    int tentativeGCost = form1.nodeArea[currentNodeLocation.X, currentNodeLocation.Y].gCost + CalculateDistanceCost(currentNodeLocation, neighbourNode);
                    if (tentativeGCost <= form1.nodeArea[neighbourNode.X, neighbourNode.Y].gCost)
                    {
                        form1.nodeArea[neighbourNode.X, neighbourNode.Y].parentPathNode = form1.nodeArea[currentNodeLocation.X, currentNodeLocation.Y]; // Případně přidat lokaci
                        form1.nodeArea[neighbourNode.X, neighbourNode.Y].gCost = tentativeGCost;
                        form1.nodeArea[neighbourNode.X, neighbourNode.Y].hCost = CalculateDistanceCost(neighbourNode, Points.endPoint);
                        form1.nodeArea[neighbourNode.X, neighbourNode.Y].CalculateFCost();

                        if (!openList.Contains(neighbourNode))
                        {
                            openList.Add(neighbourNode);
                            if (showAnim)
                            {
                                form1.nodeArea[neighbourNode.X, neighbourNode.Y].tag = 'O';
                                form1.nodeInArea[neighbourNode.X, neighbourNode.Y].BackColor = Color.Green;
                            }
                        }
                    }
                }
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
            MessageBox.Show("No possible path found.", "Pathfinding - A*", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }

        private List<Point> CalcularePath(PathNode finalNode)
        {
            List<Point> path = new List<Point>() { finalNode.location };
            PathNode currentNode = finalNode;

            while (currentNode.parentPathNode != null)
            {
                form1.nodeInArea[currentNode.location.X, currentNode.location.Y].BackColor = Color.Magenta;
                path.Add(currentNode.parentNodeLocation);
                currentNode = form1.nodeArea[currentNode.parentNodeLocation.X,currentNode.parentNodeLocation.Y];
            }

            form1.nodeInArea[currentNode.location.X, currentNode.location.Y].BackColor = Color.Magenta;
            path.Reverse();
            return path;
        }

        private List<Point> GetNeighbourList(PathNode currentNode)
        {
            List<Point> neighbourList = new List<Point>();

            if (currentNode.location.X - 1 >= 0)
            {
                // LEFT
                neighbourList.Add(new Point(currentNode.location.X - 1, currentNode.location.Y));
                form1.nodeArea[currentNode.location.X - 1, currentNode.location.Y].gCost = currentNode.gCost + 10;
                // LEFT DOWN
                if (currentNode.location.Y - 1 >= 0)
                {
                    neighbourList.Add(new Point(currentNode.location.X - 1, currentNode.location.Y - 1));
                    form1.nodeArea[currentNode.location.X - 1, currentNode.location.Y - 1].gCost = currentNode.gCost + 14;
                }
                // LEFT UP
                if (currentNode.location.Y + 1 < form1.areaSize)
                {
                    neighbourList.Add(new Point(currentNode.location.X - 1, currentNode.location.Y + 1));
                    form1.nodeArea[currentNode.location.X - 1, currentNode.location.Y + 1].gCost = currentNode.gCost + 14;
                }
            }
            if (currentNode.location.X + 1 < form1.areaSize)
            {
                // RIGHT
                neighbourList.Add(new Point(currentNode.location.X + 1, currentNode.location.Y));
                form1.nodeArea[currentNode.location.X + 1, currentNode.location.Y].gCost = currentNode.gCost + 10;
                // RIGHT DOWN
                if (currentNode.location.Y - 1 >= 0)
                {
                    neighbourList.Add(new Point(currentNode.location.X + 1, currentNode.location.Y - 1));
                    form1.nodeArea[currentNode.location.X + 1, currentNode.location.Y - 1].gCost = currentNode.gCost + 14;
                }
                // RIGHT UP
                if (currentNode.location.Y + 1 < form1.areaSize)
                {
                    neighbourList.Add(new Point(currentNode.location.X + 1, currentNode.location.Y + 1));
                    form1.nodeArea[currentNode.location.X + 1, currentNode.location.Y + 1].gCost = currentNode.gCost + 14;
                }
            }
            // DOWN
            if (currentNode.location.Y - 1 >= 0)
            {
                neighbourList.Add(new Point(currentNode.location.X, currentNode.location.Y - 1));
                form1.nodeArea[currentNode.location.X, currentNode.location.Y - 1].gCost = currentNode.gCost + 10;
            }
            // UP
            if (currentNode.location.Y + 1 < form1.areaSize)
            {
                neighbourList.Add(new Point(currentNode.location.X, currentNode.location.Y + 1));
                form1.nodeArea[currentNode.location.X, currentNode.location.Y + 1].gCost = currentNode.gCost + 10;
            }

            return neighbourList;
        }

        private int CalculateDistanceCost(Point pathNodeAPosition, Point pathNodeBPosition)
        {
            int xDistance = Math.Abs(pathNodeAPosition.X - pathNodeBPosition.X);
            int yDistance = Math.Abs(pathNodeAPosition.Y - pathNodeBPosition.Y);
            int remaining = Math.Abs(xDistance - yDistance);
            return MOVE_DIAGONAL_COST * Math.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
        }

        private Point GetLowestFCostNode(List<Point> pathNodeList)
        {
            PathNode lowestFCostNodeLocation = form1.nodeArea[pathNodeList[0].X, pathNodeList[0].Y];

            for (int i = 0; i < pathNodeList.Count; i++)
            {
                if (form1.nodeArea[pathNodeList[i].X, pathNodeList[i].Y].fCost < lowestFCostNodeLocation.fCost)
                    lowestFCostNodeLocation = form1.nodeArea[pathNodeList[i].X, pathNodeList[i].Y];
            }

            return lowestFCostNodeLocation.location;
        }
    }
}
