using LMS.Controllers;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS.Views
{
    public partial class FRMDisplayLicenses : Form
    {
        LicenseController liceControl = new LicenseController();
        public FRMDisplayLicenses()
        {
            InitializeComponent();
        }

        private void FRMDisplayLicenses_Load(object sender, EventArgs e)
        {
            if(rbtnOwner.Checked)
            {
                grpAgent.Visible = false;
                grpOwner.Visible = true;
                grpLocation.Visible = false;
            }
            if (rbtnAgent.Checked)
            {
                grpAgent.Visible = true;
                grpOwner.Visible = false;
                grpLocation.Visible = false;
            }
            if (rbtnLocation.Checked)
            {
                grpAgent.Visible = false;
                grpOwner.Visible = false;
                grpLocation.Visible = true;
            }
        }

        private void rbtnOwner_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnOwner.Checked)
            {
                grpAgent.Visible = false;
                grpOwner.Visible = true;
                grpLocation.Visible = false;
            }
        }

        private void rbtnAgent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAgent.Checked)
            {
                grpAgent.Visible = true;
                grpOwner.Visible = false;
                grpLocation.Visible = false;
            }
        }

        private void rbtnLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnLocation.Checked)
            {
                grpAgent.Visible = false;
                grpOwner.Visible = false;
                grpLocation.Visible = true;
            }
        }

        private async void txtAgentNationalId_OnValueChanged(object sender, EventArgs e)
        {
            if(dgvDisplay.Rows.Count > 0)
                dgvDisplay.Refresh();
            //Search By Owner Data
            if (rbtnOwner.Checked)
            {
                if (txtOwnerName.Text != string.Empty && txtOwnerNationalId.Text != string.Empty)
                {
                    dgvDisplay.DataSource = await Task.Run(() => liceControl.SearchLicenseByOwnerNationalIdAndName(
                        txtOwnerNationalId.Text, txtOwnerName.Text));
                }
                else
                {
                    if (txtOwnerName.Text != string.Empty)
                    {
                        dgvDisplay.DataSource = await Task.Run(() => liceControl.SearchLicenseByOwnerName(txtOwnerName.Text));
                    }
                    if (txtOwnerNationalId.Text != string.Empty)
                    {
                        dgvDisplay.DataSource = await Task.Run(() => liceControl.SearchLicenseByOwnerNationalID(txtOwnerNationalId.Text));
                    }
                }
            }

            //Search By Agent Data
            if (rbtnAgent.Checked)
            {
                if (txtAgentName.Text != string.Empty && txtAgentNationalId.Text != string.Empty)
                {
                    dgvDisplay.DataSource = await Task.Run(() => liceControl.SearchLicenseByAgentNameAndNationalId(
                        txtAgentNationalId.Text, txtAgentName.Text));
                }
                else
                {
                    if (txtAgentName.Text != string.Empty)
                    {
                        dgvDisplay.DataSource = await Task.Run(() => liceControl.SearchLicenseByAgentName(txtAgentName.Text));
                    }
                    if (txtAgentNationalId.Text != string.Empty)
                    {
                        dgvDisplay.DataSource = await Task.Run(() => liceControl.SearchLicenseByAgentNationalID(txtAgentNationalId.Text));
                    }
                }
            }

            //Search By Location Data
            if (rbtnLocation.Checked)
            {
                if (txtLocation.Text != string.Empty && txtPlotNumber.Text != string.Empty)
                {
                    dgvDisplay.DataSource = await Task.Run(() => liceControl.SearchLicenseByLocationAndPlotNumber(txtLocation.Text, txtPlotNumber.Text));
                }
                else
                {
                    if (txtLocation.Text != string.Empty)
                    {
                        dgvDisplay.DataSource = await Task.Run(() => liceControl.SearchLicenseByLocation(txtLocation.Text));
                    }
                    if (txtPlotNumber.Text != string.Empty)
                    {
                        dgvDisplay.DataSource = await Task.Run(() => liceControl.SearchLicenseByPlotNumber(txtPlotNumber.Text));
                    }
                }
            }
            dgvDisplay.Columns["LicenseId"].Visible = false;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var result = await Task.Run(() => liceControl.SearchLicenseByOwnerNationalID(txtOwnerNationalId.Text));
            dgvDisplay.DataSource = result;
        }

        private void btndetails_Click(object sender, EventArgs e)
        {
            if (dgvDisplay.Rows.Count > 0)
            {
                string id = dgvDisplay.CurrentRow.Cells[0].Value.ToString();
                FRMMain frm = (FRMMain)Application.OpenForms["FRMMain"];
                frm.LoadForm(new FRMNewLicense(1, "Edit", Convert.ToInt32(id)));
            }
            else MessageBox.Show("اختر الرخصة المراد تعديلها");
        }

        private void btnFees_Click(object sender, EventArgs e)
        {
            if (dgvDisplay.Rows.Count > 0)
            {
                string id = dgvDisplay.CurrentRow.Cells[0].Value.ToString();
                FRMMain frm = (FRMMain)Application.OpenForms["FRMMain"];
                frm.LoadForm(new FRMFees(1, Convert.ToInt32(id)));
            }
            else MessageBox.Show("اختر الرخصة أولاً");
        }
    }
}
