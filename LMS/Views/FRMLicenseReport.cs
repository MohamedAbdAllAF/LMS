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
            //ReportDataSource source = new ReportDataSource(
            //    "LicenseDataSet", LicenseController.GetAllLicensesForReports());
            reportViewer1.LocalReport.DataSources.Clear();
            DateTime From = new DateTime(picFrom.Value.Year, picFrom.Value.Month, picFrom.Value.Day,0,0,0);
            DateTime To = new DateTime(picTo.Value.Year, picTo.Value.Month, picTo.Value.Day,23,59,59);
            ReportDataSource source = new ReportDataSource(
                "LicenseDataSet", LicenseController.GetAllLicensesInRange(From,To));
            this.reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();
        }
    }
}
