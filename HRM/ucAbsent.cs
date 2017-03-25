using System;
using System.Collections.Generic;
using System.Drawing;
using BUS;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Calendar;
using System.Linq;
using System.Windows.Forms;

namespace HRM
{
    public partial class UcAbsent : XtraUserControl
    {
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        public readonly AbsentBus AbsentBus = new AbsentBus();
        public bool AllowClosePopup = true;
        private readonly List<int> _list = new List<int>();
        private int _coHieu;
        private int _ngayBatDau, _ngayKetThuc;
        public UcAbsent()
        {
            InitializeComponent();
            SetText(false);
            SetButton(true);
        }
        private void ucAbsent_Load(object sender, EventArgs e)
        {
            gcAbsent.DataSource = AbsentBus.GetAbsent();
            LoadluChonNv();
            dateChonBD.Properties.MinValue = AbsentBus.NgayDauThang(DateTime.Now);
            dateChonBD.Properties.MaxValue = AbsentBus.NgayCuoiThang(DateTime.Now).AddDays(-1);
            dateChonKT.Properties.MinValue = AbsentBus.NgayDauThang(DateTime.Now);
            dateChonKT.Properties.MaxValue = AbsentBus.NgayCuoiThang(DateTime.Now);
        }
        private void Clear()
        {
            luChonNV.SelectedText = null;
            dateChonBD.SelectionStart = 0;
            dateChonKT.Enabled = false;
            txtSoNgayNghi.Text = null;
            txtGhiChu.Text = null;
            rbCoLuong.Checked = true;
            _list.Clear();
        }
        #region Chọn nhân viên
        private void NgayDaNghi()
        {
            _list.AddRange(AbsentBus.ListNgayNghi(luChonNV.EditValue.ToString(), DateTime.Now));
            if (_coHieu != 2) return;
            for (var i = _ngayBatDau; i < _ngayKetThuc; i++)
            {
                _list.Remove(i);
            }
        }
        private void luChonNV_TextChanged(object sender, EventArgs e)
        {
            _list.Clear();
            NgayDaNghi();
            dateChonBD.EditValue = null;
            dateChonKT.EditValue = null;
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
            dateChonKT.DateTime = dateChonBD.DateTime.AddDays(1);
        }
        private void dateChonBD_QueryCloseUp(object sender, System.ComponentModel.CancelEventArgs e)
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
            txtSoNgayNghi.Text = (dateChonKT.DateTime.Day - dateChonBD.DateTime.Day -
                    AbsentBus.TongNgayChuNhat(dateChonKT.DateTime, dateChonBD.DateTime)).ToString();
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
        private void dateChonKT_QueryCloseUp(object sender, System.ComponentModel.CancelEventArgs e)
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
        private void gcAbsent_Click(object sender, EventArgs e)
        {
            luChonNV.EditValue = gridView1.GetFocusedRowCellDisplayText(StaffID);
            dateChonBD.Text = gridView1.GetFocusedRowCellDisplayText(FromDate);
            dateChonKT.Text = gridView1.GetFocusedRowCellDisplayText(ToDate);
            txtGhiChu.Text = gridView1.GetFocusedRowCellDisplayText(Note);
            txtSoNgayNghi.Text = gridView1.GetFocusedRowCellDisplayText(AbsentDay);
            var absentType = gridView1.GetFocusedRowCellDisplayText(AbsentType);
            if (absentType == "Có lương")
                rbCoLuong.Checked = true;
            else
                rbKhongLuong.Checked = true;
        }
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
        #region Chức năng thêm, xóa, sửa, lưu
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _coHieu = 1;
            Clear();
            SetText(true);
            SetButton(false);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            SetText(false);
            SetButton(true);
        }
        private void edit_Click(object sender, EventArgs e)
        {
            _coHieu = 2;
            SetText(true);
            luChonNV.Enabled = false;
            SetButton(false);
            _ngayBatDau = DateTime.Parse(gridView1.GetFocusedRowCellDisplayText(FromDate)).Day;
            _ngayKetThuc = DateTime.Parse(gridView1.GetFocusedRowCellDisplayText(ToDate)).Day;
            luChonNV.EditValue = gridView1.GetFocusedRowCellDisplayText(StaffID);
            NgayDaNghi();
            dateChonBD.DateTime = DateTime.Parse(gridView1.GetFocusedRowCellDisplayText(FromDate));
            dateChonKT.DateTime = DateTime.Parse(gridView1.GetFocusedRowCellDisplayText(ToDate));
            txtGhiChu.Text = gridView1.GetFocusedRowCellDisplayText(Note);
            txtSoNgayNghi.Text = gridView1.GetFocusedRowCellDisplayText(AbsentDay);
            var absentType = gridView1.GetFocusedRowCellDisplayText(AbsentType);
            if (absentType != null && absentType != "Có lương")
                rbKhongLuong.Checked = true;
            else
                rbCoLuong.Checked = true;
        }
        private void delete_Click(object sender, EventArgs e)
        {
            var dialog = XtraMessageBox.Show($"Bạn muốn xóa nghĩ phép của nhân viên: {gridView1.GetFocusedRowCellDisplayText(StaffName)}!" +
                                             $"\nNgày bắt đầu: {gridView1.GetFocusedRowCellDisplayText(FromDate)}" +
                                             $"\nNgày kết thúc: {gridView1.GetFocusedRowCellDisplayText(ToDate)}" +
                                             $"\nLoại nghĩ: {gridView1.GetFocusedRowCellDisplayText(AbsentType)}", "Xóa nhân viên", MessageBoxButtons.YesNo);
            try
            {
                if (dialog == DialogResult.Yes)
                {
                    AbsentBus.DeleteAbsent(int.Parse(gridView1.GetFocusedRowCellDisplayText(AbsentID)));
                }
            }
            catch
            {
                // ignored
            }
            ucAbsent_Load(sender, e);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (luChonNV.EditValue != null && dateChonBD.EditValue != null && dateChonKT.EditValue != null)
            {
                switch (_coHieu)
                {
                    case 1:
                        if (!AbsentBus.SaveAbsent(luChonNV.EditValue.ToString(), dateChonBD.DateTime,
                            dateChonKT.DateTime, rbCoLuong.Checked, txtGhiChu.Text))
                            XtraMessageBox.Show("Có lỗi trong quá trình thêm");
                        else
                            ucAbsent_Load(sender, e);
                        break;
                    case 2:
                        if (!AbsentBus.UpdateAbsent(int.Parse(gridView1.GetFocusedRowCellDisplayText(AbsentID)),
                            luChonNV.EditValue.ToString(), dateChonBD.DateTime, dateChonKT.DateTime, rbCoLuong.Checked,
                            txtGhiChu.Text))
                            XtraMessageBox.Show("Có lỗi trong quá trình sửa");
                        else
                            ucAbsent_Load(sender, e);
                        break;
                }
                Clear();
                SetText(false);
                SetButton(true);
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn đầy đủ thông tin!");
            }
        }
        #endregion
    }
}
