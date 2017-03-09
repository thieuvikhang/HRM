using DAL;
using System.Linq;

namespace BUS
{
    public class SalaryBUS
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();
        //Tính tiền bảo hiểm của nhân viên
        public decimal siPrice(float SIPayRate, decimal basicPay)
        {
            return (basicPay * (int)SIPayRate) / 100;
        }
        //Tính lương cơ bản của tháng
        public decimal BasicSalary(decimal basicPay, int standardWorkday, int absentDay)
        {
            return (basicPay / standardWorkday) * (standardWorkday - absentDay);
        }
        //Tính lương thực lãnh
        public decimal RealPay(decimal basicSalary, decimal allowance, decimal siPrice)
        {
            return basicSalary + allowance - siPrice;
        }
        //Lấy giá trị tháng lương trong bảng lương
        public IQueryable GetMonth()
        {
            var month = (from m in aHRM.Salaries select m.SalaryMonth).Distinct();
            return month;
        }
        public IQueryable LoadSalary()
        {
            var salary = from sta in aHRM.Staffs
                         from sala in aHRM.Salaries
                         where sta.StaffID == sala.StaffID
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
