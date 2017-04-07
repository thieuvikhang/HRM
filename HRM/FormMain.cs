﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AddTab;
using DAL;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.Skins;
using System.Drawing;
using BUS;

namespace HRM
{
    public partial class FormMain : RibbonForm
    {
        #region Khai báo biến
        private readonly TabAdd _clsAddTab = new TabAdd();
        public static HRMModelDataContext Hrm = new HRMModelDataContext();
        public Session Sessionfrmmain = new Session();
        private readonly AccessBus _accessBus = new AccessBus();
        FormLogin frmlogin = new FormLogin();
        public List<AccessBus.ListGroupAccess> List;
        private readonly List<BarButtonItem> _barButtonItem = new List<BarButtonItem>();
        #endregion

        #region From Main Load
        public FormMain()
        {
            InitializeComponent();
            _barButtonItem.AddRange(new[] { barEmployees, barSection, barPostion, barContract, barSI, barAbsent, barSalary, barAccess });
            foreach (var bar in _barButtonItem)
            {
                //Ẩn các item
                bar.Enabled = false;
            }
            Skin skin = RibbonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default);
            SkinElement elem = skin[RibbonSkins.SkinFormApplicationButton];
            elem.Image.SetImage((Image)null, Color.Empty);
            elem.Size.MinSize = new Size(44, 42);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //label1.Text = _aSessionfrmmain["staffName"].ToString();
            var groupAccesId = int.Parse(Sessionfrmmain["sessionGroupAccessId"].ToString());
            List = _accessBus.ListGroupAcces(groupAccesId);
            foreach (var item in List)
            {
                foreach (var bar in _barButtonItem)
                {
                    if (!item.Form.Equals(bar.Name)) continue;
                    //Hiện item khi có quyền
                    bar.Enabled = true;
                }
            }
        }
        #endregion

        #region Các hàm xử lý Tab: Thêm, Đóng, Focus
        private void AddTab(string tabName, UserControl uc)
        {
            // Kiểm tra khi Click vào Button Nếu đã có TAb này rồi thì không Add vào nữa
            // mà nó sẽ chuyển focus tới TAb vừa click này
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
        private void barAccess_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab Nhân viên
            AddTab("Phân quyền", new UcAccess());
        }
        private void barButtonItem4_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab Nhân viên
            AddTab("Quản lý tài khoản", new UcAccounts());
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
            AddTab("Nghỉ phép", new UcAbsent());
        }
        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            //Mở Tab chức vụ
            AddTab("Thống kê nhân viên", new UcDashEmployees());
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
            AddTab("Thông tin nhân viên", new UcStaffInfo{ _aSession = Sessionfrmmain });
        }
        #endregion

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //show form login
            this.Close();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit()
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
