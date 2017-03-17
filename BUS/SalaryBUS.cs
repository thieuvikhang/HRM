using System;
using DAL;
using System.Linq;

namespace BUS
{
    public class SalaryBus
    {
        public readonly ExtendBus ExtendBus = new ExtendBus();
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        //Kiểm tra mả trả về là phòng ban hay nhân viên
        public bool CheckTheCode(string maSo, string kyTu)
        {
            //Kiểm tra chuổi maSo có bắt đầu bằng ký tự kyTu không
            return maSo.StartsWith(kyTu);
            //Không
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
            return basicPay * (int)siPayRate / 100;
        }
        //Tính lương cơ bản của tháng
        public decimal BasicSalary(decimal basicPay, int standardWorkday, int absentDay)
        {
            return basicPay / standardWorkday * (standardWorkday - absentDay);
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
                var month = (from m in _aHrm.Salaries select m.SalaryMonth).Distinct();
                return month;
            }
        }

        public IQueryable LoadSalary
        {
            get
            {
                var salary = from sta in _aHrm.Staffs
                             from sala in _aHrm.Salaries
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
                                 BasicPay = ExtendBus.FormatMoney(d.Key.basicPay.Value),
                                 Allowance = ExtendBus.FormatMoney(d.Key.allowance.Value),
                                 Workdays = d.Key.workdays,
                                 RealPay = ExtendBus.FormatMoney(d.Key.realPay.Value),
                             };
                return salary;
            }
        }
        public IQueryable LoadStaffNonSalary(string maPb, int month, int year)
        {
            if (maPb == "-")
            {
                var list2 = (from pb in _aHrm.Sections
                             from nv in _aHrm.Staffs
                             where nv.SectionID == pb.SectionID
                             select new
                             {
                                 nv.StaffID,
                                 nv.StaffName,
                                 pb.SectionName
                             }).ToList();
                var list1 = (from luong in _aHrm.Salaries
                             from pb in _aHrm.Sections
                             from nv in _aHrm.Staffs
                             where nv.SectionID == pb.SectionID
                                   && nv.StaffID == luong.StaffID
                                   && luong.SalaryMonth.Value.Month == month
                                   && luong.SalaryMonth.Value.Year == year
                             select new
                             {
                                 nv.StaffID,
                                 nv.StaffName,
                                 pb.SectionName
                             }).ToList();
                foreach (var item1 in list1)
                {
                    for (var index = 0; index < list2.Count; index++)
                    {
                        var item2 = list2[index];
                        if (item1.StaffID != item2.StaffID || item1.StaffName != item2.StaffName ||
                            item1.SectionName != item2.SectionName) continue;
                        list2.RemoveAt(index);
                    }
                }
                return list2.AsQueryable();
            }
            else
            {
                var list2 = (from pb in _aHrm.Sections
                             from nv in _aHrm.Staffs
                             where nv.SectionID == pb.SectionID
                                   && nv.SectionID == maPb
                             select new
                             {
                                 nv.StaffID,
                                 nv.StaffName,
                                 pb.SectionName
                             }).ToList();
                var list1 = (from luong in _aHrm.Salaries
                             from pb in _aHrm.Sections
                             from nv in _aHrm.Staffs
                             where nv.SectionID == pb.SectionID
                                   && nv.StaffID == luong.StaffID
                                   && luong.SalaryMonth.Value.Month == month
                                   && luong.SalaryMonth.Value.Year == year
                             select new
                             {
                                 nv.StaffID,
                                 nv.StaffName,
                                 pb.SectionName
                             }).ToList();
                foreach (var item1 in list1)
                {
                    for (var index = 0; index < list2.Count; index++)
                    {
                        var item2 = list2[index];
                        if (item1.StaffID != item2.StaffID || item1.StaffName != item2.StaffName ||
                            item1.SectionName != item2.SectionName) continue;
                        list2.RemoveAt(index);
                    }
                }
                return list2.AsQueryable();
            }
        }
        //Lưu tính lương
        public bool SaveSalary(string staffId, decimal basicPay, string monthYear, int workdays, decimal allowance, string allowanceDescription, int standardWorkdays, decimal realPay)
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            var date = 01 + "/" + monthYear;
            var day = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            try
            {
                var salarry = new Salary
                {
                    StaffID = staffId,
                    BasicPay = basicPay,
                    SalaryMonth = day,
                    Workdays = workdays,
                    Allowance = allowance,
                    AllowanceDescription = allowanceDescription,
                    StandardWorkdays = standardWorkdays,
                    RealPay = realPay
                };
                _aHrm.Salaries.InsertOnSubmit(salarry);
                _aHrm.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
