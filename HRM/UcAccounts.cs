using System;
using System.Drawing;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace HRM
{
    public partial class UcAccounts : XtraUserControl
    {
        #region Khai báo biến
        public Session Session = new Session();
        private readonly AccessBus _accessBus = new AccessBus();
        private readonly AccountBus _accountBus = new AccountBus();
        private int _maNhomQuyen = -1, _maTaiKhoan, _coHieu;
        private string _maNhanVien;
        #endregion

        #region Load
        public UcAccounts()
        {
            InitializeComponent();
            btnSave.Enabled = false;
        }

        private void UcAccounts_Load(object sender, EventArgs e)
        {
            var access = int.Parse(Session["Access"].ToString());
            if (access != 1)
            {
                groupBox3.Visible = false;
                btnAdd.Visible = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;
                gvTaiKhoan.Columns[5].Visible = false;
                gvTaiKhoan.Columns[6].Visible = false;
            }
            gcNhomQuyen.DataSource = null;
            gcNhanVien.DataSource = null;
            gcTaiKhoan.DataSource = _accountBus.GetAllAccount();
            SetText(false);
            SetButton(true);
        }
        #endregion

        #region Set Text, Button
        private void SetText(bool val)
        {
            gcNhanVien.Enabled = val;
            gcNhomQuyen.Enabled = val;
            txtMatKhau.Enabled = false;
            txtNhapLaiMatKhau.Enabled = false;
            txtTaiKhoang.Enabled = false;
            gcTaiKhoan.Enabled = !val;
        }
        private void SetButton(bool val)
        {
            btnAdd.Enabled = val;
            btnCancel.Enabled = !val;
            btnSave.Enabled = false;
        }
        private void Clear()
        {
            gvPhongBan.ClearSelection();
            gvNhanVien.ClearSelection();
            txtTaiKhoang.Text = null;
            txtMatKhau.Text = @"**********";
            txtNhapLaiMatKhau.Text = @"**********";
            txtThongBao.Text = null;
            txtThongBaoMK.Text = null;
            txtThongBaoNLMK.Text = null;
            _maNhanVien = null;
            _maNhomQuyen =-1;
        }
        private void SetCheck(int ma)
        {
            gcNhomQuyen.DataSource = _accessBus.GetAllGroupAccess1();
            gcNhanVien.DataSource = _accountBus.GetStaffByAccountId(ma);
            var row = gvPhongBan.LocateByValue("GroupAccessName", gvTaiKhoan.GetFocusedRowCellDisplayText(GroupAccessName1));
            gvPhongBan.SelectRow(row);
            gvNhanVien.SelectAll();
        }
        #endregion

        #region Thêm, xóa, sửa
        private void btEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            _coHieu = 2;
            Clear();
            SetButton(false);
            SetText(true);
            btnSave.Enabled = true;
            txtTaiKhoang.Text = gvTaiKhoan.GetFocusedRowCellDisplayText(UserName);
            _maTaiKhoan = int.Parse(gvTaiKhoan.GetFocusedRowCellDisplayText(AccID));
            gcNhanVien.Enabled = false;
            SetCheck(_maTaiKhoan);
        }
        private void btDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var dialog = XtraMessageBox.Show($"Tài khoản: {gvTaiKhoan.GetFocusedRowCellDisplayText(UserName)}" +
                                 $"\nNhóm quyền: {gvTaiKhoan.GetFocusedRowCellDisplayText(GroupAccessName1)}",
                                 "XÓA TÀI KHOẢNG", MessageBoxButtons.YesNo);
            try
            {
                if (dialog != DialogResult.Yes) return;
                _accountBus.DeleteAccount(int.Parse(gvTaiKhoan.GetFocusedRowCellDisplayText(AccID)));
            }
            catch
            {
                XtraMessageBox.Show("Lỗi xóa!");
            }
            UcAccounts_Load(sender, e);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _coHieu = 1;
            Clear();
            gcNhomQuyen.DataSource = _accessBus.GetAllGroupAccess1();
            gcNhanVien.DataSource = _accountBus.GetAllStaff();
            SetButton(false);
            SetText(true);
            txtMatKhau.Text = null;
            txtNhapLaiMatKhau.Text = null;
            txtTaiKhoang.Enabled = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_maNhomQuyen == -1)
            {
                XtraMessageBox.Show("Vui Lòng Chọn Một Nhóm Quyền!");
                return;
            }
            if (_coHieu == 1 && !_accountBus.AddAccountNew(txtTaiKhoang.Text, txtMatKhau.Text, _maNhomQuyen, _maNhanVien))
            {
                XtraMessageBox.Show("Lỗi thêm!");
            }
            if (_coHieu == 2 && !_accountBus.UpdateAccount(_maTaiKhoan, _maNhomQuyen, _maNhanVien))
            {
                XtraMessageBox.Show("Lỗi sửa!");
            }
            Clear();
            SetText(false);
            SetButton(true);
            _coHieu = 0;
            UcAccounts_Load(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _coHieu = 0;
            Clear();
            SetText(false);
            SetButton(true);
            UcAccounts_Load(sender, e);
        }
        #endregion

        #region Validate
        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (_coHieu != 1 || txtMatKhau.Text.Length == 0) return;
            btnSave.Enabled = false;
            if (txtMatKhau.Text.Length >= 4)
            {
                txtNhapLaiMatKhau_TextChanged(sender,e);
                txtThongBaoMK.ForeColor = Color.Blue;
                txtThongBaoMK.Text = @"Chấp Nhận";
/*                if (txtMatKhau.Text.Equals(txtNhapLaiMatKhau.Text))
                {
                    txtThongBaoNLMK.ForeColor = Color.Blue;
                    txtThongBaoNLMK.Text = @"Chấp Nhận";
                    btnSave.Enabled = true;
                }
                else
                {
                    txtThongBaoNLMK.ForeColor = Color.Red;
                    txtThongBaoNLMK.Text = @"Mật Khẩu Nhập Lại Không Đúng";
                }*/
            }
            else
            {
                txtThongBaoMK.ForeColor = Color.Red;
                txtThongBaoMK.Text = @"Mật Khẩu Qúa Ngắn";
            }
        }

        private void txtNhapLaiMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (_coHieu != 1 || txtNhapLaiMatKhau.Text.Length == 0) return;
            btnSave.Enabled = false;
            if (txtMatKhau.Text.Equals(txtNhapLaiMatKhau.Text))
            {
                txtThongBaoNLMK.ForeColor = Color.Blue;
                txtThongBaoNLMK.Text = @"Chấp Nhận";
                btnSave.Enabled = true;
            }
            else
            {
                txtThongBaoNLMK.ForeColor = Color.Red;
                txtThongBaoNLMK.Text = @"Mật Khẩu Nhập Lại Không Đúng";
            }
        }

        private void txtTaiKhoang_TextChanged(object sender, EventArgs e)
        {
            if (_coHieu != 1) return;
            btnSave.Enabled = false;
            txtMatKhau.Enabled = false;
            txtNhapLaiMatKhau.Enabled = false;
            if (txtTaiKhoang.Text.Length >= 4)
            {
                var list = _accountBus.ListUserName();
                var check = _accountBus.CheckUserName(txtTaiKhoang.Text, list);
                if (check)
                {
                    txtMatKhau_TextChanged(sender, e);
                    txtThongBao.ForeColor = Color.Blue;
                    txtThongBao.Text = @"Chấp Nhận";
                    txtMatKhau.Enabled = true;
                    txtNhapLaiMatKhau.Enabled = true;
                }
                else
                {
                    txtThongBao.ForeColor = Color.Red;
                    txtThongBao.Text = @"Tên Đăng Nhập Đã Được Dùng";
                }
            }
            else
            {
                txtThongBao.ForeColor = Color.Red;
                txtThongBao.Text = @"Tên Đăng Nhập Qúa Ngắn";
            }
        }

        private void txtTaiKhoang_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue?.ToString().Length > 20 || e.NewValue?.ToString() == "  ")
                e.Cancel = true;
        }

        private void txtMatKhau_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue?.ToString().Length > 20 || e.NewValue?.ToString() == "  ")
                e.Cancel = true;
        }

        private void txtNhapLaiMatKhau_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue?.ToString().Length > 20 || e.NewValue?.ToString() == "  ")
                e.Cancel = true;
        }

        private void gvPhongBan_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            for (var index = gvPhongBan.GetSelectedRows().Length - 1; index >= 0; index--)
            {
                var i = gvPhongBan.GetSelectedRows()[index];
                var accessId = (int)gvPhongBan.GetRowCellValue(Convert.ToInt32(i), "GroupAccessID");
                _maNhomQuyen = accessId;
            }
        }

        private void gvPhongBan_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            for (var index = gvPhongBan.GetSelectedRows().Length - 1; index >= 0; index--)
            {
                var i = gvPhongBan.GetSelectedRows()[index];
                if (i == gvPhongBan.FocusedRowHandle) continue;
                gvPhongBan.UnselectRow(i);
            }
        }

        private void gvNhanVien_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            for (var index = gvNhanVien.GetSelectedRows().Length - 1; index >= 0; index--)
            {
                var i = gvNhanVien.GetSelectedRows()[index];
                if (i == gvNhanVien.FocusedRowHandle) continue;
                gvNhanVien.UnselectRow(i);
            }
        }
        private void gvNhanVien_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            for (var index = 0; index < gvNhanVien.GetSelectedRows().Length; index++)
            {
                var i = gvNhanVien.GetSelectedRows()[index];
                var accessId = (string)gvNhanVien.GetRowCellValue(Convert.ToInt32(i), "StaffID");
                _maNhanVien = accessId;
            }
        }

        private void txtTaiKhoang_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void txtNhapLaiMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void gvTaiKhoan_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName != "Delete") return;
            var kpm = (string)gvTaiKhoan.GetRowCellValue(Convert.ToInt32(e.RowHandle), "AccountStatusOnline");
            if (!kpm.Equals("Online")) return;
            using (var hide = new RepositoryItemButtonEdit())
            {
                hide.Buttons[0].Visible = true;
                e.RepositoryItem = hide;
            }
        }
        #endregion

        #region Grid View Tài Khoản
        private void gcTaiKhoan_Click(object sender, EventArgs e)
        {
            Clear();
            txtTaiKhoang.Text = gvTaiKhoan.GetFocusedRowCellDisplayText(UserName);
            gcNhomQuyen.DataSource = _accessBus.GetGroupAccess(gvTaiKhoan.GetFocusedRowCellDisplayText(GroupAccessName1));
            gcNhanVien.DataSource = _accountBus.GetStaffByAccountId(int.Parse(gvTaiKhoan.GetFocusedRowCellDisplayText(AccID)));
            gvPhongBan.SelectAll();
            gvNhanVien.SelectAll();
        }
        #endregion
    }
}