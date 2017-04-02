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
    public partial class UCStaffInfo : UserControl
    {

        HRMModelDataContext _HRM = new HRMModelDataContext();
        public Session _aSession = new Session();
        ExtendBus newExtend = new ExtendBus();
        bool checkChooseChangePass = false;

        public UCStaffInfo()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string chon = btnChangePassword.Text;
            switch (chon)
            {
                case "Đổi mật khẩu":
                    {
                        checkChooseChangePass = true;
                        panChangePassword.Enabled = true;
                        txtOldPassword.Text = "";
                        txtNewpassword.Text = "";
                        txtAgainPassword.Text = "";
                        btnCheckError.Enabled = false;
                        btnSaveNewPasswoed.Enabled = false;
                        btnChangePassword.Text = "Hủy đổi mật khẩu";
                        btnChangePassword.ForeColor = Color.Red;
                        lblTrangThai.Text = "Đang điền thông tin đổi mật khẩu.";
                        break;
                    }
                case "Hủy đổi mật khẩu":
                {
                        checkChooseChangePass = false;
                        panChangePassword.Enabled = false;
                        btnChangePassword.Text = "Đổi mật khẩu";
                        btnChangePassword.ForeColor = Color.Black;
                        lblTrangThai.Text = "Đã hủy đỏi mật khẩu.";
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
        }

        private void btnSaveNewPasswoed_Click(object sender, EventArgs e)
        {
            lblTrangThai.Text = "bạn vừa đổi mật khẩu cho nhân viên....";
        }

        private void btnChangePassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCheckError_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewpassword.Text;
            string againPassword = txtAgainPassword.Text;
            string idStaff = _aSession["staffID"].ToString();
            Account AccountOnline = _HRM.Accounts.SingleOrDefault(ac => ac.StaffID == idStaff);
            string passworddAccout = AccountOnline.Password;


            if (oldPassword != passworddAccout)
            {
                lblNoteOldPassword.ForeColor = Color.Red;
                lblNoteOldPassword.Text = "Mặt khẩu hiện tại ko đúng";
            }
            else { 
                lblNoteOldPassword.ForeColor = Color.Yellow;
                lblNoteOldPassword.Text = "Hợp lý";
                if(newPassword != againPassword)
                {
                    lblNoteAdainPassword.ForeColor = Color.Red;
                    lblNoteAdainPassword.Text = "Mật khẩu xác nhận ko khớp vs mật khẩu mới.";
                }
                else
                {

                }
            }    
        }

        private void txtOldPassword_TextChanged(object sender, EventArgs e)
        {
            if(txtOldPassword.Text == "")
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
           if(txtNewpassword.Text == "")
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
            if(txtAgainPassword.Text == "")
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
    }
}
