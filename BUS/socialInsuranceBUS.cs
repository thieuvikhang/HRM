using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BUS
{
    public class socialInsuranceBUS
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();

        // Load tat ca socialInsurance
        public IQueryable loadAllSocialInsurance()
        {
            var shawAllSocialInsurance = from si in aHRM.SocialInsurances select si;
            return shawAllSocialInsurance;
        }

        // Load tat ca socialInsurance theo StaffID
        public IQueryable loadAllSocialInsuranceWithStaffID(string staffID)
        {
            var shawAllSocialInsurance = from si in aHRM.SocialInsurances
                                         where si.StaffID == staffID
                                         select si;
            return shawAllSocialInsurance;
        }

        //Check trung ky tu
        public bool checkInputDuplicate(string stringInput)
        {
            int countDataDuplicate = (from si in aHRM.SocialInsurances
                                      where si.InsuranceID == stringInput
                                      select si).Count();
            if (countDataDuplicate == 0)
            {
                //khong co record trung ten nhap vao
                return true;
            }
            else
            {
                //co record trung ten nhap vao
                return false;
            }
        }

        //Tem moi 1 SocialInsurances
        public bool createNewSocialInsurances(string siID, DateTime NewSIMonth, int newSIPayRate, decimal newPrice, string newPayment, string staffID)
        {
            try
            {
                if (checkInputDuplicate(siID))
                {
                    SocialInsurance aSI = new SocialInsurance();

                    aSI.InsuranceID = siID;
                    aSI.InsuranceID = newPayment;
                    aSI.PayRate = newSIPayRate;
                    aSI.Price = newPrice;
                    aSI.SIMonth = NewSIMonth;
                    aSI.StaffID = staffID;

                    aHRM.SocialInsurances.InsertOnSubmit(aSI);
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

        //Sua moi 1 SocialInsurances
        public bool editASocialInsurances(string siID, DateTime NewSIMonth, int newSIPayRate, decimal newPrice, string newPayment, string staffID)
        {
            try
            {
                //tim kiem record cua SocialInsurance theo ID
                SocialInsurance aSI = aHRM.SocialInsurances.SingleOrDefault(si => si.InsuranceID == siID);
                //Kiem tra record co ton tai
                if (aSI != null)
                {
                    aSI.InsuranceID = siID;
                    aSI.InsuranceID = newPayment;
                    aSI.PayRate = newSIPayRate;
                    aSI.Price = newPrice;
                    aSI.SIMonth = NewSIMonth;
                    aSI.StaffID = staffID;
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

        // Xoa Sociallnsurance theo SociallnsuranceID
        public void deleteASociallnsurance(string sociallnsuranceID)
        {
            SocialInsurance aSI = (from si in aHRM.SocialInsurances select si).SingleOrDefault(si => si.InsuranceID == sociallnsuranceID);
            aHRM.SocialInsurances.DeleteOnSubmit(aSI);
            aHRM.SubmitChanges();
        }
    }
}
