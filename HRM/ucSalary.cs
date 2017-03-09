using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DAL;
using BUS;
using DevExpress.XtraEditors;
using System.Collections;

namespace HRM
{
    public partial class ucSalary : XtraUserControl
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();
        SalaryBUS salaryBUS = new SalaryBUS();
        staffBUS staffBUS = new staffBUS();
        public ucSalary()
        {
            InitializeComponent();
        }

        #region Load Combobox
        public void LoadComboboxStaff()
        {   //Load Chọn nhân viên
            ArrayList sta = new ArrayList();
            sta.Add(new { tennv = "Tất cả", manv = "all" });
            var section = (from se in aHRM.Sections
                           select new
                           {
                               tennv = se.SectionName,
                               manv = se.SectionID,
                           }).ToList();
            sta.AddRange(section);
            var staff = (from s in aHRM.Staffs
                         select new
                         {
                             tennv = s.StaffName,
                             manv = s.StaffID,
                         }).ToArray();
            sta.AddRange(staff);
            cbbStaffID.DataSource = sta;
            cbbStaffID.DisplayMember = "tennv";
            cbbStaffID.ValueMember = "manv";
        }
        public void LoadComboboxMonth()
        {
            ArrayList sta = new ArrayList();
            sta.Add(new { dt = "Tất cả" , monthID = DateTime.Now});
            //Load chọn tháng định dạng MM/yyyy
            var grouped = (from p in aHRM.Salaries
                           group p by new { month = p.SalaryMonth.Value.Month, year = p.SalaryMonth.Value.Year, monthID = p.SalaryMonth } into d
                           select new { dt = string.Format("{0}/{1}", d.Key.month, d.Key.year), monthID = d.Key.monthID}).ToList().OrderByDescending(g => g.dt).ToArray();
            sta.AddRange(grouped);
            cbbMonthYear.DataSource = sta;
            cbbMonthYear.DisplayMember = "dt";
            cbbMonthYear.ValueMember = "monthID";
        }
        #endregion
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gcSalary.ShowRibbonPrintPreview();
        }
        private void ucSalary_Load(object sender, EventArgs e)
        {
            gcSalary.DataSource = salaryBUS.LoadSalary();
            // For en-US culture, displays 3/1/2008 7:00:00 AM
            //DateTime date1 = new DateTime(2016, 11, 11, 7, 0, 0);
            //gcSalary.DataSource = staffBUS.LoadSalaryBySectionID("1", date1);
            LoadComboboxStaff();
            LoadComboboxMonth();
        }

        private void ribbonControl_Click(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gcSalary_Load(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void gcSalary_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
        #region Sự kiện thay đổi giá trị combobox
        private void cbbStaffID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int selectedIndex = cbbStaffID.SelectedIndex;
            //object selectedItem = cbbStaffID.SelectedItem;
            //MessageBox.Show("Selected Item Text: " + selectedItem.ToString() + "\n" + "Index: " + selectedIndex.ToString());
        }

        private void cbbMonthYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
