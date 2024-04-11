using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMS.Controllers;
using LMS.Models;
using LMS.ViewModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        private List<(int id, string FileName, string Extension, byte[] Data)> fileList = new List<(int, string, string, byte[])>();
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
                btnDeleteLicense.Visible = true;
                LoadData();
            }
            // Add columns only once when the form is initialized
            lvFilesList.View = View.Details;
            lvFilesList.GridLines = true;
            lvFilesList.FullRowSelect = true;
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
            if (licenseVM.LInitialSupplyDate != null)
            {
                picLInitialSupplyDate.Value = (DateTime)licenseVM.LInitialSupplyDate;
                txtLInitialSupplyDate.Text = licenseVM.LInitialSupplyDate.ToString();
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
            if (licenseVM.LFinalPaymentDate != null)
            {
                picLFinalPaymentDate.Value = (DateTime)licenseVM.LFinalPaymentDate;
                txtLFinalPaymentDate.Text = licenseVM.LFinalPaymentDate.ToString();
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
            picLInitialSupplyDate.Value = DateTime.Now;
            picLFinalPaymentDate.Value = DateTime.Now;
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

            if(txtOwnerName.Text != string.Empty)
            {
                if(txtOwnerNationalId.Text.Length == 14 || txtOwnerNationalId.Text ==string.Empty)
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

            if (txtAgentName.Text != string.Empty )
            {
                if (txtAgentNationalId.Text.Length == 14 || txtAgentNationalId.Text ==string.Empty)
                {
                    Agent = new User { NationalId = txtAgentNationalId.Text, Name = txtAgentName.Text };
                }
                else
                {
                    errorMessages.Add("الرقم القومي للوكيل غير صحيح");
                }
            }

            if (txtFees.Text != string.Empty)
            {
                decimal x;
                if (!decimal.TryParse(txtFees.Text, out x))
                {
                    errorMessages.Add("قيمة الاتعاب غير صحيحة");
                }
            }

            if(errorMessages.Count > 0)
            {
                string message = null;
                foreach (var error in errorMessages)
                {
                    message += error+"\n";
                }
                MessageBox.Show(message);
                errorMessages.Clear();
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
                    InitialSupplyDate=txtVInitialSupplyDate.Text !=string.Empty ? picLInitialSupplyDate.Value : (DateTime?)null,
                    ExaminationFeeDate = txtLExaminationFeeDate.Text != string.Empty ? picLExaminationFeeDate.Value : (DateTime?)null,
                    FeesPaymentDate = txtLFeesPaymentDate.Text != string.Empty ? picLFeesPaymentDate.Value : (DateTime?)null,
                    FinalPaymentDate = txtLFinalPaymentDate.Text != string.Empty ? picLFinalPaymentDate.Value : (DateTime?)null,
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
                            LInitialSupplyDate = txtVInitialSupplyDate.Text != string.Empty ? picLInitialSupplyDate.Value : (DateTime?)null,
                            LExaminationFeeDate = txtLExaminationFeeDate.Text != string.Empty ? picLExaminationFeeDate.Value : (DateTime?)null,
                            LFeesPaymentDate = txtLFeesPaymentDate.Text != string.Empty ? picLFeesPaymentDate.Value : (DateTime?)null,
                            LFinalPaymentDate = txtLFinalPaymentDate.Text != string.Empty ? picLFinalPaymentDate.Value : (DateTime?)null,
                            LSignatureDate = txtLSignatureDate.Text != string.Empty ? picLSignatureDate.Value : (DateTime?)null,
                            LReceiveDate = txtLReceiveDate.Text != string.Empty ? picLReceiveDate.Value : (DateTime?)null,
                            Fees = txtFees.Text != string.Empty ? Convert.ToDecimal(txtFees.Text) : 0,
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

        private void btnLInitialSupplyDate_Click(object sender, EventArgs e)
        {
            txtLInitialSupplyDate.Text = picLInitialSupplyDate.Value.ToString();
        }

        private void btnLFinalPaymentDate_Click(object sender, EventArgs e)
        {
            txtLFinalPaymentDate.Text = picLFinalPaymentDate.Value.ToString();
        }
        #endregion

        private void btnDeleteLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد الحذف ؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (licensecont.DeleteLicense(AdminId, licenseId))
                {
                    FRMMain frm = (FRMMain)Application.OpenForms["FRMMain"];
                    MessageBox.Show("تم الحذف بنجاح");
                    frm.LoadForm(new FRMNewLicense(1));
                }
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    string fileExtension = Path.GetExtension(file);
                    byte[] fileData = File.ReadAllBytes(file);

                    string displayName = fileName + fileExtension;

                    int newId = 1;
                    if (fileList.Count != 0)
                        newId = fileList.Max(f => f.id) + 1;

                    ListViewItem item = new ListViewItem(new[] {newId.ToString() , displayName });
                    lvFilesList.Items.Add(item);

                    fileList.Add((newId, displayName, fileExtension, fileData));
                }
            }
        }

        private void lvFilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFilesList.SelectedItems.Count > 0)
            {
                btnDownloadFile.Enabled = true;
                btnDeleteFile.Enabled = true;
            }
            else
            {
                btnDownloadFile.Enabled = false;
                btnDeleteFile.Enabled = false;
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد الحذف ؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (lvFilesList.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem selectedItem in lvFilesList.SelectedItems)
                    {
                        lvFilesList.Items.Remove(selectedItem);

                        int selectedIndex = fileList.FindIndex(item => item.id == int.Parse(selectedItem.SubItems[0].Text));

                        if (selectedIndex != -1)
                        {
                            fileList.RemoveAt(selectedIndex);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select an item to delete.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            if (lvFilesList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvFilesList.SelectedItems[0];

                var selectedFile = fileList.Find(item => item.id == int.Parse(selectedItem.SubItems[0].Text));

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = selectedFile.FileName; // Set initial filename
                saveFileDialog.Filter = "All Files|*.*"; // Set file filter
                saveFileDialog.Title = "Save File"; // Set dialog title

                // Show the dialog and get the result
                DialogResult result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Get the selected file data
                    byte[] fileData = selectedFile.Data;

                    // Get the selected file extension
                    string fileExtension = Path.GetExtension(saveFileDialog.FileName);

                    // Save the file with the selected filename and extension
                    File.WriteAllBytes(saveFileDialog.FileName, fileData);

                    // Inform the user that the file has been saved
                    MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            else
            {
                MessageBox.Show("Please select a file to save.", "No File Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
