using System;
using System.Linq;
using DAL;

namespace BUS
{
    /**
     * sectionBUS xu ly cac nghiep vu lien quan den table section
     * LoadAll, create, edit, delete, checkValueInputDuplicate
    */
    public class SectionBus
    {
        readonly HRMModelDataContext _aHrm = new HRMModelDataContext();

        // Load tat ca section
        public IQueryable LoadAll() {
            var allRecords = from st in _aHrm.Sections select st;
            return allRecords;
        }

        //Ham tim kiem nameInput trong table section
        public bool FindNameInputIntable(string nameInput) {
            //Dem record trung ten hoac so dien thoai
            int countSection = (from st in _aHrm.Sections
                                where (st.SectionName == nameInput)
                                select st).Count();

            if (countSection == 0) {
                //Khong co record trung 
                return false;
            }
            else {
                //co record trung
                return true;
            }
        }

        //Ham tim kiem idInput trong table section 
        public bool FindIdInputIntable(string idInput) {
            //Dem record trung ten hoac so dien thoai
            int countSection = (from st in _aHrm.Sections
                                where (st.SectionID == idInput)
                                select st).Count();

            if (countSection == 0) {
                //Khong co record trung 
                return false;
            }
            else {
                //co record trung
                return true;
            }
        }

        //Ham tim kiem phoneInput trong table section 
        public bool FindPhoneInputIntable(string phoneInput) {
            //Dem record trung ten hoac so dien thoai
            int countSection = (from st in _aHrm.Sections
                                where (st.Phone == phoneInput)
                                select st).Count();

            if (countSection == 0) {
                //Khong co record trung 
                return false;
            }
            else {
                //co record trung
                return true;
            }
        }

        public bool CreateASection(string idInput, string nameInput, string descriptionInput, int standWorkDayInput, string phoneInput) {
            try
            {
                if (FindIdInputIntable(idInput) == false && FindNameInputIntable(nameInput) == false) {
                    Section aSection = new Section();
                    aSection.SectionID = idInput;
                    aSection.SectionName = nameInput;
                    aSection.Description = descriptionInput;
                    aSection.StandardWorkdays = standWorkDayInput;
                    aSection.Phone = phoneInput;

                    _aHrm.Sections.InsertOnSubmit(aSection);
                    _aHrm.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception) {
                return false;
            }
        }

        public bool EditSection(string newStid, string newName, string newDescription, int newStandWorkDay, string newPhone) {
            try {
                //Tim redocrd cua section co ID
                Section aSection = _aHrm.Sections.SingleOrDefault(st => st.SectionID == newStid);
                //Kiem tra record co ton tai
                if (aSection != null) {
                    aSection.SectionID = newStid;
                    aSection.SectionName = newName;
                    aSection.Description = newDescription;
                    aSection.StandardWorkdays = newStandWorkDay;
                    aSection.Phone = newPhone;
                    _aHrm.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception) {
                return false;
            }
        }

        public bool DeleteASection(string idInput) {
            try {
                Section aSection = (from st in _aHrm.Sections select st).SingleOrDefault(st => st.SectionID == idInput);
                if(aSection != null) {
                    _aHrm.Sections.DeleteOnSubmit(aSection);
                    _aHrm.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception) {
                return false;
            }
        }
        //Lấy só ngày công quy định dựa vào Mã phòng ban
        public int GetStandardWorkdaysBySectionId(string sectionId)
        {
            var standardWorkday = (from s in _aHrm.Sections where s.SectionID == sectionId select s.StandardWorkdays).FirstOrDefault();
            return Convert.ToInt16(standardWorkday);
        }
    }
}
