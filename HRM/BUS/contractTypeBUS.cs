using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class contractTypeBUS
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();

        // Load tat ca contract
        public IQueryable loadAllContractType()
        {
            var shawAllContractType = from ct in aHRM.ContractTypes select ct;
            return shawAllContractType;
        }

        //Check giatri nhap vao vs record trong database
        public bool CheckName(string contractTypeName)
        {
            int countContractType = (from ctt in aHRM.ContractTypes
                                     where ctt.Name == contractTypeName
                                     select ctt).Count();
            if (countContractType == 0)
            {
                //khong co record naof trung 
                return true;
            }
            else
            {
                //Tim ra co record trung
                return false;
            }
        }

        //Check giatri nhap vao vs record trong database
        public bool CheckID(string contractTypeID)
        {
            int countContractType = (from ctt in aHRM.ContractTypes
                                     where ctt.ContractTypeID == contractTypeID
                                     select ctt).Count();
            if (countContractType == 0)
            {
                //khong co record naof trung 
                return true;
            }
            else
            {
                //Tim ra co record trung
                return false;
            }
        }

        public bool createNewContractType(string newContractTypeID, string newContractTypeName)
        {
            try
            {
                if (CheckName(newContractTypeName))
                {
                    ContractType aContractType = new ContractType();
                    aContractType.ContractTypeID = newContractTypeID;
                    aContractType.Name = newContractTypeName;
                    aHRM.ContractTypes.InsertOnSubmit(aContractType);
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
    }
}
