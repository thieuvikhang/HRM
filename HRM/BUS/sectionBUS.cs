using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class sectionBUS
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();

        // Load tat ca section
        public IQueryable loadAllSection()
        {
            var shawAllSection = from st in aHRM.Sections select st;
            return shawAllSection;
        }

        public bool checkInputDuplicate(string stringInput)
        {
            //Dem record trung ten hoac so dien thoai
            int countSection = (from st in aHRM.Sections
                                where (st.Name == stringInput) || (st.Phone == stringInput) || (st.SectionID == stringInput)
                                select st).Count();

            if(countSection == 0)
            {
                //Khong co record trung 
                return true;
            }
            else
            {
                //co record trung
                return false;
            }
        }

        public bool createASection(string newSTID, string newName, string newDescription, int NewStandWorkDay, string newPhone)
        {
            try
            {
                if (checkInputDuplicate(newSTID) == true || checkInputDuplicate(newPhone) == true || checkInputDuplicate(newSTID) == true)
                {
                    Section aSection = new Section();
                    aSection.SectionID = newSTID;
                    aSection.Name = newName;
                    aSection.Description = newDescription;
                    aSection.StandardWorkdays = NewStandWorkDay;
                    aSection.Phone = newPhone;

                    aHRM.Sections.InsertOnSubmit(aSection);
                    aHRM.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ecitSection(string newSTID, string newName, string newDescription, int NewStandWorkDay, string newPhone)
        {
            try
            {
                //Tim redocrd cua section co ID
                Section aSection = aHRM.Sections.SingleOrDefault(st => st.SectionID == newSTID);
                //Kiem tra record co ton tai
                if(aSection != null){
                    aSection.SectionID = newSTID;
                    aSection.Name = newName;
                    aSection.Description = newDescription;
                    aSection.StandardWorkdays = NewStandWorkDay;
                    aSection.Phone = newPhone;
                    aHRM.SubmitChanges();
                    return true;
                }else
                {
                    return false;
                }
                    
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool deleteASection(string sectionID)
        {
            try
            {
                Section aSection = (from st in aHRM.Sections select st).SingleOrDefault(st => st.SectionID == sectionID);
                aHRM.Sections.DeleteOnSubmit(aSection);
                aHRM.SubmitChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
