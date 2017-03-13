using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PostBUS
    {
        readonly HRMModelDataContext _aHrm = new HRMModelDataContext();

        // Load tat ca section
        public IQueryable LoadAll()
        {
            var allRecords = from st in _aHrm.Positions select st;
            return allRecords;
        }
        //tim key trung
        public bool FindIdInputIntable(string id)
        {
            //Dem record trung ten hoac so dien thoai
            int count = (from st in _aHrm.Positions
                                where (st.PostID == id)
                                select st).Count();

            if (count == 0)
            {
                //Khong co record trung 
                return false;
            }
            else
            {
                //co record trung
                return true;
            }
        }
        public bool FindNameInputIntable(string name)
        {
            //Dem record trung ten hoac so dien thoai
            int count = (from st in _aHrm.Positions
                         where (st.PostName == name)
                         select st).Count();

            if (count == 0)
            {
                //Khong co record trung 
                return false;
            }
            else
            {
                //co record trung
                return true;
            }
        }
        public bool CreateAPost(string idInput, string nameInput, string descriptionInput)
        {
            try
            {
                if (FindIdInputIntable(idInput) == false && FindNameInputIntable(nameInput) == false)
                {
                    Position aPost = new Position();
                    aPost.PostID = idInput;
                    aPost.PostName = nameInput;
                    aPost.Description = descriptionInput;

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
