using DAL;
using System;
using System.Linq;

namespace BUS
{
    internal class AbsentBus
    {
        readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        //Lấy số ngày nghỉ không lương theo Mã nhân viên, tháng
        public int GetAbsentDays(DateTime day, string staffId)
        {
            var absentDays = (from ad in _aHrm.DetailAbsents where ad.AbsentMonth == day && ad.StaffID == staffId select ad.AbsentDays).FirstOrDefault();
            return Convert.ToInt16(absentDays);
        }
    }
}
