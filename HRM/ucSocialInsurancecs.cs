using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;
namespace HRM
{
    public partial class UcSocialInsurancecs : XtraUserControl
    {
        public UcSocialInsurancecs()
        {
            InitializeComponent();
        }
        readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        public void LoadLookUpId()
        {
            var mana = from ma in _aHrm.Staffs
                       select new
                       {
                           ID = ma.StaffID,
                           Name = ma.StaffName,                          
                       };
            lkStaffID.Properties.DataSource = mana.ToList();
            lkStaffID.Properties.ValueMember = "ID";
            lkStaffID.Properties.DisplayMember = "Name";           
        }
        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxEdit3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void UcSocialInsurancecs_Load(object sender, EventArgs e)
        {
            LoadLookUpId();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            var f2 = new frmPayrate();
            f2.ShowDialog(); // Shows Form2
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }
    }
}
