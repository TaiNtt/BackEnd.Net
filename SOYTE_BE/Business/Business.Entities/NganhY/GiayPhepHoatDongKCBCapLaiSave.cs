using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class GiayPhepHoatDongKCBCapLaiSave : EntityBase
    {
        public GiayPhepHoatDongKCB_CapLai giayPhepHoatDongKCB_caplai { get; set; }
        public GiayPhepHoatDongKCB_CapLaiCT giayPhepHoatDongKCB_caplaict { get; set; }
        public GiayPhepHoatDongKCBSave noidungtruoc { get; set; }
        public GiayPhepHoatDongKCBSave noidungsau { get; set; }
    }
}