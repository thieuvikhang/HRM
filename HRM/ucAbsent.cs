﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using BUS;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Calendar;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace HRM
{
    public partial class UcAbsent : XtraUserControl
    {
        #region Khai báo biến
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        public readonly AbsentBus AbsentBus = new AbsentBus();
        public readonly DaysRemainBus DaysRemainBus = new DaysRemainBus();
        public Session Session = new Session();
        public bool AllowClosePopup = true;
        private readonly List<int> _list = new List<int>();
        private int _coHieu, _ngayBatDau, _ngayKetThuc, _soNgayNghiCoLuong;
        private int _maxValue;
        #endregion

        #region UcAbsent Load
        public UcAbsent()
        {
            InitializeComponent();
            SetText(false);
            SetButton(true);
        }
        private void ucAbsent_Load(object sender, EventArgs e)
        {
            var access = int.Parse(Session["Access"].ToString());
            if (access != 1)
            {
                groupBox1.Visible = false;
                btnAdd.Visible = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;
                gridView1.Columns[8].Visible = false;
                gridView1.Columns[9].Visible = false;
            }
            gcAbsent.DataSource = AbsentBus.GetAbsent();
            LoadluChonNv();
            dateChonBD.Properties.MaxValue = AbsentBus.NgayCuoiThang(DateTime.Now);
        }
        #endregion

        #region Chọn nhân viên
        private void NgayDaNghi()
        {
            if (_coHieu != 0 && luChonNV.EditValue != null)
            {
                var listNgayNghi = AbsentBus.ListNgayNghi(luChonNV.EditValue.ToString(), DateTime.Now);
                _list.AddRange(listNgayNghi);
                _maxValue = _list.Concat(new[] { 0 }).Max();
                dateChonBD.Properties.MinValue = _maxValue == 0 ? AbsentBus.NgayDauThang(DateTime.Now) : new DateTime(DateTime.Now.Year, DateTime.Now.Month, _maxValue + 1);
            }
            if (_coHieu != 2) return;
            for (var i = _ngayKetThuc; i >= _ngayBatDau; i--)
            {
                _list.Remove(i);
                _maxValue = _list.Concat(new[] { 0 }).Max();
                dateChonBD.Properties.MinValue = _maxValue == 0 ? AbsentBus.NgayDauThang(DateTime.Now) : new DateTime(DateTime.Now.Year, DateTime.Now.Month, _maxValue + 1);
            }
        }
        private void luChonNV_TextChanged(object sender, EventArgs e)
        {
            txtSoNgayNghi.Text = @"0";
            _list.Clear();
            if (luChonNV.EditValue != null)
            {
                NgayDaNghi();
            }
            dateChonBD.EditValue = null;
            dateChonKT.EditValue = null;
            if (_coHieu != 1) return;
            dateChonBD.Enabled = true;
            dateChonKT.Enabled = false;
        }
        private void LoadluChonNv()
        {
            luChonNV.Properties.DataSource = _aHrm.Staffs.Select(staff => new
            {
                ID = staff.StaffID,
                Name = staff.StaffName
            });
            luChonNV.Properties.ValueMember = "ID";
            luChonNV.Properties.DisplayMember = "Name";
        }
        #endregion

        #region Chọn ngày bắt đầu
        private void dateChonBD_TextChanged(object sender, EventArgs e)
        {
            dateChonKT.Properties.MinValue = dateChonBD.DateTime;
            dateChonKT.Properties.MaxValue = AbsentBus.NgayCuoiThang(DateTime.Now);
            dateChonKT.DateTime = dateChonBD.DateTime;
            if (_coHieu != 1) return;
            dateChonKT.Enabled = true;
        }
        private void dateChonBD_QueryCloseUp(object sender, CancelEventArgs e)
        {
            if (_coHieu == 0) return;
            e.Cancel = !AllowClosePopup;
        }
        private void dateChonBD_DateTimeChanged(object sender, EventArgs e)
        {
            if (_coHieu == 0) return;
            var dateEdit = (DateEdit)sender;
            var hide = 0;
            foreach (var item in _list)
            {
                if (item != dateEdit.DateTime.Day) continue;
                hide = 1;
            }
            if (dateEdit.EditValue == null) return;
            if (dateEdit.DateTime.DayOfWeek != 0 && hide != 1) return;
            dateEdit.EditValue = null;
        }
        private void dateChonBD_DrawItem(object sender, CustomDrawDayNumberCellEventArgs e)
        {
            if (_coHieu == 0) return;
            var hide = 0;
            foreach (var item in _list)
            {
                if (item != e.Date.Day) continue;
                hide = 1;
            }
            if (e.Selected)
            {
                AllowClosePopup = true;
            }
            if (e.Date.DayOfWeek != 0 && hide != 1) return;
            e.Style.ForeColor = Color.White;
            if (e.Selected)
            {
                AllowClosePopup = false;
            }
        }
        #endregion

        #region Chọn ngày kết thúc
        private void dateChonKT_TextChanged(object sender, EventArgs e)
        {
            if (_coHieu == 0 || luChonNV.EditValue == null || dateChonKT.EditValue == null || dateChonBD.EditValue == null) return;
            var soNgayNghi = dateChonKT.DateTime.Day - dateChonBD.DateTime.Day - AbsentBus.TongNgayChuNhat(dateChonKT.DateTime, dateChonBD.DateTime) + 1;
            txtSoNgayNghi.Text = soNgayNghi.ToString();
            if (DaysRemainBus.GetAbsentType(luChonNV.EditValue.ToString(), dateChonKT.DateTime.Year, soNgayNghi, _soNgayNghiCoLuong))
            {
                rbCoLuong.Enabled = true;
                rbKhongLuong.Enabled = true;
                rbCoLuong.Checked = true;
            }
            else
            {
                rbCoLuong.Enabled = false;
                rbKhongLuong.Enabled = true;
                rbKhongLuong.Checked = true;
            }
        }
        private void dateChonKT_DateTimeChanged(object sender, EventArgs e)
        {
            if (_coHieu == 0) return;
            var dateEdit = (DateEdit)sender;
            var hide = 0;
            foreach (var item in _list)
            {
                if (item != dateEdit.DateTime.Day) continue;
                hide = 1;
            }
            if (dateEdit.EditValue == null) return;
            if (dateEdit.DateTime.DayOfWeek != 0 && hide != 1) return;
            dateEdit.EditValue = null;
        }
        private void dateChonKT_QueryCloseUp(object sender, CancelEventArgs e)
        {
            if (_coHieu == 0) return;
            e.Cancel = !AllowClosePopup;
        }
        private void dateChonKT_DrawItem(object sender, CustomDrawDayNumberCellEventArgs e)
        {
            if (_coHieu == 0) return;
            var hide = 0;
            foreach (var item in _list)
            {
                if (item != e.Date.Day) continue;
                hide = 1;
            }
            if (e.Selected)
            {
                AllowClosePopup = true;
            }
            if (e.Date.DayOfWeek != 0 && hide != 1) return;
            e.Style.ForeColor = Color.White;
            if (e.Selected)
            {
                AllowClosePopup = false;
            }
        }
        #endregion

        #region Set Button, Text, Clear
        /// <summary>
        /// Set trường Text
        /// </summary>
        /// <param name="val"> = true các trường text được mở, girdata ẩn</param>
        private void SetText(bool val)
        {
            luChonNV.Enabled = val;
            dateChonBD.Enabled = val;
            dateChonKT.Enabled = val;
            txtSoNgayNghi.Enabled = false;
            rbCoLuong.Enabled = val;
            rbKhongLuong.Enabled = val;
            txtGhiChu.Enabled = val;
            gcAbsent.Enabled = !val;
        }
        /// <summary>
        /// Set các nút Thêm, lưu, hủy
        /// </summary>
        /// <param name="val"> = true nút thêm được mở</param>
        private void SetButton(bool val)
        {
            btnAdd.Enabled = val;
            btnSave.Enabled = !val;
            btnCancel.Enabled = !val;
        }
        /// <summary>
        /// Xóa các trường text
        /// </summary>
        private void Clear()
        {
            luChonNV.EditValue = null;
            dateChonBD.EditValue = null;
            dateChonKT.EditValue = null;
            txtSoNgayNghi.Text = @"0";
            txtGhiChu.Text = null;
            rbCoLuong.Checked = true;
            _list.Clear();
            _soNgayNghiCoLuong = 0;
        }
        #endregion

        #region Chức năng thêm, xóa, sửa, lưu
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _coHieu = 1;
            Clear();
            SetText(true);
            SetButton(false);
            dateChonBD.Enabled = false;
            dateChonKT.Enabled = false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _coHieu = 0;
            Clear();
            SetText(false);
            SetButton(true);
        }

        private void edit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            _coHieu = 2;
            if (FromDate != null)
                _ngayBatDau = DateTime.Parse(gridView1.GetFocusedRowCellDisplayText(FromDate)).Day;
            if (ToDate != null) _ngayKetThuc = DateTime.Parse(gridView1.GetFocusedRowCellDisplayText(ToDate)).Day;
            SetText(true);
            luChonNV.Enabled = false;
            SetButton(false);
            var absentType = gridView1.GetFocusedRowCellDisplayText(AbsentType);
            if (absentType != null && absentType != "Có lương")
            {
                rbKhongLuong.Checked = true;
            }
            else
            {
                rbCoLuong.Checked = true;
                if (AbsentDay != null)
                    _soNgayNghiCoLuong = int.Parse(gridView1.GetFocusedRowCellDisplayText(AbsentDay));
            }
            if (StaffID != null) luChonNV.EditValue = gridView1.GetFocusedRowCellDisplayText(StaffID);
            NgayDaNghi();
            if (FromDate != null)
                dateChonBD.DateTime = DateTime.Parse(gridView1.GetFocusedRowCellDisplayText(FromDate));
            if (ToDate != null)
                dateChonKT.DateTime = DateTime.Parse(gridView1.GetFocusedRowCellDisplayText(ToDate));
            txtGhiChu.Text = gridView1.GetFocusedRowCellDisplayText(Note);
            if (AbsentDay != null) txtSoNgayNghi.Text = gridView1.GetFocusedRowCellDisplayText(AbsentDay);
        }

        private void delete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (DateTime.Parse(gridView1.GetFocusedRowCellDisplayText(FromDate)).Month != DateTime.Now.Month ||
                DateTime.Parse(gridView1.GetFocusedRowCellDisplayText(FromDate)).Year != DateTime.Now.Year)
            {
                XtraMessageBox.Show("Bạn không được xóa nghĩ phép này!");
            }
            else
            {
                var dialog = XtraMessageBox.Show($"Nhân viên: {gridView1.GetFocusedRowCellDisplayText(StaffName)}" +
                                                 $"\nTừ: {gridView1.GetFocusedRowCellDisplayText(FromDate)}" +
                                                 $" - đến: {gridView1.GetFocusedRowCellDisplayText(ToDate)}" +
                                                 $"\nNghĩ: {gridView1.GetFocusedRowCellDisplayText(AbsentType)}",
                    "XÓA NGHĨ PHÉP", MessageBoxButtons.YesNo);
                try
                {
                    if (dialog == DialogResult.Yes)
                    {
                        AbsentBus.DeleteAbsent(int.Parse(gridView1.GetFocusedRowCellDisplayText(AbsentID)));
                    }
                }
                catch
                {
                    XtraMessageBox.Show("Lỗi xóa!");
                }
                ucAbsent_Load(sender, e);
            }
        }
        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName != "edit" && e.Column.FieldName != "delete") return;
            var kpm = (DateTime)gridView1.GetRowCellValue(Convert.ToInt32(e.RowHandle), "ToDate");
            var maxValue = AbsentBus.MaxValue((string)gridView1.GetRowCellValue(Convert.ToInt32(e.RowHandle), "StaffID"));
            if (kpm.Month == DateTime.Now.Month && kpm.Day == maxValue) return;
            using (var hide = new RepositoryItemButtonEdit())
            {
                hide.Buttons[0].Enabled = true;
                e.RepositoryItem = hide;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (luChonNV.EditValue != null && dateChonBD.EditValue != null && dateChonKT.EditValue != null)
            {
                switch (_coHieu)
                {
                    case 1:
                        if (AbsentBus.SaveAbsent(luChonNV.EditValue.ToString(), dateChonBD.DateTime, dateChonKT.DateTime,
                            rbCoLuong.Checked, txtGhiChu.Text))
                            ucAbsent_Load(sender, e);
                        else
                            XtraMessageBox.Show("Có lỗi trong quá trình thêm");
                        break;
                    case 2:
                        if (AbsentBus.UpdateAbsent(int.Parse(gridView1.GetFocusedRowCellDisplayText(AbsentID)),
                            luChonNV.EditValue.ToString(), dateChonBD.DateTime, dateChonKT.DateTime, rbCoLuong.Checked,
                            txtGhiChu.Text))
                            ucAbsent_Load(sender, e);
                        else
                            XtraMessageBox.Show("Có lỗi trong quá trình sửa");
                        break;
                }
                Clear();
                SetText(false);
                SetButton(true);
                _coHieu = 0;
            }
            else
            {
                XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
        }

        private void txtGhiChu_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue?.ToString().Length > 100 || e.NewValue?.ToString() == "  ")
                e.Cancel = true;
        }
        #endregion

        #region Xử lý trong DataGirdView
        private void gcAbsent_Click(object sender, EventArgs e)
        {
            Clear();
            if (StaffID != null) luChonNV.EditValue = gridView1.GetFocusedRowCellDisplayText(StaffID);
            if (FromDate != null) dateChonBD.Text = gridView1.GetFocusedRowCellDisplayText(FromDate);
            if (ToDate != null) dateChonKT.Text = gridView1.GetFocusedRowCellDisplayText(ToDate);
            if (Note != null) txtGhiChu.Text = gridView1.GetFocusedRowCellDisplayText(Note);
            if (AbsentDay != null) txtSoNgayNghi.Text = gridView1.GetFocusedRowCellDisplayText(AbsentDay);
            if (AbsentType == null) return;
            var absentType = gridView1.GetFocusedRowCellDisplayText(AbsentType);
            if (absentType == null || absentType != "Có lương")
                rbKhongLuong.Checked = true;
            else
                rbCoLuong.Checked = true;
        }
        #endregion
    }
}