using System;
using System.Collections.Generic;
using System.Drawing;
using BUS;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Calendar;
using System.Linq;

namespace HRM
{
    public partial class UcAbsent : XtraUserControl
    {
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        public readonly AbsentBus AbsentBus = new AbsentBus();
        public bool AllowClosePopup = true;
        private readonly List<int> _list = new List<int>();

        public UcAbsent()
        {
            InitializeComponent();
        }

        private void ucAbsent_Load(object sender, EventArgs e)
        {
            gcAbsent.DataSource = AbsentBus.GetAbsent();
            LoadluChonNv();
        }

        private void panelControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void delete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
        }

        private void edit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
        }

        private void edit_Click(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AbsentBus.SaveAbsent(luChonNV.EditValue.ToString(), dateChonBD.DateTime, dateChonKT.DateTime,
                rbCoLuong.Checked, txtGhiChu.Text))
            {
                ucAbsent_Load(sender, e);
                Clear();
            }
            else
            {
                XtraMessageBox.Show("Lỗi");
                Clear();
            }
        }

        private void HideLuu(bool b)
        {
            if (!b)
            {
                btnSave.Enabled = false;
            }
            else
            {
                if (luChonNV.SelectionStart <= 0 || !(dateChonBD.SelectionStart > 0 & dateChonKT.SelectionStart > 0))
                    return;
                btnSave.Enabled = true;
            }
        }
        private void Clear()
        {
            luChonNV.ItemIndex = -1;
            dateChonBD.SelectionStart = 0;
            dateChonKT.Enabled = false;
            txtSoNgayNghi.Text = null;
            txtGhiChu.Text = null;
            rbCoLuong.Checked = true;
        }


        #region Chọn nhân viên
        private void LoadDateChonBd()
        {
            dateChonBD.Properties.MinValue = AbsentBus.NgayDauThang(DateTime.Now);
            dateChonBD.Properties.MaxValue = AbsentBus.NgayCuoiThang(DateTime.Now);
            dateChonBD.DateTime = DateTime.Now;
            dateChonKT.DateTime = DateTime.Now.AddDays(1);
        }
        private void luChonNV_TextChanged(object sender, EventArgs e)
        {
            LoadDateChonBd();
            dateChonBD.Enabled = true;
            _list.AddRange(AbsentBus.ListNgayNghi(luChonNV.EditValue.ToString(), DateTime.Now));
        }
        private void LoadluChonNv()
        {
            var nv = from staff in _aHrm.Staffs
                     select new
                     {
                         ID = staff.StaffID,
                         Name = staff.StaffName
                     };
            luChonNV.Properties.DataSource = nv.ToList();
            luChonNV.Properties.ValueMember = "ID";
            luChonNV.Properties.DisplayMember = "Name";
            dateChonBD.Enabled = false;
            dateChonKT.Enabled = false;
            HideLuu(true);
        }


        #endregion

        #region Chọn ngày bắt đầu
        private void dateChonBD_TextChanged(object sender, EventArgs e)
        {
            dateChonKT.Properties.MinValue = dateChonBD.DateTime;
            dateChonKT.Properties.MaxValue = AbsentBus.NgayCuoiThang(DateTime.Now);
            dateChonKT.SelectedText = dateChonBD.SelectedText;
            dateChonKT.Enabled = true;
        }
        private void dateChonBD_QueryCloseUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !AllowClosePopup;
        }
        private void dateChonBD_DateTimeChanged(object sender, EventArgs e)
        {
            var dateEdit = (DateEdit)sender;
            var coHieu = 0;
            foreach (var item in _list)
            {
                if (item != dateEdit.DateTime.Day) continue;
                coHieu = 1;
            }
            if (dateEdit.EditValue == null) return;
            if (dateEdit.DateTime.DayOfWeek != 0 && coHieu != 1) return;
            dateEdit.EditValue = null;
        }
        private void dateChonBD_DrawItem(object sender, CustomDrawDayNumberCellEventArgs e)
        {
            var coHieu = 0;
            foreach (var item in _list)
            {
                if (item != e.Date.Day) continue;
                coHieu = 1;
            }
            if (e.Selected)
            {
                AllowClosePopup = true;
            }
            if (e.Date.DayOfWeek != 0 && coHieu != 1) return;
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
            var dateEdit = (DateEdit)sender;
            var coHieu = 0;
            foreach (var item in _list)
            {
                if (item != dateEdit.DateTime.Day) continue;
                coHieu = 1;
            }
            if (dateEdit.EditValue == null) return;
            if (dateEdit.DateTime.DayOfWeek != 0 && coHieu != 1) return;
            dateEdit.EditValue = null;
        }

        private void dateChonKT_QueryCloseUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !AllowClosePopup;
        }
        private void dateChonKT_DrawItem(object sender, CustomDrawDayNumberCellEventArgs e)
        {
            var coHieu = 0;
            foreach (var item in _list)
            {
                if (item != e.Date.Day) continue;
                coHieu = 1;
            }
            if (e.Selected)
            {
                AllowClosePopup = true;
            }
            if (e.Date.DayOfWeek != 0 && coHieu != 1) return;
            e.Style.ForeColor = Color.White;
            if (e.Selected)
            {
                AllowClosePopup = false;
            }
        }
        #endregion
    }
}
