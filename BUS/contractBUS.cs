using System;
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
        public IQueryable LoadAll() {
            var allContract = from ct in _aHrm.Contracts select ct;
            return allContract;
        }

        //LoadAll contract whith contractTypeID
        public IQueryable LoadAllWithTypeId(string idInput) {
            var allRecord = from ct in _aHrm.Contracts
                                  where ct.ContractTypeID == idInput
                                  select ct;
            return allRecord;
        }

        //Ham tim kiem idInput trong table contract
        public bool FindIdInputInTable(string idInput) {
            int numberOfRecords = (from ct in _aHrm.Contracts
                               where ct.ContractID == idInput
                               select ct).Count();
            if(numberOfRecords == 0)
            {
                //idInput khong ton tai trong table contract
                return false;
            }else
            {
                //idInput da ton tai trong table contract
                return true;
            }
        }

        //Create a contract
        public bool CreateAContract(string idInput, DateTime dateInput, string currencyInput, DateTime startDateInput, 
            DateTime endDateInput, bool statusInput, decimal basicPayInput, string paymentInput, string noteInput, 
            string staffIdInput, string contractTypeIdInput) {
            try
            {
                //Kiem tra idInput vs Id trong table contract
                if(!FindIdInputInTable(idInput)) {
                    //tao mot doi tuong 
                    Contract aContract = new Contract();
                    aContract.ContractID = idInput;
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
                    // Thong tin khach hang se dc luu lai
                    _aHrm.Contracts.InsertOnSubmit(aContract);
                    // Luu thong tin xuong SQL
                    _aHrm.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception) {
                return false;
            } 
        }

        //Ham edit mot contract
        public bool EditContract(string idInput, DateTime dateInput, string currencyInput, DateTime startDateInput,
            DateTime endDateInput, bool statusInput, decimal basicPayInput, string paymentInput, string noteInput,
            string staffIdInput, string contractTypeIdInput) {
            try {
                Contract aContract = _aHrm.Contracts.SingleOrDefault(ct => ct.ContractID == idInput);
                //kiem tra aContract co tontai
                if(aContract != null) {
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
                return false;
            }
            catch (Exception ex) {
                return false;
            }
        }

        //Ham xoa mot contract theo idInput
        public bool DeleteAContract(string idInput) {
            try
            {
                //kiem tra contract co ton tai
                if(FindIdInputInTable(idInput)) {
                    Contract aContract = _aHrm.Contracts.SingleOrDefault(ct => ct.ContractID == idInput);
                    _aHrm.Contracts.DeleteOnSubmit(aContract);
                    _aHrm.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex) {
                return false;
            }
        }
        //Lấy Lương cơ bản trong bảng hợp đồng dựa vào Mã nhân viên
        public decimal GetBasicPayByStaffId(string staffId)
        {
            var basicPay = (from cc in _aHrm.Contracts where cc.StaffID == staffId select cc.BasicPay).FirstOrDefault();
            return Convert.ToDecimal(basicPay);
        }
    }
}
