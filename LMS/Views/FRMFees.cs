using LMS.Controllers;
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
            LoadData();
        }

        private void btnAddFee_Click(object sender, EventArgs e)
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
                    feesController.AddNewFee(adminId, new Fee
                    {
                        LicenseId = licenseId,
                        Amount = Convert.ToDecimal(txtFeeAmount.Text),
                        CreatedOn = picFeeDate.Value
                    });
                    LoadData();
                }
            }
        }

        private void btnFeeDate_Click(object sender, EventArgs e)
        {
            txtFeeDate.Text = picFeeDate.Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDisplay.Rows.Count > 0)
            {
                if (MessageBox.Show("هل تريد الحذف", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    string id = dgvDisplay.CurrentRow.Cells[0].Value.ToString();
                    if (feesController.DeleteFee(Convert.ToInt32(id)))
                        MessageBox.Show("تم الحذف بنجاح");
                    else
                        MessageBox.Show("لم يتم الحذف");
                    LoadData();
                }
            }
            else MessageBox.Show("اختر الرخصة أولاً");
        }

        public void LoadData()
        {
            decimal? fees = context.Licenses.Where(l => l.Id == licenseId).Select(l => l.Fees).FirstOrDefault();
            decimal paid = 0;
            foreach (var fee in feesController.GetFees(licenseId))
            {
                paid += fee.Amount;
            }
            dgvDisplay.DataSource = feesController.GetFees(licenseId);
            dgvDisplay.Columns["FeeId"].Visible = false;
            dgvDisplay.Columns["Amount"].HeaderText = "قيمة المبلغ";
            dgvDisplay.Columns["CreatedOn"].HeaderText = "تاريخ الإضافة";
            lblFees.Text = "قيمة الأتعاب : " + fees.ToString();
            lblPaid.Text = "الواصل : " + paid.ToString();
            lblRemaining.Text = "المتبقي : " + Convert.ToString(fees - paid);
        }
    }
}
