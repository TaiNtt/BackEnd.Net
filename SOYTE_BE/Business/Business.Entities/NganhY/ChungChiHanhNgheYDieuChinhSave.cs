using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class ChungChiHanhNgheYDieuChinhSave : EntityBase
    {
        public ChungChiHanhNgheY_DieuChinh chungChiHanhNgheY_dieuchinh { get; set; }
        public ChungChiHanhNgheY_DieuChinhCT chungChiHanhNgheY_dieuchinhct { get; set; }
        public ChungChiHanhNgheYSave noidungtruoc { get; set; }
        public ChungChiHanhNgheYSave noidungsau { get; set; }
    }
}