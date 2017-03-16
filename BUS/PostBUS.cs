using DAL;
using System;
using System.Linq;

namespace BUS
{
    public class PostBus
    {
        readonly HRMModelDataContext _aHrm = new HRMModelDataContext();

        // Load tat ca section
        public IQueryable LoadAll()
        {
            var allRecords = from st in _aHrm.Positions select st;
            return allRecords;
        }
       //
        public bool GetMainId(string maPhongBan)
        {
            var exist = (from st in _aHrm.Staffs
                         from sect in _aHrm.Sections
                         from pos in _aHrm.Positions
                         where st.PostID == pos.PostID && st.SectionID == sect.SectionID
                         && sect.SectionID == maPhongBan
                         && pos.PostName == "Trưởng phòng"
                         select st).Any();
            return exist;
        }
        public IQueryable LoadAllCheck()
        {
            var allRecords = from st in _aHrm.Positions
                             from staf in _aHrm.Staffs
                             from sec in _aHrm.Sections
                             where (st.PostID == staf.PostID && staf.SectionID == sec.SectionID && st.PostName =="Trưởng phòng")
                               select staf.StaffID;
            return allRecords;
        }
        //tim key trung
        public bool FindIdInputIntable(string id)
        {
            //Dem record trung ten hoac so dien thoai
            int count = (from st in _aHrm.Positions
                                where (st.PostID == id)
                                select st).Count();

            return count != 0;
        }
        public bool FindNameInputIntable(string name)
        {
            //Dem record trung ten hoac so dien thoai
            var count = (from st in _aHrm.Positions
                         where (st.PostName == name)
                         select st).Count();

            return count != 0;
        }
        public bool CreateAPost(string idInput, string nameInput, string descriptionInput)
        {
            try
            {
                if (FindIdInputIntable(idInput) == false && FindNameInputIntable(nameInput) == false)
                {
                    var aPost = new Position
                    {
                        PostID = idInput,
                        PostName = nameInput,
                        Description = descriptionInput
                    };

                    _aHrm.Positions.InsertOnSubmit(aPost);
                    _aHrm.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EditPost(string newStid, string newName, string newDescription)
        {
            try
            {
                //Tim redocrd cua section co ID
                Position aPost = _aHrm.Positions.SingleOrDefault(st => st.PostID == newStid);
                //Kiem tra record co ton tai
                if (aPost != null)
                {
                    aPost.PostID = newStid;
                    aPost.PostName = newName;
                    aPost.Description = newDescription;

                    _aHrm.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteAPost(string idInput)
        {
            try
            {
                Position aPost = (from st in _aHrm.Positions select st).SingleOrDefault(st => st.PostID == idInput);
                if (aPost != null)
                {
                    _aHrm.Positions.DeleteOnSubmit(aPost);
                    _aHrm.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
