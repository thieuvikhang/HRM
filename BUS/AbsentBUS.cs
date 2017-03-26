using System;
using System.Collections.Generic;
using DAL;
using System.Linq;
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
            var absentDays = _aHrm.Absents.Where(ad => ad.StaffID == staffId
                                                       && ad.ToDate.Value.Year == year
                                                       && ad.ToDate.Value.Month == month
                                                       && ad.AbsentType == false).Select(ad => ad.AbsentDay).Sum();
            return ToInt16(absentDays);
        }
        /// <summary>
        /// Lấy ra danh sách của bảng nghĩ phép
        /// </summary>
        /// <returns>Danh sách nghĩ phép</returns>
        public IQueryable GetAbsent()
        {
            return from nv in _aHrm.Staffs
                   from np in _aHrm.Absents
                   where nv.StaffID == np.StaffID
                   select new
                   {
                       np.AbsentID,
                       nv.StaffID,
                       nv.StaffName,
                       np.AbsentDay,
                       np.FromDate,
                       np.ToDate,
                       np.Note,
                       AbsentType = np.AbsentType == true ? "Có lương" : "Không lương",
                   };
        }
        /// <summary>
        /// Lấy ra một ngày đầu tiên với ngày truyền vào 
        /// </summary>
        /// <param name="ngay">Một ngày bất kỳ</param>
        /// <returns>Một ngày đầu của tháng</returns>
        public DateTime NgayDauThang(DateTime ngay)
        {
            return new DateTime(ngay.Year, ngay.Month, 1);
        }
        /// <summary>
        /// Lấy ra ngày cuối của ngày truyền vào
        /// </summary>
        /// <param name="ngay">Ngày truyền vào</param>
        /// <returns>Ngày cuối tháng</returns>
        public DateTime NgayCuoiThang(DateTime ngay)
        {
            return ngay.AddMonths(1).AddDays(-ngay.Day);
        }

        /// <summary>
        /// Trả về ngày không được chọn
        /// </summary>
        /// <param name="ngay">Ngày truyền vào</param>
        /// <returns>true = ngày không được chọn</returns>
        public bool IsHoliday(DateTime ngay)
        {
            //Ngày chủ nhật
            return ngay.DayOfWeek == 0;
        }
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
                var absentDay = (denNgay - tuNgay).Days - TongNgayChuNhat(denNgay, tuNgay);
                var absent = new Absent
                {
                    StaffID = maNv,
                    FromDate = tuNgay,
                    ToDate = denNgay,
                    AbsentDay = absentDay,
                    AbsentType = loaiNghi,
                    Note = note
                };
                if (loaiNghi)
                {
                    return DaysRemainBus.AddOrUpdateDaysRemain(maNv, absentDay, denNgay.Year);
                }
                _aHrm.Absents.InsertOnSubmit(absent);
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
        /// Xóa nghĩ phép
        /// </summary>
        /// <param name="maPhep">Mã nghĩ phép</param>
        /// <returns>true = thành công</returns>
        public bool DeleteAbsent(int maPhep)
        {
            try
            {
                var absent = (from st in _aHrm.Absents select st).SingleOrDefault(st => st.AbsentID == maPhep);
                if (absent == null) return false;
                if (absent.FromDate != null && absent.AbsentType == true)
                {
                    return DaysRemainBus.AddOrUpdateDaysRemain(absent.StaffID, -ToInt16(absent.AbsentDay), absent.FromDate.Value.Year);
                }
                _aHrm.Absents.DeleteOnSubmit(absent);
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
                var absentDay = (denNgay - tuNgay).Days - TongNgayChuNhat(denNgay, tuNgay);
                var absent = _aHrm.Absents.SingleOrDefault(ab => ab.AbsentID == maPhep);
                if (absent == null) return false;
                absent.AbsentID = maPhep;
                absent.StaffID = maNv;
                absent.FromDate = tuNgay;
                absent.ToDate = denNgay;
                absent.AbsentDay = absentDay;
                absent.Note = note;
                absent.AbsentType = loaiNghi;
                if (DaysRemainBus.AddOrUpdateDaysRemain(maNv, absentDay, denNgay.Year))
                {
                    return true;
                }
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
        /// Lấy danh sách ngày mà nhân viên đã nghĩ phép trong tháng
        /// </summary>
        /// <param name="maNv">Mã nhân viên</param>
        /// <param name="ngay">Ngày</param>
        /// <returns>Danh sách ngày nghĩ phép</returns>
        public List<int> ListNgayNghi(string maNv, DateTime ngay)
        {
            var list = new List<int>();
            foreach (var item in _aHrm.Absents.Where(ab => ab.StaffID == maNv
                                                           && ab.FromDate.Value.Month == ngay.Month
                                                           && ab.FromDate.Value.Year == ngay.Year).Select(ab => new
                                                           {
                                                               FromDate = ab.FromDate.Value.Day,
                                                               ToDate = ab.ToDate.Value.Day
                                                           }).ToList())
            {
                for (var i = item.FromDate; i < item.ToDate; i++)
                {
                    list.Add(i);
                }
            }
            return list;
        }
    }
}