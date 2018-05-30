using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class ChungChiHanhNgheY_QTTH : EntityBase
    {
        public long QuaTrinhID { get; set; }
        public long? ChungChiHanhNgheYID { get; set; }
        public string ThoiGianThucHanh { get; set; }
        public string TenDonViThucHanh { get; set; }
        public bool? IsDonViNhaNuoc { get; set; }
    }
}
