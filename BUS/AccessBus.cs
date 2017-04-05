﻿using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BUS
{
    public class AccessBus
    {
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();

        public IQueryable GetList(int groupAccessId)
        {
            var list = (from aHmDetailAccesses in _aHrm.DetailAccesses
                        from aHrmAccess in _aHrm.Accesses
                        where aHmDetailAccesses.GroupAccessID == groupAccessId
                        && aHrmAccess.AccessID == aHmDetailAccesses.AccessID
                        select new
                        {
                            aHrmAccess.Form,
                            aHrmAccess.Edit
                        }).ToList();
            return list.AsQueryable();
        }
        public IQueryable LoadAll()
        {
            var all = (from ct in _aHrm.Accesses
                              select new
                              {
                                  ct.Form,
                                  ct.DescriptionAccess
                              }).Distinct();
            return all;
        }
    }
}
