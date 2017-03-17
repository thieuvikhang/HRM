using DAL;
using System.Linq;
using static System.Convert;

namespace BUS
{
    public class AbsentBus
    {
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        //Lấy số ngày nghỉ không lương theo Mã nhân viên, tháng
        public int GetAbsentDays(int month, int year, string staffId)
        {
            var absentDays = (from ad in _aHrm.Absents
                              where ad.StaffID == staffId
                                && ad.ToDate.Value.Year == year
                                && ad.ToDate.Value.Month == month
                                && ad.AbsentType == true
                              select ad.AbsentDay).Count();
            return ToInt16(absentDays);
        }
    }
}
