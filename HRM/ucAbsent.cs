using System;
using System.Drawing;
using BUS;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Calendar;
using DevExpress.XtraEditors.Repository;
using System.Linq;
using static System.Convert;

namespace HRM
{
    public partial class UcAbsent : XtraUserControl
    {

        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        public readonly AbsentBus AbsentBus = new AbsentBus();

        public UcAbsent()
        {
            InitializeComponent();
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
            luChonNV.SelectionStart = 0;
            dateChonBD.Enabled = false;
            dateChonKT.Enabled = false;
            HideLuu(true);
        }

        private void ucAbsent_Load(object sender, EventArgs e)
        {
            gcAbsent.DataSource = AbsentBus.GetAbsent();
            LoadluChonNv();
            dateChonBD.Properties.CalendarView = CalendarView.Vista;
            dateChonKT.Properties.CalendarView = CalendarView.Vista;
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

        private void LoadDateChonBd()
        {
            dateChonBD.Properties.MinValue = AbsentBus.NgayDauThang(DateTime.Now);
            dateChonBD.Properties.MaxValue = AbsentBus.NgayCuoiThang(DateTime.Now);
            dateChonBD.DateTime = DateTime.Now;
        }

        private void dateChonBD_TextChanged(object sender, EventArgs e)
        {
            dateChonKT.Properties.MinValue = dateChonBD.DateTime;
            dateChonKT.Properties.MaxValue = AbsentBus.NgayCuoiThang(DateTime.Now);
            dateChonKT.SelectedText = dateChonBD.SelectedText;
            dateChonKT.Enabled = true;
        }

        private void dateChonKT_TextChanged(object sender, EventArgs e)
        {
            var day = (dateChonKT.DateTime - dateChonBD.DateTime).Days -
                    AbsentBus.TongNgayChuNhat(dateChonBD.DateTime, dateChonKT.DateTime);
            txtSoNgayNghi.Text = day.ToString();
        }

        private void AnNgay(string maNv, CustomDrawDayNumberCellEventArgs e)
        {
            if (e.View != DateEditCalendarViewType.MonthInfo) return;
            if (!AbsentBus.IsHoliday(e.Date, maNv)) return;
            if (e.Selected)
            {
                e.Graphics.FillRectangle(e.Style.GetBackBrush(e.Cache), e.Bounds);
            }
            var brush = e.Highlighted ? Brushes.AntiqueWhite : Brushes.White;
            var strFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, brush, e.Bounds, strFormat);
            e.Handled = true;
        }

        private void ChanChon(string maNv, ChangingEventArgs e)
        {
            if (ToDateTime(e.NewValue, System.Globalization.CultureInfo.InvariantCulture).DayOfWeek == 0)
            {
                e.Cancel = true;
                return;
            }
            foreach (var item in _aHrm.Absents.Where(ab => ab.StaffID == maNv
                                                           && ab.FromDate.Value.Month == DateTime.Now.Month
                                                           && ab.FromDate.Value.Year == DateTime.Now.Year).Select(ab => new
                                                           {
                                                               FromDate = ab.FromDate.Value.Day,
                                                               ToDate = ab.ToDate.Value.Day
                                                           }).ToList())
            {
                if (ToDateTime(e.NewValue, System.Globalization.CultureInfo.InvariantCulture).Day >= item.FromDate)
                {
                    if (ToDateTime(e.NewValue, System.Globalization.CultureInfo.InvariantCulture).Day < item.ToDate)
                        continue;
                }
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void dateChonBD_DrawItem(object sender, CustomDrawDayNumberCellEventArgs e)
        {
            AnNgay(luChonNV.EditValue.ToString(), e);
        }

        private void dateChonBD_EditValueChanging(object sender, ChangingEventArgs e)
        {
            ChanChon(luChonNV.EditValue.ToString(), e);
        }

        private void dateChonKT_DrawItem(object sender, CustomDrawDayNumberCellEventArgs e)
        {
            //AnNgay(luChonNV.EditValue.ToString(), e);
        }

        private void dateChonKT_EditValueChanging(object sender, ChangingEventArgs e)
        {
            //ChanChon(luChonNV.EditValue.ToString(), e);

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!AbsentBus.SaveAbsent(luChonNV.EditValue.ToString(), dateChonBD.DateTime, dateChonKT.DateTime,
                rbCoLuong.Checked, txtGhiChu.Text))
            {
                XtraMessageBox.Show("Lỗi");
                Clear();
            }
            else
            {
                ucAbsent_Load(sender, e);
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
                if (luChonNV.SelectionStart > 0 && dateChonBD.SelectionStart > 0 & dateChonKT.SelectionStart > 0)
                {
                    btnSave.Enabled = true;
                }
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
        private void luChonNV_TextChanged(object sender, EventArgs e)
        {
            LoadDateChonBd();
            dateChonBD.Enabled = true;
        }
    }
}
