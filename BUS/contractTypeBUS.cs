using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    /**
     * contractTypeBUS xu ly cac nghiep vu lien quan den table contractType
     * LoadAll, create, edit, delete, checkValueInputDuplicate
    */
    public class contractTypeBUS
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();

        // Load tat ca contract
        public IQueryable loadAll() {
            var AllContractType = from ct in aHRM.ContractTypes select ct;
            return AllContractType;
        }


        //Ham tim kiem nameInput trong table contractType
        public bool findNameInputInTable(string nameInput) {
            int nunberOfRecords = (from ctt in aHRM.ContractTypes
                                     where ctt.Name == nameInput
                                     select ctt.Name).Count();
            if (nunberOfRecords == 0) {
                //nameInput khong ton tai trong table contractType
                return false;
            }
            else {
                //nameInput da ton tai trong table contractType
                return true;
            }
        }

        //Ham tim kiem idInput Trong table contractType
        public bool findIdInputInTable(string idInput) {
            int numberOfRecord = (from ctt in aHRM.ContractTypes
                                     where ctt.ContractTypeID == idInput
                                     select ctt.ContractTypeID).Count();
            if (numberOfRecord == 0) {
                //idInput Khong ton tai trong table contractType
                return false;
            }
            else {
                //idInput da ton tai trong contractType
                return true;
            }
        }

        public bool createAContractType(string idInput, string nameInput) {
            try {
                //check su ton tai cua nameInput va idInput trong database
                if (findNameInputInTable(nameInput) == false && findIdInputInTable(idInput) == false) {
                    ContractType aContractType = new ContractType();
                    aContractType.ContractTypeID = idInput;
                    aContractType.Name = nameInput;
                    aHRM.ContractTypes.InsertOnSubmit(aContractType);
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

        public bool editAContractType(string idInput, string nameInput) {
            try {
                //kiem tra nameInput co ton tai trong database
                if(!findNameInputInTable(nameInput)) {
                    ContractType aContractType = aHRM.ContractTypes.SingleOrDefault(ctt => ctt.ContractTypeID == idInput);
                    aContractType.Name = nameInput;
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

        //Ham xoa 1 contractType
        public bool deleteAContractType(string idIput) {
            try {
                //kiem tra idInput co ton tai trong database
                if(findIdInputInTable(idIput)) {
                    ContractType aContracType = aHRM.ContractTypes.SingleOrDefault(ctt => ctt.ContractTypeID == idIput);
                    aHRM.ContractTypes.DeleteOnSubmit(aContracType);
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
    }
}