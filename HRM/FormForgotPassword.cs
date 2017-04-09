using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;
using System.Net.Mail;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;

namespace HRM
{
    public partial class FormForgotPassword : Form
    {
        AccountBus newAccountBus = new AccountBus();
        Account newAccount = new Account();
        ExtendBus newExtendBus = new ExtendBus();

        public FormForgotPassword()
        {
            InitializeComponent();
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            if(newAccountBus.check1AccByAccNameAndIdStaff(txtPhoneStaff.Text, txtEmailStaff.Text, txtAccName.Text))
            {
                newAccount = newAccountBus.GetAccByAccNameAndIdStaff(txtPhoneStaff.Text, txtEmailStaff.Text, txtAccName.Text);

                string newpass = ""; 
                newpass = newAccount.Password.Substring(0, 8);
                string newPassEnc = "";
                newPassEnc = newExtendBus.GetMd5(newpass.ToString());
                newPassEnc = newPassEnc.ToLower();

                bool checkGetPass = false;
                checkGetPass = newAccountBus.EditPassword(newAccount.AccID, newPassEnc);
                if (checkGetPass)
                {
                    SendMail(newpass);
                    XtraMessageBox.Show($@"Mật khẩu mới đã được gửi vào mail {txtEmailStaff.Text}. Bạn bạn nên đổi mật khẩu sau khi đã đăng nhập.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblthongbao.Text = "";
                }
                else
                {
                    lblthongbao.Text = "Nhập sai thông tin.";
                    lblThongBao2.Text = "";
                }
            } 
            else
            {
                lblthongbao.Text = "Không tìm thấy Acc.";
            }
        }

        public void SendMail(string newPass)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("badao1269@gmail.com", "cuong123");

            MailMessage mm = new MailMessage("badao1269@gmail.com", "dangduongcuong@gmail.com", "Forgot pass", "Mật khẩu mới của bạn là:" + newPass);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }

        private void FormForgotPassword_Load(object sender, EventArgs e)
        {
            Localizer.Active = new showMessageBox("&hủy bỏ", "&Hủy", "&Chấp nhận", "&Không", "&Được", "&Thử lại", "&Đồng ý");
        }
    }
}
