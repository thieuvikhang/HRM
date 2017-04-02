using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.Xpo;

namespace HRM
{
    public partial class FormLogin : XtraForm
    {
        readonly HRMModelDataContext hrm = new HRMModelDataContext();
        readonly AccountBus _anAccountBus = new AccountBus();
        readonly Session _aSession = new Session(); 
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
            passwordInputEncrypt = passwordInputEncrypt.Substring(0, 26);
            //gọi tới hàm checklogin vs 2 biến ở trên truyền vào để check
            var checkLogin = _anAccountBus.CheckLogin(userNameInput, passwordInputEncrypt); 
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

                //Gán những thông tin cần thiết vào từng tên biến Session(aSession)
                _aSession["userName"] = userNameInput;
                _aSession["staffName"] = staffName;
                _aSession["staffID"] = staffID;
                _aSession["groupAccessName"] = groupAccessName;
                _aSession["ListGroupAccess"] = (from aHmDetailAccesses in hrm.DetailAccesses
                                                from aHrmAccess in hrm.Accesses
                                                where aHmDetailAccesses.GroupAccessID == _anAccount.GroupAccessID
                                                      && aHrmAccess.AccessID == aHmDetailAccesses.AccessD
                                                select new
                                                {
                                                    aHrmAccess.Form,
                                                    aHrmAccess.Edit
                                                }).ToList();
                //Gọi tới form newlogin
                //trong form newlogin mình có tạo 1 biến sesstion getsession
                //(form này Cường mới tạo thêm để demo về session) m.nTham khảo  
                //var newfrmlogin = new demoSession {getsession = _aSession};
                //đưa tất cả biến aSession ở trên vào biến getsession ở form newfrmlogin
                //sau đó show form lên và xem kết quả
                //newfrmlogin.ShowDialog();
                FormMain frmain = new FormMain { _aSession = _aSession };
                frmain.ShowDialog();

                //test thử sau khi đã gửi session bên form này qua form kia rồi
                //ta clear session ở form này
                //xem thử nó sẽ thế nào nha
                _aSession.Clear();
                lblThongBao.Text = "";
            }
            else
            {
                lblThongBao.Text = @"Nhập sai tên đăng nhập hoặc mật khẩu";
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        { 
            //gsf
        }
    }
}