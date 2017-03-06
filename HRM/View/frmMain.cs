using AddTab;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using HRM.VIEW.Splash_Screen;
using System;
using System.Windows.Forms;

namespace HRM
{
    public partial class frmMain : RibbonForm
    {
        TabAdd clsAddTab = new TabAdd();
        public frmMain()
        {
            InitializeComponent();
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Hàm thêm Tab
        private void AddTab(String nameTab, XtraUserControl userControl)
        {
            // Kiểm tra Click. Nếu đã có TAb này rồi thì không Add vào nữa
            // mà nó sẽ chuyển focus tới TAb này
            int t = 0;
            foreach (XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == nameTab)
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {   // Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                clsAddTab.AddTab(xtraTabControl1, "", nameTab, userControl);
            }
            //Đóng From Loading
            SplashScreenManager.CloseForm(false);
        }
        #endregion


        #region Xử lý nút đóng Tab
        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {   // dong tab
            XtraTabControl tabControl = sender as XtraTabControl;
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            (arg.Page as XtraTabPage).Dispose();
        }
        #endregion


        #region Xử lý nút mử lại Tab đã được mở
        private void xtraTabControl1_ControlAdded(object sender, ControlEventArgs e)
        {   // Khi add vào thì Focus tới ngay Tab vừa Add
            xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 1;
        }
        #endregion


        #region Xử lý mở các Tab
        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {   //From chờ khởi động
            SplashScreenManager.ShowForm(this, typeof(WaitFormLoading), true, true, false);
            //Add Tab Quản lý lương
            AddTab("Quản lý lương", new ucSalary());
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {   //From chờ khởi động
            SplashScreenManager.ShowForm(this, typeof(WaitFormLoading), true, true, false);
            //Add Tab Phòng ban
            AddTab("Phòng ban", new ucSection());
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {   //From chờ khởi động
            SplashScreenManager.ShowForm(this, typeof(WaitFormLoading), true, true, false);
            //Add Tab nhân viên
            AddTab("Nhân viên", new ucEmployees());
        }
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
