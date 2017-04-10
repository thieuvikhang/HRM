using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BUS
{
    public class AccountBus
    {
        private readonly HRMModelDataContext _hrm = new HRMModelDataContext();
        private readonly ExtendBus _extendBus = new ExtendBus();
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
            catch (Exception)
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

        public bool Check1AccByAccNameAndIdStaff(string staffPhone, string staffEmail, string AccName)
        {
            try
            {
                Staff newStaff = _hrm.Staffs.SingleOrDefault(st => st.Phone == staffPhone & st.Email == staffEmail);
                var numbAccByNameAccAndIdStaff = (from ac in _hrm.Accounts
                                                  where ac.UserName == AccName & ac.StaffID == newStaff.StaffID
                                                  select ac).Count();
                return numbAccByNameAccAndIdStaff == 1;
            }
            catch
            {
                return false;
            }
        }

        public Account GetAccByAccNameAndIdStaff(string staffPhone, string staffEmail, string AccName)
        {
            try
            {
                Staff newStaff = _hrm.Staffs.SingleOrDefault(st => st.Phone == staffPhone & st.Email == staffEmail);
                Account newAccount = _hrm.Accounts.SingleOrDefault(ac => ac.UserName == AccName & ac.StaffID == newStaff.StaffID);
                return newAccount;
            }
            catch(Exception)
            {
                return null;
            }
        }

        #region Quản Lý Tai Khoản
        public IQueryable GetAllAccount()
        {
            return
                _hrm.Accounts.SelectMany(a => _hrm.GroupAccesses, (a, ga) => new {a, ga})
                    .Where(t => t.a.GroupAccessID == t.ga.GroupAccessID)
                    .Select(t => new
                    {
                        t.a.AccID,
                        t.a.UserName,
                        StaffName1 = t.a.StaffID == null ? null : t.a.Staff.StaffName,
                        GroupAccessName1 = t.ga.GroupAccessName,
                        AccountStatusOnline = t.a.AccountStatusOnline == true ? "Online" : "Offline"
                    });
        }
        public IQueryable GetAllStaff()
        {
            return
                _hrm.Staffs.SelectMany(st => _hrm.Sections, (st, se) => new { st, se })
                    .Where(t => t.st.SectionID == t.se.SectionID)
                    .Select(t => new
                    {
                        t.st.StaffID,
                        t.st.StaffName,
                        t.se.SectionName
                    });
        }
        public IQueryable GetStaffByAccountId(int accId)
        {
            return
                _hrm.Staffs.SelectMany(st => _hrm.Sections, (st, se) => new {st, se})
                    .SelectMany(t => _hrm.Accounts, (t, ac) => new {t, ac})
                    .Where(
                        t =>
                            t.t.st.SectionID == t.t.se.SectionID && t.ac.StaffID == t.t.st.StaffID &&
                            t.ac.AccID == accId)
                    .Select(t => new
                    {
                        t.t.st.StaffID,
                        t.t.st.StaffName,
                        t.t.se.SectionName
                    });
        }
        public bool AddAccountNew(string user, string pass, int nhomQuyen, string maNv)
        {
            if (user == null || pass == null || nhomQuyen < 1) return false;
            try
            {
                var acc = new Account();
                {
                    acc.UserName = user;
                    acc.Password = _extendBus.GetMd5(pass).ToLower();
                    acc.GroupAccessID = nhomQuyen;
                    acc.StaffID = maNv;
                    acc.AccountStatusOnline = false;
                }
                _hrm.Accounts.InsertOnSubmit(acc);
                _hrm.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool UpdateAccount(int maTk, int nhomQuyen, string maNv)
        {
            try
            {
                var acc = _hrm.Accounts.Select(st => st).SingleOrDefault(st => st.AccID == maTk /*&& st.AccountStatusOnline.Value == false*/);
                if (acc == null) return false;
                acc.GroupAccessID = nhomQuyen;
                acc.StaffID = maNv;
                _hrm.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool DeleteAccount(int maTk)
        {
            try
            {
                var acc = _hrm.Accounts.Select(st => st).SingleOrDefault(st => st.AccID == maTk && st.AccountStatusOnline == false);
                if (acc == null) return false;
                _hrm.Accounts.DeleteOnSubmit(acc);
                _hrm.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public List<string> ListUserName()
        {
            var check = _hrm.Accounts.Select(ga => ga.UserName).Distinct().ToList();
            return check;
        }
        public bool CheckUserName(string text, List<string> list)
        {
            return list.All(item => !text.Equals(item));
        }
        #endregion
    }
}
