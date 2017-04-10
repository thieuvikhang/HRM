﻿using System;
using System.Linq;
using DAL;

namespace BUS
{
    /**
     * contractBUS xu ly cac nghiep vu lien quan den table contract
     * LoadAll, create, edit, delete, checkValueInputDuplicate
    */
    public class ContractBus
    {
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();

        //Load all contract
        //public IQueryable LoadAll() {
        //    var allContract = _aHrm.Contracts.OrderByDescending(ct => ct.Date);
        //    return allContract;
        //}

        public IQueryable LoadAll()
        {
            var allContract = from ct in _aHrm.Contracts
                              from st in _aHrm.Staffs
                              where ct.StaffID == st.StaffID
                              select new
                              {
                                  ct.ContractID,
                                  st.StaffName,
                                  ct.Date,
                                  ct.StartDate,
                                  ct.EndDate,
                                  ct.BasicPay
                              };
            return allContract;
        }

        //LoadAll contract whith contractTypeID

        //Ham tim kiem idInput trong table contract
        public bool FindIdInputInTable(string idInput)
        {
            var numberOfRecords = (from ct in _aHrm.Contracts
                               where ct.ContractID == idInput
                               select ct).Count();
            return numberOfRecords != 0;
        }

        //Kiem tra thoi han hop dong
        public bool CheckIdInputInTable(string idInput)
        {
            var numberOfRecords = (from ct in _aHrm.Contracts
                                   where idInput==ct.StaffID && ct.EndDate > DateTime.Now
                                   select ct).Count();
            return numberOfRecords != 0;
        }
        //Create a contract
        public bool CreateAContract(string idInput, DateTime? dateInput, string currencyInput, DateTime? startDateInput, 
            DateTime? endDateInput, bool statusInput, decimal basicPayInput, string paymentInput, string noteInput, 
            string staffIdInput, int contractTypeIdInput) {
            try
            {
                //Kiem tra idInput vs Id trong table contract
                if (FindIdInputInTable(idInput)) return false;
                //tao mot doi tuong 
                var aContract = new Contract
                {
                    ContractID = idInput,
                    Date = dateInput,
                    Currency = currencyInput,
                    StartDate = startDateInput,
                    EndDate = endDateInput,
                    Status = statusInput,
                    BasicPay = basicPayInput,
                    Payment = paymentInput,
                    Note = noteInput,
                    StaffID = staffIdInput,
                    ContractTypeID = contractTypeIdInput
                };
                // Thong tin khach hang se dc luu lai
                _aHrm.Contracts.InsertOnSubmit(aContract);
                // Luu thong tin xuong SQL
                _aHrm.SubmitChanges();
                return true;
            }
            catch (Exception) {
                return false;
            } 
        }

        //Ham edit mot contract
        public bool EditContract(string idInput, DateTime? dateInput, string currencyInput, DateTime? startDateInput,
            DateTime? endDateInput, bool statusInput, decimal basicPayInput, string paymentInput, string noteInput,
            string staffIdInput, int contractTypeIdInput) {
            try {
                var aContract = _aHrm.Contracts.SingleOrDefault(ct => ct.ContractID == idInput);
                //kiem tra aContract co tontai
                if (aContract == null) return false;
                aContract.Date = dateInput;
                aContract.Currency = currencyInput;
                aContract.StartDate = startDateInput;
                aContract.EndDate = endDateInput;
                aContract.Status = statusInput;
                aContract.BasicPay = basicPayInput;
                aContract.Payment = paymentInput;
                aContract.Note = noteInput;
                aContract.StaffID = staffIdInput;
                aContract.ContractTypeID = contractTypeIdInput;
                //thay doi csdl trong SQL
                _aHrm.SubmitChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        //Ham xoa mot contract theo idInput
        public bool DeleteAContract(string idInput) {
            try
            {
                //kiem tra contract co ton tai
                if (!FindIdInputInTable(idInput)) return false;
                var aContract = _aHrm.Contracts.SingleOrDefault(ct => ct.ContractID == idInput);
                if (aContract != null) _aHrm.Contracts.DeleteOnSubmit(aContract);
                _aHrm.SubmitChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
        //Lấy Lương cơ bản trong bảng hợp đồng dựa vào Mã nhân viên
        public decimal GetBasicPayByStaffId(string staffId, DateTime date)
        {
            var basicPay = (from cc in _aHrm.Contracts where cc.StaffID == staffId && DateTime.Compare(cc.StartDate.Value.Date, date) != 1 && DateTime.Compare(date, cc.EndDate.Value.Date) != 1 select cc.BasicPay).FirstOrDefault();
            return basicPay == null ? 0 : Convert.ToDecimal(basicPay);
        }

        public Contract LoadContractbyId(string id)
        {
            var ct = _aHrm.Contracts.SingleOrDefault(c => c.ContractID == id);
            return ct;
        }
        

        public bool FindContractByIDStaff(string idStaff)
        {
            var numberOfRecords = (from ct in _aHrm.Contracts
                                   where ct.StaffID == idStaff
                                   select ct).Count();
            return numberOfRecords != 0;
        }

        public Contract LoadLastDateContract(string idstaff)
        {
            var ct = _aHrm.Contracts.OrderByDescending(hd => hd.EndDate).FirstOrDefault(ct2 => ct2.StaffID == idstaff);
            return ct;
        }
    }
}
