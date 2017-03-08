using DAL;
using System;
using System.Linq;

namespace BUS
{
    class RuleBUS
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();
        //Lấy số % bảo hiểm xã hội
        public float GetAbsentDays()
        {
            var SIPayRate = (from ad in aHRM.Rules select ad.SIPayRate).FirstOrDefault();
            return Convert.ToInt16(SIPayRate);
        }
    }
}
