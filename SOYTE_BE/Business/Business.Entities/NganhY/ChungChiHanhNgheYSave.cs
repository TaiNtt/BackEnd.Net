using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class ChungChiHanhNgheYSave : EntityBase
    {
        public ChungChiHanhNgheY chungChiHanhNgheY { get; set; }
        public List<ChungChiHanhNgheY_QTTH> lstChungChiHanhNgheY_QTTH { get; set; }
        public List<ChungChiHanhNgheY_TDCM> lstChungChiHanhNgheY_TDCM { get; set; }        
    }
}