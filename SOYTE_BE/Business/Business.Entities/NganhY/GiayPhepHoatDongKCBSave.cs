using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class GiayPhepHoatDongKCBSave// : EntityBase
    {
        public GiayPhepHoatDongKCB giayPhepHoatDongKCB { get; set; }
        public List<GiayPhepHoatDongKCB_DSNhanSu> lstGiayPhepHoatDongKCB_DSNhanSu { get; set; }
    }
}