using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS.Views
{
    public partial class FRMMain : Form
    {
        public int AdminId;
        public FRMMain(int adminId)
        {
            InitializeComponent();
            AdminId = adminId;
        }

        #region Form Loader Controller

        private Form activeForm = null;
        public void LoadForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(childForm);
            pnlContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        #endregion

        #region Make The Form Movable Events
        bool drag = false;
        Point StartPoint = new Point(0,0);
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            StartPoint = new Point(e.X, e.Y);
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag)
            {
                Point Current =  PointToScreen(e.Location);
                this.Location = new Point(Current.X-StartPoint.X,Current.Y-StartPoint.Y);
            }
        }

        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        #endregion

        #region Exit Label Events

        private void lblExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("هل تريد الخروج","تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void lblExit_MouseEnter(object sender, EventArgs e)
        {
            lblExit.BackColor = Color.Red;
        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.BackColor = Color.FromArgb(100, 149, 237);
        }


        #endregion

        #region Minimize Label Events

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblMinimize_MouseEnter(object sender, EventArgs e)
        {
            lblMinimize.BackColor = Color.FromArgb(200, 200, 200);
        }

        private void lblMinimize_MouseLeave(object sender, EventArgs e)
        {
            lblMinimize.BackColor = Color.FromArgb(100, 149, 237);
        }


        #endregion

        private void btnNewLicense_Click(object sender, EventArgs e)
        {
            LoadForm(new FRMNewLicense(AdminId));
        }

        private void pctDashboard_Click(object sender, EventArgs e)
        {
            LoadForm(new FRMDashboard());
        }

        private void btnLicenseSearch_Click(object sender, EventArgs e)
        {
            LoadForm(new FRMDisplayLicenses());
        }
    }
}
