using System;
using System.Globalization;
using System.Linq;
using DAL;

namespace BUS
{
    public class SalaryBus
    {
        public readonly ExtendBus ExtendBus = new ExtendBus();
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        //Kiểm tra mả trả về là phòng ban hay nhân viên
        public bool CheckTheCode(string maSo, string kyTu)
        {
            if (maSo == null || kyTu == null) return false;
            //Kiểm tra chuổi maSo có bắt đầu bằng ký tự kyTu không
            return maSo.StartsWith(kyTu);
            //Không
        }
        //Lấy mã số phòng ban
        public string GetTheSectionId(string sectionId, int kt)
        {
            if (sectionId == null || kt < 0) return null;
            //Tạo chuỗi con từ chuỗi sectionID bắt đầu từ vị trí kt đến hết.
            return sectionId.Substring(kt);
        }
        //Tính tiền bảo hiểm của nhân viên
        public decimal SiPrice(float siPayRate, decimal basicPay)
        {
            if (basicPay == 0) return 0;
            return basicPay * (int)siPayRate / 100;
        }
        //Tính lương cơ bản của tháng
        public decimal BasicSalary(decimal basicPay, int standardWorkday, int absentDay)
        {
            if (basicPay == 0 || standardWorkday == 0 || absentDay < 0) return 0;
            var luong = basicPay / standardWorkday * (standardWorkday - absentDay);
            return luong == 0 ? 0 : luong;
        }
        //Tính lương thực lãnh
        public decimal RealPay(decimal basicSalary, decimal allowance, decimal siPrice)
        {
            if (basicSalary == 0 || allowance < 0 || siPrice < 0) return 0;
            return basicSalary + allowance - siPrice;
        }
        //Lấy giá trị tháng lương trong bảng lương
        public IQueryable Month => (from m in _aHrm.Salaries select m.SalaryMonth).Distinct();
        public IQueryable LoadSalary =>
            _aHrm.Staffs.SelectMany(sta => _aHrm.Salaries, (sta, sala) => new { sta, sala })
                .Where(t => t.sta.StaffID == t.sala.StaffID)
                .GroupBy(t => new
                {
                    staffID = t.sta.StaffID,
                    name = t.sta.StaffName,
                    basicPay = t.sala.BasicPay,
                    allowance = t.sala.Allowance,
                    workdays = t.sala.Workdays,
                    realPay = t.sala.RealPay,
                    month = t.sala.SalaryMonth.Value.Month,
                    year = t.sala.SalaryMonth.Value.Year
                }, t => t.sala)
                .Select(d => new
                {
                    StaffID = d.Key.staffID,
                    Name = d.Key.name,
                    SalaryMonth = $"{d.Key.month}/{d.Key.year}",
                    BasicPay = ExtendBus.FormatMoney(d.Key.basicPay.Value),
                    Allowance = ExtendBus.FormatMoney(d.Key.allowance.Value),
                    Workdays = d.Key.workdays,
                    RealPay = ExtendBus.FormatMoney(d.Key.realPay.Value)
                });

        public IQueryable LoadStaffNonSalary(string maPb, int month, int year)
        {
            if (maPb == "-")
            {
                var list2 = _aHrm.Sections.SelectMany(pb => _aHrm.Staffs, (pb, nv) => new { pb, nv })
                    .Where(t => t.nv.SectionID == t.pb.SectionID)
                    .Select(t => new { t.nv.StaffID, t.nv.StaffName, t.pb.SectionName }).ToList();
                var list1 = (_aHrm.Salaries.SelectMany(luong => _aHrm.Sections, (luong, pb) => new { luong, pb })
                    .SelectMany(t => _aHrm.Staffs, (t, nv) => new { t, nv })
                    .Where(t => t.nv.SectionID == t.t.pb.SectionID && t.nv.StaffID == t.t.luong.StaffID &&
                           t.t.luong.SalaryMonth.Value.Month == month && t.t.luong.SalaryMonth.Value.Year == year)
                    .Select(t => new { t.nv.StaffID, t.nv.StaffName, t.t.pb.SectionName })).ToList();
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
                var list2 = (_aHrm.Sections.SelectMany(pb => _aHrm.Staffs, (pb, nv) => new { pb, nv })
                    .Where(t => t.nv.SectionID == t.pb.SectionID && t.nv.SectionID == maPb)
                    .Select(t => new { t.nv.StaffID, t.nv.StaffName, t.pb.SectionName })).ToList();
                var list1 = (_aHrm.Salaries.SelectMany(luong => _aHrm.Sections, (luong, pb) => new { luong, pb })
                    .SelectMany(t => _aHrm.Staffs, (t, nv) => new { t, nv })
                    .Where(t => t.nv.SectionID == t.t.pb.SectionID && t.nv.StaffID == t.t.luong.StaffID &&
                           t.t.luong.SalaryMonth.Value.Month == month && t.t.luong.SalaryMonth.Value.Year == year)
                    .Select(t => new { t.nv.StaffID, t.nv.StaffName, t.t.pb.SectionName })).ToList();
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
            if (staffId == null || monthYear == null || basicPay == 0 || workdays == 0 || allowance == 0 || realPay == 0) return false;
            IFormatProvider culture = new CultureInfo("vi-VN", true);
            var date = 01 + "/" + monthYear;
            var day = DateTime.Parse(date, culture, DateTimeStyles.AssumeLocal);
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
