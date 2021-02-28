using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

                    return CalcularePath(form1.nodeArea[currentNodeLocation.X, currentNodeLocation.Y]);
                }

                // Revrite Lists
                openList.Remove(currentNodeLocation);
                closedList.Add(currentNodeLocation);

                form1.nodeArea[currentNodeLocation.X, currentNodeLocation.Y].tag = 'C';
                if (showAnim)
                {
                    form1.nodeInArea[currentNodeLocation.X, currentNodeLocation.Y].BackColor = Color.Red;
                }

                foreach (Point neighbourNode in GetNeighbourList(form1.nodeArea[currentNodeLocation.X, currentNodeLocation.Y], form1.chbAllowDiagonal.Checked))
                {
                    if (form1.nodeArea[neighbourNode.X, neighbourNode.Y].tag == 'B')
                        continue;

                    if (form1.nodeArea[neighbourNode.X, neighbourNode.Y].tag == 'C')
                        continue;

                    int tentativeGCost = form1.nodeArea[currentNodeLocation.X, currentNodeLocation.Y].gCost + CalculateDistanceCost(currentNodeLocation, neighbourNode);
                    if (tentativeGCost <= form1.nodeArea[neighbourNode.X, neighbourNode.Y].gCost)
                    {
                        PathNode neighbourPathNode = new PathNode(neighbourNode);
                        //form1.nodeArea[neighbourNode.X, neighbourNode.Y].parentNodeLocation = currentNodeLocation;
                        //form1.nodeArea[neighbourNode.X, neighbourNode.Y].gCost = tentativeGCost;
                        //form1.nodeArea[neighbourNode.X, neighbourNode.Y].hCost = CalculateDistanceCost(neighbourNode, Points.endPoint);
                        //form1.nodeArea[neighbourNode.X, neighbourNode.Y].CalculateFCost();

                        neighbourPathNode.parentNodeLocation = currentNodeLocation;
                        neighbourPathNode.gCost = tentativeGCost;
                        neighbourPathNode.hCost = CalculateDistanceCost(neighbourNode, Points.endPoint);
                        neighbourPathNode.CalculateFCost();

                        if (!openList.Contains(neighbourNode))
                        {
                            openList.Add(neighbourNode);
                            form1.nodeArea[neighbourNode.X, neighbourNode.Y] = neighbourPathNode;
                            form1.nodeArea[neighbourNode.X, neighbourNode.Y].tag = 'O';

                            if (showAnim)
                            {
                                form1.nodeInArea[neighbourNode.X, neighbourNode.Y].BackColor = Color.Green;
                            }
                        }
                        else if (neighbourPathNode.fCost <= form1.nodeArea[neighbourNode.X, neighbourNode.Y].fCost)
                        {
                            form1.nodeArea[neighbourNode.X, neighbourNode.Y] = neighbourPathNode;
                            form1.nodeArea[neighbourNode.X, neighbourNode.Y].tag = 'O';

                            if (showAnim)
                            {
                                form1.nodeInArea[neighbourNode.X, neighbourNode.Y].BackColor = Color.Green;
                            }
                        }
                    }
                }

                if (showAnim)
                    Thread.Sleep(5);
            }
            form1.stopwatch.Stop();
            form1.timer.Stop();

            if (!form1.lblRunTime.InvokeRequired)
            {
                form1.lblRunTime.Text = form1.stopwatch.Elapsed.ToString();
                form1.btnStart.Enabled = true;
            }
            else
                form1.lblRunTime.Invoke((MethodInvoker)delegate
                {
                    form1.lblRunTime.Text = form1.stopwatch.Elapsed.ToString();
                    form1.btnStart.Enabled = true;
                });
            MessageBox.Show("No possible path found.", "Pathfinding - A*", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }

        private List<Point> CalcularePath(PathNode finalNode)
        {
            List<Point> path = new List<Point>() { finalNode.location };
            PathNode currentNode = finalNode;
            int length = 1;

            while (!currentNode.parentNodeLocation.IsEmpty)
            {
                form1.nodeInArea[currentNode.location.X, currentNode.location.Y].BackColor = Color.Magenta;
                path.Add(currentNode.parentNodeLocation);
                currentNode = form1.nodeArea[currentNode.parentNodeLocation.X,currentNode.parentNodeLocation.Y];
                length++;
            }

            form1.nodeInArea[currentNode.location.X, currentNode.location.Y].BackColor = Color.Magenta;
            path.Reverse();

            if (!form1.lblTheLength.InvokeRequired)
                form1.lblTheLength.Text = length.ToString();
            else
                form1.lblTheLength.Invoke((MethodInvoker)delegate
                {
                    form1.lblTheLength.Text = length.ToString();
                });

            return path;
        }

        private List<Point> GetNeighbourList(PathNode currentNode, bool diagonalMove)
        {
            List<Point> neighbourList = new List<Point>();

            int currentGCost = form1.nodeArea[currentNode.location.X, currentNode.location.Y].gCost;

            if (currentNode.location.X - 1 >= 0)
            {
                // LEFT
                neighbourList.Add(new Point(currentNode.location.X - 1, currentNode.location.Y));
                form1.nodeArea[currentNode.location.X - 1, currentNode.location.Y].gCost = MOVE_STRAIGHT_COST + currentGCost;
                // LEFT DOWN
                if (currentNode.location.Y - 1 >= 0 && diagonalMove)
                {
                    neighbourList.Add(new Point(currentNode.location.X - 1, currentNode.location.Y - 1));
                    form1.nodeArea[currentNode.location.X - 1, currentNode.location.Y - 1].gCost = MOVE_DIAGONAL_COST + currentGCost;
                }
                // LEFT UP
                if (currentNode.location.Y + 1 < form1.areaSize && diagonalMove)
                {
                    neighbourList.Add(new Point(currentNode.location.X - 1, currentNode.location.Y + 1));
                    form1.nodeArea[currentNode.location.X - 1, currentNode.location.Y + 1].gCost = MOVE_DIAGONAL_COST + currentGCost;
                }
            }
            if (currentNode.location.X + 1 < form1.areaSize)
            {
                // RIGHT
                neighbourList.Add(new Point(currentNode.location.X + 1, currentNode.location.Y));
                form1.nodeArea[currentNode.location.X + 1, currentNode.location.Y].gCost = MOVE_STRAIGHT_COST + currentGCost;
                // RIGHT DOWN
                if (currentNode.location.Y - 1 >= 0 && diagonalMove)
                {
                    neighbourList.Add(new Point(currentNode.location.X + 1, currentNode.location.Y - 1));
                    form1.nodeArea[currentNode.location.X + 1, currentNode.location.Y - 1].gCost = MOVE_DIAGONAL_COST + currentGCost;
                }
                // RIGHT UP
                if (currentNode.location.Y + 1 < form1.areaSize && diagonalMove)
                {
                    neighbourList.Add(new Point(currentNode.location.X + 1, currentNode.location.Y + 1));
                    form1.nodeArea[currentNode.location.X + 1, currentNode.location.Y + 1].gCost = MOVE_DIAGONAL_COST + currentGCost;
                }
            }
            // DOWN
            if (currentNode.location.Y - 1 >= 0)
            {
                neighbourList.Add(new Point(currentNode.location.X, currentNode.location.Y - 1));
                form1.nodeArea[currentNode.location.X, currentNode.location.Y - 1].gCost = MOVE_STRAIGHT_COST + currentGCost;
            }
            // UP
            if (currentNode.location.Y + 1 < form1.areaSize)
            {
                neighbourList.Add(new Point(currentNode.location.X, currentNode.location.Y + 1));
                form1.nodeArea[currentNode.location.X, currentNode.location.Y + 1].gCost = MOVE_STRAIGHT_COST + currentGCost;
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
