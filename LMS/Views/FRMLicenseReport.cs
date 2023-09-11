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
        }

        private void FRMLicenseReport_Load(object sender, EventArgs e)
        {
            BindingSource binding = new BindingSource();
            //binding.Add(LicenseController.DisplayLicense(1));
            ReportDataSource source = new ReportDataSource(
                "LicenseDataSet",LicenseController.GetAllLicensesForReports());
            this.reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();
        }
    }
}
