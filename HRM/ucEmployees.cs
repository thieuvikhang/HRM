using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System.IO; 


namespace HRM
{
    public partial class UcEmployees : XtraUserControl
    {
        public Session Session = new Session();
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

        protected virtual void SetTxt(bool val)
        {
            txtName.Enabled = val;
            txtPhone.Enabled = val;
            txtAddress.Enabled = val;
            txtCardID.Enabled = val;
            cbbSection.Enabled = val;
            cbbPost.Enabled = val;
            lkupManID.Enabled = val;
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
            dateEnd.Text = "";
            dateStart.Text = "";
            dateBirth.Text = "";
            txtMail.Text = "";
        }

        private void SetBtn(bool val)
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
                              maloai = sec.SectionID
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
                           maloai = po.PostID
                       };
            cbbPost.DataSource = post.ToList();
            cbbPost.DisplayMember = "tenloai";
            cbbPost.ValueMember = "maloai";
        }
        public void LoadComboboxPositionCheck()
        {
            var post = from po in _aHrm.Positions 
                       select new
                       {
                           tenloai = po.PostName,
                           maloai = po.PostID
                       };
            var pos = from po in _aHrm.Positions
                      where po.PostName =="Trưởng phòng"
                      select new
                      {
                          tenloai = po.PostName,
                          maloai = po.PostID
                      };
            cbbPost.DataSource = post.Except(pos).ToList();
            cbbPost.DisplayMember = "tenloai";
            cbbPost.ValueMember = "maloai";
        }
        public void LoadComboboxManId()
        {
            var mana = from ma in _aHrm.Staffs
                       select new
                       {
                           Name = ma.StaffName,
                           ID = ma.StaffID
                       };
            lkupManID.Properties.DataSource = mana.ToList();
            lkupManID.Properties.DisplayMember = "Name";
            lkupManID.Properties.ValueMember = "ID";
        }
        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }
        private string GetNewId()
        {
            var generator = new Random();
            string idNew;
            bool checkId;
            do
            {
                var getrandom = generator.Next(1000, 10000);
                idNew = "NV" + getrandom;
                var act = _aHrm.Staffs.SingleOrDefault(staff => staff.StaffID == idNew);
                checkId = act == null;
            } while (checkId == false);
            return idNew;
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
            var access = int.Parse(Session["Access"].ToString());
            if (access != 1)
            {
                groupControl2.Visible = false;
                btnAdd.Visible = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
            SetTxt(false);
            SetBtn(true);
            txtStaffID.Enabled = false;
            gcEmployees.DataSource = _staffBus.LoadStaff();
            LoadComboboxSection();
            LoadComboboxManId();
            rbNam.Checked = true;
            cbbEducation.SelectedItem = "Đại học";
            lkupManID.ItemIndex = 0;
            txtStaffID.Properties.MaxLength = 6;
            txtName.Properties.MaxLength = 30;
            txtCardID.Properties.MaxLength = 12;
            cbbEducation.MaxLength = 30;
            txtPhone.Properties.MaxLength = 11;
            txtMail.Properties.MaxLength = 20;
            txtAddress.Properties.MaxLength = 100;
            txtMail.SelectionStart = txtMail.Text.Length;
            dateBirth.Properties.MaxValue = DateTime.Today; 
        }

        public void AddStaff()
        {
            string section = cbbSection.SelectedValue.ToString();
            string post = cbbPost.SelectedValue.ToString();
            string manid = lkupManID.EditValue.ToString();
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
                manid, txtMail.Text, post, section);
        }
        public void EditStaff()
        {
            var section = cbbSection.SelectedValue.ToString();
            var post = cbbPost.SelectedValue.ToString();
            var manid = lkupManID.EditValue.ToString();
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
                manid, txtMail.Text, post, section);
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
            var idInsert = GetNewId();
            txtStaffID.Text = idInsert;
            gcEmployees.Enabled = false;
            CheckPosition();
            picImageStaff.Image = HRM.Properties.Resources.thumb_14400082930User;
            dxErrorProvider.ClearErrors();
        }

        void CheckPosition()
        {
            string section = cbbSection.SelectedValue.ToString();
            var postBus = new PostBus();
            if (postBus.GetMainId(section))
            {
                LoadComboboxPositionCheck();
            }
            else
            {
                LoadComboboxPosition();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_checkAdd == 1)
                {
                    if (string.IsNullOrEmpty(txtStaffID.Text))
                    {
                        dxErrorProvider.SetError(txtStaffID, "Mã nhân viên không được trống");
                    }
                    if (string.IsNullOrEmpty(txtName.Text))
                    {
                        dxErrorProvider.SetError(txtName, "Tên nhân viên không được trống");
                    }
        
                    if (!dxErrorProvider.HasErrors)
                    {
                        AddStaff();
                        ResettextBox();
                        SetTxt(false);
                        SetBtn(true);
                        gcEmployees.Enabled = true;
                        LoadComboboxManId();
                        _checkAdd = 0;
                    }
                }
                if (_checkAdd == 2)
                {
                    if (string.IsNullOrEmpty(txtName.Text))
                    {
                        dxErrorProvider.SetError(txtName, "Tên nhân viên không được trống");
                    }
                    if (!dxErrorProvider.HasErrors)
                    {
                        EditStaff();
                        ResettextBox();
                        SetTxt(false);
                        SetBtn(true);
                        gcEmployees.Enabled = true;
                        LoadComboboxManId();
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
            var id = gridView1.GetFocusedRowCellDisplayText(gcManagerID);
            var singleOrDefault = _aHrm.Staffs.SingleOrDefault(staff => staff.StaffID == id);
            if (singleOrDefault != null)
                lkupManID.Text = singleOrDefault.StaffName;
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


            kiemtraAnhNhanVien();

        }

        // Hàm kiểm tra ảnh Nhan Vien đã có chưa.
        public void kiemtraAnhNhanVien()
        {
            try
            {
                string idStaff = "";
                idStaff = txtStaffID.Text;
                var staff = (from sp in _aHrm.Staffs
                             where sp.StaffID == idStaff
                             select sp).SingleOrDefault();
                if(staff.Image != null)
                {
                    picImageStaff.Image = ByteArrayToImage(staff.Image.ToArray());
                    picImageStaff.SizeMode = PictureBoxSizeMode.StretchImage;
                } 
                else
                { 
                    picImageStaff.Image = HRM.Properties.Resources.thumb_14400082930User; 
                }
            }
            catch
            {
                //lblThongBao.Text = "Nhân viên vẫn chưa có hình ảnh. bạn hãy thêm ảnh cho nhân viên này.";
            }
        }

        //Hàm để chuyển byte[] => image
        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image image = Image.FromStream(ms);
            return image;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool checkStaffHasAcc = false;
                bool checkStatusOfAccountOnline = false;
                
                checkStaffHasAcc = _staffBus.checkIDStaffinAccount(txtStaffID.Text);
                checkStatusOfAccountOnline = _staffBus.checkStatusOfAccountOnline(txtStaffID.Text);
                //kiểm tra nhân viên này có tài khoản không
                if (checkStaffHasAcc)
                {
                    //kiểm tra tài khoản của nhân viên này có đang online không
                    if(checkStatusOfAccountOnline)
                    {
                        XtraMessageBox.Show($"Nhân viên: {txtName.Text} đang online. Không thể xóa.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var dialog = XtraMessageBox.Show($"Nhân viên: {txtName.Text} đã offline. Bạn có muốn xóa không ", "XÓA NHÂN VIÊN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialog == DialogResult.Yes)
                        {
                            _staffBus.DeleteAStaff(txtStaffID.Text);
                        }
                    }
                }
                else
                {
                    var dialog = XtraMessageBox.Show($"Bạn muốn xóa nhân viên {txtName.Text} này", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                    {
                        _staffBus.DeleteAStaff(txtStaffID.Text);
                    }
                } 
            }
            catch
            {
                // ignored
            }
            gcEmployees.DataSource = _staffBus.LoadStaff();
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
            if(txtStaffID.Text != "")
            {
                _checkAdd = 2;
                SetTxt(true);
                SetBtn(false);
                gcEmployees.Enabled = false;
                CheckPosition();
            }
            else
            {
                XtraMessageBox.Show("Chua chọn nhân viên nào để sửa", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

            bool checkStaffHasAcc = false;
            bool checkStatusOfAccountOnline = false;
            Staff newStaff = _staffBus.LoadStaffByIDStaff(txtStaffID.Text);
            checkStaffHasAcc = _staffBus.checkIDStaffinAccount(newStaff.StaffID);
            checkStatusOfAccountOnline = _staffBus.checkStatusOfAccountOnline(newStaff.StaffID); 
            if (checkStaffHasAcc)
            {
                lblTitleOnlineStatus.Visible = true; 
                if (checkStatusOfAccountOnline)
                {
                    lblTitleOnlineStatus.Text = "Đang online";
                }
                else
                {
                    lblTitleOnlineStatus.Text = "Đã offline";
                }
            }
            else
            {
                lblTitleOnlineStatus.Visible = false;
                lblTitleOnlineStatus.Text = "Nhân viên: " + newStaff.StaffName + " không có tài khoản.";
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
                dxErrorProvider.SetError(txtCardID, "Chứng minh thư trùng");
            }
            else
            {
                dxErrorProvider.SetError(txtCardID, null);
            }
        }

        private void dateBirth_Click(object sender, EventArgs e)
        {
            
        }

        private void dateBirth_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void cbbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckPosition();
        }
         
    }
}


