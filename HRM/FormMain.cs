using AddTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HRM
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        AddTab.TabAdd clsAddTab = new TabAdd();
        ucEmployees employees = new ucEmployees();
        public FormMain()
        {
            InitializeComponent();
        }
        
        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Kiểm tra khi bấm nút Sinh Viên: Nếu đã có TAb này rồi thì không Add vào nữa
            // mà nó sẽ chuyển focus tới TAb Sinh Viên này
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Nhân viên")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {
                
            }
            else
            {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                clsAddTab.AddTab(xtraTabControl1, "", "Nhân viên", new ucEmployees());
            }
        }
        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {// dong tab
            DevExpress.XtraTab.XtraTabControl tabControl = sender as DevExpress.XtraTab.XtraTabControl;
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            (arg.Page as DevExpress.XtraTab.XtraTabPage).Dispose();
        }
        private void xtraTabControl1_ControlAdded(object sender, ControlEventArgs e)
        {// Khi add vào thì Focus tới ngay Tab vừa Add
            xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 1;
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Kiểm tra khi bấm nút Sinh Viên: Nếu đã có TAb này rồi thì không Add vào nữa
            // mà nó sẽ chuyển focus tới TAb Sinh Viên này
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Quản lý lương")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                clsAddTab.AddTab(xtraTabControl1, "", "Quản lý lương", new ucSalary());
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Kiểm tra khi bấm nút Sinh Viên: Nếu đã có TAb này rồi thì không Add vào nữa
            // mà nó sẽ chuyển focus tới TAb Sinh Viên này
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Phòng ban")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                clsAddTab.AddTab(xtraTabControl1, "", "Phòng ban", new ucSection());
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Kiểm tra khi bấm nút Sinh Viên: Nếu đã có TAb này rồi thì không Add vào nữa
            // mà nó sẽ chuyển focus tới TAb Sinh Viên này
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Hợp đồng")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                clsAddTab.AddTab(xtraTabControl1, "", "Hợp đồng", new ucContract());
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Kiểm tra khi bấm nút Sinh Viên: Nếu đã có TAb này rồi thì không Add vào nữa
            // mà nó sẽ chuyển focus tới TAb Sinh Viên này
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "BHXH")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                clsAddTab.AddTab(xtraTabControl1, "", "BHXH", new ucSocialInsurancecs());
            }
        }
    }
}
