using System;
using DevExpress.XtraEditors;
using HRM.HRMDataSetTableAdapters;

namespace HRM
{
    public partial class AgeChart : XtraUserControl
    {
        public AgeChart()
        {
            InitializeComponent();
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }

        private void AgeChart_Load(object sender, EventArgs e)
        {
            new QueriesTableAdapter().Age_Range();
            // TODO: This line of code loads data into the 'hRMDataSet1.cateage' table. You can move, or remove it, as needed.
            cateAgeTableAdapter.Fill(hRMDataSet.CateAge);
        }
    }
}
