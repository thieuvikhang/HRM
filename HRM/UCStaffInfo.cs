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

namespace HRM
{
    public partial class UcStaffInfo : UserControl
    {
        private readonly HRMModelDataContext _hrm = new HRMModelDataContext();
        public Session ASession = new Session();
        private readonly ExtendBus _newExtend = new ExtendBus();
        private readonly AccountBus _newAccountBus = new AccountBus();
        public bool CheckChooseChangePass;

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
            string idStaff = ASession["staffID"].ToString();
            lblShowIDStaff.Text = idStaff;

            panChangePassword.Enabled = false;
        }

        private void btnSaveNewPasswoed_Click(object sender, EventArgs e)
        {
            //khai bao cac bien can dùng
            string passwordInput = txtAgainPassword.Text;
            string passwordEncrypt = _newExtend.GetMd5(passwordInput);
            bool checkChangepass = false;
            string idStaff = ASession["staffID"].ToString();
            int accountID = 0;
            Account AccountOnline = _hrm.Accounts.SingleOrDefault(ac => ac.StaffID == idStaff);

            accountID = AccountOnline.AccID;
            passwordEncrypt = passwordEncrypt.Substring(0, 26);

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
            lblPassEncrypt.Text = passwordEncrypt;
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
            oldPasswordEncrypt = oldPasswordEncrypt.Substring(0, 26);
            string newPassword = txtNewpassword.EditValue.ToString();
            string againPassword = txtAgainPassword.EditValue.ToString();
            string idStaff = ASession["staffID"].ToString();
            Account acc = new Account();
            acc = _newAccountBus.getpass(idStaff);
            string passworddAccout = acc.Password;
            passworddAccout = passworddAccout.Trim();
            lblShowPassStaff.Text = passworddAccout;

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
    }
}
