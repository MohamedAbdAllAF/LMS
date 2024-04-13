using LMS.Controllers;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS.Views
{
    public partial class FRMFees : Form
    {
        int adminId, licenseId;
        FeesController feesController = new FeesController();
        List<string> errorMessages = new List<string>();
        LMSContext context = new LMSContext();
        public FRMFees(int _adminId,int _liccenseId)
        {
            InitializeComponent();
            picFeeDate.Value = DateTime.Now;
            this.adminId = _adminId;
            this.licenseId = _liccenseId;
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await LoadData();
        }

        private async void btnAddFee_Click(object sender, EventArgs e)
        {
            decimal x;
            if (!decimal.TryParse(txtFeeAmount.Text, out x))
            {
                errorMessages.Add("قيمة الاتعاب غير صحيحة");
            }
            if (txtFeeDate.Text == string.Empty)
                errorMessages.Add("أدخل تاريخ الدفع");
            if (errorMessages.Count > 0)
            {
                string message = null;
                foreach (var error in errorMessages)
                {
                    message += error + "\n";
                }
                MessageBox.Show(message);
                errorMessages.Clear();
            }
            else
            {
                if (MessageBox.Show("هل تريد الإضافة", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
                {
                    await Task.Run(() => feesController.AddNewFee(adminId, new Fee
                    {
                        LicenseId = licenseId,
                        Amount = Convert.ToDecimal(txtFeeAmount.Text),
                        CreatedOn = picFeeDate.Value
                    }));
                    await LoadData();
                }
            }
        }

        private void btnFeeDate_Click(object sender, EventArgs e)
        {
            txtFeeDate.Text = picFeeDate.Value.ToString();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDisplay.Rows.Count > 0)
            {
                if (MessageBox.Show("هل تريد الحذف", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    string id = dgvDisplay.CurrentRow.Cells[0].Value.ToString();
                    var isDone = await Task.Run(() => feesController.DeleteFee(Convert.ToInt32(id)));
                    if (isDone)
                        MessageBox.Show("تم الحذف بنجاح");
                    else
                        MessageBox.Show("لم يتم الحذف");
                    await LoadData();
                }
            }
            else MessageBox.Show("اختر الرخصة أولاً");
        }

        public async Task LoadData()
        {
            decimal? fees = await context.Licenses.Where(l => l.Id == licenseId).Select(l => l.Fees).FirstOrDefaultAsync();
            decimal paid = 0;
            var feesList = await Task.Run(() => feesController.GetFees(licenseId));
            foreach (var fee in feesList)
            {
                paid += fee.Amount;
            }
            dgvDisplay.DataSource = await Task.Run(() => feesController.GetFees(licenseId));
            dgvDisplay.Columns["FeeId"].Visible = false;
            dgvDisplay.Columns["Amount"].HeaderText = "قيمة المبلغ";
            dgvDisplay.Columns["CreatedOn"].HeaderText = "تاريخ الإضافة";
            lblFees.Text = "قيمة الأتعاب : " + fees.ToString();
            lblPaid.Text = "الواصل : " + paid.ToString();
            lblRemaining.Text = "المتبقي : " + Convert.ToString(fees - paid);
        }
    }
}
