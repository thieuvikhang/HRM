using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddTab;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;

namespace HRM
{
    public partial class UcAnalytics : DevExpress.XtraEditors.XtraUserControl
    {
        readonly TabAdd _clsAddTab = new TabAdd();
        public UcAnalytics()
        {
            InitializeComponent();
        }
        private void AddTab(string tabName, UserControl uc)
        {
            // Kiểm tra khi Click vào Button Nếu đã có TAb này rồi thì không Add vào nữa
            // mà nó sẽ chuyển focus tới TAb vừa click này
            var t = 0;
            for (var index = 0; index < xtraTabControl2.TabPages.Count; index++)
            {
                var tab = xtraTabControl2.TabPages[index];
                if (tab.Text != tabName) continue;
                xtraTabControl2.SelectedTabPage = tab;
                t = 1;
            }
            if (t != 1)
            {
                // Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                _clsAddTab.AddTab(xtraTabControl2, "", tabName, uc);
            }
            //Đóng màn hình Loading
            SplashScreenManager.CloseForm();
        }
        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            // Đóng tab
            var arg = e as ClosePageButtonEventArgs;
            (arg?.Page as XtraTabPage)?.Dispose();
        }
        private void xtraTabControl1_ControlAdded(object sender, ControlEventArgs e)
        {   // Khi add vào thì Focus tới ngay Tab vừa Add
            xtraTabControl2.SelectedTabPageIndex = xtraTabControl2.TabPages.Count - 1;
        }
        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab chức vụ
            AddTab("Thống kê theo độ tuổi", new AgeChart());
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab chức vụ
            AddTab("Thống kê nhân viên", new UcDashEmployees());
        }
    }
}
