using System;
using System.Linq;
using DevExpress.XtraBars.Docking2010;
using BUS;
using System.Collections;
using DAL;
using DevExpress.XtraEditors;

namespace HRM.Salary
{
    public partial class frmAddSalary : XtraForm
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();
        SalaryBUS salaryBUS = new SalaryBUS();
        string maChonPhongBan = null, maChonThangNam = null;
        int month = 0, year = 0;
        public frmAddSalary()
        {
            InitializeComponent();
        }
        #region Load Combobox chọn phòng ban và tháng lương
        public void LoadComboboxChonPB()
        {   //Load Chọn phòng ban
            ArrayList sta = new ArrayList();
            sta.Add(new { tennv = "Tất cả nhân viên", manv = "-" });
            var section = (from se in aHRM.Sections
                           select new
                           {
                               tennv = "Phòng " + se.SectionName,
                               manv = se.SectionID
                           }).Distinct().ToList();
            sta.AddRange(section);
            cbbChonPB.DataSource = sta;
            cbbChonPB.DisplayMember = "tennv";
            cbbChonPB.ValueMember = "manv";
        }
        private string MonthOldMonthYear()
        {
            int monthNow = DateTime.Now.Month;
            int yearNow = DateTime.Now.Year;
            int monthOld = 0, yearOld = 0;
            //1-12-2016  1-1-2017
            if (monthNow == 1)
            {
                monthOld = 12;
                yearOld = yearNow - 1;
            }
            else
            {
                monthOld = monthNow - 1;
                yearOld = yearNow;
            }
            return "Tháng " + monthOld.ToString() + "/" + yearOld.ToString();
        }
        private string MonthOldYearMonth()
        {
            int monthNow = DateTime.Now.Month;
            int yearNow = DateTime.Now.Year;
            int monthOld = 0, yearOld = 0;
            //1-12-2016  1-1-2017
            if (monthNow == 1)
            {
                monthOld = 12;
                yearOld = yearNow - 1;
            }
            else
            {
                monthOld = monthNow - 1;
                yearOld = yearNow;
            }
            return yearOld.ToString() + "-" + monthOld.ToString();
        }
        public void LoadComboboxChonThang()
        {

            ArrayList monthAS = new ArrayList();
            monthAS.Add(new { dt = MonthOldMonthYear(), month = MonthOldYearMonth() });
            //Load chọn tháng định dạng MM/yyyy
            var grouped = ((from p in aHRM.Salaries
                            where (p.SalaryMonth.Value.Month != DateTime.Now.Month
                                && p.SalaryMonth.Value.Year != DateTime.Now.Year)
                            group p by new { month = p.SalaryMonth.Value.Month, year = p.SalaryMonth.Value.Year } into d
                            select new
                            {
                                dt = string.Format("Tháng {0}/{1}", d.Key.month, d.Key.year),
                                month = string.Format("{0}-{1}", d.Key.year, d.Key.month),
                            }).Distinct().ToList()
                           .OrderByDescending(g => g.month)).ToArray();
            monthAS.AddRange(grouped);
            cbbChonThang.DataSource = monthAS;
            cbbChonThang.DisplayMember = "dt";
            cbbChonThang.ValueMember = "month";
        }
        #endregion
        private void windowsUIButtonPanelMain_Click(object sender, EventArgs e)
        {

        }

        private void windowsUIButtonPanelMain_ButtonChecked(object sender, ButtonEventArgs e)
        {

        }

        private void windowsUIButton_ButtonClick(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "tagSave":
                    this.Close();
                    break;
                case "tagSaveAndClose":
                    this.Close();
                    break;
                case "tagSaveAndNew":
                    this.Close();
                    break;
                case "tagReset":
                    this.Close();
                    break;
                case "tagDelete":
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private void frmAddSalary_Load(object sender, EventArgs e)
        {
            gcAddSalary.DataSource = salaryBUS.LoadStaffNonSalary("-", 2, 2013); ;
            LoadComboboxChonPB();
            LoadComboboxChonThang();
            XtraMessageBox.Show("PB" + maChonPhongBan + "Month" + month + "Year" + year);
        }

        private void cbbChonPB_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbChonPB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbChonPB_SelectedValueChanged(object sender, EventArgs e)
        {
            maChonPhongBan = cbbChonPB.SelectedValue.ToString();/*Mã số chọn phòng ban*/
        }

        private void cbbChonThang_SelectedValueChanged(object sender, EventArgs e)
        {
            maChonThangNam = cbbChonThang.SelectedValue.ToString();/*Mã số chọn tháng lương*/
            //string[] arrListStr = maChonThangNam.Split('-');/*Dùng hàng cắt chuổi với đầu cắt là ký tự - */
            //year = int.Parse(arrListStr[0]);/*Lấy giá trị năm*/
            //month = int.Parse(arrListStr[1]);/*Lấy giá trị tháng*/
        }

        private void cbbChonThang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}