using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PostBUS
    {
        readonly HRMModelDataContext _aHrm = new HRMModelDataContext();

        // Load tat ca section
        public IQueryable LoadAll()
        {
            var allRecords = from st in _aHrm.Positions select st;
            return allRecords;
        }
    }
}
