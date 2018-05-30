using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class ChungChiHanhNgheYCapLaiSave : EntityBase
    {
        public ChungChiHanhNgheY_CapLai chungChiHanhNgheY_caplai { get; set; }
        public ChungChiHanhNgheY_CapLaiCT chungChiHanhNgheY_caplaict { get; set; }
        public ChungChiHanhNgheYSave noidungtruoc { get; set; }
        public ChungChiHanhNgheYSave noidungsau { get; set; }
    }
}