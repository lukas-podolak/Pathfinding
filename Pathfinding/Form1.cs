using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public PathNode[,] nodeArea;

        public Stopwatch stopwatch = new Stopwatch();

        public int areaSize = 15;

        private int width = 800;
        private int height = 800;

        public Form1()
        {
            InitializeComponent();

            //width = this.ClientSize.Width - areaSize;
            //height = this.ClientSize.Height - areaSize;

            chbShowAnimation.Checked = true;
            //chbShowAnimation.Enabled = false;

            btnGenerateMaze.Enabled = false;

            nudSize.Value = areaSize;

            GenerateArea(areaSize);
        }

        // Vygeneruje pole
        public void GenerateArea(int size)
        {
            //nodeInArea = new Node.NodeControl[size, size];
            nodeInArea = new Label[size, size];
            nodeArea = new PathNode[size, size];

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
                    nodeInArea[x, y].Font = new Font(this.Font.FontFamily, (float)((height / size) / 2), FontStyle.Bold);
                    nodeInArea[x, y].TextAlign = ContentAlignment.MiddleCenter;
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

                    nodeArea[x, y] = new PathNode(new Point(x, y));
                }
            }
        }

        bool mouseIsDown = false;

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
                    if (Points.startPointExist == false)
                    {
                        nodeInArea[x, y].BackColor = Color.LightBlue;
                        nodeInArea[x, y].Text = "S";
                        nodeArea[x, y].tag = 'S';
                        Points.startPointExist = true;
                        Points.startPoint = new Point(x, y);
                        mouseIsDown = false;
                        Console.WriteLine("X=" + x + " Y=" + y + " is start.");
                    }
                    else if (Points.endPointExist == false && (Points.startPoint != new Point(x, y)))
                    {
                        nodeInArea[x, y].BackColor = Color.LightBlue;
                        nodeInArea[x, y].Text = "E";
                        nodeArea[x, y].tag = 'E';
                        Points.endPointExist = true;
                        Points.endPoint = new Point(x, y);
                        mouseIsDown = false;
                        Console.WriteLine("X=" + x + " Y=" + y + " is end.");
                    }
                    else if (nodeInArea[x, y].BackColor == Color.White)
                    {
                        nodeInArea[x, y].BackColor = Color.Black;
                        nodeArea[x, y].tag = 'B';
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (nodeInArea[x, y].BackColor == Color.LightBlue && nodeInArea[x, y].Text == "S")
                    {
                        nodeInArea[x, y].BackColor = Color.White;
                        nodeInArea[x, y].Text = "";
                        nodeArea[x, y].tag = 'N';
                        Points.startPointExist = false;
                        Points.startPoint = Point.Empty;
                        Console.WriteLine("X=" + x + " Y=" + y + " is not start.");
                    }
                    else if (nodeInArea[x, y].BackColor == Color.LightBlue && nodeInArea[x, y].Text == "E")
                    {
                        nodeInArea[x, y].BackColor = Color.White;
                        nodeInArea[x, y].Text = "";
                        nodeArea[x, y].tag = 'N';
                        Points.endPointExist = false;
                        Points.endPoint = Point.Empty;
                        Console.WriteLine("X=" + x + " Y=" + y + " is not end.");
                    }
                    else if (nodeInArea[x, y].BackColor != Color.White)
                    {
                        nodeInArea[x, y].BackColor = Color.White;
                        nodeArea[x, y].tag = 'N';
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
                            nodeArea[x, y].tag = 'B';
                        }
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        if (nodeInArea[x, y].BackColor == Color.LightBlue && nodeInArea[x, y].Text == "S")
                        {
                            nodeInArea[x, y].BackColor = Color.White;
                            nodeInArea[x, y].Text = "";
                            nodeArea[x, y].tag = 'N';
                            Points.startPointExist = false;
                            Points.startPoint = Point.Empty;
                            Console.WriteLine("X=" + x + " Y=" + y + " is not start.");
                        }
                        else if (nodeInArea[x, y].BackColor == Color.LightBlue && nodeInArea[x, y].Text == "E")
                        {
                            nodeInArea[x, y].BackColor = Color.White;
                            nodeInArea[x, y].Text = "";
                            nodeArea[x, y].tag = 'N';
                            Points.endPointExist = false;
                            Points.endPoint = Point.Empty;
                            Console.WriteLine("X=" + x + " Y=" + y + " is not end.");
                        }
                        else if (nodeInArea[x, y].BackColor != Color.White)
                        {
                            nodeInArea[x, y].BackColor = Color.White;
                            nodeArea[x, y].tag = 'N';
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;

            AStarV2 aStar = new AStarV2(this);
            List<Point> pathNodes = new List<Point>();

            if (Points.startPointExist && Points.endPointExist)
            {
                Thread pathFinding;
                if (chbShowAnimation.Checked)
                    pathFinding = new Thread(() => pathNodes = aStar.FindPath(true));
                else
                    pathFinding = new Thread(() => pathNodes = aStar.FindPath(false));
                pathFinding.Start();
                stopwatch.Start();
                timer.Start();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Points.Clear();
            nodeArea = new PathNode[areaSize, areaSize];

            for (int x = 0; x < areaSize; x++)
            {
                for (int y = 0; y < areaSize; y++)
                {
                    nodeInArea[x, y].BackColor = Color.White;
                    nodeInArea[x, y].Text = "";

                    nodeArea[x, y] = new PathNode(new Point(x, y));
                }
            }

            btnStart.Enabled = true;
        }

        private void btnRebuild_Click(object sender, EventArgs e)
        {
            Thread treadRebuild = new Thread(() => {
                BeginInvoke(new Action(() =>
                {
                    for (int ix = this.Controls.Count - 1; ix >= 0; ix--)
                    {
                        if (this.Controls[ix] is Label) this.Controls[ix].Dispose();
                    }
                }));

                Points.Clear();
                areaSize = (int)nudSize.Value;
                BeginInvoke(new Action(() => GenerateArea(areaSize)));
            });
            treadRebuild.Start();
            btnStart.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Points.Clear();
            nodeArea = new PathNode[areaSize, areaSize];

            for (int x = 0; x < areaSize; x++)
            {
                for (int y = 0; y < areaSize; y++)
                {
                    if (nodeInArea[x, y].BackColor != Color.Black)
                    {
                        nodeInArea[x, y].BackColor = Color.White;
                        nodeInArea[x, y].Text = "";

                        nodeArea[x, y] = new PathNode(new Point(x, y));
                    }
                }
            }

            btnStart.Enabled = true;
        }

        private void btnGenerateMaze_Click(object sender, EventArgs e)
        {
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //TimeSpan timeSpan = TimeSpan.FromSeconds(Convert.ToInt32(stopwatch.Elapsed));
            lblRunTime.Text = stopwatch.Elapsed.ToString();
        }
    }
}
