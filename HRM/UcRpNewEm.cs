using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Microsoft.Reporting.WinForms;

namespace HRM
{
    public partial class UcRpNewEm : XtraUserControl
    {
        public UcRpNewEm()
        {
            InitializeComponent();
        }

        private void btnSummit_Click(object sender, EventArgs e)
        {
            SetParameter(dateFrom.DateTime, dateTo.DateTime);
            reportViewer1.RefreshReport();
        }

        private void UcRpNewEm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'HRMDataSet.NewEmployees' table. You can move, or remove it, as needed.
            NewEmployeesTableAdapter.Fill(HRMDataSet.NewEmployees);
            dateFrom.EditValue = DateTime.Today;
            dateTo.EditValue = DateTime.Today;
            SetParameter(dateFrom.DateTime, dateTo.DateTime);
            reportViewer1.RefreshReport();

        }
        private void SetParameter(DateTime fromYear, DateTime toYear)
        {
            ReportParameter[] rp = new ReportParameter[2];
            rp[0] = new ReportParameter("FromYear");
            rp[1] = new ReportParameter("ToYear");
            rp[0].Values.Add(fromYear.ToString());
            rp[1].Values.Add(toYear.ToString());
            reportViewer1.LocalReport.SetParameters(rp);
        }       
        private void dateTo_TextChanged(object sender, EventArgs e)
        {
            dateFrom.Properties.MaxValue = dateTo.DateTime;
        }

        private void dateFrom_TextChanged(object sender, EventArgs e)
        {
            dateTo.Properties.MinValue = dateFrom.DateTime;
            dateTo.SelectedText = dateFrom.SelectedText;        
        }
    }
}
