using BusinessObject.Repository;
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
    public partial class frmLogin : Form
    {
        public IMemberRepository repository = new MemberRepository();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            var check = repository.checkLogin(email, password);
            if (check != null)
            {
                //if login with admin
                if (check.Email.Equals("admin@fstore.com"))
                {
                    frmMain main = new frmMain();
                    main.ShowDialog();
                    Hide();
                }
                //if login with user
                else
                {
                    frmUser mainUser = new frmUser(check);
                    mainUser.ShowDialog();
                    Hide();
                }
            }
            else
            {
                MessageBox.Show("ERORR");
            }
        }
    }
}
