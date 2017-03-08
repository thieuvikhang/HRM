using DAL;
using System;
using System.Linq;

namespace BUS
{
    class AbsentBUS
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();
        //Lấy số ngày nghỉ không lương theo Mã nhân viên, tháng
        public int GetAbsentDays(DateTime day, string StaffID)
        {
            var absentDays = (from ad in aHRM.DetailAbsents where ad.AbsentMonth == day && ad.StaffID == StaffID select ad.AbsentDays).FirstOrDefault();
            return Convert.ToInt16(absentDays);
        }
    }
}
