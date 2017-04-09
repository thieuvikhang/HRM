using System.ComponentModel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraTab;

namespace HRM
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barEmployees = new DevExpress.XtraBars.BarButtonItem();
            this.barSection = new DevExpress.XtraBars.BarButtonItem();
            this.barContract = new DevExpress.XtraBars.BarButtonItem();
            this.barSI = new DevExpress.XtraBars.BarButtonItem();
            this.barSalary = new DevExpress.XtraBars.BarButtonItem();
            this.barAccess = new DevExpress.XtraBars.BarButtonItem();
            this.barPostion = new DevExpress.XtraBars.BarButtonItem();
            this.barAbsent = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.ribbonGalleryBarItem1 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.barAccount = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbonControl1.ApplicationIcon")));
            this.ribbonControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItem1,
            this.barEmployees,
            this.barSection,
            this.barContract,
            this.barSI,
            this.barSalary,
            this.barAccess,
            this.barPostion,
            this.barAbsent,
            this.barButtonItem13,
            this.barButtonItem2,
            this.barButtonItem3,
            this.skinRibbonGalleryBarItem1,
            this.ribbonGalleryBarItem1,
            this.barAccount});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 21;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(762, 143);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Đăng xuất";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barEmployees
            // 
            this.barEmployees.Caption = "Nhân viên";
            this.barEmployees.Glyph = ((System.Drawing.Image)(resources.GetObject("barEmployees.Glyph")));
            this.barEmployees.Id = 2;
            this.barEmployees.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barEmployees.LargeGlyph")));
            this.barEmployees.Name = "barEmployees";
            this.barEmployees.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barSection
            // 
            this.barSection.Caption = "Phòng ban";
            this.barSection.Id = 3;
            this.barSection.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barSection.LargeGlyph")));
            this.barSection.Name = "barSection";
            this.barSection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barContract
            // 
            this.barContract.Caption = "Hợp đồng";
            this.barContract.Id = 4;
            this.barContract.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barContract.LargeGlyph")));
            this.barContract.Name = "barContract";
            this.barContract.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barSI
            // 
            this.barSI.Caption = "Bảo hiểm xã hội";
            this.barSI.Id = 5;
            this.barSI.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barSI.LargeGlyph")));
            this.barSI.Name = "barSI";
            this.barSI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barSalary
            // 
            this.barSalary.Caption = "Quản lý Lương";
            this.barSalary.Id = 6;
            this.barSalary.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barSalary.LargeGlyph")));
            this.barSalary.Name = "barSalary";
            this.barSalary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // barAccess
            // 
            this.barAccess.Caption = "Phân quyền";
            this.barAccess.Id = 8;
            this.barAccess.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barAccess.LargeGlyph")));
            this.barAccess.Name = "barAccess";
            this.barAccess.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barAccess_ItemClick);
            // 
            // barPostion
            // 
            this.barPostion.Caption = "Chức vụ";
            this.barPostion.Id = 10;
            this.barPostion.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barPostion.LargeGlyph")));
            this.barPostion.Name = "barPostion";
            this.barPostion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem9_ItemClick);
            // 
            // barAbsent
            // 
            this.barAbsent.Caption = "Quản lý Nghỉ phép";
            this.barAbsent.Id = 11;
            this.barAbsent.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barAbsent.LargeGlyph")));
            this.barAbsent.Name = "barAbsent";
            this.barAbsent.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem10_ItemClick);
            // 
            // barButtonItem13
            // 
            this.barButtonItem13.Caption = "Thông tin cá nhân";
            this.barButtonItem13.Id = 15;
            this.barButtonItem13.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem13.LargeGlyph")));
            this.barButtonItem13.Name = "barButtonItem13";
            this.barButtonItem13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem13_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Thống kê";
            this.barButtonItem2.Id = 16;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick_1);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Báo cáo";
            this.barButtonItem3.Id = 17;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick_1);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 18;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // ribbonGalleryBarItem1
            // 
            this.ribbonGalleryBarItem1.Caption = "ribbonGalleryBarItem1";
            this.ribbonGalleryBarItem1.Id = 19;
            this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
            // 
            // barAccount
            // 
            this.barAccount.Caption = "Quản lý Tài khoản";
            this.barAccount.Id = 20;
            this.barAccount.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barAccount.LargeGlyph")));
            this.barAccount.Name = "barAccount";
            this.barAccount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick_1);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup6,
            this.ribbonPageGroup8});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Hệ Thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem13);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Nhân Sự";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barEmployees);
            this.ribbonPageGroup2.ItemLinks.Add(this.barSection);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barPostion);
            this.ribbonPageGroup3.ItemLinks.Add(this.barContract);
            this.ribbonPageGroup3.ItemLinks.Add(this.barSI);
            this.ribbonPageGroup3.ItemLinks.Add(this.barAbsent);
            this.ribbonPageGroup3.ItemLinks.Add(this.barSalary);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barAccess);
            this.ribbonPageGroup4.ItemLinks.Add(this.barAccount);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5,
            this.ribbonPageGroup7});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Báo Cáo Thống Kê";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.HeaderButtons = DevExpress.XtraTab.TabButtons.Close;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 143);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.Size = new System.Drawing.Size(762, 317);
            this.xtraTabControl1.TabIndex = 18;
            this.xtraTabControl1.CloseButtonClick += new System.EventHandler(this.xtraTabControl1_CloseButtonClick);
            this.xtraTabControl1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.xtraTabControl1_ControlAdded);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(0, 143);
            this.pictureEdit1.MenuManager = this.ribbonControl1;
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit1.Size = new System.Drawing.Size(762, 317);
            this.pictureEdit1.TabIndex = 20;
            // 
            // FormMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 460);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Phần mềm quản lý nhân sự";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RibbonControl ribbonControl1;
        private RibbonPage ribbonPage1;
        private RibbonPageGroup ribbonPageGroup1;
        private BarButtonItem barButtonItem1;
        private BarButtonItem barEmployees;
        private BarButtonItem barSection;
        private RibbonPage ribbonPage2;
        private RibbonPageGroup ribbonPageGroup2;
        private BarButtonItem barContract;
        private BarButtonItem barSI;
        private BarButtonItem barSalary;
        private RibbonPageGroup ribbonPageGroup3;
        private RibbonPageGroup ribbonPageGroup4;
        private XtraTabControl xtraTabControl1;
        private BarButtonItem barAccess;
        private RibbonPage ribbonPage3;
        private BarButtonItem barPostion;
        private BarButtonItem barAbsent;
        private RibbonPageGroup ribbonPageGroup5;
        private BarButtonItem barButtonItem13;
        private RibbonPageGroup ribbonPageGroup6;
        private BarButtonItem barButtonItem2;
        private BarButtonItem barButtonItem3;
        private RibbonPageGroup ribbonPageGroup7;
        private SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private RibbonPageGroup ribbonPageGroup8;
        private RibbonGalleryBarItem ribbonGalleryBarItem1;
        private BarButtonItem barAccount;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}

