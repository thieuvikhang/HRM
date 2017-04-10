using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BUS;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace HRM
{
    public partial class UcAccess : XtraUserControl
    {
        #region Khai báo biến
        public Session Session = new Session();
        private readonly AccessBus _accessBus = new AccessBus();
        private readonly List<int> _rows = new List<int>();
        private int _coHieu, _maGroupAccess;
        private string _tenNhomQuyen;
        #endregion

        #region Load Form
        public UcAccess()
        {
            InitializeComponent();
            btnSave.Enabled = false;
        }

        private void UcAccess_Load(object sender, EventArgs e)
        {
            var access = int.Parse(Session["Access"].ToString());
            if (access != 1)
            {
                groupBox2.Visible = false;
                btnAdd.Visible = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;
                gridView2.Columns[3].Visible = false;
                gridView2.Columns[4].Visible = false;
            }
            gridAccessEdit.DataSource = null;
            gridAccessView.DataSource = null;
            gridControl2.DataSource = _accessBus.GetAllGroupAccess();
            SetText(false);
            SetButton(true);
        }
        #endregion

        #region Grid View Danh sách quyền
        private void gridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_coHieu == 0) return;
            _rows.Clear();
            for (var index = 0; index < gridViewEdit.GetSelectedRows().Length; index++)
            {
                var i = gridViewEdit.GetSelectedRows()[index];
                var accessId = (int)gridViewEdit.GetRowCellValue(Convert.ToInt32(i), "AccessID");
                _rows.Add(accessId);
                var accessName = (string)gridViewEdit.GetRowCellValue(Convert.ToInt32(i), "Form");
                var rowHandle = gridViewView.LocateByValue("Form", accessName);
                gridViewView.UnselectRow(rowHandle);
            }
            for (var index = 0; index < gridViewView.GetSelectedRows().Length; index++)
            {
                var i = gridViewView.GetSelectedRows()[index];
                var accessId = (int)gridViewView.GetRowCellValue(Convert.ToInt32(i), "AccessID");
                _rows.Add(accessId);
            }
        }
        private void gridViewView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_coHieu == 0) return;
            _rows.Clear();
            for (var index = 0; index < gridViewView.GetSelectedRows().Length; index++)
            {
                var i = gridViewView.GetSelectedRows()[index];
                var accessId = (int)gridViewView.GetRowCellValue(Convert.ToInt32(i), "AccessID");
                _rows.Add(accessId);
                var accessName = (string)gridViewView.GetRowCellValue(Convert.ToInt32(i), "Form");
                var rowHandle = gridViewEdit.LocateByValue("Form", accessName);
                gridViewEdit.UnselectRow(rowHandle);
            }
            for (var index = 0; index < gridViewEdit.GetSelectedRows().Length; index++)
            {
                var i = gridViewEdit.GetSelectedRows()[index];
                var accessId = (int)gridViewEdit.GetRowCellValue(Convert.ToInt32(i), "AccessID");
                _rows.Add(accessId);
            }
        }

        #endregion

        #region Grid View Danh sách nhóm quyền
        private void gridView2_Click(object sender, EventArgs e)
        {
            Clear();
            txtTenNhom.Text = gridView2.GetFocusedRowCellDisplayText(GroupAccessName);
            txtMoTa.Text = gridView2.GetFocusedRowCellDisplayText(Description);
            var groupAccessId = int.Parse(gridView2.GetFocusedRowCellDisplayText(GroupAccessID));
            gridAccessEdit.DataSource = _accessBus.ListAccessesByGroupAccesses(groupAccessId , true);
            gridAccessView.DataSource = _accessBus.ListAccessesByGroupAccesses(groupAccessId, false);
            gridViewEdit.SelectAll();
            gridViewView.SelectAll();
        }
        private void gridView2_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName != "Delete") return;
            var kpm = (int)gridView2.GetRowCellValue(Convert.ToInt32(e.RowHandle), "GroupAccessID");
            if (!_accessBus.CheckGroupAccessesUsing(kpm)) return;
            using (var hide = new RepositoryItemButtonEdit())
            {
                hide.Buttons[0].Visible = true;
                e.RepositoryItem = hide;
            }
        }
        #endregion

        #region Set Text, Button
        private void SetCheck(int ma)
        {
            gridAccessEdit.DataSource = _accessBus.LoadAllAccess(true);
            gridAccessView.DataSource = _accessBus.LoadAllAccess(false);
            foreach (var item in _accessBus.ListAccesses(ma, true))
            {
                var rowHandle = gridViewEdit.LocateByValue("AccessID", item);
                gridViewEdit.SelectRow(rowHandle);
            }
            foreach (var item in _accessBus.ListAccesses(ma, false))
            {
                var rowHandle = gridViewView.LocateByValue("AccessID", item);
                gridViewView.SelectRow(rowHandle);
            }
        }
        private void SetText(bool val)
        {
            gridAccessEdit.Enabled = val;
            gridAccessView.Enabled = val;
            txtMoTa.Enabled = val;
            txtTenNhom.Enabled = val;
            gridControl2.Enabled = !val;
        }
        private void SetButton(bool val)
        {
            btnAdd.Enabled = val;
            btnCancel.Enabled = !val;
            btnSave.Enabled = false;
        }
        private void Clear()
        {
            txtTenNhom.Text = null;
            txtMoTa.Text = null;
            _rows.Clear();
            gridViewEdit.ClearSelection();
            gridViewView.ClearSelection();
            _maGroupAccess = 0;
            _tenNhomQuyen = null;
            lbThongBao.Text = null;
        }
        #endregion

        #region Thêm, xóa, sửa
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _tenNhomQuyen = null;
            _coHieu = 1;
            gridAccessEdit.DataSource = _accessBus.LoadAllAccess(true);
            gridAccessView.DataSource = _accessBus.LoadAllAccess(false);
            Clear();
            SetButton(false);
            SetText(true);
        }
        private void btnEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Clear();
            _coHieu = 2;
            _maGroupAccess = int.Parse(gridView2.GetFocusedRowCellDisplayText(GroupAccessID));
            _tenNhomQuyen = gridView2.GetFocusedRowCellDisplayText(GroupAccessName);
            SetButton(false);
            SetText(true);
            txtTenNhom.Text = _tenNhomQuyen;
            txtMoTa.Text = gridView2.GetFocusedRowCellDisplayText(Description);
            SetCheck(_maGroupAccess);
        }
        private void btnDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var dialog = XtraMessageBox.Show($"Nhóm quyền: {gridView2.GetFocusedRowCellDisplayText(GroupAccessName)}" +
                                 $"\nMô tả: {gridView2.GetFocusedRowCellDisplayText(Description)}",
                                 "XÓA NHÓM QUYỀN", MessageBoxButtons.YesNo);
            try
            {
                if (dialog != DialogResult.Yes) return;
                _accessBus.DeleteGroupAccesses(int.Parse(gridView2.GetFocusedRowCellDisplayText(GroupAccessID)));
            }
            catch
            {
                XtraMessageBox.Show("Lỗi xóa!");
            }
            UcAccess_Load(sender, e);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var ten = txtTenNhom.Text;
            var mota = txtMoTa.Text;
            if (_coHieu == 1 && !_accessBus.AddGroupAccess(ten, mota, _rows))
                XtraMessageBox.Show("Lỗi thêm!");
            if (_coHieu == 2 && !_accessBus.UpdateGroupAccesses(_maGroupAccess, ten, mota, _rows))
                XtraMessageBox.Show("Lỗi sửa!");
            SetText(false);
            SetButton(true);
            _coHieu = 0;
            UcAccess_Load(sender, e);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _coHieu = 0;
            Clear();
            SetText(false);
            SetButton(true);
            UcAccess_Load(sender, e);
        }
        #endregion

        #region Validate
        private void txtMoTa_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue?.ToString().Length > 100 || e.NewValue?.ToString() == "  ")
                e.Cancel = true;
        }
        private void txtTenNhom_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue?.ToString().Length > 50 || e.NewValue?.ToString() == "  ")
                e.Cancel = true;
        }

        private void txtTenNhom_TextChanged(object sender, EventArgs e)
        {
            if (_coHieu == 0) return;
            btnSave.Enabled = false;
            if (txtTenNhom.Text.Length >= 4)
            {
                var list = _accessBus.ListNameGroupAccesses();
                var check = _accessBus.CheckNameGroupAccesses(_tenNhomQuyen, txtTenNhom.Text, _coHieu, list);
                if (check)
                {
                    lbThongBao.ForeColor = Color.Blue;
                    lbThongBao.Text = @"Chấp Nhận";
                    btnSave.Enabled = true;
                }
                else
                {
                    lbThongBao.ForeColor = Color.Red;
                    lbThongBao.Text = @"Tên Nhóm Quyền Đã Được Dùng";
                }
            }
            else
            {
                lbThongBao.ForeColor = Color.Red;
                lbThongBao.Text = @"Tên Nhóm Quyền Qúa Ngắn";
            }
        }
        #endregion
    }
}