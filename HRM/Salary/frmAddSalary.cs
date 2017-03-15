using System;
using System.Linq;
using DevExpress.XtraBars.Docking2010;
using BUS;
using System.Collections;
using System.Globalization;
using DAL;
using DevExpress.XtraEditors;
using static System.Int32;

namespace HRM.Salary
{
    public partial class FrmAddSalary : XtraForm
    {
        readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        readonly SalaryBus _salaryBus = new SalaryBus();
        readonly StaffBus _staffBus = new StaffBus();
        readonly SectionBus _sectionBus = new SectionBus();
        readonly ContractBus _contractBus = new ContractBus();
        readonly AbsentBus _absentBus = new AbsentBus();
        readonly RuleBus _ruleBus = new RuleBus();
        int _month;
        int _year;

        public FrmAddSalary()
        {
            InitializeComponent();
            LoadComboboxChonPb();
            LoadComboboxChonThang();
        }
        private void frmAddSalary_Load(object sender, EventArgs e)
        {
            gcAddSalary.DataSource = _salaryBus.LoadStaffNonSalary("-", MonthOld(), YearOld());
            cbbChonNv.DataSource = _salaryBus.LoadStaffNonSalary("-", MonthOld(), YearOld());
            cbbChonNv.DisplayMember = "StaffName";
            cbbChonNv.ValueMember = "StaffID";
            LoadTextEditOnAddSalary();
        }

        //Xử lý các nút UI Button
        private void windowsUIButton_ButtonClick(object sender, ButtonEventArgs e)
        {
            var tag = ((WindowsUIButton)e.Button).Tag.ToString();
            if (tag == "tagSave")
                Close();
            else if (tag == "tagSaveAndClose")
            {
                Close();
            }
            else if (tag == "tagSaveAndNew")
            {
                Close();
            }
            else if (tag == "tagReset")
            {
                Close();
            }
            else if (tag == "tagThoat")
            {
                Close();
            }
        }

        #region Load Combobox chọn phòng ban và tháng lương
        //Lấy tháng trước
        private static int MonthOld()
        {
            //Lấy tháng trước đó
            var monthNow = DateTime.Now.Month;
            if (monthNow != 1)
            {
                return monthNow - 1;
            }
            return 12;
        }
        //Lấy năm trước
        private int YearOld()
        {
            //Lấy năm trước đó
            var yearNow = DateTime.Now.Year;
            if (MonthOld() != 12)
            {
                return yearNow;
            }
            return yearNow - 1;
        }
        //Load Conbobox chọn phòng ban
        public void LoadComboboxChonPb()
        {   //Load Chọn phòng ban
            var sta = new ArrayList { new { tennv = "Tất cả nhân viên", manv = "-" } };
            sta.AddRange((from se in _aHrm.Sections
                          select new
                          {
                              tennv = "Phòng " + se.SectionName,
                              manv = se.SectionID
                          }).Distinct().ToList());
            cbbChonPB.DataSource = sta;
            cbbChonPB.DisplayMember = "tennv";
            cbbChonPB.ValueMember = "manv";
            cbbChonPB.SelectedIndex = 0;
        }
        //Load Conbobox chọn tháng
        public void LoadComboboxChonThang()
        {
            var monthAs = new ArrayList { new { dt = "Tháng " + MonthOld() + "/" + YearOld(), month = YearOld() + "-" + MonthOld() } };
            //Load chọn tháng định dạng MM/yyyy
            monthAs.AddRange((from p in _aHrm.Salaries
                              where p.SalaryMonth.Value.Month != MonthOld()
                                    && p.SalaryMonth.Value.Year != YearOld()
                              group p by new { month = p.SalaryMonth.Value.Month, year = p.SalaryMonth.Value.Year } into d
                              select new
                              {
                                  dt = $"Tháng {d.Key.month}/{d.Key.year}",
                                  month = $"{d.Key.year}-{d.Key.month}",
                              }).Distinct().ToList().OrderByDescending(g => g.month).ToArray());
            cbbChonThang.DataSource = monthAs;
            cbbChonThang.DisplayMember = "dt";
            cbbChonThang.ValueMember = "month";
            cbbChonThang.SelectedIndex = 0;
        }
        #endregion


        #region Load GirdView theo sự kiện chọn phòng ban, tháng
        private void LoadGirdView()
        {
            var maChonPhongBan = cbbChonPB.SelectedValue.ToString();/*Mã số chọn phòng ban*/
            var maChonThang = cbbChonThang.SelectedValue.ToString();/*Mã số chọn tháng lương*/
            var arrListStr = maChonThang.Split('-');/*Dùng hàng cắt chuổi với đầu cắt là ký tự - */
            _year = Parse(arrListStr[0]);
            _month = Parse(arrListStr[1]);/*Lấy giá trị tháng*/
            gcAddSalary.DataSource = _salaryBus.LoadStaffNonSalary(maChonPhongBan, _month, _year);
            if (cbbChonNv != null)
            {
                cbbChonNv.DataSource = _salaryBus.LoadStaffNonSalary(maChonPhongBan, _month, _year);
                cbbChonNv.DisplayMember = "StaffName";
                cbbChonNv.ValueMember = "StaffID";
            }
            if (gridView1.SelectedRowsCount >= 1) return;
            ClearTextAddSalary();
        }
        private void cbbChonPB_TextChanged(object sender, EventArgs e)
        {
            if (cbbChonThang.Items.Count <= 0) return;
            LoadGirdView();
        }
        private void cbbChonThang_TextChanged(object sender, EventArgs e)
        {
            var maChonThang = cbbChonThang.SelectedValue.ToString();/*Mã số chọn tháng lương*/
            if (cbbChonPB.Items.Count <= 0 || maChonThang.Length >= 8) return;
            LoadGirdView();
        }

        #endregion

        #region Loai dữ liệu các TextEdit theo Combobox chọn nhân viên
        //Xóa trắng các trường trong From
        private void ClearTextAddSalary()
        {
            if (cbbChonNv != null) cbbChonNv.Text = null;
            if (txtLuongHD != null) txtLuongHD.Text = null;
            if (txtBHXH != null) txtBHXH.Text = null;
            if (txtGhiChu != null) txtGhiChu.Text = null;
            if (txtLuongCoBan != null) txtLuongCoBan.Text = null;
            if (txtLuongThucLanh != null) txtLuongThucLanh.Text = null;
            if (txtNgayCongQuyDinh != null) txtNgayCongQuyDinh.Text = null;
            if (txtPhongBan != null) txtPhongBan.Text = null;
            if (txtSoNgayCong != null) txtSoNgayCong.Text = null;
            if (txtSoNgayNghi != null) txtSoNgayNghi.Text = null;
        }
        private void LoadTextEditOnAddSalary()
        {
            if (cbbChonNv.SelectedIndex == -1 && cbbChonNv.SelectedValue.ToString().Length >= 8) return;
            var maNhanVien = cbbChonNv.SelectedValue.ToString();
            var maPhongBan = _staffBus.GetSectionIdByStaffId(maNhanVien);
            var absentNoSalary = _absentBus.GetAbsentDays(_month, _year, maNhanVien);
            var basicSalary = _contractBus.GetBasicPayByStaffId(maNhanVien);
            var lePhiBaoHiem = _ruleBus.GetAbsentDays();
            txtPhongBan.Text = _sectionBus.GetSectionName(maPhongBan);
            txtNgayCongQuyDinh.Text = _sectionBus.GetStandardWorkdaysBySectionId(maPhongBan).ToString();
            txtLuongHD.Text = basicSalary.ToString(CultureInfo.InvariantCulture);
            txtSoNgayCong.Text = (Parse(txtNgayCongQuyDinh.Text) - absentNoSalary).ToString();
            txtSoNgayNghi.Text = absentNoSalary.ToString();
            txtLuongCoBan.Text = _salaryBus.BasicSalary(_contractBus.GetBasicPayByStaffId(maNhanVien), _sectionBus.GetStandardWorkdaysBySectionId(maPhongBan), _absentBus.GetAbsentDays(_month, _year, maNhanVien)).ToString(CultureInfo.InvariantCulture);
            txtBHXH.Text = _salaryBus.SiPrice(lePhiBaoHiem, basicSalary).ToString(CultureInfo.InvariantCulture);
        }
        private void cbbChonNv_TextChanged(object sender, EventArgs e)
        {
            //LoadTextEditOnAddSalary();
        }

        #endregion

        private void gcAddSalary_Click(object sender, EventArgs e)
        {
            LoadTextEditOnAddSalary();
        }
    }
}