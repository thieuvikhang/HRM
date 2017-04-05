using System;
using System.Linq;
using DAL;

namespace BUS
{
    public class DaysRemainBus
    {
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        private static readonly RuleBus RuleBus = new RuleBus();
        private static readonly AbsentBus AbsentBus = new AbsentBus();
        private readonly int _soNgayNghiQuyDinh = RuleBus.GetSoNgayNghiQuyDinh();
        /// <summary>
        /// Lấy số ngày nghỉ có lương của nhân viên
        /// </summary>
        /// <param name="year">năm</param>
        /// <param name="staffId">mã nhân viên</param>
        /// <returns>số ngày nghỉ còn lại</returns>
        public int GetDaysRemain(int year, string staffId)
        {
            if (staffId == null || year < 2000) return 0;
            foreach (var index in _aHrm.DaysRemains.Where(l1 => l1.StaffID == staffId).Select(l1 => new { l1.StaffID, l1.Year, l1.UsedInYear }))
            {
                foreach (var item in _aHrm.DaysRemains.Where(l1 => l1.Year == year).Select(l1 => new { l1.StaffID, l1.Year, l1.UsedInYear }))
                {
                    if (index.StaffID != item.StaffID || index.Year != item.Year) continue;
                    return Convert.ToInt16(index.UsedInYear);
                }
            }
            return 0;
        }

        /// <summary>
        /// Thêm hoặc cập nhật số ngày nghỉ có phép
        /// </summary>
        /// <param name="staffId">Mã nhân viên</param>
        /// <param name="dayRemain">Số ngày nghĩ</param>
        /// <param name="year">Năm</param>
        /// <param name="loai"></param>
        /// <returns>True là thành công</returns>
        public bool AddOrUpdateDaysRemain(string staffId, int dayRemain, int year, bool loai)
        {
            if (loai == false) return true;
            if (staffId == null || dayRemain <= 0 || year < 2000 || dayRemain > _soNgayNghiQuyDinh) return false;
            try
            {
                var dk = _aHrm.DaysRemains.SingleOrDefault(ab => ab.StaffID == staffId && ab.Year == year);
                if (dk != null)
                {
                    dk.UsedInYear = AbsentBus.SumDaysRemain(staffId, year);
                    dk.LeaveAYear = _soNgayNghiQuyDinh;
                    _aHrm.SubmitChanges();
                    return true;
                }
                var remain = new DaysRemain();
                {
                    remain.StaffID = staffId;
                    remain.UsedInYear = dayRemain;
                    remain.LeaveAYear = _soNgayNghiQuyDinh;
                    remain.Year = year;
                }
                _aHrm.DaysRemains.InsertOnSubmit(remain);
                _aHrm.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Trả về loại nghỉ phép
        /// </summary>
        /// <param name="staffId">Mã nhân viên</param>
        /// <param name="year">Năm</param>
        /// <param name="absent">Số ngày nghĩ</param>
        /// <param name="truSoNgayNghi">số ngày nghì trừ ra= 0, chức năng thêm, lớn hơn 0 sửa</param>
        /// <returns>true nghĩ phép có lương</returns>
        public bool GetAbsentType(string staffId, int year, int absent, int truSoNgayNghi)
        {
            if (staffId == null || year < 2000 || absent < 1 || truSoNgayNghi < 0 || truSoNgayNghi > _soNgayNghiQuyDinh) return false;
            var soNgayNghiCoLuong = GetDaysRemain(year, staffId);
            var tongNgayNghi = soNgayNghiCoLuong - truSoNgayNghi + absent;
            var dk = _aHrm.DaysRemains.SingleOrDefault(ab => ab.StaffID == staffId && ab.Year == year);
            return dk == null && absent <= _soNgayNghiQuyDinh || dk != null && tongNgayNghi <= _soNgayNghiQuyDinh;
        }
    }
}