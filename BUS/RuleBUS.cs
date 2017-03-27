using DAL;
using System;
using System.Linq;

namespace BUS
{
    public class RuleBus
    {
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        //Lấy số % bảo hiểm xã hội
        public float GetBhxh()
        {
            var siPayRate = _aHrm.Rules.Select(ad => ad.SIPayRate).FirstOrDefault();
            return siPayRate == null ? 0 : Convert.ToInt16(siPayRate);
        }
        /// <summary>
        /// Lấy số ngày nghỉ quy định
        /// </summary>
        /// <returns>số ngày nghĩ quy định, nếu không tồn tại trả về 0</returns>
        public int GetSoNgayNghiQuyDinh()
        {
            var ngay = _aHrm.Rules.Select(ad => ad.LeaveAYear).FirstOrDefault();
            return ngay == null ? 0 : Convert.ToInt16(ngay.ToString());
        }
    }
}
