using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class DK_HoiThaoGioiThieuThuocSave : EntityBase
    {
        public DK_HoiThaoGioiThieuThuoc hoiThaoGioiThieuThuoc { get; set; }
        public List<DK_HoiThaoGioiThieuThuoc_DMThuoc> lsthoiThaoGioiThieuThuoc_DMThuoc { get; set; }
    }
}