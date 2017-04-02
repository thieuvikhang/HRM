using System;
using Microsoft.Reporting.WinForms;

namespace HRM
{
    public partial class UcRpContract : DevExpress.XtraEditors.XtraUserControl
    {
        public UcRpContract()
        {
            InitializeComponent();
        }
        private void UcRpContract_Load(object sender, EventArgs e)
        {
            ContractRpTableAdapter.Fill(HRMDataSet.ContractRp);
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            SetParameter(month,year);
            reportViewer1.RefreshReport();
        }
        private void SetParameter(int month, int year)
        {
            ReportParameter[] rp = new ReportParameter[2];
            rp[0] = new ReportParameter("Month");
            rp[1] = new ReportParameter("Year");
            rp[0].Values.Add(month.ToString());
            rp[1].Values.Add(year.ToString());
            reportViewer1.LocalReport.SetParameters(rp);
        }
    }
}
