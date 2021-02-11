using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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

        public void GenerateMaze(Point startPoint)
        {
            stonks.Push(form1.nodeArea[startPoint.X, startPoint.Y].location);
            form1.nodeArea[startPoint.X, startPoint.Y].generatorVisited = true;
            counter++;

            List<Point> neighboursLocation = new List<Point>();
            neighboursLocation = GetNeighbours(startPoint);
            
            if (neighboursLocation.Count > 0)
            {
                Random random = new Random();
                int rand = random.Next(0, neighboursLocation.Count);
                Point nextHop = neighboursLocation[rand];
                Console.WriteLine(neighboursLocation.Count + " - " + rand + " - " + nextHop);

                if (nextHop.X > startPoint.X)
                {
                    form1.nodeArea[(nextHop.X - 1), startPoint.Y].generatorVisited = true;
                    counter++;
                }
                if (nextHop.X < startPoint.X)
                {
                    form1.nodeArea[(nextHop.X + 1), startPoint.Y].generatorVisited = true;
                    counter++;
                }
                if (nextHop.Y > startPoint.Y)
                {
                    form1.nodeArea[startPoint.X, (nextHop.Y - 1)].generatorVisited = true;
                    counter++;
                }
                if (nextHop.Y < startPoint.Y)
                {
                    form1.nodeArea[startPoint.X, (nextHop.Y + 1)].generatorVisited = true;
                    counter++;
                }

                GenerateMaze(nextHop);
            }
            else
            {
                Point next = stonks.Pop();
            
                if (counter >= (Math.Pow(form1.areaSize, 2)))
                {
                    ColorIt();
                }
                else
                {
                    GenerateMaze(next);
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
