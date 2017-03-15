using System;
using System.Linq;
using System.Windows.Forms;
using DAL;
using DevExpress.XtraEditors;
using BUS;
using System.Text.RegularExpressions;

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
        private int _checkAdd;
        readonly StaffBus _staffbus = new StaffBus();

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
            txtMail.Enabled = val;
            rbNam.Enabled = val;
            rbNu.Enabled = val;
        }
        public void ResettextBox()
        {
            txtStaffID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtCardID.Text = "";
            //cbbSection.Text = "";
            //cbbPost.Text = "";
            //cbbManID.Text = "";
            //cbbEducation.Text = "";
            dateEnd.Text = "";
            dateStart.Text = "";
            dateBirth.Text = "";
            txtMail.Text = "";
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
        private string GetLastIdEmployee()
        {
            int id;

            int countrecords = _aHrm.Staffs.Count();
            if (countrecords == 0)
            {
                id = 0;
            }
            else
            {
                id = countrecords + 1;
            }
            var lastId = "NV" + id;
            return lastId;
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
            dxErrorProvider.ClearErrors();
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
            txtStaffID.Properties.MaxLength = 6;
            txtName.Properties.MaxLength = 30;
            txtCardID.Properties.MaxLength = 12;
            cbbEducation.MaxLength = 30;
            txtPhone.Properties.MaxLength = 11;
            txtMail.Properties.MaxLength = 20;
            txtAddress.Properties.MaxLength = 100;
            txtMail.SelectionStart = txtMail.Text.Length;
        }

        public void AddStaff()
        {
            string section = cbbSection.SelectedValue.ToString();
            string post = cbbPost.SelectedValue.ToString();
            string manid = cbbManID.SelectedValue.ToString();
            var gender = rbNam.Checked;
            DateTime? birth = null, start = null, end = null;
            if (dateBirth.SelectionLength != 0)
            {
                birth = dateBirth.DateTime;
            }
            if (dateStart.SelectionLength != 0)
            {
                start = dateStart.DateTime;

            }
            if (dateEnd.SelectionLength != 0)
            {
                end = dateEnd.DateTime;

            }
            _staffBus.CreateAStaff(txtStaffID.Text, txtName.Text, gender, birth,
                txtCardID.Text, txtPhone.Text, txtAddress.Text, cbbEducation.Text, start, end,
                manid, txtMail.Text, 10, post, section);
        }
        public void EditStaff()
        {
            var section = cbbSection.SelectedValue.ToString();
            var post = cbbPost.SelectedValue.ToString();
            var manid = cbbManID.SelectedValue.ToString();
            DateTime? birth = null, start = null, end = null;
            var gender = rbNam.Checked;
            if (dateBirth.SelectionLength != 0)
            {
                birth = dateBirth.DateTime;
            }
            if (dateStart.SelectionLength != 0)
            {
                start = dateStart.DateTime;

            }
            if (dateEnd.SelectionLength != 0)
            {
                end = dateEnd.DateTime;

            }
            _staffBus.EditAStaff(txtStaffID.Text, txtName.Text, gender, birth,
                txtCardID.Text, txtPhone.Text, txtAddress.Text, cbbEducation.Text, start, end,
                manid, txtMail.Text, 10, post, section);
        }
        public const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            SetTxt(true);
            ResettextBox();
            SetBtn(false);
            _checkAdd = 1;
            var idInsert = GetLastIdEmployee();
            txtStaffID.Text = idInsert;
            gcEmployees.Enabled = false;
            dxErrorProvider.ClearErrors();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_checkAdd == 1)
                {
                    if (string.IsNullOrEmpty(txtStaffID.Text))
                    {
                        dxErrorProvider.SetError(txtStaffID, "Mã nhân viên ko dc trống");
                    }
                    if (string.IsNullOrEmpty(txtName.Text))
                    {
                        dxErrorProvider.SetError(txtName, "Tên nhân viên ko dc trống");
                    }
                    if (!dxErrorProvider.HasErrors)
                    {
                        AddStaff();
                        ResettextBox();
                        SetTxt(false);
                        SetBtn(true);
                        gcEmployees.Enabled = true;
                    }
                }
                if (_checkAdd == 2)
                {
                    if (string.IsNullOrEmpty(txtName.Text))
                    {
                        dxErrorProvider.SetError(txtName, "Tên nhân viên ko dc trống");
                    }
                    if (!dxErrorProvider.HasErrors)
                    {
                        EditStaff();
                        ResettextBox();
                        SetTxt(false);
                        SetBtn(true);
                        gcEmployees.Enabled = true;
                    }
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
            txtMail.Text = gridView1.GetFocusedRowCellDisplayText(gcEmail);
            cbbPost.Text = gridView1.GetFocusedRowCellDisplayText(gcPosition);
            string gender = gridView1.GetFocusedRowCellDisplayText(gcoGender);
            if (gender == "Nam")
            {
                rbNam.Checked = true;
            }
            else
            {
                rbNu.Checked = true;
            }

            cbbSection.Text = gridView1.GetFocusedRowCellDisplayText(gcSection);

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = XtraMessageBox.Show($"Bạn muốn xóa nhân viên {txtName.Text} này", "Xóa nhân viên", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    _staffBus.DeleteAStaff(txtStaffID.Text);

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
            SetTxt(true);
            SetBtn(false);
            txtStaffID.Enabled = false;
            gcEmployees.Enabled = false;
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetBtn(true);
            ResettextBox();
            SetTxt(false);
            _checkAdd = 0;
            dxErrorProvider.ClearErrors();
            gcEmployees.Enabled = true;
        }

        private void txtStaffID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void txtStaffID_TextChanged(object sender, EventArgs e)
        {
            if (_staffbus.FindIdInputInTable(txtStaffID.Text))
            {
                dxErrorProvider.SetError(txtStaffID, "Mã phòng ban trùng");
            }
            else
            {
                dxErrorProvider.SetError(txtStaffID, null);
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            dxErrorProvider.SetError(txtName, null);
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (_staffbus.FindPhoneInputInTable(txtPhone.Text) && (txtPhone.Text != ""))
            {
                dxErrorProvider.SetError(txtPhone, "Số điện thoại trùng");
            }
            else
            {
                dxErrorProvider.SetError(txtPhone, null);
            }
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtMail.Text, MatchEmailPattern) && txtMail.Text != "")
            {
                dxErrorProvider.SetError(txtMail, "Email chưa đúng định dạng");
            }
            else if (_staffbus.FindEmailInputInTable(txtMail.Text) && txtMail.Text != "")
            {
                dxErrorProvider.SetError(txtMail, "Email trùng");
            }
            else
            {
                dxErrorProvider.SetError(txtMail, null);
            }
        }

        private void dateStart_DateTimeChanged(object sender, EventArgs e)
        {
            dateEnd.Properties.MinValue = dateStart.DateTime;
        }

        private void dateEnd_DateTimeChanged(object sender, EventArgs e)
        {
            dateStart.Properties.MaxValue = dateEnd.DateTime;
        }

        private void txtCardID_TextChanged(object sender, EventArgs e)
        {
            if (_staffbus.FindCardIdInputInTable(txtCardID.Text) && txtCardID.Text != "")
            {
                dxErrorProvider.SetError(txtCardID, "CMND trùng");
            }
            else
            {
                dxErrorProvider.SetError(txtCardID, null);
            }
        }
    }
}


