using System;
using DevExpress.XtraEditors;
using Microsoft.Reporting.WinForms;

namespace HRM
{
    public partial class Report : XtraForm
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'HRMDataSet.NewEmployees' table. You can move, or remove it, as needed.
            NewEmployeesTableAdapter.Fill(HRMDataSet.NewEmployees);

            reportViewer1.RefreshReport();
            SetParameter(dateEdit1.DateTime, dateEdit2.DateTime);
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SetParameter(dateEdit1.DateTime, dateEdit2.DateTime);
            reportViewer1.RefreshReport();
        }
    }
}