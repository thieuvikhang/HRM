using System;
using System.Linq;
using DAL;

namespace BUS
{
    /**
     * contractTypeBUS xu ly cac nghiep vu lien quan den table contractType
     * LoadAll, create, edit, delete, checkValueInputDuplicate
    */
    public class ContractTypeBus
    {
        public readonly HRMModelDataContext AHrm = new HRMModelDataContext();

        // Load tat ca contract
        public IQueryable LoadAll() {
            var allContractType = from ct in AHrm.ContractTypes select ct;
            return allContractType;
        }


        //Ham tim kiem nameInput trong table contractType
        public bool FindNameInputInTable(string nameInput) {
            var nunberOfRecords = (from ctt in AHrm.ContractTypes
                                     where ctt.ContractTypeName == nameInput
                                     select ctt.ContractTypeName).Count();
            return nunberOfRecords != 0;
            //nameInput da ton tai trong table contractType
        }

        //Ham tim kiem idInput Trong table contractType
        public bool FindIdInputInTable(string idInput) {
            var numberOfRecord = (from ctt in AHrm.ContractTypes
                                     where ctt.ContractTypeID == idInput
                                     select ctt.ContractTypeID).Count();
            return numberOfRecord != 0;
            //idInput da ton tai trong contractType
        }

        public bool CreateAContractType(string idInput, string nameInput) {
            try
            {
                //check su ton tai cua nameInput va idInput trong database
                if (FindNameInputInTable(nameInput) || FindIdInputInTable(idInput)) return false;
                var aContractType = new ContractType
                {
                    ContractTypeID = idInput,
                    ContractTypeName = nameInput
                };
                AHrm.ContractTypes.InsertOnSubmit(aContractType);
                AHrm.SubmitChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public bool EditAContractType(string idInput, string nameInput) {
            try
            {
                //kiem tra nameInput co ton tai trong database
                if (FindNameInputInTable(nameInput)) return false;
                var aContractType = AHrm.ContractTypes.SingleOrDefault(ctt => ctt.ContractTypeID == idInput);
                if (aContractType != null) aContractType.ContractTypeName = nameInput;
                AHrm.SubmitChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        //Ham xoa 1 contractType
        public bool DeleteAContractType(string idIput) {
            try
            {
                //kiem tra idInput co ton tai trong database
                if (!FindIdInputInTable(idIput)) return false;
                var aContracType = AHrm.ContractTypes.SingleOrDefault(ctt => ctt.ContractTypeID == idIput);
                if (aContracType != null) AHrm.ContractTypes.DeleteOnSubmit(aContracType);
                AHrm.SubmitChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
    }
}