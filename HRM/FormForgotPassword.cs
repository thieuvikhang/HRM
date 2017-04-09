using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUS;
using DAL;
using System.Net.Mail;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;

namespace HRM
{
    public partial class FormForgotPassword : DevExpress.XtraEditors.XtraForm
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
            if(newAccountBus.Check1AccByAccNameAndIdStaff(txtPhoneStaff.Text, txtEmailStaff.Text, txtAccName.Text))
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
            } 
            else
            {
                XtraMessageBox.Show("Nhập sai thông tin. Vui lòng nhập lại.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtAccName.Properties.MaxLength = 20;
            txtEmailStaff.Properties.MaxLength = 50;
            txtPhoneStaff.Properties.MaxLength = 11;
            txtEmailStaff.Enabled = false;
            txtPhoneStaff.Enabled = false;
            btnForgotPassword.Enabled = false;
            lblthongbao.Text = "Vui lòng điền đầy đủ thông tin.";
        }

        private void txtAccName_TextChanged(object sender, EventArgs e)
        {
            if(txtAccName.Text.Length <= 3)
            {
                lblNoteAccName.ForeColor = Color.Red;
                lblNoteAccName.Text = "Độ dài quá ngắn.";
                txtPhoneStaff.Enabled = false;
            }
            else if(txtAccName.Text.Length >= 20)
            {
                lblNoteAccName.ForeColor = Color.Red;
                lblNoteAccName.Text = "Tên tài khoản dài quá 20 ký tự.";
            }
            else
            {
                lblNoteAccName.ForeColor = Color.Blue;
                lblNoteAccName.Text = "độ dài hợp lý.";
                txtPhoneStaff.Enabled = true;
            }
        }

        private void txtPhoneStaff_TextChanged(object sender, EventArgs e)
        {
            if (txtPhoneStaff.Text.Length <= 3)
            {
                lblNoteStaffPhone.ForeColor = Color.Red;
                lblNoteStaffPhone.Text = "độ dài quá ngắn.";
                txtEmailStaff.Enabled = false;
            }
            else if (txtPhoneStaff.Text.Length >= 11)
            {
                lblNoteStaffPhone.ForeColor = Color.Red;
                lblNoteStaffPhone.Text = "Số điện thoại dài quá 11 ký tự.";
            }
            else
            {
                lblNoteStaffPhone.ForeColor = Color.Blue;
                lblNoteStaffPhone.Text = "độ dài hợp lý.";
                txtEmailStaff.Enabled = true;
            }
        }

        public const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

  

        private void txtEmailStaff_TextChanged(object sender, EventArgs e)
        {
            if (txtEmailStaff.Text.Length <= 3)
            {
                lblNoteStaffEmail.ForeColor = Color.Red;
                lblNoteStaffEmail.Text = "độ dài quá ngắn.";
                btnForgotPassword.Enabled = false;
            }
            else if (!Regex.IsMatch(txtEmailStaff.Text, MatchEmailPattern))
            {
                lblNoteStaffEmail.ForeColor = Color.Red;
                lblNoteStaffEmail.Text = "Email không đúng định dạng.";
                btnForgotPassword.Enabled = false;
            }
            else if (txtEmailStaff.Text.Length >= 50)
            {
                lblNoteStaffEmail.ForeColor = Color.Red;
                lblNoteStaffEmail.Text = "Email dài quá 50 ký tự.";
            }
            else
            {
                lblNoteStaffEmail.ForeColor = Color.Blue;
                lblNoteStaffEmail.Text = "độ dài hợp lý.";
                btnForgotPassword.Enabled = true;
            }
            txtEmailStaff.Text = ConvertToUnsign.convertToUnSign2(txtEmailStaff.Text);
        }



        private void txtAccName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space); 
        }

        private void txtPhoneStaff_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                lblNoteStaffPhone.ForeColor = Color.Red;
                lblNoteStaffPhone.Text = "bạn không thể nhập ký tự vào ô này.";
            }
        }


        class ConvertToUnsign
        {

            // Way 2
            public static string convertToUnSign2(string s)
            {
                string stFormD = s.Normalize(NormalizationForm.FormD);
                StringBuilder sb = new StringBuilder();
                for (int ich = 0; ich < stFormD.Length; ich++)
                {
                    System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                    if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                    {
                        sb.Append(stFormD[ich]);
                    }
                }
                sb = sb.Replace('Đ', 'D');
                sb = sb.Replace('đ', 'd');
                return (sb.ToString().Normalize(NormalizationForm.FormD));
            }

            // Way 3
            public static string convertToUnSign3(string s)
            {
                Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
                string temp = s.Normalize(NormalizationForm.FormD);
                return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            }

        }

        private void txtEmailStaff_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
    }
}
