using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class GiayChungNhanBTGTCapLaiSave : EntityBase
    {
        public GiayChungNhanBTGT_CapLai giayChungNhanBTGT_CapLai { get; set; }
        public GiayChungNhanBTGT_CapLaiCT giayChungNhanBTGT_CapLaiCT { get; set; }
        public GiayChungNhanBTGTSave noidungtruoc { get; set; }
        public GiayChungNhanBTGTSave noidungsau { get; set; }
    }
}