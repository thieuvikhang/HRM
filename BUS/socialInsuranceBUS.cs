using System;
using System.Linq;
using DAL;

namespace BUS
{
    /**
     * contractBUS xu ly cac nghiep vu lien quan den table contract
     * LoadAll, create, edit, delete, checkValueInputDuplicate
    */
    public class SocialInsuranceBus
    {
        public readonly HRMModelDataContext AHrm = new HRMModelDataContext();

        // Load tat ca socialInsurance
        public IQueryable LoadAll() {
            var allRecords = from si in AHrm.SocialInsurances
                             from sta in AHrm.Staffs
                             where si.StaffID == sta.StaffID
                             select new {
                                 si.InsuranceID,
                                 sta.StaffName,
                                 si.SIStartDate,
                                 si.PayRate,
                                 si.Price
                             };
            return allRecords;
        }

        // Load tat ca socialInsurance theo StaffID
        public IQueryable LoadAllWithStaffId(string idInput) {
            var allRecords = from si in AHrm.SocialInsurances
                                         where si.StaffID == idInput
                                         select si;
            return allRecords;
        }

        public int countAllStaffHasNotsocial()
        {
            var allInfoOfStaff = from sta in AHrm.Staffs
                                 from post in AHrm.Positions
                                 from sect in AHrm.Sections
                                 where !AHrm.SocialInsurances.Any(social => social.StaffID == sta.StaffID)
                                 && sta.PostID == post.PostID
                                 && sta.SectionID == sect.SectionID
                                 select new
                                 {
                                     sta.StaffID,
                                     sta.StaffName,
                                     post.PostName,
                                     sect.SectionName
                                 };

            int numbStaffHasInConTract = (from st in allInfoOfStaff
                                        where AHrm.Contracts.Any(ct => ct.StaffID == st.StaffID)
                                        select st).Count();
            return numbStaffHasInConTract;
        }

        public IQueryable loadAllInfoOfStaff()
        {
            var allInfoOfStaff = from sta in AHrm.Staffs
                           from post in AHrm.Positions
                           from sect in AHrm.Sections
                           where !AHrm.SocialInsurances.Any(social => social.StaffID == sta.StaffID)
                           && sta.PostID == post.PostID
                           && sta.SectionID == sect.SectionID
                           select new {
                               sta.StaffID,
                               sta.StaffName,
                               post.PostName,
                               sect.SectionName
                           };

            var allStaffHasInConTract = from st in allInfoOfStaff
                                        where AHrm.Contracts.Any(ct => ct.StaffID == st.StaffID)
                                        select st;
            return allStaffHasInConTract;
        }



        //Check trung ky tu
        public bool FindIdInputInTable(string idInput)
        {
            var numberOfRecords = (from si in AHrm.SocialInsurances
                where si.InsuranceID == idInput
                select si).Count();
            return numberOfRecords != 0;
        }

        //Tem moi 1 SocialInsurances
        public bool CreateASocialInsurances(string idInput, DateTime monthInput, int payRateInput, decimal priceInput, string staffIdInput) {
            try
            {
                if (FindIdInputInTable(idInput)) return false;
                var aSi = new SocialInsurance {InsuranceID = idInput};
                aSi.InsuranceID = idInput;
                aSi.PayRate = payRateInput;
                aSi.Price = priceInput;
                aSi.SIStartDate = monthInput;
                aSi.StaffID = staffIdInput;

                AHrm.SocialInsurances.InsertOnSubmit(aSi);
                AHrm.SubmitChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        //Sua moi 1 SocialInsurances
        public bool EditASocialInsurances(string idInput, DateTime monthInput, int payRateInput, decimal priceInput, string staffIdInput) {
            try {
                //tim kiem record cua SocialInsurance theo ID
                var aSi = AHrm.SocialInsurances.SingleOrDefault(si => si.InsuranceID == idInput);
                //Kiem tra record co ton tai
                if (aSi == null) return false;
                aSi.InsuranceID = idInput;
                aSi.PayRate = payRateInput;
                aSi.Price = priceInput;
                aSi.SIStartDate = monthInput;
                aSi.StaffID = staffIdInput;
                AHrm.SubmitChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        // Xoa Sociallnsurance theo SociallnsuranceID
        public bool DeleteASociallnsurance(string sociallnsuranceId) {
            try {
                var aSi = AHrm.SocialInsurances.SingleOrDefault(si => si.InsuranceID == sociallnsuranceId);
                if (aSi == null) return false;
                AHrm.SocialInsurances.DeleteOnSubmit(aSi);
                AHrm.SubmitChanges();
                return true;
            } catch (Exception) {
                return false;
            }
        }


    }
}
