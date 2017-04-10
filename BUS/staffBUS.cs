using System;
using System.Data.Linq;
using System.Linq;
using DAL;

namespace BUS
{
    public class StaffBus
    {
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        public readonly ExtendBus ExtendBus = new ExtendBus();
        public IQueryable LoadStaff()
        {
            var loadStaff = from st in _aHrm.Staffs
                from post in _aHrm.Positions
                from sec in _aHrm.Sections
                where st.PostID == post.PostID && st.SectionID == sec.SectionID
                select new
                {
                    st.StaffID,
                    st.StaffName,
                    Gender = st.Gender == true ? "Nam" : "Nữ",
                    st.BirthDay,
                    st.CardID,
                    st.Phone,
                    st.Address,
                    st.Education,
                    st.StartDate,
                    st.EndDate,
                    st.ManagerID,
                    st.Email,
                    post.PostName,
                    sec.SectionName
                };
            return loadStaff;
        }

        public Staff LoadStaffByIdStaff(string idStaff)
        {
            var loadStaff = _aHrm.Staffs.SingleOrDefault(st => st.StaffID == idStaff);
            return loadStaff;
        }

        //Lấy số ID phòng ban dựa vào Mã nhân viên
        public string GetSectionIdByStaffId(string staffId)
        {
            var sectionId = (from s in _aHrm.Staffs where s.StaffID == staffId select s.SectionID).FirstOrDefault();
            return Convert.ToString(sectionId);
        }

        //Load lương theo nhân viên và tháng
        public IQueryable LoadSalaryByStaffId(string staffId, int month, int year)
        {
            var salary = _aHrm.Staffs.SelectMany(sta => _aHrm.Salaries, (sta, sala) => new {sta, sala})
                .Where(t => t.sta.StaffID == t.sala.StaffID
                             && t.sta.StaffID == staffId
                             && t.sala.SalaryMonth.Value.Month == month
                             && t.sala.SalaryMonth.Value.Year == year).GroupBy(t => new
                {
                                 staffID = t.sta.StaffID,
                                 name = t.sta.StaffName,
                                 basicPay = t.sala.BasicPay == 0 ? 0 : t.sala.BasicPay,
                                 allowance = t.sala.Allowance == 0 ? 0 : t.sala.Allowance,
                                 workdays = t.sala.Workdays,
                                 allowanceDescription = t.sala.AllowanceDescription,
                                 realPay = t.sala.RealPay == 0 ? 0 : t.sala.RealPay,
                                 month = t.sala.SalaryMonth.Value.Month,
                                 year = t.sala.SalaryMonth.Value.Year
                             }, t => t.sala).Select(d => new
                {
                                 StaffID = d.Key.staffID,
                                 Name = d.Key.name,
                                 SalaryMonth = $"Tháng {d.Key.month} - {d.Key.year}",
                                 BasicPay = $"{ExtendBus.FormatMoney(d.Key.basicPay.Value)} ₫",
                                 Allowance = $"{ExtendBus.FormatMoney(d.Key.allowance.Value)} ₫",
                                 AllowanceDescription = d.Key.allowanceDescription,
                                 Workdays = $"{d.Key.workdays.ToString()} ngày",
                                 RealPay = $"{ExtendBus.FormatMoney(d.Key.realPay.Value)} ₫"
                             });
            return salary;
        }
        //Load lương tất cả tháng của 1 nhân viên
        public IQueryable LoadSalaryByStaffIdNonMonthYear(string staffId)
        {
            var salary = _aHrm.Staffs.SelectMany(sta => _aHrm.Salaries, (sta, sala) => new {sta, sala})
                .Where(t => t.sta.StaffID == t.sala.StaffID
                             && t.sta.StaffID == staffId).GroupBy(t => new
                {
                                 staffID = t.sta.StaffID,
                                 name = t.sta.StaffName,
                                 basicPay = t.sala.BasicPay == 0 ? 0 : t.sala.BasicPay,
                                 allowance = t.sala.Allowance == 0 ? 0 : t.sala.Allowance,
                                 workdays = t.sala.Workdays,
                                 allowanceDescription = t.sala.AllowanceDescription,
                                 realPay = t.sala.RealPay == 0 ? 0 : t.sala.RealPay,
                                 month = t.sala.SalaryMonth.Value.Month,
                                 year = t.sala.SalaryMonth.Value.Year
                             }, t => t.sala).Select(d => new
                {
                                 StaffID = d.Key.staffID,
                                 Name = d.Key.name,
                                 SalaryMonth = $"Tháng {d.Key.month} - {d.Key.year}",
                                 BasicPay = $"{ExtendBus.FormatMoney(d.Key.basicPay.Value)} ₫",
                                 Allowance = $"{ExtendBus.FormatMoney(d.Key.allowance.Value)} ₫",
                                 AllowanceDescription = d.Key.allowanceDescription,
                                 Workdays = $"{d.Key.workdays.ToString()} ngày",
                                 RealPay = $"{ExtendBus.FormatMoney(d.Key.realPay.Value)} ₫"
                             });
            return salary;
        }
        //Load lương của tất cả nhân viên theo tháng và năm
        public IQueryable LoadSalaryByMonthYear(int month, int year)
        {
            var salary = _aHrm.Staffs.SelectMany(sta => _aHrm.Salaries, (sta, sala) => new {sta, sala})
                .Where(t => t.sta.StaffID == t.sala.StaffID
                             && t.sala.SalaryMonth.Value.Month == month
                             && t.sala.SalaryMonth.Value.Year == year).GroupBy(t => new
                {
                                 staffID = t.sta.StaffID,
                                 name = t.sta.StaffName,
                                 basicPay = t.sala.BasicPay == 0 ? 0 : t.sala.BasicPay,
                                 allowance = t.sala.Allowance == 0 ? 0 : t.sala.Allowance,
                                 workdays = t.sala.Workdays,
                                 allowanceDescription = t.sala.AllowanceDescription,
                                 realPay = t.sala.RealPay == 0 ? 0 : t.sala.RealPay,
                                 month = t.sala.SalaryMonth.Value.Month,
                                 year = t.sala.SalaryMonth.Value.Year
                             }, t => t.sala).Select(d => new
                {
                                 StaffID = d.Key.staffID,
                                 Name = d.Key.name,
                                 SalaryMonth = $"Tháng {d.Key.month} - {d.Key.year}",
                                 BasicPay = $"{ExtendBus.FormatMoney(d.Key.basicPay.Value)} ₫",
                                 Allowance = $"{ExtendBus.FormatMoney(d.Key.allowance.Value)} ₫",
                                 AllowanceDescription = d.Key.allowanceDescription,
                                 Workdays = $"{d.Key.workdays.ToString()} ngày",
                                 RealPay = $"{ExtendBus.FormatMoney(d.Key.realPay.Value)} ₫"
                             });
            return salary;
        }
        //Load lương của tất cả nhân vien trong 1 phòng ban và tương ứng tháng, năm
        public IQueryable LoadSalaryBySectionId(string sectionId, int month, int year)
        {
            var salary = _aHrm.Staffs.SelectMany(sta => _aHrm.Salaries, (sta, sala) => new {sta, sala})
                .Where(t => t.sta.StaffID == t.sala.StaffID
                             && t.sta.SectionID == sectionId
                             && t.sala.SalaryMonth.Value.Month == month
                             && t.sala.SalaryMonth.Value.Year == year).GroupBy(t => new
                {
                                 staffID = t.sta.StaffID,
                                 name = t.sta.StaffName,
                                 basicPay = t.sala.BasicPay == 0 ? 0 : t.sala.BasicPay,
                                 allowance = t.sala.Allowance == 0 ? 0 : t.sala.Allowance,
                                 workdays = t.sala.Workdays,
                                 allowanceDescription = t.sala.AllowanceDescription,
                                 realPay = t.sala.RealPay == 0 ? 0 : t.sala.RealPay,
                                 month = t.sala.SalaryMonth.Value.Month,
                                 year = t.sala.SalaryMonth.Value.Year
                             }, t => t.sala).Select(d => new
                {
                                 StaffID = d.Key.staffID,
                                 Name = d.Key.name,
                                 SalaryMonth = $"Tháng {d.Key.month} - {d.Key.year}",
                                 BasicPay = $"{ExtendBus.FormatMoney(d.Key.basicPay.Value)} ₫",
                                 Allowance = $"{ExtendBus.FormatMoney(d.Key.allowance.Value)} ₫",
                                 AllowanceDescription = d.Key.allowanceDescription,
                                 Workdays = $"{d.Key.workdays.ToString()} ngày",
                                 RealPay = $"{ExtendBus.FormatMoney(d.Key.realPay.Value)} ₫"
                             });
            return salary;
        }
        //Load lương của tất cả nhân vien trong 1 phòng ban và tương ứng tháng, năm
        public IQueryable LoadSalaryByAllSection(string sectionId)
        {
            var salary = _aHrm.Staffs.SelectMany(sta => _aHrm.Salaries, (sta, sala) => new {sta, sala})
                .Where(t => t.sta.StaffID == t.sala.StaffID
                             && t.sta.SectionID == sectionId).GroupBy(t => new
                {
                                 staffID = t.sta.StaffID,
                                 name = t.sta.StaffName,
                                 basicPay = t.sala.BasicPay == 0 ? 0 : t.sala.BasicPay,
                                 allowance = t.sala.Allowance == 0 ? 0 : t.sala.Allowance,
                                 workdays = t.sala.Workdays,
                                 allowanceDescription = t.sala.AllowanceDescription,
                                 realPay = t.sala.RealPay == 0 ? 0 : t.sala.RealPay,
                                 month = t.sala.SalaryMonth.Value.Month,
                                 year = t.sala.SalaryMonth.Value.Year
                             }, t => t.sala).Select(d => new
                {
                    StaffID = d.Key.staffID,
                    Name = d.Key.name,
                    SalaryMonth = $"Tháng {d.Key.month} - {d.Key.year}",
                    BasicPay = $"{ExtendBus.FormatMoney(d.Key.basicPay.Value)} ₫",
                    Allowance = $"{ExtendBus.FormatMoney(d.Key.allowance.Value)} ₫",
                    AllowanceDescription = d.Key.allowanceDescription,
                    Workdays = $"{d.Key.workdays.ToString()} ngày",
                    RealPay = $"{ExtendBus.FormatMoney(d.Key.realPay.Value)} ₫"
                });
            return salary;
        }
        //kiem tra trung id
        public bool FindIdInputInTable(string idInput)
        {
            var numberOfRecords = (from ct in _aHrm.Staffs
                                   where ct.StaffID == idInput
                                   select ct).Count();
            return numberOfRecords != 0;
        }
        public bool FindPhoneInputInTable(string phoneInput)
        {
            var numberOfRecords = (from ct in _aHrm.Staffs
                                   where ct.Phone == phoneInput
                                   select ct).Count();
            return numberOfRecords != 0;
        }
        public bool FindCardIdInputInTable(string input)
        {
            var numberOfRecords = (from ct in _aHrm.Staffs
                                   where ct.CardID == input
                                   select ct).Count();
            return numberOfRecords != 0;
        }
        public bool FindEmailInputInTable(string emailInput)
        {
            var numberOfRecords = (from ct in _aHrm.Staffs
                                   where ct.Email == emailInput
                                   select ct).Count();
            return numberOfRecords != 0;
        }
        public bool CreateAStaff(string idInput, string nameInput, bool genderInput, DateTime? birthdayInput, string cardidInput, string phoneInput, string addressInput, string eduInput, DateTime? startdateInput, DateTime? enddateInput, string manageridInput, string emailInput, string postidInput, string sectionidInput)
        {
            try
            {
                if (FindIdInputInTable(idInput)) return false;
                var aStaff = new Staff
                {
                    StaffID = idInput,
                    StaffName = nameInput,
                    Gender = genderInput,
                    BirthDay = birthdayInput,
                    CardID = cardidInput,
                    Phone = phoneInput,
                    Address = addressInput,
                    Education = eduInput,
                    StartDate = startdateInput,
                    EndDate = enddateInput,
                    ManagerID = manageridInput,
                    Email = emailInput,
                    PostID = postidInput,
                    SectionID = sectionidInput
                };

                _aHrm.Staffs.InsertOnSubmit(aStaff);
                _aHrm.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EditAStaff(string newid, string nameInput, Boolean genderInput, 
            DateTime? birthdayInput, string cardidInput, string phoneInput, 
            string addressInput, string eduInput, DateTime? startdateInput,
            DateTime? enddateInput, string manageridInput, string emailInput, 
            string postidInput, string sectionidInput)
        {
            try
            {
                var aStaff = _aHrm.Staffs.SingleOrDefault(st => st.StaffID == newid);
                if (aStaff == null) return false;
                aStaff.StaffID = newid;
                aStaff.StaffName = nameInput;
                aStaff.Gender = genderInput;
                aStaff.BirthDay = birthdayInput;
                aStaff.CardID = cardidInput;
                aStaff.Phone = phoneInput;
                aStaff.Address = addressInput;
                aStaff.Education = eduInput;
                aStaff.StartDate = startdateInput;
                aStaff.EndDate = enddateInput;
                aStaff.ManagerID = manageridInput;
                aStaff.Email = emailInput;
                aStaff.PostID = postidInput;
                aStaff.SectionID = sectionidInput;
                    
                _aHrm.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditImageStaff(string newid, Binary ImageStaff)
        {
            var newStaff = _aHrm.Staffs.SingleOrDefault(st => st.StaffID == newid);
            if (newStaff == null) return false;
            newStaff.Image = ImageStaff;
            _aHrm.SubmitChanges();
            return true;
        }

        public bool DeleteAStaff(string idInput)
        {
            try
            {
                var aStaff = (from st in _aHrm.Staffs select st).SingleOrDefault(st => st.StaffID == idInput);
                if (aStaff == null) return false;
                _aHrm.Staffs.DeleteOnSubmit(aStaff);
                _aHrm.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool checkIDStaffinAccount(string idStaff)
        {
            var countAccount = (from ac in _aHrm.Accounts
                                where ac.StaffID == idStaff
                                select ac).Count();
            return countAccount != 0;
        } 

        public bool checkStatusOfAccountOnline(string idStaff)
        {
            var countAccountOnline = (from ac in _aHrm.Accounts
                                where ac.StaffID == idStaff && ac.AccountStatusOnline == true
                                select ac).Count();
            return countAccountOnline != 0;
        }
    }
}
