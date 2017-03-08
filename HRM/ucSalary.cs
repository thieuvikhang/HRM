﻿using System;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using DAL;
using BUS;
using DevExpress.XtraEditors;

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
            var staff = from s in aHRM.Staffs
                        select new
                        {
                            tennv = s.Name,
                            manv = s.StaffsID,
                        };
            cbbStaffID.DataSource = staff.ToList();
            cbbStaffID.DisplayMember = "tennv";
            cbbStaffID.ValueMember = "manv";
        }
        public void LoadComboboxMonth()
        {   //Load chọn tháng
            var staff = (from s in aHRM.Salaries
                         select new
                         {
                             month = s.SalaryMonth,
                        }).Distinct();
            cbbMonthYear.DataSource = staff.ToList();
            cbbMonthYear.DisplayMember = "month";
            cbbMonthYear.ValueMember = "month";
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
    }
}
