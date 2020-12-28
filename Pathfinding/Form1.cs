using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

            GenerateArea(50);

            lblSize.Text = this.ClientSize.Width + "px W and " + this.ClientSize.Height + " px H";
        }

        public void GenerateArea(int size)
        {
            nodeInArea = new UserControl[size, size];

            int width = this.ClientSize.Width - size;
            int height = this.ClientSize.Height - 2 * size;

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    nodeInArea[x, y] = new UserControl();
                    nodeInArea[x, y].Width = width / size;
                    nodeInArea[x, y].Height = height / size;
                    nodeInArea[x, y].Top = (y * (height / size + 1)) + 1;
                    nodeInArea[x, y].Left = (x * (width / size + 1)) + 1;
                    nodeInArea[x, y].BackColor = Color.White;
                    nodeInArea[x, y].Parent = this;
                }
            }
        }

        private void lblSize_SizeChanged(object sender, EventArgs e)
        {
            lblSize.Text = this.ClientSize.Width + "px W and " + this.ClientSize.Height + " px H";
        }
    }
}
