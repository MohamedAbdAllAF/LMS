using LMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS.Views
{
    public partial class FRMLogin : Form
    {
        LMSContext context = new LMSContext();
        public FRMLogin()
        {
            InitializeComponent();
            txtPassword.Text = "Password";
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Handling Password textBox Visibility
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.isPassword = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.isPassword = false;
            }
        }

        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text != string.Empty && txtUserName.Text != string.Empty)
            {
                var admin = context.Admins.FirstOrDefault();

                if(admin != null)
                {
                    this.Hide();
                    var frm = new FRMMain(admin.Id);
                    frm.Closed += (s, args) => this.Close();
                    frm.Show();
                }

            }
        }
    }
}
