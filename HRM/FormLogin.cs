﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;

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

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //khai báo 1 số biến sẽ dùng


            //gán các giá trị text input vào biến
            var userNameInput = txtAcc.Text;
            var passwordInput = txtPass.Text;
            string passwordInputEncrypt = "";
            passwordInputEncrypt = newExtendBus.GetMd5(passwordInput.ToString());
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
                    XtraMessageBox.Show("Trạng thái online đã được bật.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Gán những thông tin cần thiết vào từng tên biến Session(aSession)
                    _aSession["userName"] = userNameInput;
                    _aSession["staffName"] = staffName;
                    _aSession["staffID"] = staffID;
                    
                    _aSession["groupAccessName"] = groupAccessName;
                    _aSession["ListGroupAccess"] = (from aHmDetailAccesses in hrm.DetailAccesses
                                                    from aHrmAccess in hrm.Accesses
                                                    where aHmDetailAccesses.GroupAccessID == _anAccount.GroupAccessID
                                                          && aHrmAccess.AccessID == aHmDetailAccesses.AccessID
                                                    select new
                                                    {
                                                        aHrmAccess.Form,
                                                        aHrmAccess.Edit
                                                    }).ToList();
                    
                    this.Hide();
                    FormMain frmain = new FormMain() { _aSessionfrmmain = _aSession };
                    frmain.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Trạng thái online ko bật được.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (txtPass.Text.Length <= 3)
            {
                lblThongBaoNhapMatKhau.ForeColor = Color.Red;
                lblThongBaoNhapMatKhau.Text = "Tên tài khoản quá ngắn.";
            }
            else if (txtPass.Text.Length >= 19)
            {
                lblThongBaoNhapMatKhau.ForeColor = Color.Red;
                lblThongBaoNhapMatKhau.Text = "Tên tài khoản dài quá 19 ký tự.";
                e.Handled = true;
            }
            else
            {
                lblThongBaoNhapMatKhau.ForeColor = Color.Blue;
                lblThongBaoNhapMatKhau.Text = "Độ dài hợp lý.";
            }
        }

        private void txtAcc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
            if(txtAcc.Text.Length <= 3)
            {
                lblThongBaoNhapTaiKhoan.ForeColor = Color.Red;
                lblThongBaoNhapTaiKhoan.Text = "Tên tài khoản quá ngắn.";
            }
            else if(txtAcc.Text.Length >= 19)
            {
                lblThongBaoNhapTaiKhoan.ForeColor = Color.Red;
                lblThongBaoNhapTaiKhoan.Text = "Tên tài khoản dài quá 19 ký tự.";
                e.Handled = true;
            }
            else
            {
                lblThongBaoNhapTaiKhoan.ForeColor = Color.Blue;
                lblThongBaoNhapTaiKhoan.Text = "Độ dài hợp lý.";
            }
        }

        private void txtAcc_TextChanged(object sender, EventArgs e)
        {
            if(txtAcc.Text.Length < 4 )
            {
                txtPass.Enabled = false;
            }
            else
            {
                txtPass.Enabled = true;
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.Text.Length < 4)
            {
                btnLogin.Enabled = false;
            }
            else
            {
                btnLogin.Enabled = true;
            }
        }

        private void FormLogin_Shown(object sender, EventArgs e)
        {
            //dfd
        }
    }
}