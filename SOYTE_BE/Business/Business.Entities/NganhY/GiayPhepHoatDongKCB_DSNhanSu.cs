using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class GiayPhepHoatDongKCB_DSNhanSu : EntityBase
    {
        public long NhanSuID { get; set; }
        public long? GiayPhepKhamChuaBenhID { get; set; }
        public string HoTen { get; set; }
        public long ChungChiHanhNgheYID { get; set; }
        public string ThoiGianLamViec { get; set; }
        public int? ViTriChuyenMonID { get; set; }
    }
}
