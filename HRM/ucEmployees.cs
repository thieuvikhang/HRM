using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;
namespace HRM
{
    public partial class ucEmployees : DevExpress.XtraEditors.XtraUserControl
    {
        public ucEmployees()
        {
            InitializeComponent();
        }
        staffBUS staffBUS = new staffBUS();
        HRMModelDataContext aHRM = new HRMModelDataContext();
        private void labelControl7_Click(object sender, EventArgs e)
        {

        }
        public void loadComboboxSection()
        {
            var section = from sec in aHRM.Sections
                          select new
                          {
                              tenloai = sec.Name,
                              maloai = sec.SectionID,
                          };
            cbbSection.DataSource = section.ToList();
            cbbSection.DisplayMember = "tenloai";
            cbbSection.ValueMember = "maloai";
        }
        public void loadComboboxPosition()
        {
            var post = from po in aHRM.Positions
                       select new
                       {
                           tenloai = po.Name,
                           maloai = po.PostID,
                       };
            cbbPost.DataSource = post.ToList();
            cbbPost.DisplayMember = "tenloai";
            cbbPost.ValueMember = "maloai";
        }
        public void loadComboboxManID()
        {
            var mana = from ma in aHRM.Staffs
                       select new
                       {
                           tenloai = ma.Name,
                           maloai = ma.StaffID,
                       };
            cbbManID.DataSource = mana.ToList();
            cbbManID.DisplayMember = "tenloai";
            cbbManID.ValueMember = "maloai";
        }
        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        public void LoadStaff()
        {
            staffBUS.loadStaff();
     
        }
        private void ucEmployees_Load(object sender, EventArgs e)
        {
            gcEmployees.DataSource = staffBUS.loadStaff();
            loadComboboxSection();
            loadComboboxPosition();
            loadComboboxPosition();
            cbbEducation.SelectedItem = "Đại học";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
