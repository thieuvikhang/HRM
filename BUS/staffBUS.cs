using DAL;
using System;
using System.Linq;

namespace BUS
{
    public class staffBUS
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();
        public IQueryable loadStaff()
        {
            var loadStaff = (from st in aHRM.Staffs
                             from post in aHRM.Positions
                             from sec in aHRM.Sections
                             where st.PostID == post.PostID && st.SectionID == sec.SectionID
                          select new
                          {
                              st.StaffID,
                              st.StaffName,
                              st.Gender,
                              st.BirthDay,
                              st.CardID,
                              st.Phone,
                              st.Address,
                              st.Education,
                              st.StartDate,
                              st.EndDate,
                              st.ManagerID,                     
                              st.Email,
                              st.DaysRemain,
                              post.PostName,                        
                              sec.SectionName
                          });
            return loadStaff;
        }
        //Lấy số ID phòng ban dựa vào Mã nhân viên
        public string GetSectionIDByStaffID(string staffID)
        {
            var sectionID = (from s in aHRM.Staffs where s.StaffID == staffID select s.SectionID).FirstOrDefault();
            return Convert.ToString(sectionID);
        }

        //Load lương theo nhân viên và tháng
        public IQueryable LoadSalaryByStaffID(string staffID, int month, int year)
        {
            var salary = from sta in aHRM.Staffs
                         from sala in aHRM.Salaries
                         where sta.StaffID == sala.StaffID
                            && sta.StaffID == staffID
                            && sala.SalaryMonth.Value.Month == month
                            && sala.SalaryMonth.Value.Year == year
                         group sala by new
                         {
                             staffID = sta.StaffID,
                             name = sta.StaffName,
                             basicPay = sala.BasicPay,
                             allowance = sala.Allowance,
                             workdays = sala.Workdays,
                             realPay = sala.RealPay,
                             month = sala.SalaryMonth.Value.Month,
                             year = sala.SalaryMonth.Value.Year
                         } into d
                         select new
                         {
                             StaffID = d.Key.staffID,
                             Name = d.Key.name,
                             //định dạng MM/yyyy
                             SalaryMonth = string.Format("{0}/{1}", d.Key.month, d.Key.year),
                             BasicPay = d.Key.basicPay,
                             Allowance = d.Key.allowance,
                             Workdays = d.Key.workdays,
                             RealPay = d.Key.realPay,
                         };
            return salary;
        }
        //Load lương tất cả tháng của 1 nhân viên
        public IQueryable LoadSalaryByStaffIDNonMonthYear(string staffID)
        {
            var salary = from sta in aHRM.Staffs
                         from sala in aHRM.Salaries
                         where sta.StaffID == sala.StaffID
                            && sta.StaffID == staffID
                         group sala by new
                         {
                             staffID = sta.StaffID,
                             name = sta.StaffName,
                             basicPay = sala.BasicPay,
                             allowance = sala.Allowance,
                             workdays = sala.Workdays,
                             realPay = sala.RealPay,
                             month = sala.SalaryMonth.Value.Month,
                             year = sala.SalaryMonth.Value.Year
                         } into d
                         select new
                         {
                             StaffID = d.Key.staffID,
                             Name = d.Key.name,
                             //định dạng MM/yyyy
                             SalaryMonth = string.Format("{0}/{1}", d.Key.month, d.Key.year),
                             BasicPay = d.Key.basicPay,
                             Allowance = d.Key.allowance,
                             Workdays = d.Key.workdays,
                             RealPay = d.Key.realPay,
                         };
            return salary;
        }
        //Load lương của tất cả nhân viên theo tháng và năm
        public IQueryable LoadSalaryByMonthYear(int month, int year)
        {
            var salary = from sta in aHRM.Staffs
                         from sala in aHRM.Salaries
                         where sta.StaffID == sala.StaffID
                            && sala.SalaryMonth.Value.Month == month
                            && sala.SalaryMonth.Value.Year == year
                         group sala by new
                         {
                             staffID = sta.StaffID,
                             name = sta.StaffName,
                             basicPay = sala.BasicPay,
                             allowance = sala.Allowance,
                             workdays = sala.Workdays,
                             realPay = sala.RealPay,
                             month = sala.SalaryMonth.Value.Month,
                             year = sala.SalaryMonth.Value.Year
                         } into d
                         select new
                         {
                             StaffID = d.Key.staffID,
                             Name = d.Key.name,
                             //định dạng MM/yyyy
                             SalaryMonth = string.Format("{0}/{1}", d.Key.month, d.Key.year),
                             BasicPay = d.Key.basicPay,
                             Allowance = d.Key.allowance,
                             Workdays = d.Key.workdays,
                             RealPay = d.Key.realPay,
                         };
            return salary;
        }
        //Load lương của tất cả nhân vien trong 1 phòng ban và tương ứng tháng, năm
        public IQueryable LoadSalaryBySectionID(string sectionID, int month, int year)
        {
            var salary = from sta in aHRM.Staffs
                         from sala in aHRM.Salaries
                         where sta.StaffID == sala.StaffID
                            && sta.SectionID == sectionID
                            && sala.SalaryMonth.Value.Month == month
                            && sala.SalaryMonth.Value.Year == year
                         group sala by new
                         {
                             staffID = sta.StaffID,
                             name = sta.StaffName,
                             basicPay = sala.BasicPay,
                             allowance = sala.Allowance,
                             workdays = sala.Workdays,
                             realPay = sala.RealPay,
                             month = sala.SalaryMonth.Value.Month,
                             year = sala.SalaryMonth.Value.Year
                         } into d
                         select new
                         {
                             StaffID = d.Key.staffID,
                             Name = d.Key.name,
                             //định dạng MM/yyyy
                             SalaryMonth = string.Format("{0}/{1}", d.Key.month, d.Key.year),
                             BasicPay = d.Key.basicPay,
                             Allowance = d.Key.allowance,
                             Workdays = d.Key.workdays,
                             RealPay = d.Key.realPay,
                         };
            return salary;
        }
        //Load lương của tất cả nhân vien trong 1 phòng ban và tương ứng tháng, năm
        public IQueryable LoadSalaryByAllSection(string sectionID)
        {
            var salary = from sta in aHRM.Staffs
                         from sala in aHRM.Salaries
                         where sta.StaffID == sala.StaffID
                            && sta.SectionID == sectionID
                         group sala by new
                         {
                             staffID = sta.StaffID,
                             name = sta.StaffName,
                             basicPay = sala.BasicPay,
                             allowance = sala.Allowance,
                             workdays = sala.Workdays,
                             realPay = sala.RealPay,
                             month = sala.SalaryMonth.Value.Month,
                             year = sala.SalaryMonth.Value.Year
                         } into d
                         select new
                         {
                             StaffID = d.Key.staffID,
                             Name = d.Key.name,
                             //định dạng MM/yyyy
                             SalaryMonth = string.Format("{0}/{1}", d.Key.month, d.Key.year),
                             BasicPay = d.Key.basicPay,
                             Allowance = d.Key.allowance,
                             Workdays = d.Key.workdays,
                             RealPay = d.Key.realPay,
                         };
            return salary;
        }

    }
}
