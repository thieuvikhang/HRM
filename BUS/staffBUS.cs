using DAL;
using System;
using System.Linq;

namespace BUS
{
    public class staffBUS
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();
        public IQueryable loadStaff()
        {
            var loadStaff = (from st in aHRM.Staffs
                             from post in aHRM.Positions
                             from sec in aHRM.Sections
                             where st.PostID == post.PostID && st.SectionID == sec.SectionID
                          select new
                          {
                              st.StaffID,
                              st.Name,
                              st.Gender,
                              st.BirthDay,
                              st.CardID,
                              st.Phone,
                              st.Address,
                              st.Education,
                              st.Email,
                              postName = post.Name,                        
                              secName = sec.Name
                          });
            return loadStaff;
        }
        //Lấy số ID phòng ban dựa vào Mã nhân viên
        public string GetSectionIDByStaffID(string staffID)
        {
            var sectionID = (from s in aHRM.Staffs where s.StaffID == staffID select s.SectionID).FirstOrDefault();
            return Convert.ToString(sectionID);
        }
    }
}
