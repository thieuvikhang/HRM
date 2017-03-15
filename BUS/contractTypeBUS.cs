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
        readonly HRMModelDataContext _aHrm = new HRMModelDataContext();

        // Load tat ca contract
        public IQueryable LoadAll() {
            var allContractType = from ct in _aHrm.ContractTypes select ct;
            return allContractType;
        }


        //Ham tim kiem nameInput trong table contractType
        public bool FindNameInputInTable(string nameInput) {
            int nunberOfRecords = (from ctt in _aHrm.ContractTypes
                                     where ctt.ContractTypeName == nameInput
                                     select ctt.ContractTypeName).Count();
            if (nunberOfRecords == 0) {
                //nameInput khong ton tai trong table contractType
                return false;
            }
            //nameInput da ton tai trong table contractType
            return true;
        }

        //Ham tim kiem idInput Trong table contractType
        public bool FindIdInputInTable(string idInput) {
            int numberOfRecord = (from ctt in _aHrm.ContractTypes
                                     where ctt.ContractTypeID == idInput
                                     select ctt.ContractTypeID).Count();
            if (numberOfRecord == 0) {
                //idInput Khong ton tai trong table contractType
                return false;
            }
            //idInput da ton tai trong contractType
            return true;
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
                _aHrm.ContractTypes.InsertOnSubmit(aContractType);
                _aHrm.SubmitChanges();
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
                var aContractType = _aHrm.ContractTypes.SingleOrDefault(ctt => ctt.ContractTypeID == idInput);
                if (aContractType != null) aContractType.ContractTypeName = nameInput;
                _aHrm.SubmitChanges();
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
                if(FindIdInputInTable(idIput)) {
                    var aContracType = _aHrm.ContractTypes.SingleOrDefault(ctt => ctt.ContractTypeID == idIput);
                    if (aContracType != null) _aHrm.ContractTypes.DeleteOnSubmit(aContracType);
                    _aHrm.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception) {
                return false;
            }
        }
    }
}