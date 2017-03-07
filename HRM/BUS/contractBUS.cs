using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class contractBUS
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();

        // Load tat ca contract
        public IQueryable loadAllContract()
        {
            var shawAllContract = from ct in aHRM.Contracts select ct;
            return shawAllContract;
        }

        //Load contract theo contractTypeID
        // Load tat ca contract
        public IQueryable loadAllContractWhitType(string contractTypeID)
        {
            var shawAllContract = from ct in aHRM.Contracts
                                  where ct.ContractTypeID == contractTypeID
                                  select ct;
            return shawAllContract;
        }

        // Them 1 contract
        public void CreateNewContract(string newContractID, DateTime newDate, string newCurrency,
            DateTime newStartDate, DateTime newEndDate, bool newStatus,
            decimal newBasicPay, string newPayment, string newNote, string staffID, string contractTypeID)
        {
            //tao mot doi tuong 
            Contract newContract = new Contract();

            newContract.ContractID = newContractID;
            newContract.Date = newDate;
            newContract.Currency = newCurrency;
            newContract.StartDate = newStartDate;
            newContract.EndDate = newEndDate;
            newContract.Status = newStatus;
            newContract.BasicPay = newBasicPay;
            newContract.Payment = newPayment;
            newContract.Note = newNote;
            newContract.StaffID = staffID;
            newContract.ContractTypeID = contractTypeID;

            // Thong tin khach hang se dc luu lai
            aHRM.Contracts.InsertOnSubmit(newContract);

            //luu thong tin xuong SQL
            aHRM.SubmitChanges();
        }

        // Sua thong tin contract
        public void EditContract(string newCOntractID, DateTime newDate, string newCurrency,
            DateTime newStartDate, DateTime newEndDate, bool newStatus,
            decimal newBasicPay, string newPayment, string newNote, string staffID, string contractTypeID)
        {

            Contract newContract = (from ct in aHRM.Contracts select ct).SingleOrDefault(ct => ct.ContractID == newCOntractID);

            newContract.Date = newDate;
            newContract.Currency = newCurrency;
            newContract.StartDate = newStartDate;
            newContract.EndDate = newEndDate;
            newContract.Status = newStatus;
            newContract.BasicPay = newBasicPay;
            newContract.Payment = newPayment;
            newContract.Note = newNote;
            newContract.StaffID = staffID;
            newContract.ContractTypeID = contractTypeID;

            //thay doi csdl trong SQL
            aHRM.SubmitChanges();
        }

        // Xoa contract theo contractID
        public void DeleteContract(string contractID)
        {
            Contract contract = (from ct in aHRM.Contracts select ct).SingleOrDefault(ct => ct.ContractID == contractID);
            aHRM.Contracts.DeleteOnSubmit(contract);
            aHRM.SubmitChanges();
        }
    }
}
