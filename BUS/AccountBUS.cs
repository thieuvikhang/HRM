using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class AccountBUS
    {
        HRMModelDataContext hrm = new HRMModelDataContext();
        // Kiem tra dang nhap tai khoan 
        public bool CheckLogin(string tendangnhap, string matkhau)
        {
            //Dung LinQ dem so luong tk khi nhap ten dang nhap va mat khau
            int ktdangnhap = (from tk in hrm.Accounts
                              where tk.UserName == tendangnhap && tk.Password == matkhau
                              select tk).Count();
            if (ktdangnhap == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Lấy thông tin Account từ userName và Pass truyền vào
        public Account GetInfoAccount(string userName, string password)
        {
            Account infoAccount = hrm.Accounts.SingleOrDefault(acc => acc.UserName == userName && acc.Password == password);
            return infoAccount;
        }

        //lấy thông tin staff từ 
        public Staff GetInfoStaff(string idStaff)
        {  
            Staff infoAccount = hrm.Staffs.SingleOrDefault(sta => sta.StaffID == idStaff);
            return infoAccount;
        }

        //Lấy thông tin 1 groupAccess từ idGroupAccess truyền vào
        public GroupAccess GetInfoGroupAccess(int idGroupAccess)
        {
            GroupAccess infoGroupAccess = hrm.GroupAccesses.SingleOrDefault(gra => gra.GroupAccessID == idGroupAccess);
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
