using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public static class Points
    {
        public static bool startPointExist = false;
        public static Point startPoint;

        public static bool endPointExist = false;
        public static Point endPoint;

        public static void Clear()
        {
            startPointExist = false;
            endPointExist = false;
        }
    }
}
