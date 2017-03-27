using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Reporting.WinForms;

namespace HRM
{
    public partial class XtraForm2 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm2()
        {
            InitializeComponent();
        }

        private void XtraForm2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'HRMDataSet.NewEmployees' table. You can move, or remove it, as needed.
            this.NewEmployeesTableAdapter.Fill(this.HRMDataSet.NewEmployees);
            comboBox1.SelectedItem = "10";
            this.reportViewer1.RefreshReport();
            if(comboBox1.SelectedItem != null)
            SetParameter(int.Parse(comboBox1.SelectedItem.ToString()));
            
            this.reportViewer1.RefreshReport();
        }
        private void SetParameter(int month)
        {
            ReportParameter rp = new ReportParameter("month");       
            rp.Values.Add(month.ToString());
            reportViewer1.LocalReport.SetParameters(rp);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {


            this.reportViewer1.RefreshReport();
        }
    }
}