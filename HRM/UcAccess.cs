﻿using System;
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
        private readonly AccessBus _accessBus = new AccessBus();
        public int CoHieu, MaGroupAccess;
        public readonly List<int> Rows = new List<int>();
        public string TenNhomQuyen;
        public Session Session = new Session();
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
            gridAccess.DataSource = null;
            gridControl2.DataSource = _accessBus.GetAllGroupAccess();
            SetText(false);
            SetButton(true);

        }
        #endregion

        #region Grid View Danh sách quyền
        private void gridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CoHieu == 0) return;
            Rows.Clear();
            foreach (var i in gridView1.GetSelectedRows())
            {
                var d = (int)gridView1.GetRowCellValue(Convert.ToInt32(i), "AccessID");
                Rows.Add(d);
            }
        }
        #endregion

        #region Grid View Danh sách nhóm quyền
        private void gridView2_Click(object sender, EventArgs e)
        {
            Clear();
            txtTenNhom.Text = gridView2.GetFocusedRowCellDisplayText(GroupAccessName);
            txtMoTa.Text = gridView2.GetFocusedRowCellDisplayText(Description);
            gridAccess.DataSource = _accessBus.ListAccessesByGroupAccesses(int.Parse(gridView2.GetFocusedRowCellDisplayText(GroupAccessID)));
            gridView1.SelectAll();
        }
        private void gridView2_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName != "Delete") return;
            var kpm = (int)gridView2.GetRowCellValue(Convert.ToInt32(e.RowHandle), "GroupAccessID");
            if (!_accessBus.CheckGroupAccessesUsing(kpm)) return;
            using (var hide = new RepositoryItemButtonEdit())
            {
                hide.Buttons[0].Enabled = true;
                e.RepositoryItem = hide;
            }
        }
        #endregion

        #region Set Text, Button
        private void SetCheck(IEnumerable<int> list)
        {
            gridAccess.DataSource = _accessBus.LoadAllAccess();
            foreach (var item in list)
            {
                var rowHandle = gridView1.LocateByValue("AccessID", item);
                gridView1.SelectRow(rowHandle);
            }
        }
        private void SetText(bool val)
        {
            gridAccess.Enabled = val;
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
            Rows.Clear();
            gridView1.ClearSelection();
            MaGroupAccess = 0;
            TenNhomQuyen = null;
            lbThongBao.Text = null;
        }
        #endregion

        #region Thêm, xóa, sửa
        private void btnAdd_Click(object sender, EventArgs e)
        {
            TenNhomQuyen = null;
            CoHieu = 1;
            gridAccess.DataSource = _accessBus.LoadAllAccess();
            Clear();
            SetButton(false);
            SetText(true);
        }
        private void btnEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Clear();
            CoHieu = 2;
            MaGroupAccess = int.Parse(gridView2.GetFocusedRowCellDisplayText(GroupAccessID));
            TenNhomQuyen = gridView2.GetFocusedRowCellDisplayText(GroupAccessName);
            SetButton(false);
            SetText(true);
            txtTenNhom.Text = gridView2.GetFocusedRowCellDisplayText(GroupAccessName);
            txtMoTa.Text = gridView2.GetFocusedRowCellDisplayText(Description);
            SetCheck(_accessBus.ListAccesses(MaGroupAccess));
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
            if (CoHieu == 1 && !_accessBus.AddGroupAccess(ten, mota, Rows))
                XtraMessageBox.Show("Lỗi thêm!");
            if (CoHieu == 2 && !_accessBus.UpdateGroupAccesses(MaGroupAccess, ten, mota, Rows))
                XtraMessageBox.Show("Lỗi sửa!");
            SetText(false);
            SetButton(true);
            CoHieu = 0;
            UcAccess_Load(sender, e);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CoHieu = 0;
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
            if (CoHieu == 0) return;
            btnSave.Enabled = false;
            if (txtTenNhom.Text.Length >= 4)
            {
                var list = _accessBus.ListNameGroupAccesses();
                var check = _accessBus.CheckNameGroupAccesses(TenNhomQuyen, txtTenNhom.Text, CoHieu, list);
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
