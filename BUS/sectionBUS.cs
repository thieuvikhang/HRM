using System;
using System.Linq;
using DAL;

namespace BUS
{
    /**
     * sectionBUS xu ly cac nghiep vu lien quan den table section
     * LoadAll, create, edit, delete, checkValueInputDuplicate
    */
    public class sectionBUS
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();

        // Load tat ca section
        public IQueryable loadAll() {
            var allRecords = from st in aHRM.Sections select st;
            return allRecords;
        }

        //Ham tim kiem nameInput trong table section
        public bool findNameInputIntable(string nameInput) {
            //Dem record trung ten hoac so dien thoai
            int countSection = (from st in aHRM.Sections
                                where (st.Name == nameInput)
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
        public bool findIDInputIntable(string idInput) {
            //Dem record trung ten hoac so dien thoai
            int countSection = (from st in aHRM.Sections
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
        public bool findPhoneInputIntable(string phoneInput) {
            //Dem record trung ten hoac so dien thoai
            int countSection = (from st in aHRM.Sections
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

        public bool createASection(string idInput, string nameInput, string descriptionInput, int standWorkDayInput, string phoneInput) {
            try {
                if (findIDInputIntable(idInput) == false && findPhoneInputIntable(phoneInput) == false && findNameInputIntable(nameInput) == false) {
                    Section aSection = new Section();
                    aSection.SectionID = idInput;
                    aSection.Name = nameInput;
                    aSection.Description = descriptionInput;
                    aSection.StandardWorkdays = standWorkDayInput;
                    aSection.Phone = phoneInput;

                    aHRM.Sections.InsertOnSubmit(aSection);
                    aHRM.SubmitChanges();
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception ex) {
                return false;
            }
        }

        public bool editSection(string newSTID, string newName, string newDescription, int NewStandWorkDay, string newPhone) {
            try {
                //Tim redocrd cua section co ID
                Section aSection = aHRM.Sections.SingleOrDefault(st => st.SectionID == newSTID);
                //Kiem tra record co ton tai
                if (aSection != null) {
                    aSection.SectionID = newSTID;
                    aSection.Name = newName;
                    aSection.Description = newDescription;
                    aSection.StandardWorkdays = NewStandWorkDay;
                    aSection.Phone = newPhone;
                    aHRM.SubmitChanges();
                    return true;
                }
                else {
                    return false;
                }

            }
            catch (Exception ex) {
                return false;
            }
        }

        public bool deleteASection(string idInput) {
            try {
                Section aSection = (from st in aHRM.Sections select st).SingleOrDefault(st => st.SectionID == idInput);
                if(aSection != null) {
                    aHRM.Sections.DeleteOnSubmit(aSection);
                    aHRM.SubmitChanges();
                    return true;
                }
                else {
                    return false;
                } 
            }
            catch (Exception ex) {
                return false;
            }
        }
        //Lấy só ngày công quy định dựa vào Mã phòng ban
        public int GetStandardWorkdaysBySectionID(string sectionID)
        {
            var standardWorkday = (from s in aHRM.Sections where s.SectionID == sectionID select s.StandardWorkdays).FirstOrDefault();
            return Convert.ToInt16(standardWorkday);
        }
    }
}
