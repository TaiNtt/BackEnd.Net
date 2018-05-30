using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class GiayChungNhanATSHCapLaiSave : EntityBase
    {
        public GiayChungNhanATSH_CapLai giayChungNhanATSH_caplai { get; set; }
        public GiayChungNhanATSH_CapLaiCT giayChungNhanATSH_caplaict { get; set; }
        public GiayChungNhanATSHSave noidungtruoc { get; set; }
        public GiayChungNhanATSHSave noidungsau { get; set; }
    }
}