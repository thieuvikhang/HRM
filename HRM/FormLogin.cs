using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL;
using BUS;

namespace HRM
{
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        HRMModelDataContext hrm = new HRMModelDataContext();
        AccountBUS anAccountBus = new AccountBUS();
        Session aSession = new Session(); 
        Account anAccount = new Account();
        GroupAccess aGroupAccess = new GroupAccess();
        Access anAccess = new Access();
        Staff aStaff = new Staff();

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
            bool checkLogin = false;
            string userNameInput = "";
            string passwordInput = "";
            string groupAccessName = "";
            string staffName = "";
            
            //gán các giá trị text input vào biến
            userNameInput = txtAcc.Text;
            passwordInput = txtPass.Text;
            
            //gọi tới hàm checklogin vs 2 biến ở trên truyền vào để check
            checkLogin = anAccountBus.CheckLogin(userNameInput, passwordInput); 
            if (checkLogin == true)
            {
                //Đănh nhập thành công

                //gọi các đối tượng anAccount, aStaff, aGroupAccess
                anAccount = anAccountBus.GetInfoAccount(userNameInput, passwordInput);
                aStaff = anAccountBus.GetInfoStaff(anAccount.StaffID);
                aGroupAccess = anAccountBus.GetInfoGroupAccess(anAccount.GroupAccessID);
                 
                //Lấy tên của các bảng từ đối tượng trên
                groupAccessName = aGroupAccess.GroupAccessName;
                staffName = aStaff.StaffName;

                //Gán những thông tin cần thiết vào từng tên biến Session(aSession)
                aSession["userName"] = userNameInput;
                aSession["staffName"] = staffName;
                aSession["groupAccessName"] = groupAccessName; 

                //Gọi tới form newlogin
                //trong form newlogin mình có tạo 1 biến sesstion getsession
                //(form này Cường mới tạo thêm để demo về session) m.nTham khảo  
                frmlogin newfrmlogin = new frmlogin();
                //đưa tất cả biến aSession ở trên vào biến getsession ở form newfrmlogin
                //sau đó show form lên và xem kết quả
                newfrmlogin.getsession = aSession;
                newfrmlogin.ShowDialog();
                //FormMain frmain = new FormMain();
                //frmain.ShowDialog();

                //test thử sau khi đã gửi session bên form này qua form kia rồi
                //ta clear session ở form này
                //xem thử nó sẽ thế nào nha
                aSession.Clear();
                lblThongBao.Text = "";
            }
            else
            {
                lblThongBao.Text = "Nhập sai tên đăng nhập hoặc mật khẩu";
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        { 
            //gsf
        }
    }
}