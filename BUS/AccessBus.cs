using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BUS
{
    public class AccessBus
    {
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        public class ListGroupAccess
        {
            public string Form { get; set; }
            public int Edit { get; set; }
        }

        public int CountAccess(int ma) => _aHrm.DetailAccesses.Where(g => g.GroupAccessID == ma).GroupBy(da => da.AccessID).Count();
        public int CountAccessEdit(int ma) => _aHrm.DetailAccesses.Where(g => g.GroupAccessID == ma && g.Access.Edit == true).GroupBy(da => da.AccessID).Count();

        /// <summary>
        /// lấy danh sách nhóm quyền
        /// </summary>
        /// <returns>danh sách nhóm quyền</returns>
        public IQueryable GetAllGroupAccess()
        {
            return _aHrm.GroupAccesses.Select(ga => new
            {
                ga.GroupAccessID,
                ga.Description,
                ga.GroupAccessName,
                Count = CountAccess(ga.GroupAccessID),
                CountEdit = CountAccessEdit(ga.GroupAccessID)
            });
        }
        /// <summary>
        /// Lấy danh sách quyền
        /// </summary>
        /// <returns>danh sách quyền</returns>
        public IQueryable LoadAllAccess()
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
        public IQueryable LoadAllAccess(bool key)
        {
            return _aHrm.Accesses.Where(ct => ct.Edit == key).Select(ct => new
            {
                ct.AccessID, ct.Form, ct.DescriptionAccess
            }).Distinct();
        }
        /// <summary>
        /// Thêm mới nhóm quyền
        /// </summary>
        /// <param name="ten">tên</param>
        /// <param name="moTa">mô tả</param>
        /// <param name="list">danh sách mã quyền</param>
        /// <returns>true thành công</returns>
        public bool AddGroupAccess(string ten, string moTa, List<int> list)
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
                var ma = _aHrm.GroupAccesses.SingleOrDefault(ab => ab.GroupAccessName == ten && ab.Description == moTa);
                if (ma != null && list.Count != 0) AddDetailAccesses(Convert.ToInt16(ma.GroupAccessID), list);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// cập nhật nhóm quyền
        /// </summary>
        /// <param name="ma">mã</param>
        /// <param name="ten">tên</param>
        /// <param name="moTa">mô tả</param>
        /// <param name="list">danh sách mã quyền</param>
        /// <returns>true thành công</returns>
        public bool UpdateGroupAccesses(int ma, string ten, string moTa, List<int> list)
        {
            try
            {
                var groupAccesses = _aHrm.GroupAccesses.SingleOrDefault(ab => ab.GroupAccessID == ma);
                if (groupAccesses == null) return false;
                groupAccesses.GroupAccessName = ten;
                groupAccesses.Description = moTa;
                _aHrm.SubmitChanges();
                AddDetailAccesses(ma, list);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// xóa nhóm quyền
        /// </summary>
        /// <param name="gaId">mã</param>
        /// <returns>true thành công</returns>
        public bool DeleteGroupAccesses(int gaId)
        {
            try
            {
                var groupAccesses = _aHrm.GroupAccesses.Select(st => st).SingleOrDefault(st => st.GroupAccessID == gaId);
                if (groupAccesses == null) return false;
                DeleteDetailAccesses(gaId);
                _aHrm.GroupAccesses.DeleteOnSubmit(groupAccesses);
                _aHrm.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// xóa chi tiết quyền
        /// </summary>
        /// <param name="gaId">mã nhóm quyền</param>
        public void DeleteDetailAccesses(int gaId)
        {
            foreach (var item in _aHrm.DetailAccesses.Where(dg => dg.GroupAccessID == gaId))
            {
                if (item != null) _aHrm.DetailAccesses.DeleteOnSubmit(item);
                _aHrm.SubmitChanges();
            }
        }
        /// <summary>
        /// thêm chi tiết quyền
        /// </summary>
        /// <param name="ma">mã nhóm quyền</param>
        /// <param name="list">danh sách mã quyền</param>
        public void AddDetailAccesses(int ma, List<int> list)
        {
            DeleteDetailAccesses(ma);
            if (list.Count == 0) return;
            var groupAccesses = _aHrm.GroupAccesses.SingleOrDefault(ab => ab.GroupAccessID == ma);
            if (groupAccesses == null) return;
            foreach (var item in list)
            {
                if(!CheckTorF(ma,item)) continue;
                var detailAccess = new DetailAccess();
                {
                    detailAccess.GroupAccessID = ma;
                    detailAccess.AccessID = item;
                }
                _aHrm.DetailAccesses.InsertOnSubmit(detailAccess);
                _aHrm.SubmitChanges();
            }
        }

        public bool CheckTorF(int ma, int quyen)
        {
            var list = _aHrm.DetailAccesses.SingleOrDefault(ab => ab.GroupAccessID == ma && ab.AccessID == quyen);
            if (list == null) return true;
            return false;
        }
        /// <summary>
        /// Kiểm tra nhóm quyền đã được sử dụng chưa
        /// </summary>
        /// <param name="gaId">mã nhóm quyền</param>
        /// <returns>true đã được dùng</returns>
        public bool CheckGroupAccessesUsing(int gaId)
        {
            var accesses = _aHrm.Accounts.SingleOrDefault(ab => ab.GroupAccessID == gaId);
            return accesses != null;
        }
        public List<int> ListAccesses(int ma, bool key)
        {
            var list = _aHrm.DetailAccesses.SelectMany(da => _aHrm.Accesses, (da, ac) => new {da, ac})
                .Where(t => t.da.AccessID == t.ac.AccessID
                            && t.da.GroupAccessID == ma
                            && t.ac.Edit == key).Select(t => t.ac.AccessID).Distinct().ToList();
            return list;
        }
        public IQueryable ListAccessesByGroupAccesses(int ma, bool key)
        {
            var list = _aHrm.DetailAccesses.SelectMany(ga => _aHrm.Accesses, (ga, ct) => new { ga, ct })
                .Where(t => t.ga.AccessID == t.ct.AccessID
                            && t.ga.GroupAccessID == ma && t.ct.Edit == key).Select(t => new
                            {
                                t.ct.AccessID,
                                t.ct.Form,
                                t.ct.DescriptionAccess
                            }).Distinct();
            return list;
        }

        public List<string> ListNameGroupAccesses()
        {
            var check = _aHrm.GroupAccesses.Select(ga => ga.GroupAccessName).Distinct().ToList();
            return check;
        }
        /// <summary>
        /// Kiểm tra tên nhóm phân quyền đã tồn tại
        /// </summary>
        /// <param name="tenNhom">khi sửa text được phép = tenNhom</param>
        /// <param name="text">tên nhóm mới</param>
        /// <param name="coHieu">=2 là sửa</param>
        /// <param name="list">danh sách tên nhóm quyền</param>
        /// <returns>true cho phép</returns>
        public bool CheckNameGroupAccesses(string tenNhom, string text, int coHieu, List<string> list)
        {
            if (coHieu == 2 && tenNhom.Equals(text)) return true;
            return list.All(item => !text.Equals(item));
        }
        /// <summary>
        /// Lấy danh sách quyền
        /// </summary>
        /// <param name="groupAccesId">mã nhóm quyền</param>
        /// <returns>danh sách quyền</returns>
        public List<ListGroupAccess> ListGroupAcces(int groupAccesId)
        {
            var listInPut = _aHrm.DetailAccesses.SelectMany(aHmDetailAccesses => _aHrm.Accesses, (aHmDetailAccesses, aHrmAccess) => new {aHmDetailAccesses, aHrmAccess})
                .Where(t => t.aHmDetailAccesses.GroupAccessID == groupAccesId && t.aHrmAccess.AccessID == t.aHmDetailAccesses.AccessID).Select(t => new
                { t.aHrmAccess.Form, Edit = t.aHrmAccess.Edit == true ? 1 : 0 }).ToList();
            if (listInPut.Count == 0) return null;
            var list0 = new List<ListGroupAccess>();
            var list1 = new List<ListGroupAccess>();
            foreach (var intPut in listInPut)
            {
                if (intPut.Edit != 1)
                    list0.Add(new ListGroupAccess {Form = intPut.Form, Edit = intPut.Edit});
                else
                    list1.Add(new ListGroupAccess {Form = intPut.Form, Edit = intPut.Edit});
            }
            if (list1.Count == 0) return list0;
            if (list0.Count == 0) return list1;
            var listOutPut = new List<ListGroupAccess>();
            listOutPut.AddRange(list0);
            listOutPut.AddRange(list1);
            return listOutPut;
        }
    }
}