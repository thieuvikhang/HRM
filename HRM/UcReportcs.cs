using DevExpress.LookAndFeel;
using DevExpress.XtraReports.UI;

namespace HRM
{
    public partial class UcReportcs : DevExpress.XtraEditors.XtraUserControl
    {
        public UcReportcs()
        {
            InitializeComponent();
        }
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            NewEmployees report = new NewEmployees();

            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                // Invoke the Print Preview form modally, 
                // and load the report document into it.
                printTool.ShowPreviewDialog();

                // Invoke the Print Preview form
                // with the specified look and feel setting.
                printTool.ShowPreviewDialog(UserLookAndFeel.Default);
            }
        }
    }
}
