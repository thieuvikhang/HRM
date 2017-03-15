using AddTab;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using System;
using System.Windows.Forms;

namespace HRM
{
    public partial class FormMain : RibbonForm
    {
        readonly TabAdd _clsAddTab = new TabAdd();
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Các hàm xử lý Tab: Thêm, Đóng, Focus
        private void AddTab(string tabName, UserControl uc)
        {
            // Kiểm tra khi Click vào Button Nếu đã có TAb này rồi thì không Add vào nữa
            // mà nó sẽ chuyển focus tới TAb vừa click này
            int t = 0;
            foreach (XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == tabName)
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
                _clsAddTab.AddTab(xtraTabControl1, "", tabName, uc);
            }
            //Đóng màn hình Loading
            SplashScreenManager.CloseForm();
        }
        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {   // Đóng tab
            XtraTabControl tabControl = sender as XtraTabControl;
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            (arg.Page as XtraTabPage).Dispose();
        }
        private void xtraTabControl1_ControlAdded(object sender, ControlEventArgs e)
        {   // Khi add vào thì Focus tới ngay Tab vừa Add
            xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 1;
        }
        #endregion

        #region Các hành động mở Tab
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {   //Mở màn hình Loading
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab Nhân viên
            AddTab("Nhân viên",new UcEmployees());
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {   //Mở màn hình Loading
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab Quản lý lương
            AddTab("Quản lý lương", new UcSalary());
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {   //Mở màn hình Loading
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab Phòng ban
            AddTab("Phòng ban", new UcSection());
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {   //Mở màn hình Loading
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab Hợp đồng
            AddTab("Hợp đồng", new UcContract());
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {   //Mở màn hình Loading
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab BHXH
            AddTab("BHXH", new UcSocialInsurancecs());
        }
        
        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab loại hợp đồng
            AddTab("Loại hợp đồng", new ucContractTypes());
        }
        
        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab chức vụ
            AddTab("Chức vụ", new UcPostions());
        }
        
        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab chức vụ
            AddTab("Nghỉ phép", new ucAbsent());
        }
        #endregion
    }
}
