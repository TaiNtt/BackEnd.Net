using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class GiayPhepHoatDongChuThapDoCapLaiSave
    {
        public GiayPhepHoatDongChuThapDo_CapLai giayPhepHoatDongChuThapDo_caplai { get; set; }
        public GiayPhepHoatDongChuThapDo_CapLaiCT giayPhepHoatDongChuThapDo_caplaict { get; set; }
        public GiayPhepHoatDongChuThapDo noidungtruoc { get; set; }
        public GiayPhepHoatDongChuThapDo noidungsau { get; set; }
    }
}