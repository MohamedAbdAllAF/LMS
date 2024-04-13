using LMS.Controllers;
using System;
using System.Windows.Forms;

namespace LMS.Views
{
    public partial class FRMDashboard : Form
    {
        LicenseController licenseController = new LicenseController();
        FeesController feesController = new FeesController();
        public FRMDashboard()
        {
            InitializeComponent();
        }

        private void FRMDashboard_Load(object sender, EventArgs e)
        {
            //lblLicenseCount.Text = 
            //    $"عدد الرخص المسجلة علي النظام \n {licenseController.GetAllLicenses().Count()} رخصة";
            //lblMonthlyIncome.Text = $"دخل الشهر الحالي \n{feesController.MonthlyIncome(DateTime.Now)} جنيه";
        }
    }
}
