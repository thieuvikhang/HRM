using System;
using System.Linq;
using System.Windows.Forms;
using DAL;
using BUS;
using DevExpress.XtraEditors;
using System.Collections;
using DevExpress.XtraSplashScreen;
using HRM.Salary;
using static System.Int32;

namespace HRM
{
    public partial class UcSalary : XtraUserControl
    {
        public readonly HRMModelDataContext AHrm = new HRMModelDataContext();
        public readonly SalaryBus SalaryBus = new SalaryBus();
        public readonly StaffBus StaffBus = new StaffBus();
        public UcSalary()
        {
            InitializeComponent();
        }

        #region Load Combobox chọn nhân viên và tháng lương
        public void LoadComboboxStaff()
        {   //Load Chọn nhân viên
            var sta = new ArrayList { new { tennv = "Tất cả nhân viên", manv = "all" } };
            sta.AddRange((from se in AHrm.Sections
                          select new
                          {
                              tennv = "# Phòng " + se.SectionName,
                              manv = "#" + se.SectionID,
                          }).ToList());
            sta.AddRange((from s in AHrm.Staffs
                          select new
                          {
                              tennv = s.StaffName,
                              manv = s.StaffID,
                          }).ToArray());
            cbbStaffID.DataSource = sta;
            cbbStaffID.DisplayMember = "tennv";
            cbbStaffID.ValueMember = "manv";
            cbbStaffID.SelectedIndex = 0;
        }
        public void LoadComboboxMonth()
        {
            var month = new ArrayList { new { dt = "Tất cả tháng lương", monthID = "all" } };
            //Load chọn tháng định dạng MM/yyyy
            month.AddRange((from p in AHrm.Salaries
                            group p by new { month = p.SalaryMonth.Value.Month, year = p.SalaryMonth.Value.Year, } into d
                            select new
                            {
                                dt = $"Tháng {d.Key.month}, {d.Key.year}",
                                monthID = $"{d.Key.month}-{d.Key.year}",
                            }).ToList().OrderByDescending(g => g.monthID).ToArray());
            cbbMonthYear.DataSource = month;
            cbbMonthYear.DisplayMember = "dt";
            cbbMonthYear.ValueMember = "monthID";
            cbbMonthYear.SelectedIndex = 0;
        }
        #endregion

        private void ucSalary_Load(object sender, EventArgs e)
        {
            gcSalary.DataSource = SalaryBus.LoadSalary;
            LoadComboboxStaff();
            LoadComboboxMonth();
        }

        private void panelControl1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void gcSalary_Click(object sender, EventArgs e)
        {

        }
        //Hàm Load GirdView khi thay đổi Combobox chọn nhân viên hoặc chọn Tháng
        private void LoadGridView()
        {
            var maChonNhanVien = cbbStaffID.SelectedValue.ToString();/*Mã số chọn nhân viên*/
            var maChonThangNam = cbbMonthYear.SelectedValue.ToString();/*Mã số chọn tháng lương*/
            int month = 0, year = 0, chonPhongBan = 0;
            if (SalaryBus.CheckTheCode(maChonNhanVien, "#"))/*Nếu maChonNhanVien có ký tự # ở đầu là phòng ban*/
            {
                maChonNhanVien = SalaryBus.GetTheSectionId(maChonNhanVien, 1);/*Cắt chuổi lấy mã phòng ban gán vào maChonNhanVien*/
                chonPhongBan = 1;/*Bật cờ hiệu*/
            }
            if (maChonThangNam != "all")/*Nếu maChonThangNam khác All tức đã chọn một tháng lương cụ thể*/
            {
                var arrListStr = maChonThangNam.Split('-');/*Dùng hàng cắt chuổi với đầu cắt là ký tự - */
                month = Parse(arrListStr[0]);/*Lấy giá trị tháng*/
                year = Parse(arrListStr[1]);/*Lấy giá trị năm*/
            }

            gcSalary.DataSource = maChonNhanVien != "all" && maChonThangNam != "all"
                ? (chonPhongBan == 1
                    ? StaffBus.LoadSalaryBySectionId(maChonNhanVien, month, year)
                    : StaffBus.LoadSalaryByStaffId(maChonNhanVien, month, year))
                : (maChonNhanVien == "all" && maChonThangNam != "all"
                    ? StaffBus.LoadSalaryByMonthYear(month, year)
                    : (maChonNhanVien != "all" && maChonThangNam == "all"
                        ? (chonPhongBan == 1
                            ? StaffBus.LoadSalaryByAllSection(maChonNhanVien)
                            : StaffBus.LoadSalaryByStaffIdNonMonthYear(maChonNhanVien))
                        : SalaryBus.LoadSalary));
        }
        #region Sự kiện thay đổi giá trị combobox
        #endregion
        //Mở Form Thêm lương
        private void btThemLuong_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoading));
            var frm = new FrmAddSalary();
            frm.Show();
            SplashScreenManager.CloseForm();
        }

        private void cbbStaffID_TextChanged(object sender, EventArgs e)
        {
            if (cbbMonthYear.SelectedIndex == -1) return;
            LoadGridView();
        }

        private void cbbMonthYear_TextChanged(object sender, EventArgs e)
        {
            if (cbbMonthYear.SelectedValue.ToString().Length > 8) return;
            LoadGridView();
        }
    }
}
