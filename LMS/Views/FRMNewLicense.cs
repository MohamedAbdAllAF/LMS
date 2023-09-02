using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMS.Controllers;
using LMS.Models;

namespace LMS.Views
{
    public partial class FRMNewLicense : Form
    {
        public int AdminId;
        LocationController locatcont = new LocationController();
        LicenseController licensecont = new LicenseController();
        public FRMNewLicense(int adminId)
        {
            InitializeComponent();
            AdminId = adminId;
        }

        private void FRMNewLicense_Load(object sender, EventArgs e)
        {
            #region txtLocation AutoComplete
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            foreach (var location in locatcont.GetAllLocations())
            {
                ac.Add(location.Name.ToString());
            }
            txtLocation.AutoCompleteCustomSource = ac;
            #endregion
        }

        private void btnSvae_Click(object sender, EventArgs e)
        {
            List<string> errorMessages = new List<string>();
            User Owner=null,Agent=null;
            ValidityStatment validityStat;
            license license;

            string location = txtLocation.Text;

            if(txtOwnerName.Text != string.Empty && txtOwnerNationalId.Text != string.Empty)
            {
                if(txtOwnerNationalId.Text.Length == 14)
                {
                    Owner = new User { NationalId = txtOwnerNationalId.Text,Name =txtOwnerName.Text };
                }
                else
                {
                    errorMessages.Add("الرقم القومي للمالك غير صحيح");
                }
            }else
            {
                errorMessages.Add("أكمل بيانات المالك");
            }

            if (txtAgentName.Text != string.Empty && txtAgentNationalId.Text != string.Empty)
            {
                if (txtAgentNationalId.Text.Length == 14)
                {
                    Agent = new User { NationalId = txtAgentNationalId.Text, Name = txtAgentName.Text };
                }
                else
                {
                    errorMessages.Add("الرقم القومي للوكيل غير صحيح");
                }
            }else
            {
                errorMessages.Add("أكمل بيانات الوكيل");
            }

            validityStat = new ValidityStatment {
                EntryDate = txtVEntryDate.Text != string.Empty ? picVEntryDate.Value :(DateTime?)null,
                InitialSupplyDate = txtVInitialSupplyDate.Text != string.Empty ? picVInitialSupplyDate.Value : (DateTime?)null,
                ReceiveDate =txtVReceiveDate.Text != string.Empty ? picVReceiveDate.Value : (DateTime?)null,
                ValidatySupplyDate = txtVValidatySupplyDate.Text != string.Empty ? picVValidatySupplyDate.Value : (DateTime?)null
            };

            license = new license
            {
                PlotNumber = txtPlotNumber.Text != string.Empty ? txtPlotNumber.Text : null,
                Work = txtWork.Text != string.Empty ? txtWork.Text : null,
                Fees = txtFees.Text != string.Empty ? Convert.ToDecimal(txtFees.Text) : (decimal?)null,
                LicenseNumber = txtLicenseNumber.Text != string.Empty ? txtLicenseNumber.Text : null,
                EntryDate = txtLEntryDate.Text != string.Empty ? picLEntryDate.Value : (DateTime?)null,
                ExaminationFeeDate = txtLExaminationFeeDate.Text != string.Empty ? picLExaminationFeeDate.Value : (DateTime?)null,
                FeesPaymentDate = txtLFeesPaymentDate.Text != string.Empty ? picLFeesPaymentDate.Value : (DateTime?)null,
                SignatureDate = txtLSignatureDate.Text != string.Empty ? picLSignatureDate.Value : (DateTime?)null,
                ReceiveDate = txtLReceiveDate.Text != string.Empty ? picLReceiveDate.Value : (DateTime?)null,
                Notes = txtNotes.Text != string.Empty ? txtNotes.Text : null,
            };
            if (licensecont.AddLicense(AdminId, Owner, Agent, validityStat, location, license))
                MessageBox.Show("تم الإضافة بنجاح");
        }
        #region Date picker Buttons Events
        private void btnVEntryDate_Click(object sender, EventArgs e)
        {
            txtVEntryDate.Text = picVEntryDate.Value.ToString();
        }

        private void btnVInitialSupplyDate_Click(object sender, EventArgs e)
        {
            txtVInitialSupplyDate.Text = picVInitialSupplyDate.Value.ToString();
        }

        private void btnVValidatySupplyDate_Click(object sender, EventArgs e)
        {
            txtVValidatySupplyDate.Text = picVValidatySupplyDate.Value.ToString();
        }

        private void btnVReceiveDate_Click(object sender, EventArgs e)
        {
            txtVReceiveDate.Text = picVReceiveDate.Value.ToString();
        }

        private void btnLEntryDate_Click(object sender, EventArgs e)
        {
            txtLEntryDate.Text = picLEntryDate.Value.ToString();
        }

        private void btnLExaminationFeeDate_Click(object sender, EventArgs e)
        {
            txtLExaminationFeeDate.Text = picLExaminationFeeDate.Value.ToString();
        }

        private void btnLFeesPaymentDate_Click(object sender, EventArgs e)
        {
            txtLFeesPaymentDate.Text = picLFeesPaymentDate.Value.ToString();
        }

        private void btnLSignatureDate_Click(object sender, EventArgs e)
        {
            txtLSignatureDate.Text = picLSignatureDate.Value.ToString();
        }

        private void btnLReceiveDate_Click(object sender, EventArgs e)
        {
            txtLReceiveDate.Text = picLReceiveDate.Value.ToString();
        }
        #endregion

    }
}
