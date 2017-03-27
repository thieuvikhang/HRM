using System;
using System.Windows.Forms;
using AddTab;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;

namespace HRM
{
    public partial class UcReportcs : XtraUserControl
    {
        readonly TabAdd _clsAddTab = new TabAdd();
        private void AddTab(string tabName, UserControl uc)
        {
            // Kiểm tra khi Click vào Button Nếu đã có TAb này rồi thì không Add vào nữa
            // mà nó sẽ chuyển focus tới TAb vừa click này
            var t = 0;
            for (var index = 0; index < xtraTabControl3.TabPages.Count; index++)
            {
                var tab = xtraTabControl3.TabPages[index];
                if (tab.Text != tabName) continue;
                xtraTabControl3.SelectedTabPage = tab;
                t = 1;
            }
            if (t != 1)
            {
                // Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                _clsAddTab.AddTab(xtraTabControl3, "", tabName, uc);
            }
            //Đóng màn hình Loading
            SplashScreenManager.CloseForm();
        }
        private void xtraTabControl3_CloseButtonClick(object sender, EventArgs e)
        {
            // Đóng tab
            var arg = e as ClosePageButtonEventArgs;
            (arg?.Page as XtraTabPage)?.Dispose();
        }
        private void xtraTabControl3_ControlAdded(object sender, ControlEventArgs e)
        {   // Khi add vào thì Focus tới ngay Tab vừa Add
            xtraTabControl3.SelectedTabPageIndex = xtraTabControl3.TabPages.Count - 1;
        }
        public UcReportcs()
        {
            InitializeComponent();
        }
        private void navBarItem1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab chức vụ
            AddTab("Danh sách nhân viên", new UcRpNewEm());
        }

        private void navBarItem2_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab chức vụ
            AddTab("Danh sách sinh nhật", new UcRpBirthDay());
        }
    }
}
