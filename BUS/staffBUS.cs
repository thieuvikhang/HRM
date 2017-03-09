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
                              st.Name,
                              st.Gender,
                              st.BirthDay,
                              st.CardID,
                              st.Phone,
                              st.Address,
                              st.Education,
                              st.Email,
                              postName = post.Name,                        
                              secName = sec.Name
                          });
            return loadStaff;
        }
        //Lấy số ID phòng ban dựa vào Mã nhân viên
        public string GetSectionIDByStaffID(string staffID)
        {
            var sectionID = (from s in aHRM.Staffs where s.StaffID == staffID select s.SectionID).FirstOrDefault();
            return Convert.ToString(sectionID);
        }
        //Load nhân salary nhân viên theo id
        public IQueryable LoadSalaryByStaffID(string staffID, DateTime date)
        {
            var salary = from sta in aHRM.Staffs
                         from sala in aHRM.Salaries
                         where sta.StaffID == sala.StaffID 
                            && sta.StaffID == staffID 
                            && sala.SalaryMonth.Value.Month == date.Month 
                            && sala.SalaryMonth.Value.Year == date.Year
                         group sala by new
                         {
                             staffID = sta.StaffID,
                             name = sta.Name,
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
        //Load nhân salary nhân viên theo id
        public IQueryable LoadSalaryBySectionID(string sectionID, DateTime date)
        {
            var salary = from sta in aHRM.Staffs
                         from sala in aHRM.Salaries
                         where sta.StaffID == sala.StaffID 
                            && sta.SectionID == sectionID
                            && sala.SalaryMonth.Value.Month == date.Month
                            && sala.SalaryMonth.Value.Year == date.Year
                         group sala by new
                         {
                             staffID = sta.StaffID,
                             name = sta.Name,
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
