using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class CC_Duoc_CapLaiSave : EntityBase
    {
        public CC_Duoc_CapLai cc_duoc_caplai { get; set; }
        public CC_Duoc_CapLaiCT cc_duoc_caplaict { get; set; }
        public CC_DuocSave noidungtruoc { get; set; }
        public CC_DuocSave noidungsau { get; set; }
    }
}