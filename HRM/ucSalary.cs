using System;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using DAL;
using BUS;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Collections;

namespace HRM
{
    public partial class ucSalary : XtraUserControl
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();
        SalaryBUS salaryBUS = new SalaryBUS();
        public ucSalary()
        {
            InitializeComponent();

            /*gcSalary.DataSource = GetDataSource();
            BindingList<Customer> dataSource = GetDataSource();
            gcSalary.DataSource = dataSource;*/

        }
        #region Load Combobox
        public void LoadComboboxStaff()
        {   //Load Chọn nhân viên
            ArrayList sta = new ArrayList();
            var section = (from se in aHRM.Sections
                           select new
                           {
                               tennv = se.Name,
                               manv = se.SectionID,
                           }).ToList();
            sta.AddRange(section);
            var staff = (from s in aHRM.Staffs
                         select new
                         {
                             tennv = s.Name,
                             manv = s.StaffID,
                         }).ToArray();
            sta.AddRange(staff);
            cbbStaffID.DataSource = sta;
            cbbStaffID.DisplayMember = "tennv";
            cbbStaffID.ValueMember = "manv";
        }
        public void LoadComboboxMonth()
        {   //Load chọn tháng định dạng MM/yyyy
            var months = aHRM.Salaries
                .AsEnumerable()
                .Select(c => new {
                    monthName = c.SalaryMonth.Value.Month,
                    yearName = c.SalaryMonth.Value.Year,
                    monthID = c.SalaryMonth,
                }).ToList();

            var grouped = (from p in aHRM.Salaries
                           group p by new { month = p.SalaryMonth.Value.Month, year = p.SalaryMonth.Value.Year } into d
                           select new { dt = string.Format("{0}/{1}", d.Key.month, d.Key.year) }).ToList().OrderByDescending(g => g.dt);

            cbbMonthYear.DataSource = grouped.ToList();
            cbbMonthYear.DisplayMember = "dt";
            cbbMonthYear.ValueMember = "dt";
        }
        #endregion
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gcSalary.ShowRibbonPrintPreview();
        }
        #region DEMO
        public BindingList<Customer> GetDataSource()
        {
            BindingList<Customer> result = new BindingList<Customer>();
            result.Add(new Customer()
            {
                ID = 1,
                Name = "ACME",
                Address = "2525 E El Segundo Blvd",
                City = "El Segundo",
                State = "CA",
                ZipCode = "90245",
                Phone = "(310) 536-0611"
            });
            result.Add(new Customer()
            {
                ID = 2,
                Name = "Electronics Depot",
                Address = "2455 Paces Ferry Road NW",
                City = "Atlanta",
                State = "GA",
                ZipCode = "30339",
                Phone = "(800) 595-3232"
            });
            return result;
        }
        public class Customer
        {
            [Key, Display(AutoGenerateField = false)]
            public int ID { get; set; }
            [Required]
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }
            public string Phone { get; set; }
        }
        #endregion
        private void ucSalary_Load(object sender, EventArgs e)
        {
            gcSalary.DataSource = salaryBUS.LoadSalary();
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
    }
}
