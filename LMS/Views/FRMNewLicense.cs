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
using LMS.ViewModel;

namespace LMS.Views
{
    public partial class FRMNewLicense : Form
    {
        public int AdminId;
        public string status = "New";
        public int licenseId;
        LocationController locatcont = new LocationController();
        LicenseController licensecont = new LicenseController();
        LicenseVM licenseVM = new LicenseVM();
        public FRMNewLicense(int adminId)
        {
            InitializeComponent();
            InitializeDatePicker();
            AdminId = adminId;
        }

        public FRMNewLicense(int adminId,string _status,int _licenseId)
        {
            InitializeComponent();
            AdminId = adminId;
            status = _status;
            licenseId = _licenseId;
            InitializeDatePicker();
            if (status == "Edit")
            {
                lblTitle.Text = "تعديل رخصة";
                lblCreatedOn.Visible = true;
                lblLastUpdate.Visible = true;
                LoadData();
            }
        }

        public void LoadData()
        {
            #region Retreive data from database for editing

            licenseVM = licensecont.GetLicenseVM(licenseId);
            lblCreatedOn.Text = $"تاريخ الأضافة : {licenseVM.CreatedOn}";
            lblLastUpdate.Text = $"تاريخ اخر تعديل : {licenseVM.LastUptate}";

            txtOwnerNationalId.Text = licenseVM.OwnarNationalId;
            txtOwnerName.Text = licenseVM.OwnarName;
            txtAgentNationalId.Text = licenseVM.AgentNationalId;
            txtAgentName.Text = licenseVM.AgentName;
            txtLocation.Text = licenseVM.Location;
            txtPlotNumber.Text = licenseVM.PlotNumber;
            txtWork.Text = licenseVM.Work;
            if (licenseVM.VEntryDate != null)
            {
                picVEntryDate.Value = (DateTime)licenseVM.VEntryDate;
                txtVEntryDate.Text = licenseVM.VEntryDate.ToString();
            }
            if (licenseVM.VInitialSupplyDate != null)
            {
                picVInitialSupplyDate.Value = (DateTime)licenseVM.VInitialSupplyDate;
                txtVInitialSupplyDate.Text = licenseVM.VInitialSupplyDate.ToString();
            }
            if (licenseVM.VValidatySupplyDate != null)
            {
                picVValidatySupplyDate.Value = (DateTime)licenseVM.VValidatySupplyDate;
                txtVValidatySupplyDate.Text = licenseVM.VValidatySupplyDate.ToString();
            }
            if (licenseVM.VReceiveDate != null)
            {
                picVReceiveDate.Value = (DateTime)(licenseVM.VReceiveDate);
                txtVReceiveDate.Text = licenseVM.VReceiveDate.ToString();
            }
            if (licenseVM.LEntryDate != null)
            {
                picLEntryDate.Value = (DateTime)licenseVM.LEntryDate;
                txtLEntryDate.Text = licenseVM.LEntryDate.ToString();
            }
            if (licenseVM.LExaminationFeeDate != null)
            {
                picLExaminationFeeDate.Value = (DateTime)licenseVM.LExaminationFeeDate;
                txtLExaminationFeeDate.Text = licenseVM.LExaminationFeeDate.ToString();
            }
            if (licenseVM.LFeesPaymentDate != null)
            {
                picLFeesPaymentDate.Value = (DateTime)licenseVM.LFeesPaymentDate;
                txtLFeesPaymentDate.Text = licenseVM.LFeesPaymentDate.ToString();
            }
            if (licenseVM.LSignatureDate != null)
            {
                picLSignatureDate.Value = (DateTime)licenseVM.LSignatureDate;
                txtLSignatureDate.Text = licenseVM.LSignatureDate.ToString();
            }
            if (licenseVM.LReceiveDate != null)
            {
                picLReceiveDate.Value = (DateTime)licenseVM.LReceiveDate;
                txtLReceiveDate.Text = licenseVM.LReceiveDate.ToString();
            }
            txtLicenseNumber.Text = licenseVM.LicenseNumber;
            txtFees.Text = licenseVM.Fees.ToString();
            txtNotes.Text = licenseVM.Notes;

            #endregion
        }

        public void InitializeDatePicker()
        {
            picVEntryDate.Value = DateTime.Now;
            picVInitialSupplyDate.Value = DateTime.Now;
            picVValidatySupplyDate.Value = DateTime.Now;
            picVReceiveDate.Value = DateTime.Now;
            picLEntryDate.Value = DateTime.Now;
            picLExaminationFeeDate.Value = DateTime.Now;
            picLFeesPaymentDate.Value = DateTime.Now;
            picLSignatureDate.Value = DateTime.Now;
            picVEntryDate.Value = DateTime.Now;
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

        private void btnSave_Click(object sender, EventArgs e)
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
                errorMessages.Add("أدخل بيانات المالك");
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
                errorMessages.Add("أدخل بيانات الوكيل");
            }

            decimal x;
            if (!decimal.TryParse(txtFees.Text, out x))
            {
                errorMessages.Add("قيمة الاتعاب غير صحيحة");
            }

            if(errorMessages.Count > 0)
            {
                string message = null;
                foreach (var error in errorMessages)
                {
                    message += error+"\n";
                }
                MessageBox.Show(message);
            }
            else
            {
                validityStat = new ValidityStatment
                {
                    EntryDate = txtVEntryDate.Text != string.Empty ? picVEntryDate.Value : (DateTime?)null,
                    InitialSupplyDate = txtVInitialSupplyDate.Text != string.Empty ? picVInitialSupplyDate.Value : (DateTime?)null,
                    ReceiveDate = txtVReceiveDate.Text != string.Empty ? picVReceiveDate.Value : (DateTime?)null,
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
                if (status == "New")
                {
                    if (MessageBox.Show("هل تريد الحفظ ؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (licensecont.AddLicense(AdminId, Owner, Agent, validityStat, location, license))
                            MessageBox.Show("تم الإضافة بنجاح");
                    }
                }
                if(status == "Edit")
                {
                    if (MessageBox.Show("هل تريد الحفظ ؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        LicenseVM newLicense = new LicenseVM
                        {
                            OwnarNationalId = txtOwnerNationalId.Text,
                            OwnarName = txtOwnerName.Text,
                            AgentNationalId = txtAgentNationalId.Text,
                            AgentName = txtAgentName.Text,
                            Location = txtLocation.Text,
                            PlotNumber = txtPlotNumber.Text,
                            LicenseNumber = txtLicenseNumber.Text,
                            Work = txtWork.Text,
                            VEntryDate = txtVEntryDate.Text != string.Empty ? picVEntryDate.Value : (DateTime?)null,
                            VInitialSupplyDate = txtVInitialSupplyDate.Text != string.Empty ? picVInitialSupplyDate.Value : (DateTime?)null,
                            VReceiveDate = txtVReceiveDate.Text != string.Empty ? picVReceiveDate.Value : (DateTime?)null,
                            VValidatySupplyDate = txtVValidatySupplyDate.Text != string.Empty ? picVValidatySupplyDate.Value : (DateTime?)null,
                            LEntryDate = txtLEntryDate.Text != string.Empty ? picLEntryDate.Value : (DateTime?)null,
                            LExaminationFeeDate = txtLExaminationFeeDate.Text != string.Empty ? picLExaminationFeeDate.Value : (DateTime?)null,
                            LFeesPaymentDate = txtLFeesPaymentDate.Text != string.Empty ? picLFeesPaymentDate.Value : (DateTime?)null,
                            LSignatureDate = txtLSignatureDate.Text != string.Empty ? picLSignatureDate.Value : (DateTime?)null,
                            LReceiveDate = txtLReceiveDate.Text != string.Empty ? picLReceiveDate.Value : (DateTime?)null,
                            Fees = Convert.ToDecimal(txtFees.Text),
                            Notes = txtNotes.Text,
                            LastUptate = DateTime.Now
                        };
                        if (licensecont.UpdateLicense(AdminId, licenseId, newLicense) > 0)
                        {
                            FRMMain frm = (FRMMain)Application.OpenForms["FRMMain"];
                            frm.LoadForm(new FRMNewLicense(1, "Edit", licenseId));
                            MessageBox.Show("تم التعديل بنجاح");
                        }
                    }
                }
            }
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
