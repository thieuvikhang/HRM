using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;
using System.Net.Mail;
using System.Text;

namespace HRM
{
    public partial class FormLogin : XtraForm
    {
        readonly HRMModelDataContext hrm = new HRMModelDataContext();
        readonly AccountBus _anAccountBus = new AccountBus();
        StaffBus _StaffBus = new StaffBus();
        public Session _aSession = new Session(); 
        Account _anAccount = new Account();
        GroupAccess _aGroupAccess = new GroupAccess();
        Access _anAccess = new Access();
        Staff _aStaff = new Staff();
        ExtendBus newExtendBus = new ExtendBus();
        

        public FormLogin()
        {
            InitializeComponent();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl3_MouseHover(object sender, EventArgs e)
        {
            labelForgot.ForeColor = Color.Black;
        }

        private void labelForgot_MouseLeave(object sender, EventArgs e)
        {
            labelForgot.ForeColor = Color.Gray;
        }

        private void labelForgot_Click(object sender, EventArgs e)
        {
            FormForgotPassword frmForhotPassword = new FormForgotPassword();
            frmForhotPassword.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //khai báo 1 số biến sẽ dùng


            //gán các giá trị text input vào biến
            var userNameInput = txtAcc.Text;
            var passwordInput = txtPass.Text;
            string passwordInputEncrypt = "";
            passwordInputEncrypt = newExtendBus.GetMd5(passwordInput.ToString());
            passwordInputEncrypt = passwordInputEncrypt.ToLower();
            //passwordInputEncrypt = passwordInputEncrypt.Substring(0, 26);
            var checkLogin = _anAccountBus.CheckLogin(userNameInput, passwordInputEncrypt); 
            //kiểm tra đăng nhập;
            if (checkLogin)
            {
                //Đănh nhập thành công

                //gọi các đối tượng anAccount, aStaff, aGroupAccess
                _anAccount = _anAccountBus.GetInfoAccount(userNameInput, passwordInputEncrypt);
                _aStaff = _anAccountBus.GetInfoStaff(_anAccount.StaffID);
                _aGroupAccess = _anAccountBus.GetInfoGroupAccess(_anAccount.GroupAccessID);
                 
                //Lấy tên của các bảng từ đối tượng trên
                var groupAccessName = _aGroupAccess.GroupAccessName;
                var groupAccessId = _aGroupAccess.GroupAccessID.ToString();
                var staffName = _aStaff.StaffName;
                var staffID = _aStaff.StaffID;
                var turnOnStatusOnline = _anAccountBus.EditAccountStatusOnline(staffID, true);
                // Bật trạng thái online của Account
                if (turnOnStatusOnline)
                {
                    //Gán những thông tin cần thiết vào từng tên biến Session(aSession)
                    _aSession["userName"] = userNameInput;
                    _aSession["staffName"] = staffName;
                    _aSession["staffID"] = staffID;
                    
                    _aSession["groupAccessName"] = groupAccessName;
                    _aSession["sessionGroupAccessId"] = groupAccessId;
                    
                    this.Hide();
                    FormMain frmain = new FormMain() { SessionFrmmain = _aSession };
                    frmain.ShowDialog();
                } 
            }
            else
            {
                XtraMessageBox.Show("Tài khoản hoặc mật khẩu không đúng.", "ThÔNG BÁO.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtAcc.Properties.MaxLength = 20;
            txtPass.Properties.MaxLength = 30;
            txtAcc.Enabled = true;
            txtPass.Enabled = false;
            btnLogin.Enabled = false;
            Localizer.Active = new showMessageBox("&hủy bỏ", "&Hủy", "&Chấp nhận", "&Không", "&Được", "&Thử lại", "&Đồng ý");
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space); 
            if(e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtAcc_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtAcc_TextChanged(object sender, EventArgs e)
        { 
            if (txtAcc.Text.Length <= 3)
            {
                lblThongBaoNhapTaiKhoan.ForeColor = Color.Red;
                lblThongBaoNhapTaiKhoan.Text = "Tên tài khoản quá ngắn.";
                txtPass.Enabled = false;
            }
            else if (txtAcc.Text.Length >= 20)
            {
                lblThongBaoNhapTaiKhoan.ForeColor = Color.Red;
                lblThongBaoNhapTaiKhoan.Text = "Tên tài khoản dài quá 20 ký tự."; 
            }
            else
            {
                lblThongBaoNhapTaiKhoan.ForeColor = Color.Blue;
                lblThongBaoNhapTaiKhoan.Text = "Độ dài hợp lý.";
                txtPass.Enabled = true;
            } 
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.Text.Length <= 3)
            {
                lblThongBaoNhapMatKhau.ForeColor = Color.Red;
                lblThongBaoNhapMatKhau.Text = "Tên tài khoản quá ngắn.";
                btnLogin.Enabled = false;
            }
            else if (txtPass.Text.Length >= 30)
            {
                lblThongBaoNhapMatKhau.ForeColor = Color.Red;
                lblThongBaoNhapMatKhau.Text = "Tên tài khoản dài quá 30 ký tự.";
            }
            else
            {
                lblThongBaoNhapMatKhau.ForeColor = Color.Blue;
                lblThongBaoNhapMatKhau.Text = "Độ dài hợp lý.";
                btnLogin.Enabled = true;
            } 
        }

        private void FormLogin_Shown(object sender, EventArgs e)
        {
            //dfd
        }

        private void txtAcc_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space); 
        } 

    }
}