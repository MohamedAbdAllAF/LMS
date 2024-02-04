using LMS.Controllers;
using Microsoft.Reporting.WinForms;
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
    public partial class FRMLicenseReport : Form
    {
        LicenseController LicenseController = new LicenseController();
        public FRMLicenseReport()
        {
            InitializeComponent();
            picFrom.Value = picTo.Value = DateTime.Now;
        }

        private void FRMLicenseReport_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var choice = "";
            if (rbtnAddedInSystem.Checked) choice = "CreatedOn";
            else if (rbtnLEntryDate.Checked) choice = "LEntryDate";
            else if (rbtnLExaminationFeeDate.Checked) choice = "LExaminationFeeDate";
            else if (rbtnLFinalPaymentDate.Checked) choice = "LFinalPaymentDate";
            else if (rbtnLInitialSupplyDate.Checked) choice = "LInitialSupplyDate";
            else if (rbtnVEntryDate.Checked) choice = "VEntryDate";
            else if (rbtnVInitialSupplyDate.Checked) choice = "VInitialSupplyDate";
            else if (rbtnVValidatySupplyDate.Checked) choice = "VValidatySupplyDate";

            reportViewer1.LocalReport.DataSources.Clear();
            DateTime From = new DateTime(picFrom.Value.Year, picFrom.Value.Month, picFrom.Value.Day,0,0,0);
            DateTime To = new DateTime(picTo.Value.Year, picTo.Value.Month, picTo.Value.Day,23,59,59);
            ReportDataSource source = new ReportDataSource(
                "LicenseDataSet", LicenseController.GetAllLicensesInRange(From,To,choice));
            this.reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();
        }

        private void rbtnVValidatySupplyDate_Click(object sender, EventArgs e)
        {
            var choice = sender as RadioButton;
            rbtnAddedInSystem.Checked = rbtnLEntryDate.Checked = rbtnLExaminationFeeDate.Checked = rbtnLFinalPaymentDate.Checked =
                rbtnLInitialSupplyDate.Checked = rbtnVEntryDate.Checked = rbtnVInitialSupplyDate.Checked = rbtnVValidatySupplyDate.Checked = false;

            if (rbtnAddedInSystem.Text == choice.Text)
            {
                rbtnAddedInSystem.Checked = true;
            }
            else if (rbtnLEntryDate.Text == choice.Text)
            {
                rbtnLEntryDate.Checked = true;
            }
            else if (rbtnLExaminationFeeDate.Text == choice.Text)
            {
                rbtnLExaminationFeeDate.Checked = true;
            }
            else if (rbtnLFinalPaymentDate.Text == choice.Text)
            {
                rbtnLFinalPaymentDate.Checked = true;
            }
            else if (rbtnLInitialSupplyDate.Text == choice.Text)
            {
                rbtnLInitialSupplyDate.Checked = true;
            }
            else if (rbtnVEntryDate.Text == choice.Text)
            {
                rbtnVEntryDate.Checked = true;
            }
            else if (rbtnVInitialSupplyDate.Text == choice.Text)
            {
                rbtnVInitialSupplyDate.Checked = true;
            }
            else if (rbtnVValidatySupplyDate.Text == choice.Text)
            {
                rbtnVValidatySupplyDate.Checked = true;
            }
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            ReportDataSource source = new ReportDataSource(
                "LicenseDataSet", LicenseController.GetAllLicensesForReports());
            reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();
        }
    }
}
