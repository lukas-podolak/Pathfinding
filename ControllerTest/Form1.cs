using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControllerTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            userControl11.BackColor = Color.Blue;
            userControl11.lblG.Text = "10";
            userControl11.lblH.Text = "34";
            userControl11.lblG.Text = "44";
        }
    }
}
