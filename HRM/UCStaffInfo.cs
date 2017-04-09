using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DAL;
using BUS;
using System.IO;
using DevExpress.XtraEditors;
using System.Data.Linq;

namespace HRM
{
    public partial class UcStaffInfo : UserControl
    {
        private readonly HRMModelDataContext _hrm = new HRMModelDataContext();
        public Session _aSession = new Session();
        private readonly ExtendBus _newExtend = new ExtendBus();
        private readonly AccountBus _newAccountBus = new AccountBus();
        StaffBus newStaffBus = new StaffBus();
        public bool CheckChooseChangePass;
        string fileNameimage = "";

        public UcStaffInfo()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string chon = btnChangePassword.Text;
            lblThongBao.Text = "";
            switch (chon)
            {
                case "Đổi mật khẩu":
                { 
                    btnChangePassword.Text = "Hủy đổi mật khẩu"; 
                    break;
                }
                case "Hủy đổi mật khẩu":
                {
                    setTextbox(); 
                    btnChangePassword.Text = "Đổi mật khẩu"; 
                    break;
                }
                default:
                {
                    break;
                }
            }
        }

        private void UCStaffInfo_Load(object sender, EventArgs e)
        {
            string idStaff = _aSession["staffID"].ToString();
            lblShowIDStaff.Text = idStaff;

            panChangePassword.Enabled = false;

            string genderStaff = "";
            Staff astaff = newStaffBus.LoadStaffByIDStaff(idStaff);
            Staff astaffManager = newStaffBus.LoadStaffByIDStaff(astaff.ManagerID);
            Position aPosition = _hrm.Positions.SingleOrDefault(pst => pst.PostID == astaff.PostID);
            Section aSection = _hrm.Sections.SingleOrDefault(st => st.SectionID == astaff.SectionID);

            if (astaff.Gender == true) {
                genderStaff = "Nam";
            }
            else {
                genderStaff = "Nữ";
            }

            lblStaffGender.Text = genderStaff;
            lblStaffName.Text = astaff.StaffName;
            lblStaffBirth.Text = String.Format("{0:dd/mm/yy}", astaff.BirthDay);
            lblStaffAddress.Text = astaff.Address;
            lblStaffPhone.Text = astaff.Phone;
            lblStaffEmail.Text = astaff.Email;
            lblStaffCard.Text = astaff.CardID;
            lblStaffEducation.Text = astaff.Education;
            lblDateStard.Text = String.Format("{0:dd/mm/yy}", astaff.StartDate);
            lblManager.Text = astaffManager.StaffName;
            lblPosition.Text = aPosition.PostName;
            lblSection.Text = aSection.SectionName;
            //Load hinhAnh:
            kiemtraAnhNhanVien();
            btnSaveImageStaffChange.Visible = false;
            btnCancelChangeImage.Visible = false;
        }

        private void btnSaveNewPasswoed_Click(object sender, EventArgs e)
        {
            //khai bao cac bien can dùng
            string passwordInput = txtAgainPassword.Text;
            string passwordEncrypt = _newExtend.GetMd5(passwordInput);
            bool checkChangepass = false;
            string idStaff = _aSession["staffID"].ToString();
            int accountID = 0;
            Account AccountOnline = _hrm.Accounts.SingleOrDefault(ac => ac.StaffID == idStaff);

            accountID = AccountOnline.AccID;
            //passwordEncrypt = passwordEncrypt.Substring(0, 26);

            checkChangepass = _newAccountBus.EditPassword(accountID, passwordEncrypt);

            if (checkChangepass == true)
            { 
                MessageBox.Show("Bạn đã đổi mật khẩu thành công.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblTrangThai.Text = "Bạn vừa đổi mật khẩu cho nhân viên....";
                setTextbox();
                btnChangePassword.Text = "Đổi mật khẩu"; 
            }
            else
            {
                lblThongBao.Text = "Đổi mật khẩu thất bại.";
            }
        }

        private void btnChangePassword_TextChanged(object sender, EventArgs e)
        {
            string chon = btnChangePassword.Text;
            lblThongBao.Text = "";
            if (chon == "Đổi mật khẩu") {
                CheckChooseChangePass = false;
                panChangePassword.Enabled = false;
                btnChangePassword.ForeColor = Color.Black;
                lblTrangThai.Text = "Đã hủy đỏi mật khẩu.";
            } 
            if(chon == "Hủy đổi mật khẩu")
            { 
                CheckChooseChangePass = true;
                panChangePassword.Enabled = true;
                setTextbox();
                btnCheckError.Enabled = false;
                btnSaveNewPassword.Enabled = false;
                btnChangePassword.ForeColor = Color.Red;
                lblTrangThai.Text = "Đang điền thông tin đổi mật khẩu.";
            }    
        }

        private void btnCheckError_Click(object sender, EventArgs e)
        {
            CheckInputError();

            if (lblNoteAdainPassword.ForeColor == Color.Orange && lblNoteOldPassword.ForeColor == Color.Orange && lblNoteNewPassword.ForeColor == Color.Orange)
            {
                MessageBox.Show("Đã không còn lỗi nữa. Click vào \"Xác nhận đổi\" để hoàn tất đổi mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSaveNewPassword.Enabled = true;
            }
            else
            {
                btnSaveNewPassword.Enabled = false;
                lblThongBao.Text = "Vẫn còn lỗi không thể đổi mật khẩu.";
            }
        }

        private void txtOldPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtOldPassword.Text == "")
            {
                txtNewpassword.Text = "";
                txtNewpassword.Enabled = false;
            }
            else
            {
                txtNewpassword.Enabled = true;
            }
        }

        private void txtNewpassword_TextChanged(object sender, EventArgs e)
        {
            if (txtNewpassword.Text == "")
            {
                txtAgainPassword.Text = "";
                txtAgainPassword.Enabled = false;
            }
            else
            {
                txtAgainPassword.Enabled = true;
            }
        }

        private void txtAgainPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtAgainPassword.Text == "")
            {
                lblThongBao.Text = "Chưa điền đủ thông tn không thể kiểm tra để dổi mật khẩu.";
                btnCheckError.Enabled = false;
            }
            else
            {
                btnCheckError.Enabled = true;
                lblThongBao.Text = "Bạn hãy kiểm tra trước khi lưu mật khẩu mới.";
            }
        }

        void setTextbox()
        {
            txtOldPassword.Text = "";
            txtNewpassword.Text = "";
            txtAgainPassword.Text = "";
            lblNoteOldPassword.Text = "";
            lblNoteNewPassword.Text = "";
            lblNoteAdainPassword.Text = "";
            lblThongBao.Text = "";
        }

        void CheckInputError()
        {
            string oldPassword = txtOldPassword.EditValue.ToString();
            string oldPasswordEncrypt = _newExtend.GetMd5(oldPassword);
            //oldPasswordEncrypt = oldPasswordEncrypt.Substring(0, 26);
            string newPassword = txtNewpassword.EditValue.ToString();
            string againPassword = txtAgainPassword.EditValue.ToString();
            string idStaff = _aSession["staffID"].ToString();
            Account acc = new Account();
            acc = _newAccountBus.GetPass(idStaff);
            string passworddAccout = acc.Password;
            passworddAccout = passworddAccout.Trim(); 

            if (String.Compare(oldPasswordEncrypt, passworddAccout) != 0)
            {
                lblNoteOldPassword.ForeColor = Color.Red;
                lblNoteOldPassword.Text = "Mặt khẩu hiện tại ko đúng";
            }
            else
            {
                lblNoteOldPassword.ForeColor = Color.Orange;
                lblNoteOldPassword.Text = "Hợp lý";
                if (String.Compare(newPassword, oldPassword) == 0)
                {
                    lblNoteNewPassword.ForeColor = Color.Red;
                    lblNoteNewPassword.Text = "Mật khẩu mới trùng với mật khẩu cũ.";
                }
                else
                {
                    lblNoteNewPassword.ForeColor = Color.Orange;
                    lblNoteNewPassword.Text = "Hợp lý.";
                    if (String.Compare(newPassword, againPassword) != 0)
                    {
                        lblNoteAdainPassword.ForeColor = Color.Red;
                        lblNoteAdainPassword.Text = "Mật khẩu xác nhận ko khớp vs mật khẩu mới.";
                    }
                    else
                    {
                        lblNoteAdainPassword.ForeColor = Color.Orange;
                        lblNoteAdainPassword.Text = "Hợp lý.";
                    }
                }
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        // Hàm kiểm tra ảnh Nhan Vien đã có chưa.
        public void kiemtraAnhNhanVien()
        {
            try
            {
                string idStaff = _aSession["staffID"].ToString();
                var staff = (from sp in _hrm.Staffs
                               where sp.StaffID == idStaff
                               select sp).SingleOrDefault();
                picImageChange.Image = ByteArrayToImage(staff.Image.ToArray());
                picImageChange.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
                lblThongBao.Text =  "Nhân viên vẫn chưa có hình ảnh. bạn hãy thêm ảnh cho nhân viên này.";
            }
        }

        //Hàm để chuyển byte[] => image
        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image image = Image.FromStream(ms);
            return image;
        }

        // Hàm dùng để chuyển image => byte[]
        private byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        // Hàm mở HÌnh ảnh
        private void moHinhAnh()
        {
            OpenFileDialog openfile = new OpenFileDialog() { Filter = "JPEG|*.jpg;*.png", ValidateNames = true, Multiselect = false };
            try
            {
                if (openfile.ShowDialog() == DialogResult.OK)
                {
                    fileNameimage = openfile.FileName;
                    //lbFilename.Text = filename;
                    picImageChange.Image = Image.FromFile(fileNameimage);
                    Image image = Image.FromFile(fileNameimage);
                    if (image.Width < picImageChange.Width && image.Height < picImageChange.Height)
                    {
                        picImageChange.SizeMode = PictureBoxSizeMode.Normal;
                    }
                    else
                    {
                        picImageChange.SizeMode = PictureBoxSizeMode.Zoom;
                    }

                    picImageChange.SizeMode = PictureBoxSizeMode.StretchImage;
                    btnSaveImageStaffChange.Visible = true;
                    btnCancelChangeImage.Visible = true;
                }
            }
            // File chọn ko phải là file ảnh (jpg, ....)
            catch
            {
                XtraMessageBox.Show(string.Format("File : {0} Không phải là file hình ảnh, hãy chọn file khác(.ipg)", fileNameimage), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Hàm sửa sản phẩm
        public void suaSanPham()
        { 

            DialogResult suaAnh = XtraMessageBox.Show("Bạn vẫn muốn giữ ảnh này lại", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (suaAnh == DialogResult.Yes)
            {
                string idStaff = _aSession["staffID"].ToString();
                //Chuyển image thành binary thông qua byte[]
                byte[] file_Byte = ImageToByteArray(picImageChange.Image);
                Binary file_Binary = new Binary(file_Byte);

                if(newStaffBus.EditImageStaff(idStaff, file_Binary))
                {
                    lblTrangThai.Text = "Bạn đã đổi ảnh thành công.";
                }
                else
                {
                    lblTrangThai.Text = "Bạn đã đổi ảnh thất bại.";
                }
            }
            else
            {
                lblTrangThai.Text = "Bạn đã không đổi ảnh.";
            }
        }

        private void btnChooseImageStaff_Click(object sender, EventArgs e)
        {
            moHinhAnh(); 
        }

        private void btnSaveImageStaffChange_Click(object sender, EventArgs e)
        {
            try
            {
                suaSanPham();
                btnSaveImageStaffChange.Visible = false;
                btnCancelChangeImage.Visible = false;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Chưa có hình ảnh.");
            }
        }

        private void btnCancelChangeImage_Click(object sender, EventArgs e)
        {
            kiemtraAnhNhanVien();
            btnSaveImageStaffChange.Visible = false;
            btnCancelChangeImage.Visible = false;
        }

        private void picImageChange_Click(object sender, EventArgs e)
        {
            moHinhAnh();
        }

        private void picImageChange_MouseHover(object sender, EventArgs e)
        {
            lblTrangThai.Text = "Click vào hỉnh ảnh để thay đổi ảnh đại diện.";
        }
    }
}
