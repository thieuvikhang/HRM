using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace HRM
{
    public partial class UcRpBirthDay : DevExpress.XtraEditors.XtraUserControl
    {
        public UcRpBirthDay()
        {
            InitializeComponent();
        }

        private void UcRpBirthDay_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> filterItems = new Dictionary<string, string>
            {
                {"Tháng 1", "1"},
                {"Tháng 2", "2"},
                {"Tháng 3", "3"},
                {"Tháng 4", "4"},
                {"Tháng 5", "5"},
                {"Tháng 6", "6"},
                {"Tháng 7", "7"},
                {"Tháng 8", "8"},
                {"Tháng 9", "9"},
                {"Tháng 10", "10"},
                {"Tháng 11", "11"},
                {"Tháng 12", "12"}
            };
            comboBox1.DataSource = new BindingSource(filterItems, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";

            comboBox1.SelectedIndex = 0;

            // TODO: This line of code loads data into the 'HRMDataSet.NewEmployees' table. You can move, or remove it, as needed.
            NewEmployeesTableAdapter.Fill(HRMDataSet.NewEmployees);
            int n = Int32.Parse(comboBox1.SelectedValue.ToString());
            SetParameter(n);

            reportViewer1.RefreshReport();
        }
        private void SetParameter(int month)
        {
            ReportParameter rp = new ReportParameter("month");
            rp.Values.Add(month.ToString());
            reportViewer1.LocalReport.SetParameters(rp);
        }

   

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int n = Int32.Parse(comboBox1.SelectedValue.ToString());
            SetParameter(n);
            reportViewer1.RefreshReport();
        }
    }
}
