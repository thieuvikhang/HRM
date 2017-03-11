using System;
using System.Linq;
using System.Windows.Forms;
using DAL;
using BUS;
using DevExpress.XtraEditors;
using System.Collections;
using DevExpress.XtraSplashScreen;
using HRM.Salary;

namespace HRM
{
    public partial class UcSalary : XtraUserControl
    {
        readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        readonly SalaryBus _salaryBus = new SalaryBus();
        readonly StaffBus _staffBus = new StaffBus();
        public UcSalary()
        {
            InitializeComponent();
        }

        #region Load Combobox chọn nhân viên và tháng lương
        public void LoadComboboxStaff()
        {   //Load Chọn nhân viên
            var sta = new ArrayList { new { tennv = "Tất cả nhân viên", manv = "all" } };
            var section = (from se in _aHrm.Sections
                           select new
                           {
                               tennv = "# Phòng " + se.SectionName,
                               manv = "#" + se.SectionID,
                           }).ToList();
            sta.AddRange(section);
            var staff = (from s in _aHrm.Staffs
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
            var month = new ArrayList { new { dt = "Tất cả tháng lương", monthID = "all" } };
            //Load chọn tháng định dạng MM/yyyy
            var grouped = ((from p in _aHrm.Salaries
                            group p by new { month = p.SalaryMonth.Value.Month, year = p.SalaryMonth.Value.Year, } into d
                            select new
                            {
                                dt = $"Tháng {d.Key.month}, {d.Key.year}",
                                monthID = $"{d.Key.month}-{d.Key.year}",
                            }).ToList()
                           .OrderByDescending(g => g.monthID));
            month.AddRange(grouped.ToArray());
            cbbMonthYear.DataSource = month;
            cbbMonthYear.DisplayMember = "dt";
            cbbMonthYear.ValueMember = "monthID";
        }
        #endregion

        private void ucSalary_Load(object sender, EventArgs e)
        {
            gcSalary.DataSource = _salaryBus.LoadSalary;
            LoadComboboxStaff();
            LoadComboboxMonth();
        }

        private void panelControl1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void gcSalary_Click(object sender, EventArgs e)
        {

        }
        //Xử lý sự kiện xem lương
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string maChonNhanVien = cbbStaffID.SelectedValue.ToString();/*Mã số chọn nhân viên*/
            string maChonThangNam = cbbMonthYear.SelectedValue.ToString();/*Mã số chọn tháng lương*/
            int month = 0, year = 0, chonPhongBan = 0;
            if (_salaryBus.CheckTheCode(maChonNhanVien, "#") == true)/*Nếu maChonNhanVien có ký tự # ở đầu là phòng ban*/
            {
                maChonNhanVien = _salaryBus.GetTheSectionId(maChonNhanVien, 1);/*Cắt chuổi lấy mã phòng ban gán vào maChonNhanVien*/
                chonPhongBan = 1;/*Bật cờ hiệu*/
            }
            if (maChonThangNam != "all")/*Nếu maChonThangNam khác All tức đã chọn một tháng lương cụ thể*/
            {
                string[] arrListStr = maChonThangNam.Split('-');/*Dùng hàng cắt chuổi với đầu cắt là ký tự - */
                month = int.Parse(arrListStr[0]);/*Lấy giá trị tháng*/
                year = int.Parse(arrListStr[1]);/*Lấy giá trị năm*/
            }


            if (maChonNhanVien != "all" && maChonThangNam != "all")/*Không chọn tất cả nhân viên và tháng*/
            {
                if (chonPhongBan == 1)/*Cờ hiệu chọn phòng ban bật*/
                {
                    gcSalary.DataSource = _staffBus.LoadSalaryBySectionId(maChonNhanVien, month, year);/*Đã chọn phòng ban*/
                }
                else
                {
                    gcSalary.DataSource = _staffBus.LoadSalaryByStaffId(maChonNhanVien, month, year);/*Đã chọn nhân viên*/
                }
            }
            else
            {
                if (maChonNhanVien == "all" && maChonThangNam != "all")/*Chọn tất cả nhân viên, tháng lương chọn cụ thể*/
                {
                    gcSalary.DataSource = _staffBus.LoadSalaryByMonthYear(month, year);
                }
                else
                {
                    if (maChonNhanVien != "all" && maChonThangNam == "all")/*Tháng lương là tất cả, nhân viên # All*/
                    {
                        if (chonPhongBan == 1)/*Phòng ban được chọn*/
                        {
                            gcSalary.DataSource = _staffBus.LoadSalaryByAllSection(maChonNhanVien);
                        }
                        else
                        {
                            //Nhân viên được chọn
                            gcSalary.DataSource = _staffBus.LoadSalaryByStaffIdNonMonthYear(maChonNhanVien);
                        }

                    }
                    else
                    {
                        //Cả combobox nhân viên và tháng lương đều chọn tất cả
                        gcSalary.DataSource = _salaryBus.LoadSalary;
                    }
                }
            }

        }
        #region Sự kiện thay đổi giá trị combobox
        private void cbbStaffID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbMonthYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void btThemLuong_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            FrmAddSalary frm = new FrmAddSalary();
            frm.Show();
            SplashScreenManager.CloseForm();
        }
    }
}
