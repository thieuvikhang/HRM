using System;
using System.Linq;
using DAL;

namespace BUS
{
    /**
     * contractBUS xu ly cac nghiep vu lien quan den table contract
     * LoadAll, create, edit, delete, checkValueInputDuplicate
    */
    public class contractBUS
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();

        //Load all contract
        public IQueryable loadAll() {
            var AllContract = from ct in aHRM.Contracts select ct;
            return AllContract;
        }

        //LoadAll contract whith contractTypeID
        public IQueryable LoadAllWithTypeID(string idInput) {
            var allRecord = from ct in aHRM.Contracts
                                  where ct.ContractTypeID == idInput
                                  select ct;
            return allRecord;
        }

        //Ham tim kiem idInput trong table contract
        public bool findIDInputInTable(string idInput) {
            int numberOfRecords = (from ct in aHRM.Contracts
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
            string staffIDInput, string contractTypeIDInput) {
            try {
                //Kiem tra idInput vs Id trong table contract
                if(!findIDInputInTable(idInput)) {
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
                    aContract.StaffID = staffIDInput;
                    aContract.ContractTypeID = contractTypeIDInput;
                    // Thong tin khach hang se dc luu lai
                    aHRM.Contracts.InsertOnSubmit(aContract);
                    // Luu thong tin xuong SQL
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

        //Ham edit mot contract
        public bool editContract(string idInput, DateTime dateInput, string currencyInput, DateTime startDateInput,
            DateTime endDateInput, bool statusInput, decimal basicPayInput, string paymentInput, string noteInput,
            string staffIDInput, string contractTypeIDInput) {
            try {
                Contract aContract = aHRM.Contracts.SingleOrDefault(ct => ct.ContractID == idInput);
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
                    aContract.StaffID = staffIDInput;
                    aContract.ContractTypeID = contractTypeIDInput;
                    //thay doi csdl trong SQL
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

        //Ham xoa mot contract theo idInput
        public bool deleteAContract(string idInput) {
            try {
                //kiem tra contract co ton tai
                if(findIDInputInTable(idInput)) {
                    Contract aContract = aHRM.Contracts.SingleOrDefault(ct => ct.ContractID == idInput);
                    aHRM.Contracts.DeleteOnSubmit(aContract);
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
        //Lấy Lương cơ bản trong bảng hợp đồng dựa vào Mã nhân viên
        public decimal GetBasicPayByStaffID(string StaffID)
        {
            var basicPay = (from cc in aHRM.Contracts where cc.StaffID == StaffID select cc.BasicPay).FirstOrDefault();
            return Convert.ToDecimal(basicPay);
        }
    }
}
