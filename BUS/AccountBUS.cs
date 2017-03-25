using System.Linq;
using DAL;

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

        //Lấy tất cả acsess từ idGroupAccess truyền vào
        //public IQueryable GetAllAccessByIdGroupAccess(int idGroupAccess)
        //{
        //    var allAccessByIdGroupAccess = from accses in hrm.Accesses
        //                                   where accses.GroupAccessID == idGroupAccess
        //                                   select accses;
        //    return allAccessByIdGroupAccess;
        //} 
    }
}
