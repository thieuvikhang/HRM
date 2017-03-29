﻿using System;
using System.Collections;
using System.Linq;
using BUS;
using DAL;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using static System.Int32;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace HRM.Salary
{
    public partial class FrmAddSalary : XtraForm
    {
        #region Khai báo biến
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        private readonly SalaryBus _salaryBus = new SalaryBus();
        public readonly StaffBus StaffBus = new StaffBus();
        public readonly SectionBus SectionBus = new SectionBus();
        public readonly ContractBus ContractBus = new ContractBus();
        public readonly AbsentBus AbsentBus = new AbsentBus();
        public readonly RuleBus RuleBus = new RuleBus();
        public readonly ExtendBus ExtendBus = new ExtendBus();
        private string _maNhanVien, _maPhongBan, _maChonThang, _chiTietPhuCap;
        private int _absentNoSalary, _ngayCongQuyDinh;
        private decimal _basicSalary, _bhxh, _luongCoBan, _phuCap, _luongThucLanh;
        #endregion

        #region Load From tính lương
        public FrmAddSalary()
        {
            InitializeComponent();
            LoadComboboxChonPb();
            LoadComboboxChonThang();
        }
        private void frmAddSalary_Load(object sender, EventArgs e)
        {
            gcAddSalary.DataSource = _salaryBus.LoadStaffNonSalary("-", MonthOld(), YearOld());
        }
        #endregion

        #region Xử lú các nút UI Button
        //Xử lý các nút UI Button
        private void windowsUIButton_ButtonClick(object sender, ButtonEventArgs e)
        {
            var tag = ((WindowsUIButton)e.Button).Tag.ToString();
            switch (tag)
            {
                case "tagSave":
                    if (txtLuongHD.Text.Length == 0)
                    {
                        XtraMessageBox.Show("Hợp đồng lao động chưa được tạo");
                        return;
                    }
                    if (_salaryBus.SaveSalary(_maNhanVien, _basicSalary, Month() + "/" + Year(),
                        _ngayCongQuyDinh - _absentNoSalary, _phuCap, _chiTietPhuCap, _ngayCongQuyDinh, _luongThucLanh))
                    {
                        frmAddSalary_Load(sender, e);
                        ClearTextAddSalary();
                    }
                    else
                    {
                        XtraMessageBox.Show("Lỗi trong quá trình lưu");
                    }
                    break;
                case "tagSaveAndClose":
                    if (txtLuongHD.Text.Length == 0)
                    {
                        XtraMessageBox.Show("Hợp đồng lao động chưa được tạo");
                        return;
                    }
                    if (_salaryBus.SaveSalary(_maNhanVien, _basicSalary, Month() + "/" + Year(),
                        _ngayCongQuyDinh - _absentNoSalary, _phuCap, _chiTietPhuCap, _ngayCongQuyDinh, _luongThucLanh))
                    {
                        frmAddSalary_Load(sender, e);
                        ClearTextAddSalary();
                        Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Lỗi trong quá trình lưu");
                    }
                    break;
                case "tagReset":
                    ClearTextAddSalary();
                    break;
                case "tagThoat":
                    Close();
                    break;
            }
        }
        #endregion

        #region Load Combobox chọn phòng ban và tháng lương
        //Lấy tháng dựa vào tháng đã chọn
        private int Month()
        {
            if (cbbChonThang != null) _maChonThang = cbbChonThang.SelectedValue.ToString();/*Mã số chọn tháng lương*/
            var arrListStr = _maChonThang.Split('-');/*Dùng hàng cắt chuổi với đầu cắt là ký tự - */
            return Parse(arrListStr[1]);/*Lấy giá trị tháng*/
        }
        //Lấy năm dựa vào tháng đã chọn
        private int Year()
        {
            if (cbbChonThang != null) _maChonThang = cbbChonThang.SelectedValue.ToString();/*Mã số chọn tháng lương*/
            var arrListStr = _maChonThang.Split('-');/*Dùng hàng cắt chuổi với đầu cắt là ký tự - */
            return Parse(arrListStr[0]);
        }
        //Lấy tháng trước
        private static int MonthOld()
        {
            //Lấy tháng trước đó
            var monthNow = DateTime.Now.Month;
            if (monthNow != 1) { return monthNow - 1; }
            return 12;
        }
        //Lấy năm trước
        private static int YearOld()
        {
            //Lấy năm trước đó
            var yearNow = DateTime.Now.Year;
            if (MonthOld() != 12) { return yearNow; }
            return yearNow - 1;
        }
        //Load Conbobox chọn phòng ban
        public void LoadComboboxChonPb()
        {   //Load Chọn phòng ban
            var sta = new ArrayList { new { tennv = "Tất cả nhân viên", manv = "-" } };
            sta.AddRange(_aHrm.Sections.Select(se => new { tennv = "Phòng " + se.SectionName, manv = se.SectionID }).Distinct().ToList());
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
            monthAs.AddRange(_aHrm.Salaries.Where(p => p.SalaryMonth.Value.Month != MonthOld() && p.SalaryMonth.Value.Year != YearOld())
                .GroupBy(p => new { month = p.SalaryMonth.Value.Month, year = p.SalaryMonth.Value.Year })
                .Select(d => new { dt = $"Tháng {d.Key.month}/{d.Key.year}", month = $"{d.Key.year}-{d.Key.month}" })
                .Distinct().ToList().OrderByDescending(g => g.month).ToArray());
            cbbChonThang.DataSource = monthAs;
            cbbChonThang.DisplayMember = "dt";
            cbbChonThang.ValueMember = "month";
            cbbChonThang.SelectedIndex = 0;
        }

        private void txtGhiChu_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue?.ToString().Length > 50 || e.NewValue?.ToString() == "  ")
                e.Cancel = true;
        }

        #endregion

        #region Validate nhập tiền phụ cấp
        private void txtPhuCap_ValueChanged(object sender, EventArgs e)
        {
            LoadTextEditOnAddSalary();
        }
        private void txtPhuCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || txtPhuCap.Text.Length > 9) return;
            e.Handled = true;
        }

        private void txtPhuCap_TextChanged(object sender, EventArgs e)
        {
            LoadTextEditOnAddSalary();
        }

        private void txtPhuCap_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPhuCap.Text.Equals("0") || txtPhuCap.Text.Equals("")) return;
                var temp = Convert.ToDouble(txtPhuCap.Text);
                txtPhuCap.Text = temp.ToString("#,###");
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Lỗi:" + ex);
            }
        }
        #endregion

        #region Load GirdView theo sự kiện chọn phòng ban, tháng
        private void LoadGirdView()
        {
            var maChonPhongBan = cbbChonPB.SelectedValue.ToString();/*Mã số chọn phòng ban*/
            gcAddSalary.DataSource = _salaryBus.LoadStaffNonSalary(maChonPhongBan, Month(), Year());
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
        private void gcAddSalary_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0) return;
            LoadTextEditOnAddSalary();
        }
        #endregion

        #region Loai dữ liệu các TextEdit theo Combobox chọn nhân viên
        //Xóa trắng các trường trong From
        private void ClearTextAddSalary()
        {
            if (txtChonNV != null) txtChonNV.Text = null;
            if (txtLuongHD != null) txtLuongHD.Text = null;
            if (txtBHXH != null) txtBHXH.Text = null;
            if (txtGhiChu != null) txtGhiChu.Text = null;
            if (txtLuongCoBan != null) txtLuongCoBan.Text = null;
            if (txtLuongThucLanh != null) txtLuongThucLanh.Text = null;
            if (txtNgayCongQuyDinh != null) txtNgayCongQuyDinh.Text = null;
            if (txtPhongBan != null) txtPhongBan.Text = null;
            if (txtSoNgayCong != null) txtSoNgayCong.Text = null;
            if (txtSoNgayNghi != null) txtSoNgayNghi.Text = null;
            if (txtPhuCap != null) txtPhuCap.Text = null;
        }
        private void LoadTextEditOnAddSalary()
        {
            if (gcAddSalary.DataSource == null) return;
            if (gcStaffId != null) _maNhanVien = gridView1.GetFocusedRowCellDisplayText(gcStaffId);
            _maPhongBan = StaffBus.GetSectionIdByStaffId(_maNhanVien);
            _absentNoSalary = AbsentBus.GetAbsentDays(Month(), Year(), _maNhanVien);
            _basicSalary = ContractBus.GetBasicPayByStaffId(_maNhanVien);
            _bhxh = _salaryBus.SiPrice(RuleBus.GetBhxh(), _basicSalary);
            _ngayCongQuyDinh = SectionBus.GetStandardWorkdaysBySectionId(_maPhongBan);
            _luongCoBan = _salaryBus.BasicSalary(_basicSalary, _ngayCongQuyDinh, _absentNoSalary);
            _chiTietPhuCap = txtGhiChu.Text;
            _phuCap = GetPhuCap();
            _luongThucLanh = _salaryBus.RealPay(_basicSalary, _phuCap, _bhxh);
            //Gán giá trị vào Text
            if (_maNhanVien != null) txtChonNV.Text = _maNhanVien;
            if (_maPhongBan != null) txtPhongBan.Text = SectionBus.GetSectionName(_maPhongBan);
            txtNgayCongQuyDinh.Text = _ngayCongQuyDinh.ToString();
            txtLuongHD.Text = ExtendBus.FormatMoney(_basicSalary);
            txtSoNgayCong.Text = (Parse(txtNgayCongQuyDinh.Text) - _absentNoSalary).ToString();
            txtSoNgayNghi.Text = _absentNoSalary.ToString();
            txtLuongCoBan.Text = ExtendBus.FormatMoney(_luongCoBan);
            txtBHXH.Text = ExtendBus.FormatMoney(_bhxh);
            txtLuongThucLanh.Text = ExtendBus.FormatMoney(_luongThucLanh);
        }

        private decimal GetPhuCap()
        {
            return txtPhuCap.Text.Length == 0 ? 0 : decimal.Parse(txtPhuCap.Text);
        }
        #endregion
    }
}