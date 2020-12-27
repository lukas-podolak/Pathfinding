using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pathfinding
{
    public partial class Form1 : Form
    {
        public UserControl[,] nodeInArea;

        public Form1()
        {
            InitializeComponent();

            GenerateArea(5);
        }

        public void GenerateArea(int size)
        {
            nodeInArea = new UserControl[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    nodeInArea[x, y] = new UserControl();
                    nodeInArea[x, y].Width = 800 / size;
                    nodeInArea[x, y].Height = 800 / size;
                    nodeInArea[x, y].Top = (y * (800 / size + 1)) + 1;
                    nodeInArea[x, y].Left = (x * (800 / size + 1)) + 1;
                    nodeInArea[x, y].BackColor = Color.White;
                    nodeInArea[x, y].Parent = this;
                }
            }
        }
    }
}
