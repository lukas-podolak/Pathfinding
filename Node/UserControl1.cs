using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Node
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();

            ChangeSizes(this.Width, this.Height);
        }

        private void UserControl1_SizeChanged(object sender, EventArgs e)
        {
            ChangeSizes(this.Width, this.Height);
        }

        private void ChangeSizes(int width, int height)
        {
            if (width >= 50 && height >= 50)
            {
                lblG.Visible = true;
                lblG.Dock = DockStyle.Top;
                lblG.Height = height / 4;
                lblG.Font = new Font("Century Gothic", height / 4 / 1.5f, FontStyle.Bold);

                lblH.Visible = true;
                lblH.Dock = DockStyle.Bottom;
                lblH.Height = height / 4;
                lblH.Font = new Font("Century Gothic", height / 4 / 1.5f, FontStyle.Bold);

                lblF.Visible = true;
                lblF.Dock = DockStyle.Fill;
                lblF.Font = new Font("Century Gothic", height / 2 / 1.5f, FontStyle.Bold);
            }
            else if (width < 50 && height < 50)
            {
                lblG.Visible = false;
                lblH.Visible = false;

                lblF.Visible = true;
                lblF.Dock = DockStyle.Fill;
                lblF.Font = new Font("Century Gothic", height / 1.5f, FontStyle.Bold);
            }
            else if (width <= 15 && height <= 15)
            {
                lblF.Visible = false;
            }
        }
    }
}
