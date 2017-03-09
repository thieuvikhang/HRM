using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DAL;
using BUS;
using DevExpress.XtraEditors;
using System.Collections;

namespace HRM
{
    public partial class ucSalary : XtraUserControl
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();
        SalaryBUS salaryBUS = new SalaryBUS();
        staffBUS staffBUS = new staffBUS();
        public ucSalary()
        {
            InitializeComponent();
        }

        #region Load Combobox chọn nhân viên và tháng lương
        public void LoadComboboxStaff()
        {   //Load Chọn nhân viên
            ArrayList sta = new ArrayList();
            sta.Add(new { tennv = "Tất cả nhân viên", manv = "all" });
            var section = (from se in aHRM.Sections
                           select new
                           {
                               tennv = "# Phòng " + se.SectionName,
                               manv = "#" + se.SectionID,
                           }).ToList();
            sta.AddRange(section);
            var staff = (from s in aHRM.Staffs
                         select new
                         {
                             tennv = s.StaffName,
                             manv = s.StaffID,
                         }).ToArray();
            sta.AddRange(staff);
            cbbStaffID.DataSource = sta;
            cbbStaffID.DisplayMember = "tennv";
            cbbStaffID.ValueMember = "manv";
        }
        public void LoadComboboxMonth()
        {
            ArrayList month = new ArrayList();
            month.Add(new { dt = "Tất cả tháng lương", monthID = "all" });
            //Load chọn tháng định dạng MM/yyyy
            var grouped = ((from p in aHRM.Salaries
                            group p by new { month = p.SalaryMonth.Value.Month, year = p.SalaryMonth.Value.Year, } into d
                            select new
                            {
                                dt = string.Format("Tháng {0}, {1}", d.Key.month, d.Key.year),
                                monthID = string.Format("{0}-{1}", d.Key.month, d.Key.year),
                            }).ToList()
                           .OrderByDescending(g => g.dt));
            month.AddRange(grouped.ToArray());
            cbbMonthYear.DataSource = month;
            cbbMonthYear.DisplayMember = "dt";
            cbbMonthYear.ValueMember = "monthID";
        }
        #endregion

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gcSalary.ShowRibbonPrintPreview();
        }
        private void ucSalary_Load(object sender, EventArgs e)
        {
            gcSalary.DataSource = salaryBUS.LoadSalary();
            LoadComboboxStaff();
            LoadComboboxMonth();
        }

        private void ribbonControl_Click(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gcSalary_Load(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void gcSalary_Click(object sender, EventArgs e)
        {

        }
        //Xử lý sự kiện xem lương
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string maChonNhanVien = cbbStaffID.SelectedValue.ToString();/*Mã số chọn nhân viên*/
            string maChonThangNam = cbbMonthYear.SelectedValue.ToString();/*Mã số chọn tháng lương*/
            int month = 0, year = 0, chonPhongBan = 0;
            if (salaryBUS.CheckTheCode(maChonNhanVien, "#") == true)/*Nếu maChonNhanVien có ký tự # ở đầu là phòng ban*/
            {
                maChonNhanVien = salaryBUS.GetTheSectionID(maChonNhanVien, 1);/*Cắt chuổi lấy mã phòng ban gán vào maChonNhanVien*/
                chonPhongBan = 1;/*Bật cờ hiệu*/
            }
            if (maChonThangNam != "all")/*Nếu maChonThangNam khác All tức đã chọn một tháng lương cụ thể*/
            {
                string[] arrListStr = maChonThangNam.Split('-');/*Dùng hàng cắt chuổi với đầu cắt là ký tự - */
                month = int.Parse(arrListStr[0]);/*Lấy giá trị tháng*/
                year = int.Parse(arrListStr[1]);/*Lấy giá trị năm*/
            }


            if (maChonNhanVien != "all" && maChonThangNam != "all")/*Không chọn tất cả nhân viên và tháng*/
            {
                if (chonPhongBan == 1)/*Cờ hiệu chọn phòng ban bật*/
                {
                    gcSalary.DataSource = staffBUS.LoadSalaryBySectionID(maChonNhanVien, month, year);/*Đã chọn phòng ban*/
                }
                else
                {
                    gcSalary.DataSource = staffBUS.LoadSalaryByStaffID(maChonNhanVien, month, year);/*Đã chọn nhân viên*/
                }
            }
            else
            {
                if (maChonNhanVien == "all" && maChonThangNam != "all")/*Chọn tất cả nhân viên, tháng lương chọn cụ thể*/
                {
                    gcSalary.DataSource = staffBUS.LoadSalaryByMonthYear(month, year);
                }
                else
                {
                    if (maChonNhanVien != "all" && maChonThangNam == "all")/*Tháng lương là tất cả, nhân viên # All*/
                    {
                        if (chonPhongBan == 1)/*Phòng ban được chọn*/
                        {
                            gcSalary.DataSource = staffBUS.LoadSalaryByAllSection(maChonNhanVien);
                        }
                        else
                        {
                            //Nhân viên được chọn
                            gcSalary.DataSource = staffBUS.LoadSalaryByStaffIDNonMonthYear(maChonNhanVien);
                        }

                    }
                    else
                    {
                        //Cả combobox nhân viên và tháng lương đều chọn tất cả
                        gcSalary.DataSource = salaryBUS.LoadSalary();
                    }
                }
            }

        }
        #region Sự kiện thay đổi giá trị combobox
        private void cbbStaffID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbbMonthYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
