using DAL;
using System;
using System.Data.Linq;
using System.Linq;

namespace BUS
{
    public class StaffBus
    {
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
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
                    //st.DaysRemain,
                    post.PostName,
                    sec.SectionName
                };
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
            var salary = from sta in _aHrm.Staffs
                         from sala in _aHrm.Salaries
                         where sta.StaffID == sala.StaffID
                            && sta.StaffID == staffId
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
                             SalaryMonth = $"{d.Key.month}/{d.Key.year}",
                             BasicPay = d.Key.basicPay,
                             Allowance = d.Key.allowance,
                             Workdays = d.Key.workdays,
                             RealPay = d.Key.realPay,
                         };
            return salary;
        }
        //Load lương tất cả tháng của 1 nhân viên
        public IQueryable LoadSalaryByStaffIdNonMonthYear(string staffId)
        {
            var salary = from sta in _aHrm.Staffs
                         from sala in _aHrm.Salaries
                         where sta.StaffID == sala.StaffID
                            && sta.StaffID == staffId
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
        //Load lương của tất cả nhân viên theo tháng và năm
        public IQueryable LoadSalaryByMonthYear(int month, int year)
        {
            var salary = from sta in _aHrm.Staffs
                         from sala in _aHrm.Salaries
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
                             SalaryMonth = $"{d.Key.month}/{d.Key.year}",
                             BasicPay = d.Key.basicPay,
                             Allowance = d.Key.allowance,
                             Workdays = d.Key.workdays,
                             RealPay = d.Key.realPay,
                         };
            return salary;
        }
        //Load lương của tất cả nhân vien trong 1 phòng ban và tương ứng tháng, năm
        public IQueryable LoadSalaryBySectionId(string sectionId, int month, int year)
        {
            var salary = from sta in _aHrm.Staffs
                         from sala in _aHrm.Salaries
                         where sta.StaffID == sala.StaffID
                            && sta.SectionID == sectionId
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
                             SalaryMonth = $"{d.Key.month}/{d.Key.year}",
                             BasicPay = d.Key.basicPay,
                             Allowance = d.Key.allowance,
                             Workdays = d.Key.workdays,
                             RealPay = d.Key.realPay,
                         };
            return salary;
        }
        //Load lương của tất cả nhân vien trong 1 phòng ban và tương ứng tháng, năm
        public IQueryable LoadSalaryByAllSection(string sectionId)
        {
            var salary = from sta in _aHrm.Staffs
                         from sala in _aHrm.Salaries
                         where sta.StaffID == sala.StaffID
                            && sta.SectionID == sectionId
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
        public bool CreateAStaff(string idInput, string nameInput, Boolean genderInput, DateTime? birthdayInput, string cardidInput, string phoneInput, string addressInput, string eduInput, DateTime? startdateInput, DateTime? enddateInput, string manageridInput, string emailInput, int dayremainInput, string postidInput, string sectionidInput)
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
                    //DaysRemain = dayremainInput,
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
            int dayremainInput, string postidInput, string sectionidInput)
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
                //aStaff.DaysRemain = dayremainInput;
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

    }
}
