using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL;
using BUS;

namespace HRM
{
    public partial class ucSection : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSection()
        {
            InitializeComponent();
        }
        sectionBUS sectionBUS = new sectionBUS();

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ucSection_Load(object sender, EventArgs e)
        {
            gcSection.DataSource = sectionBUS.loadAll();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
        public void GetInfo()
        {
            txtSectionID.Text = gridView1.GetFocusedRowCellDisplayText(gCoSectionID);
            txtName.Text = gridView1.GetFocusedRowCellDisplayText(gCoSectionName);
            mmDescription.Text = gridView1.GetFocusedRowCellDisplayText(gCoDescription);
            numStandardWorkdays.Text = gridView1.GetFocusedRowCellDisplayText(gCoStandardWorkdays);
            txtPhone.Text = gridView1.GetFocusedRowCellDisplayText(gCoPhone);
        }
        private void gcSection_Click(object sender, EventArgs e)
        {
            GetInfo();
        }
        public void AddSection()
        {
            int stardw = int.Parse(numStandardWorkdays.Text);
            sectionBUS.createASection(txtSectionID.Text, txtName.Text, mmDescription.Text, stardw, txtPhone.Text);
        }
        public void DelSection()
        {
            sectionBUS.deleteASection(txtSectionID.Text);
        }
        private void gridView1_Click(object sender, EventArgs e)
        {
            GetInfo();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                AddSection();
            }
            catch
            {

            }
            gcSection.DataSource = sectionBUS.loadAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DelSection();
            }
            catch
            {

            }
            gcSection.DataSource = sectionBUS.loadAll();
        }
    }
}
