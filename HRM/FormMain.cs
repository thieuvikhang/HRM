using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AddTab;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.Skins;
using System.Drawing;
using BUS;
using System.Threading;

namespace HRM
{
    public partial class FormMain : RibbonForm
    {
        #region Khai báo biến
        private readonly TabAdd _clsAddTab = new TabAdd();
        public Session SessionFrmmain = new Session();
        private readonly Session _sessionUc = new Session();
        private readonly AccessBus _accessBus = new AccessBus();
        private readonly AccountBus _accountBus = new AccountBus();
        private readonly List<BarButtonItem> _barButtonItem = new List<BarButtonItem>();
        private List<AccessBus.ListGroupAccess> _list; 
        #endregion

        #region Demo
        public Session SetSession(string form, List<AccessBus.ListGroupAccess> list)
        {
            foreach (var item in list)
            {
                if (!item.Form.Equals(form) || item.Edit != 1) continue;
                _sessionUc["Access"] = item.Edit;
                return _sessionUc;
            }
            _sessionUc["Access"] = 0;
            return _sessionUc;
        }
        #endregion

        #region From Main Load
        public UcContract uccontract = new UcContract();
        public FormMain()
        {
            InitializeComponent();
            
            _barButtonItem.AddRange(new[] { barEmployees, barSection, barPostion, barContract, barSI, barAbsent, barSalary, barAccess, barAccount });
            foreach (var bar in _barButtonItem)
            {
                //Ẩn các item
                bar.Enabled = false;
            }
            var skin = RibbonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default);
            var elem = skin[RibbonSkins.SkinFormApplicationButton];
            elem.Image.SetImage((Image)null, Color.Empty);
            elem.Size.MinSize = new Size(44, 42);
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            var groupAccesId = int.Parse(SessionFrmmain["sessionGroupAccessId"].ToString());
            _list = _accessBus.ListGroupAcces(groupAccesId);
            foreach (var item in _list)
            {
                foreach (var bar in _barButtonItem)
                {
                    if (!item.Form.Equals(bar.Name)) continue;
                    //Hiện item khi có quyền
                    bar.Enabled = true;
                }
            }
            xtraTabControl1.Hide();

            if(SessionFrmmain["staffID"].ToString() == "")
            {
                ribbonPageGroup6.Visible = false;
            }
        }
        #endregion

        #region Các hàm xử lý Tab: Thêm, Đóng, Focus
        private void AddTab(string tabName, UserControl uc)
        {
            // Kiểm tra khi Click vào Button Nếu đã có TAb này rồi thì không Add vào nữa
            // mà nó sẽ chuyển focus tới TAb vừa click này
            pictureEdit1.Hide();
            xtraTabControl1.Show();
            var t = 0;           
            for (var index = 0; index < xtraTabControl1.TabPages.Count; index++)
            {
                var tab = xtraTabControl1.TabPages[index];
                if (tab.Text != tabName) continue;
                xtraTabControl1.SelectedTabPage = tab;
                t = 1;
            }
            if (t != 1)
            {
                // Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                _clsAddTab.AddTab(xtraTabControl1, "", tabName, uc);
            }
            //Đóng màn hình Loading
            SplashScreenManager.CloseForm();
        }
        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            // Đóng tab
            var arg = e as ClosePageButtonEventArgs;
            (arg?.Page as XtraTabPage)?.Dispose();
            if(xtraTabControl1.TabPages.Count == 0)
            {
                xtraTabControl1.Hide();
                pictureEdit1.Show();
            }            
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
            AddTab("Nhân viên",new UcEmployees { Session = SetSession("barEmployees", _list) });
        }
        private void barAccess_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab Nhân viên
            AddTab("Phân quyền", new UcAccess { Session = SetSession("barAccess", _list) });
        }
        private void barButtonItem4_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab Nhân viên
            AddTab("Quản lý tài khoản", new UcAccounts { Session = SetSession("barAccount", _list) });
        }
        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {   //Mở màn hình Loading
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab Quản lý lương
            AddTab("Quản lý lương", new UcSalary { Session = SetSession("barSalary", _list) });
        }
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {   //Mở màn hình Loading
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab Phòng ban
            AddTab("Phòng ban", new UcSection { Session = SetSession("barSection", _list) });
        }
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {   //Mở màn hình Loading
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab Hợp đồng
            AddTab("Hợp đồng", new UcContract { Session = SetSession("barContract", _list) });
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {   //Mở màn hình Loading
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab BHXH
            AddTab("BHXH", new UcSocialInsurancecs { Session = SetSession("barSI", _list) });
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab chức vụ
            AddTab("Chức vụ", new UcPostions { Session = SetSession("barPostion", _list) });
        }
        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab chức vụ
            AddTab("Nghỉ phép", new UcAbsent {Session = SetSession("barAbsent", _list)});
        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab chức vụ
            AddTab("Thống kê", new UcAnalytics());
        }
        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab chức vụ
            AddTab("Báo cáo", new UcReportcs());
        }
        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab chức vụ
            AddTab("Thông tin nhân viên", new UcStaffInfo{ _aSession = SessionFrmmain });
        }
        #endregion

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            int idAcc = Int32.Parse(SessionFrmmain["idAcc"].ToString());
            var turnOnStatusOnline = _accountBus.EditAccountStatusOnline(idAcc, false); 
            foreach(Form frm in Application.OpenForms)
            {
                if(frm is FormLogin)
                {
                    frm.Show();
                }
            }
            this.Close();
        }
    }
}
