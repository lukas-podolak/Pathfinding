using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pathfinding
{
    public class MazeGenerator
    {
        private Stack<Point> stonks;
        private Form1 form1;
        private int counter = 0;

        public MazeGenerator(Form1 form)
        {
            form1 = form;
            stonks = new Stack<Point>();
        }

        public void GenerateMaze(Point startPoint, bool anim)
        {
            List<Point> neighboursLocation = new List<Point>();
            neighboursLocation = GetNeighbours(startPoint);

            if (neighboursLocation.Count > 0)
            {
                if (anim)
                    Thread.Sleep(5);

                Random random;
                try
                {
                    random = new Random(Guid.NewGuid().GetHashCode());
                }
                catch (Exception ex)
                {
                    random = new Random((int)DateTime.Now.Ticks);
                }

                int rand = random.Next(0, neighboursLocation.Count);
                Point nextHop = neighboursLocation[rand];

                if (nextHop.X > startPoint.X)
                {
                    form1.nodeArea[(nextHop.X - 1), nextHop.Y].generatorVisited = true;
                    if (anim)
                        form1.nodeInArea[(nextHop.X - 1), nextHop.Y].BackColor = Color.Orange;
                    counter++;
                }
                if (nextHop.X < startPoint.X)
                {
                    form1.nodeArea[(nextHop.X + 1), nextHop.Y].generatorVisited = true;
                    if (anim)
                        form1.nodeInArea[(nextHop.X + 1), nextHop.Y].BackColor = Color.Orange;
                    counter++;
                }
                if (nextHop.Y > startPoint.Y)
                {
                    form1.nodeArea[nextHop.X, (nextHop.Y - 1)].generatorVisited = true;
                    if (anim)
                        form1.nodeInArea[nextHop.X, (nextHop.Y - 1)].BackColor = Color.Orange;
                    counter++;
                }
                if (nextHop.Y < startPoint.Y)
                {
                    form1.nodeArea[nextHop.X, (nextHop.Y + 1)].generatorVisited = true;
                    if (anim)
                        form1.nodeInArea[nextHop.X, (nextHop.Y + 1)].BackColor = Color.Orange;
                    counter++;
                }

                stonks.Push(form1.nodeArea[nextHop.X, nextHop.Y].location);

                form1.nodeArea[nextHop.X, nextHop.Y].generatorVisited = true;
                if (anim)
                    form1.nodeInArea[nextHop.X, nextHop.Y].BackColor = Color.Orange;
                counter++;

                Console.WriteLine(neighboursLocation.Count + " - " + rand + " - " + nextHop + " - " + counter);
                GenerateMaze(nextHop, anim);
            }
            else
            {
                stonks.Pop();
            
                try
                {
                    GenerateMaze(stonks.Peek(), anim);
                }
                catch
                {
                    Console.WriteLine("Maze generated.");
                    ColorIt();
                    form1.stopwatch1.Stop();
                    form1.timer.Stop();
                }
            }
        }

        private void ColorIt()
        {
            for (int x = 0; x < form1.areaSize; x++)
            {
                for (int y = 0; y < form1.areaSize; y++)
                {
                    if (!form1.nodeArea[x, y].generatorVisited)
                    {
                        form1.nodeInArea[x, y].BackColor = Color.Black;
                        form1.nodeArea[x, y].tag = 'B';
                    }
                    else
                    {
                        form1.nodeInArea[x, y].BackColor = Color.White;
                        form1.nodeArea[x, y].tag = 'N';
                    }
                }
            }
        }

        private List<Point> GetNeighbours(Point currentLocation)
        {
            const short JUMP = 2;
            List<Point> lis = new List<Point>();

            if (currentLocation.X - JUMP >= 0)
            {
                if (!form1.nodeArea[currentLocation.X - JUMP, currentLocation.Y].generatorVisited)
                {
                    lis.Add(new Point(currentLocation.X - JUMP, currentLocation.Y));
                }
            }
            if (currentLocation.X + JUMP < form1.areaSize)
            {
                if (!form1.nodeArea[currentLocation.X + JUMP, currentLocation.Y].generatorVisited)
                {
                    lis.Add(new Point(currentLocation.X + JUMP, currentLocation.Y));
                }
            }
            if (currentLocation.Y - JUMP >= 0)
            {
                if (!form1.nodeArea[currentLocation.X, currentLocation.Y - JUMP].generatorVisited)
                {
                    lis.Add(new Point(currentLocation.X, currentLocation.Y - JUMP));
                }
            }
            if (currentLocation.Y + JUMP < form1.areaSize)
            {
                if (!form1.nodeArea[currentLocation.X, currentLocation.Y + JUMP].generatorVisited)
                {
                    lis.Add(new Point(currentLocation.X, currentLocation.Y + JUMP));
                }
            }

            return lis;
        }
    }
}
