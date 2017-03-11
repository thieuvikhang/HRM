using DAL;
using System.Linq;

namespace BUS
{
    public class SalaryBus
    {
        //Kiểm tra mả trả về là phòng ban hay nhân viên
        public bool CheckTheCode(string maSo, string kyTu)
        {
            //Kiểm tra chuổi maSo có bắt đầu bằng ký tự kyTu không
            if (maSo.StartsWith(kyTu))
            {
                //Có
                return true;
            }
            //Không
            return false;
        }
        //Lấy mã số phòng ban
        public string GetTheSectionId(string sectionId, int kt)
        {
            //Tạo chuỗi con từ chuỗi sectionID bắt đầu từ vị trí kt đến hết.
            return sectionId.Substring(kt);
        }
        //Tính tiền bảo hiểm của nhân viên
        public decimal SiPrice(float siPayRate, decimal basicPay)
        {
            return (basicPay * (int)siPayRate) / 100;
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
        public IQueryable Month
        {
            get
            {
                var month = (from m in AHrm.Salaries select m.SalaryMonth).Distinct();
                return month;
            }
        }

        public IQueryable LoadSalary
        {
            get
            {
                var salary = from sta in AHrm.Staffs
                             from sala in AHrm.Salaries
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
                                 SalaryMonth = $"{d.Key.month}/{d.Key.year}",
                                 BasicPay = d.Key.basicPay,
                                 Allowance = d.Key.allowance,
                                 Workdays = d.Key.workdays,
                                 RealPay = d.Key.realPay,
                             };
                return salary;
            }
        }

        public IQueryable LoadAddSalary
        {
            get
            {
                var salary = from sta in AHrm.Staffs
                             from sala in AHrm.Salaries
                             where sta.StaffID == sala.StaffID
                             group sala by new
                             {
                                 staffID = sta.StaffID,
                                 name = sta.StaffName,
                                 realPay = sala.RealPay,
                                 month = sala.SalaryMonth.Value.Month,
                                 year = sala.SalaryMonth.Value.Year
                             } into d
                             select new
                             {
                                 StaffID = d.Key.staffID,
                                 Name = d.Key.name,
                                 //định dạng MM/yyyy
                                 SalaryMonth = $"{d.Key.month}/{d.Key.year}",
                                 RealPay = d.Key.realPay,
                             };
                return salary;
            }
        }

        public HRMModelDataContext AHrm { get; } = new HRMModelDataContext();

        public IQueryable LoadStaffNonSalary(string maPb, int month, int year)
        {
            if (maPb == "-")
            {
                var staffal = from sta in AHrm.Staffs
                              from sala in AHrm.Salaries
                              from sec in AHrm.Sections
                              where sta.StaffID == sala.StaffID
                                    && sec.SectionID == sta.SectionID
                                    && sala.SalaryMonth.Value.Month != month
                                    && sala.SalaryMonth.Value.Year != year
                              select new
                              {
                                  sta.StaffID,
                                  sta.StaffName,
                                  sec.SectionName
                              };
                return staffal;
            }
            var staff = from sta in AHrm.Staffs
                        from sala in AHrm.Salaries
                        from sec in AHrm.Sections
                        where (sta.StaffID == sala.StaffID
                               && sec.SectionID == sta.SectionID
                               && sta.SectionID == maPb
                               && sala.SalaryMonth.Value.Month != month
                               && sala.SalaryMonth.Value.Year != year)
                        select new
                        {
                            sta.StaffID,
                            sta.StaffName,
                            sec.SectionName
                        };
            return staff;
        }
    }
}
