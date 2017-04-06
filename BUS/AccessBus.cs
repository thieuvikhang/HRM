using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DAL;

namespace BUS
{
    public class AccessBus
    {
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();

        public IQueryable GetAllGroupAccess()
        {
            return from ga in _aHrm.GroupAccesses
                   select new
                   {
                       ga.GroupAccessID,
                       ga.Description,
                       ga.GroupAccessName

                   };
        }
        public IQueryable LoadAll()
        {
            var all = (from ct in _aHrm.Accesses
                       select new
                       {
                           ct.AccessID,
                           ct.Form,
                           ct.DescriptionAccess,
                           Edit = ct.Edit == true ? "Sửa" : "Xem"
                       }).Distinct();
            return all;
        }

        public bool AddAccesses(string ten, string moTa, List<int> list)
        {
            try
            {
                var groupAccess = new GroupAccess();
                {
                    groupAccess.GroupAccessName = ten;
                    groupAccess.Description = moTa;
                }
                _aHrm.GroupAccesses.InsertOnSubmit(groupAccess);
                _aHrm.SubmitChanges();
                var accesses = _aHrm.GroupAccesses.SingleOrDefault(ab => ab.GroupAccessName == ten && ab.Description == moTa);
                if (accesses == null) return false;
                foreach (var item in list)
                {
                    var detailAccess = new DetailAccess();
                    {
                        detailAccess.GroupAccessID = accesses.GroupAccessID;
                        detailAccess.AccessID = item;
                    }
                    _aHrm.DetailAccesses.InsertOnSubmit(detailAccess);
                    _aHrm.SubmitChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}