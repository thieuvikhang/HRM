using System;
using System.Linq;
using DevExpress.XtraBars.Docking2010;
using BUS;
using System.Collections;
using System.Globalization;
using DAL;
using DevExpress.XtraEditors;

namespace HRM.Salary
{
    public partial class FrmAddSalary : XtraForm
    {
        readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        readonly SalaryBus _salaryBus = new SalaryBus();
        readonly StaffBus _staffBus = new StaffBus();
        readonly SectionBus _sectionBus = new SectionBus();
        readonly ContractBus _contractBus = new ContractBus();
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
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "tagSave":
                    Close();
                    break;
                case "tagSaveAndClose":
                    Close();
                    break;
                case "tagSaveAndNew":
                    Close();
                    break;
                case "tagReset":
                    Close();
                    break;
                case "tagThoat":
                    Close();
                    break;
            }
        }

        #region Load Combobox chọn phòng ban và tháng lương
        //Lấy tháng trước
        private static int MonthOld()
        {
            //Lấy tháng trước đó
            int monthNow = DateTime.Now.Month;
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
            int yearNow = DateTime.Now.Year;
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
            var section = (from se in _aHrm.Sections
                           select new
                           {
                               tennv = "Phòng " + se.SectionName,
                               manv = se.SectionID
                           }).Distinct().ToList();
            sta.AddRange(section);
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
            var grouped = (from p in _aHrm.Salaries
                           where p.SalaryMonth.Value.Month != MonthOld()
                                 && p.SalaryMonth.Value.Year != YearOld()
                           group p by new { month = p.SalaryMonth.Value.Month, year = p.SalaryMonth.Value.Year } into d
                           select new
                           {
                               dt = $"Tháng {d.Key.month}/{d.Key.year}",
                               month = $"{d.Key.year}-{d.Key.month}",
                           }).Distinct().ToList()
                .OrderByDescending(g => g.month).ToArray();
            monthAs.AddRange(grouped);
            cbbChonThang.DataSource = monthAs;
            cbbChonThang.DisplayMember = "dt";
            cbbChonThang.ValueMember = "month";
            cbbChonThang.SelectedIndex = 0;
        }
        #endregion


        #region Load GirdView theo sự kiện chọn phòng ban, tháng
        private void LoadGirdView()
        {
            string maChonPhongBan = cbbChonPB.SelectedValue.ToString();/*Mã số chọn phòng ban*/
            string maChonThang = cbbChonThang.SelectedValue.ToString();/*Mã số chọn tháng lương*/
            string[] arrListStr = maChonThang.Split('-');/*Dùng hàng cắt chuổi với đầu cắt là ký tự - */
            _year = int.Parse(arrListStr[0]);
            _month = int.Parse(arrListStr[1]);/*Lấy giá trị tháng*/
            gcAddSalary.DataSource = _salaryBus.LoadStaffNonSalary(maChonPhongBan, _month, _year);
            cbbChonNv.DataSource = _salaryBus.LoadStaffNonSalary(maChonPhongBan, _month, _year);
            cbbChonNv.DisplayMember = "StaffName";
            cbbChonNv.ValueMember = "StaffID";
            if (gridView1.SelectedRowsCount < 1)
            { ClearTextAddSalary(); }
        }
        private void cbbChonPB_TextChanged(object sender, EventArgs e)
        {

            if (cbbChonThang.Items.Count > 0)
            {
                LoadGirdView();
            }
        }
        private void cbbChonThang_TextChanged(object sender, EventArgs e)
        {
            string maChonThang = cbbChonThang.SelectedValue.ToString();/*Mã số chọn tháng lương*/
            if (cbbChonPB.Items.Count > 0 && maChonThang.Length < 8)
            {
                LoadGirdView();
            }
        }

        #endregion

        #region Loai dữ liệu các TextEdit theo Combobox chọn nhân viên
        //Xóa trắng các trường trong From
        private void ClearTextAddSalary()
        {
            cbbChonNv.Text = null;
            txtLuongHD.Text = null;
            txtBHXH.Text = null;
            txtGhiChu.Text = null;
            txtLuongCoBan.Text = null;
            txtLuongThucLanh.Text = null;
            txtNgayCongQuyDinh.Text = null;
            txtPhongBan.Text = null;
            txtSoNgayCong.Text = null;
            txtSoNgayNghi.Text = null;
            txtLuongThucLanh.Text = null;
        }
        private void LoadTextEditOnAddSalary()
        {
            if (cbbChonNv.Items.Count > 0)
            {
                string maNhanVien = cbbChonNv.SelectedValue.ToString();
                string maPhongBan = _staffBus.GetSectionIdByStaffId(maNhanVien);
                txtPhongBan.Text = maPhongBan;
                txtNgayCongQuyDinh.Text = _sectionBus.GetStandardWorkdaysBySectionId(maPhongBan).ToString();
                txtLuongHD.Text = _contractBus.GetBasicPayByStaffId(maNhanVien).ToString(CultureInfo.InvariantCulture);
            }
        }
        private void cbbChonNv_TextChanged(object sender, EventArgs e)
        {
            LoadTextEditOnAddSalary();
        }

        #endregion

    }
}