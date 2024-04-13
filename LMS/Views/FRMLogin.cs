using LMS.Models;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Windows.Forms;

namespace LMS.Views
{
    public partial class FRMLogin : Form
    {
        LMSContext context = new LMSContext();
        public FRMLogin()
        {
            InitializeComponent();
            txtUserName.Text = "User1";
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
            if (txtPassword.Text != string.Empty && txtUserName.Text != string.Empty)
            {
                //var admin = await context.Admins.FirstOrDefaultAsync();

                if (txtPassword.Text == "123456" && txtUserName.Text == "User1")
                {
                    this.Hide();
                    var frm = new FRMMain(1);
                    frm.Closed += (s, args) => this.Close();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Error");
                }

            }
        }

        private void lblExit_MouseEnter(object sender, EventArgs e)
        {
            lblExit.BackColor = Color.Red;
            lblExit.ForeColor = Color.Black;
        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.BackColor = SystemColors.Control;
            lblExit.ForeColor = Color.FromArgb(238, 26, 74);
        }
    }
}
