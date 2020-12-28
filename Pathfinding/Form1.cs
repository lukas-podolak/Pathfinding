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
        //public Node.NodeControl[,] nodeInArea;
        public Label[,] nodeInArea;

        private int areaSize = 20;
        private int width = 0;
        private int height = 0;

        public Form1()
        {
            InitializeComponent();

            width = this.ClientSize.Width - areaSize;
            height = this.ClientSize.Height - areaSize;

            GenerateArea(areaSize);
        }

        // Vygeneruje pole
        public void GenerateArea(int size)
        {
            //nodeInArea = new Node.NodeControl[size, size];
            nodeInArea = new Label[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    //nodeInArea[x, y] = new Node.NodeControl();
                    nodeInArea[x, y] = new Label();
                    nodeInArea[x, y].Width = width / size;
                    nodeInArea[x, y].Height = height / size;
                    nodeInArea[x, y].Top = (y * (height / size + 1)) + 1;
                    nodeInArea[x, y].Left = (x * (width / size + 1)) + 1;
                    nodeInArea[x, y].BackColor = Color.White;
                    /*nodeInArea[x, y].lblF.Text = "";
                    nodeInArea[x, y].lblG.Text = "";
                    nodeInArea[x, y].lblH.Text = "";
                    nodeInArea[x, y].lblF.MouseDown += Form1_MouseDown;
                    nodeInArea[x, y].lblF.MouseMove += Form1_MouseMove;
                    nodeInArea[x, y].lblF.MouseUp += Form1_MouseUp;
                    nodeInArea[x, y].lblH.MouseDown += Form1_MouseDown;
                    nodeInArea[x, y].lblH.MouseMove += Form1_MouseMove;
                    nodeInArea[x, y].lblH.MouseUp += Form1_MouseUp;
                    nodeInArea[x, y].lblG.MouseDown += Form1_MouseDown;
                    nodeInArea[x, y].lblG.MouseMove += Form1_MouseMove;
                    nodeInArea[x, y].lblG.MouseUp += Form1_MouseUp;*/
                    nodeInArea[x, y].MouseDown += Form1_MouseDown;
                    nodeInArea[x, y].MouseMove += Form1_MouseMove;
                    nodeInArea[x, y].MouseUp += Form1_MouseUp;
                    nodeInArea[x, y].Parent = this;
                }
            }
        }

        bool mouseIsDown = false;
        float koeficient = 0.6f;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseIsDown = true;

            int x = (e.X - 1 + (sender as Label).Left) / (width / areaSize + 1);
            int y = (e.Y - 1 + (sender as Label).Top) / (height / areaSize + 1);

            Console.WriteLine("X=" + x + " Y=" + y);

            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (!Points.startPointExist)
                    {
                        nodeInArea[x, y].BackColor = Color.LightBlue;
                        nodeInArea[x, y].Text = "S";
                        Points.startPointExist = true;
                        Points.startPoint = new Point(x, y);
                        mouseIsDown = false;
                        Console.WriteLine("X=" + x + " Y=" + y + " is start.");
                    }
                    else if (!Points.endPointExist)
                    {
                        nodeInArea[x, y].BackColor = Color.LightBlue;
                        nodeInArea[x, y].Text = "E";
                        Points.endPointExist = true;
                        Points.endPoint = new Point(x, y);
                        mouseIsDown = false;
                        Console.WriteLine("X=" + x + " Y=" + y + " is end.");
                    }
                    else if (nodeInArea[x, y].BackColor == Color.White)
                    {
                        nodeInArea[x, y].BackColor = Color.Black;
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (nodeInArea[x, y].BackColor == Color.LightBlue && nodeInArea[x, y].Text == "S")
                    {
                        nodeInArea[x, y].BackColor = Color.White;
                        nodeInArea[x, y].Text = "";
                        Points.startPointExist = false;
                        Points.startPoint = Point.Empty;
                        Console.WriteLine("X=" + x + " Y=" + y + " is not start.");
                    }
                    else if (nodeInArea[x, y].BackColor == Color.LightBlue && nodeInArea[x, y].Text == "E")
                    {
                        nodeInArea[x, y].BackColor = Color.White;
                        nodeInArea[x, y].Text = "";
                        Points.endPointExist = false;
                        Points.endPoint = Point.Empty;
                        Console.WriteLine("X=" + x + " Y=" + y + " is not end.");
                    }
                    else if (nodeInArea[x, y].BackColor != Color.White)
                    {
                        nodeInArea[x, y].BackColor = Color.White;
                    }
                }
            }
            catch
            {
                Console.WriteLine("The index is out of the field. X=" + x + " Y=" + y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown == true)
            {
                //int y = (int)(e.Y / (areaSize * koeficient));
                //int x = (int)(e.X / (areaSize * koeficient));

                int x = (e.X - 1 + (sender as Label).Left) / (width / areaSize + 1);
                int y = (e.Y - 1 + (sender as Label).Top) / (height / areaSize + 1);

                Console.WriteLine("X=" + x + " Y=" + y);

                try
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (nodeInArea[x, y].BackColor == Color.White)
                        {
                            nodeInArea[x, y].BackColor = Color.Black;
                        }
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        if (nodeInArea[x, y].BackColor == Color.LightBlue && nodeInArea[x, y].Text == "S")
                        {
                            nodeInArea[x, y].BackColor = Color.White;
                            nodeInArea[x, y].Text = "";
                            Points.startPointExist = false;
                            Points.startPoint = Point.Empty;
                            Console.WriteLine("X=" + x + " Y=" + y + " is not start.");
                        }
                        else if (nodeInArea[x, y].BackColor == Color.LightBlue && nodeInArea[x, y].Text == "E")
                        {
                            nodeInArea[x, y].BackColor = Color.White;
                            nodeInArea[x, y].Text = "";
                            Points.endPointExist = false;
                            Points.endPoint = Point.Empty;
                            Console.WriteLine("X=" + x + " Y=" + y + " is not end.");
                        }
                        else if (nodeInArea[x, y].BackColor != Color.White)
                        {
                            nodeInArea[x, y].BackColor = Color.White;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("The index is out of the field. X=" + x + " Y=" + y);
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }
    }
}
