using System;
using System.Linq;
using System.Windows.Forms;
using DAL;
using DevExpress.XtraEditors;
using  BUS;

namespace HRM
{
    public partial class UcEmployees : XtraUserControl
    {
        public UcEmployees()
        {
            InitializeComponent();
        }

        readonly StaffBus _staffBus = new StaffBus();
        readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        int _checkAdd = 0;
        private void labelControl7_Click(object sender, EventArgs e)
        {

        }
        void SetTxt(bool val)
        {
            txtStaffID.Enabled = val;
            txtName.Enabled = val;
            txtPhone.Enabled = val;
            txtAddress.Enabled = val;
            txtCardID.Enabled = val;
            cbbSection.Enabled = val;
            cbbPost.Enabled = val;
            cbbManID.Enabled = val;
            cbbEducation.Enabled = val;
            dateEnd.Enabled = val;
            dateStart.Enabled = val;
            dateBirth.Enabled = val;
            txtEmail.Enabled = val;
        }
        public void ResettextBox()
        {
            txtStaffID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtCardID.Text = "";
            cbbSection.Text = "";
            cbbPost.Text = "";
            cbbManID.Text = "";
            cbbEducation.Text = "";
            dateEnd.Text = "";
            dateStart.Text = "";
            dateBirth.Text = "";
            txtEmail.Text = "";
        }
        void SetBtn(bool val)
        {
            btnAdd.Enabled = val;
            btnDelete.Enabled = val;
            btnEdit.Enabled = val;
            btnSave.Enabled = !val;
            btnCancel.Enabled = !val;
        }
        public void LoadComboboxSection()
        {
            var section = from sec in _aHrm.Sections
                          select new
                          {
                              tenloai = sec.SectionName,
                              maloai = sec.SectionID,
                          };
            cbbSection.DataSource = section.ToList();
            cbbSection.DisplayMember = "tenloai";
            cbbSection.ValueMember = "maloai";
        }
        public void LoadComboboxPosition()
        {
            var post = from po in _aHrm.Positions
                       select new
                       {
                           tenloai = po.PostName,
                           maloai = po.PostID,
                       };
            cbbPost.DataSource = post.ToList();
            cbbPost.DisplayMember = "tenloai";
            cbbPost.ValueMember = "maloai";
        }
        public void LoadComboboxManId()
        {
            var mana = from ma in _aHrm.Staffs
                       select new
                       {
                           tenloai = ma.StaffName,
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
            GetInfo();
        }
        public void LoadStaff()
        {
            gcEmployees.DataSource = _staffBus.LoadStaff();
            
        }
        private void ucEmployees_Load(object sender, EventArgs e)
        {
            SetTxt(false);
            gcEmployees.DataSource = _staffBus.LoadStaff();
            LoadComboboxSection();
            LoadComboboxPosition();
            LoadComboboxManId();
            rbNam.Checked = true;
            cbbEducation.SelectedItem = "Đại học";
        }

        public void AddStaff()
        {
            string section = cbbSection.SelectedValue.ToString();
            string post = cbbPost.SelectedValue.ToString();
            string manid = cbbManID.SelectedValue.ToString();
            if(rbNam.Checked==true)
            {
                _staffBus.createAStaff(txtStaffID.Text, txtName.Text, true, dateBirth.DateTime, txtCardID.Text, txtPhone.Text, txtAddress.Text, cbbEducation.Text, dateStart.DateTime, dateEnd.DateTime, manid, txtEmail.Text, 10, post,section);
            }
            else
            {
                _staffBus.createAStaff(txtStaffID.Text, txtName.Text, false, dateBirth.DateTime, txtCardID.Text, txtPhone.Text, txtAddress.Text, cbbEducation.Text, dateStart.DateTime, dateEnd.DateTime, manid, txtEmail.Text, 10, post, section);
            }
        }
        public void EditStaff()
        {
            string section = cbbSection.SelectedValue.ToString();
            string post = cbbPost.SelectedValue.ToString();
            string manid = cbbManID.SelectedValue.ToString();
            if (rbNam.Checked == true)
            {
                _staffBus.editAStaff(txtStaffID.Text, txtName.Text, true, dateBirth.DateTime, txtCardID.Text, txtPhone.Text, txtAddress.Text, cbbEducation.Text, dateStart.DateTime, dateEnd.DateTime, manid, txtEmail.Text, 10, post, section);
            }
            else
            {
                _staffBus.editAStaff(txtStaffID.Text, txtName.Text, false, dateBirth.DateTime, txtCardID.Text, txtPhone.Text, txtAddress.Text, cbbEducation.Text, dateStart.DateTime, dateEnd.DateTime, manid, txtEmail.Text, 10, post, section);
            }
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            SetTxt(true);
            ResettextBox();
            SetBtn(false);
            _checkAdd = 1;
            gcEmployees.Enabled = false;
            dxErrorProvider.ClearErrors();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(_checkAdd == 1)
                {
                    AddStaff();
                    ResettextBox();
                    SetTxt(false);
                    SetBtn(true);
                    gcEmployees.Enabled = true;
                }
                else if(_checkAdd == 2)
                {
                    EditStaff();
                    ResettextBox();
                    SetTxt(false);
                    SetBtn(true);
                    gcEmployees.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show(@"Các trường * không được bỏ trống");
            }
            gcEmployees.DataSource = _staffBus.LoadStaff();
        }
        public void GetInfo()
        {
            txtStaffID.Text = gridView1.GetFocusedRowCellDisplayText(gcStaffID);
            txtName.Text = gridView1.GetFocusedRowCellDisplayText(gcStaffName);
            dateBirth.Text = gridView1.GetFocusedRowCellDisplayText(gcBirthDay);
            txtCardID.Text = gridView1.GetFocusedRowCellDisplayText(gcCardID);
            txtPhone.Text = gridView1.GetFocusedRowCellDisplayText(gcPhone);
            txtAddress.Text = gridView1.GetFocusedRowCellDisplayText(gcAddress);
            cbbEducation.Text = gridView1.GetFocusedRowCellDisplayText(gcEducation);
            dateStart.Text = gridView1.GetFocusedRowCellDisplayText(gcDateStart);
            dateEnd.Text = gridView1.GetFocusedRowCellDisplayText(gcEndDate);
            cbbManID.Text = gridView1.GetFocusedRowCellDisplayText(gcManagerID);
            txtEmail.Text = gridView1.GetFocusedRowCellDisplayText(gcEmail);
            cbbPost.Text = gridView1.GetFocusedRowCellDisplayText(gcPosition);
            cbbSection.Text = gridView1.GetFocusedRowCellDisplayText(gcSection);

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = XtraMessageBox.Show($"Bạn muốn xóa nhân viên {txtName.Text} này", "Xóa nhân viên", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    _staffBus.deleteAStaff(txtStaffID.Text);

                }
                else
                {

                }

            }
            catch
            {
                // ignored
            }
            gcEmployees.DataSource = _staffBus.LoadStaff();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {

        }

        private void txtCardID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _checkAdd = 2;
        }
    }
}

