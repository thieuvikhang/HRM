using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using static System.Convert;

namespace BUS
{
    public class AbsentBus
    {
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        public readonly DaysRemainBus DaysRemainBus = new DaysRemainBus();
        /// <summary>
        /// Lấy số ngày nghỉ không lương theo Mã nhân viên, tháng
        /// </summary>
        /// <param name="month">Tháng truyền vào</param>
        /// <param name="year">Năm truyền vào</param>
        /// <param name="staffId">Mã nhân viên</param>
        /// <returns>Trả về ngày nghỉ không lương</returns>
        public int GetAbsentDays(int month, int year, string staffId)
        {
            if (staffId == null || month == 0 || year == 0) return 0;
            var absentDays = _aHrm.Absents.Where(ad => ad.StaffID == staffId && ad.ToDate.Value.Year == year && ad.ToDate.Value.Month == month && ad.AbsentType == false)
                .Select(ad => ad.AbsentDay).Sum();
            return absentDays == null ? 0 : ToInt16(absentDays);
        }
        /// <summary>
        /// Lấy ra danh sách của bảng nghĩ phép
        /// </summary>
        /// <returns>Danh sách nghĩ phép</returns>
        public IQueryable GetAbsent()
        {
            return
                _aHrm.Staffs.SelectMany(nv => _aHrm.Absents, (nv, np) => new { nv, np })
                    .Where(t => t.nv.StaffID == t.np.StaffID && t.np.ToDate.Value.Year == DateTime.Now.Year)
                    .Select(t => new
                    {
                        t.np.AbsentID,
                        t.nv.StaffID,
                        t.nv.StaffName,
                        t.np.AbsentDay,
                        t.np.FromDate,
                        t.np.ToDate,
                        t.np.Note,
                        AbsentType = t.np.AbsentType == true ? "Có lương" : "Không lương"
                    });
        }
        /// <summary>
        /// Lấy ra một ngày đầu tiên với ngày truyền vào 
        /// </summary>
        /// <param name="ngay">Một ngày bất kỳ</param>
        /// <returns>Một ngày đầu của tháng</returns>
        public DateTime NgayDauThang(DateTime ngay) => new DateTime(ngay.Year, ngay.Month, 1);
        /// <summary>
        /// Lấy ra ngày cuối của ngày truyền vào
        /// </summary>
        /// <param name="ngay">Ngày truyền vào</param>
        /// <returns>Ngày cuối tháng</returns>
        public DateTime NgayCuoiThang(DateTime ngay) => ngay.AddMonths(1).AddDays(-ngay.Day);
        /// <summary>
        /// Lấy tổng số ngày chủ nhật
        /// </summary>
        /// <param name="endDate">Ngày kết thúc</param>
        /// <param name="startDate">Ngày bắt đầu</param>
        /// <returns>Số ngày chủ nhật</returns>
        public int TongNgayChuNhat(DateTime endDate, DateTime startDate)
        {
            var sunDayCount = 0;
            for (var dt = startDate; dt < endDate; dt = dt.AddDays(1.0))
            {
                if (dt.DayOfWeek != 0) continue;
                sunDayCount++;
            }
            return sunDayCount;
        }
        /// <summary>
        /// Thêm nghĩ phép
        /// </summary>
        /// <param name="maNv">Mã nhân vien</param>
        /// <param name="tuNgay">Ngày bắt đầu nghĩ</param>
        /// <param name="denNgay">Ngày vào làm lại</param>
        /// <param name="loaiNghi">Loại nghỉ phép, true = có lương</param>
        /// <param name="note">Ghi chú</param>
        /// <returns>Trả về true = thành công</returns>
        public bool SaveAbsent(string maNv, DateTime tuNgay, DateTime denNgay, bool loaiNghi, string note)
        {
            if (maNv == null) return false;
            try
            {
                var absentDay = (denNgay - tuNgay).Days - TongNgayChuNhat(denNgay, tuNgay) + 1;
                var absent = new Absent
                {
                    StaffID = maNv,
                    FromDate = tuNgay,
                    ToDate = denNgay,
                    AbsentDay = absentDay,
                    AbsentType = loaiNghi,
                    Note = note
                };
                _aHrm.Absents.InsertOnSubmit(absent);
                _aHrm.SubmitChanges();
                return DaysRemainBus.AddOrUpdateDaysRemain(maNv, absentDay, denNgay.Year, loaiNghi);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Xóa nghĩ phép
        /// </summary>
        /// <param name="maPhep">Mã nghĩ phép</param>
        /// <returns>true = thành công</returns>
        public bool DeleteAbsent(int maPhep)
        {
            try
            {
                var absent = _aHrm.Absents.Select(st => st).SingleOrDefault(st => st.AbsentID == maPhep);
                if (absent == null) return false;
                _aHrm.Absents.DeleteOnSubmit(absent);
                _aHrm.SubmitChanges();
                return absent.AbsentType != null && (absent.FromDate == null || DaysRemainBus.AddOrUpdateDaysRemain(absent.StaffID, ToInt16(absent.AbsentDay), absent.FromDate.Value.Year, absent.AbsentType.Value));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Cập nhật nghĩ phéo
        /// </summary>
        /// <param name="maPhep">Mã nghĩ phép</param>
        /// <param name="maNv">Mã nhân viên</param>
        /// <param name="tuNgay">Ngày bắt đầu</param>
        /// <param name="denNgay">Ngày vào làm lại</param>
        /// <param name="loaiNghi">Loại nghĩ phép, true = có lương</param>
        /// <param name="note">Ghi chú</param>
        /// <returns>True = thành công</returns>
        public bool UpdateAbsent(int maPhep, string maNv, DateTime tuNgay, DateTime denNgay, bool loaiNghi, string note)
        {
            try
            {
                var absentDay = (denNgay - tuNgay).Days - TongNgayChuNhat(denNgay, tuNgay) + 1;
                var absent = _aHrm.Absents.SingleOrDefault(ab => ab.AbsentID == maPhep);
                if (absent == null) return false;
                absent.AbsentID = maPhep;
                absent.StaffID = maNv;
                absent.FromDate = tuNgay;
                absent.ToDate = denNgay;
                absent.AbsentDay = absentDay;
                absent.Note = note;
                absent.AbsentType = loaiNghi;
                _aHrm.SubmitChanges();
                return DaysRemainBus.AddOrUpdateDaysRemain(maNv, absentDay, denNgay.Year, loaiNghi);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Lấy danh sách ngày mà nhân viên đã nghĩ phép trong tháng
        /// </summary>
        /// <param name="maNv">Mã nhân viên</param>
        /// <param name="ngay">Ngày</param>
        /// <returns>Danh sách ngày nghĩ phép</returns>
        public List<int> ListNgayNghi(string maNv, DateTime ngay)
        {
            var list = new List<int>();
            foreach (var item in _aHrm.Absents.Where(ab => ab.StaffID == maNv && ab.FromDate.Value.Month == ngay.Month && ab.FromDate.Value.Year == ngay.Year)
                .Select(ab => new { FromDate = ab.FromDate.Value.Day, ToDate = ab.ToDate.Value.Day }).ToList())
            {
                for (var i = item.FromDate; i <= item.ToDate; i++)
                {
                    list.Add(i);
                }
            }
            return list;
        }
        /// <summary>
        /// Tổng số ngày nghĩ có phép trong năm
        /// </summary>
        /// <param name="staffId">Mã nhân viên</param>
        /// <param name="year">Năm</param>
        /// <returns>Số ngày nghĩ có phép trong năm</returns>
        public int SumDaysRemain(string staffId, int year)
        {
            var day = _aHrm.Absents.Where(
                    c => c.StaffID == staffId && c.FromDate.Value.Year == year && c.AbsentType == true)
                .Select(c => c.AbsentDay).Sum();
            return day == null ? 0 : ToInt16(day);
        }
        /// <summary>
        /// Lấy ngày nghỉ phép lớn nhất
        /// </summary>
        /// <param name="staffId">mã nhân viên</param>
        /// <returns>Ngày nghỉ phép lớn nhất</returns>
        public int MaxValue(string staffId)
        {
            var max = (from ab in _aHrm.Absents
                       where ab.StaffID == staffId && ab.ToDate.Value.Month == DateTime.Now.Month
                       select ab.ToDate.Value.Day).Distinct().ToList();
            return max.Concat(new[] { 0 }).Max();
        }
    }
}