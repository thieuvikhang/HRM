using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    /**
     * contractBUS xu ly cac nghiep vu lien quan den table contract
     * LoadAll, create, edit, delete, checkValueInputDuplicate
    */
    public class socialInsuranceBUS
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();

        // Load tat ca socialInsurance
        public IQueryable loadAll() {
            var allRecords = from si in aHRM.SocialInsurances select si;
            return allRecords;
        }

        // Load tat ca socialInsurance theo StaffID
        public IQueryable loadAllWithStaffID(string idInput) {
            var allRecords = from si in aHRM.SocialInsurances
                                         where si.StaffID == idInput
                                         select si;
            return allRecords;
        }

        //Check trung ky tu
        public bool findIDInputInTable(string idInput) {
            int numberOfRecords = (from si in aHRM.SocialInsurances
                                      where si.InsuranceID == idInput
                                      select si).Count();
            if (numberOfRecords == 0) {
                //khong co record trung ten nhap vao
                return false;
            }
            else {
                //co record trung ten nhap vao
                return true;
            }
        }

        //Tem moi 1 SocialInsurances
        public bool createASocialInsurances(string idInput, DateTime monthInput, int payRateInput, decimal priceInput, string paymentInput, string staffIDInput) {
            try {
                if (!findIDInputInTable(idInput)) {
                    SocialInsurance aSI = new SocialInsurance();
                    aSI.InsuranceID = idInput;
                    aSI.InsuranceID = paymentInput;
                    aSI.PayRate = payRateInput;
                    aSI.Price = priceInput;
                    aSI.SIMonth = monthInput;
                    aSI.StaffID = staffIDInput;

                    aHRM.SocialInsurances.InsertOnSubmit(aSI);
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

        //Sua moi 1 SocialInsurances
        public bool editASocialInsurances(string idInput, DateTime monthInput, int payRateInput, decimal priceInput, string paymentInput, string staffIDInput) {
            try {
                //tim kiem record cua SocialInsurance theo ID
                SocialInsurance aSI = aHRM.SocialInsurances.SingleOrDefault(si => si.InsuranceID == idInput);
                //Kiem tra record co ton tai
                if (aSI != null) {
                    aSI.InsuranceID = paymentInput;
                    aSI.PayRate = payRateInput;
                    aSI.Price = priceInput;
                    aSI.SIMonth = monthInput;
                    aSI.StaffID = staffIDInput;
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

        // Xoa Sociallnsurance theo SociallnsuranceID
        public bool deleteASociallnsurance(string sociallnsuranceID) {
            try {
                SocialInsurance aSI = aHRM.SocialInsurances.SingleOrDefault(si => si.InsuranceID == sociallnsuranceID);
                if(aSI != null) {
                    aHRM.SocialInsurances.DeleteOnSubmit(aSI);
                    aHRM.SubmitChanges();
                    return true;
                }
                else {
                    return false;
                }
            } catch (Exception ex) {
                return false;
            }
        }
    }
}
