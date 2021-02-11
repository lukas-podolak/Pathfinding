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

        public MazeGenerator(Form1 form)
        {
            form1 = form;
        }

        public void GenerateMaze(Point startPoint)
        {
            stonks = new Stack<Point>();

            stonks.Push(form1.nodeArea[startPoint.X, startPoint.Y].location);
            form1.nodeArea[startPoint.X, startPoint.Y].generatorVisited = true;

            List<Point> neighboursLocation = new List<Point>();
            neighboursLocation = GetNeighbours(startPoint);
            
            if (neighboursLocation.Count > 0)
            {
                Random random = new Random();
                GenerateMaze(neighboursLocation[random.Next(0, neighboursLocation.Count)]);
            }
            else
            {
                Point next = stonks.Pop();
            
                if (next != startPoint)
                {
                    GenerateMaze(next);
                }
                else
                {
                    ColorIt();
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
            List<Point> lis = new List<Point>();

            if (currentLocation.X - 3 >= 0)
            {
                if (!form1.nodeArea[currentLocation.X - 3, currentLocation.Y].generatorVisited)
                {
                    lis.Add(new Point(currentLocation.X - 3, currentLocation.Y));
                }
            }
            if (currentLocation.X + 3 < form1.areaSize)
            {
                if (!form1.nodeArea[currentLocation.X + 3, currentLocation.Y].generatorVisited)
                {
                    lis.Add(new Point(currentLocation.X + 3, currentLocation.Y));
                }
            }
            if (currentLocation.Y-3 >= 0)
            {
                if (!form1.nodeArea[currentLocation.X, currentLocation.Y - 3].generatorVisited)
                {
                    lis.Add(new Point(currentLocation.X, currentLocation.Y - 3));
                }
            }
            if (currentLocation.Y + 3 < form1.areaSize)
            {
                if (!form1.nodeArea[currentLocation.X, currentLocation.Y + 3].generatorVisited)
                {
                    lis.Add(new Point(currentLocation.X, currentLocation.Y + 3));
                }
            }

            return lis;
        }
    }
}
