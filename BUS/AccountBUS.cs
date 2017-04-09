using System.Linq;
using DAL;
using System;

namespace BUS
{
    public class AccountBus
    {
        private readonly HRMModelDataContext _hrm = new HRMModelDataContext();
        // Kiem tra dang nhap tai khoan 
        public bool CheckLogin(string tendangnhap, string matkhau)
        {
            //Dung LinQ dem so luong tk khi nhap ten dang nhap va mat khau
            var ktdangnhap = (from tk in _hrm.Accounts
                              where tk.UserName == tendangnhap && tk.Password == matkhau
                              select tk).Count();
            return ktdangnhap == 1;
        }

        //Lấy thông tin Account từ userName và Pass truyền vào
        public Account GetInfoAccount(string userName, string password)
        {
            var infoAccount = _hrm.Accounts.SingleOrDefault(acc => acc.UserName == userName && acc.Password == password);
            return infoAccount;
        }

        //lấy thông tin staff từ 
        public Staff GetInfoStaff(string idStaff)
        {  
            var infoAccount = _hrm.Staffs.SingleOrDefault(sta => sta.StaffID == idStaff);
            return infoAccount;
        }

        //Lấy thông tin 1 groupAccess từ idGroupAccess truyền vào
        public GroupAccess GetInfoGroupAccess(int idGroupAccess)
        {
            var infoGroupAccess = _hrm.GroupAccesses.SingleOrDefault(gra => gra.GroupAccessID == idGroupAccess);
            return infoGroupAccess;
        }
         
        public Account GetPass(string idstaff)
        {
            var accountOnline = _hrm.Accounts.FirstOrDefault(ac => ac.StaffID == idstaff);
            return accountOnline;
        }

        public bool EditAccountStatusOnline(string idStaff, bool statusOnline)
        {
            try
            {
                var aAccount = _hrm.Accounts.SingleOrDefault(ac => ac.StaffID == idStaff);
                //kiem tra aAccount co tontai
                if (aAccount == null) return false;
                aAccount.AccountStatusOnline = statusOnline;
                //thay doi csdl trong SQL
                _hrm.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Ham edit mot contract
        public bool EditPassword(int acId, string pass)
        {
            try
            {
                var aAccount = _hrm.Accounts.SingleOrDefault(ac => ac.AccID == acId);
                //kiem tra aAccount co tontai
                if (aAccount == null) return false;
                aAccount.Password = pass;
                //thay doi csdl trong SQL
                _hrm.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
