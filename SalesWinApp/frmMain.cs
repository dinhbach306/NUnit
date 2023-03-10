using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void btnMember_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            frmMembers members = new frmMembers(main);
            members.ShowDialog();
            Hide();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            frmOders oders = new frmOders(main);
            oders.ShowDialog();
            Hide();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            frmProducts products = new frmProducts(main);
            products.ShowDialog();
            Hide();
        }
    }
}
