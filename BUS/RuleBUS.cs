﻿using DAL;
using System;
using System.Linq;

namespace BUS
{
    public class RuleBus
    {
        private readonly HRMModelDataContext _aHrm = new HRMModelDataContext();
        //Lấy số % bảo hiểm xã hội
        public float GetBhxh()
        {
            var siPayRate = (from ad in _aHrm.Rules select ad.SIPayRate).FirstOrDefault();
            return Convert.ToInt16(siPayRate);
        }
    }
}
