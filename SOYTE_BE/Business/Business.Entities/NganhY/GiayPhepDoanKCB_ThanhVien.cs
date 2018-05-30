using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class GiayPhepDoanKCB_ThanhVien : EntityBase
    {
        public long ThanhVienID { get; set; }
        public long? GiayPhepDoanKCBID { get; set; }
        public string HoTen { get; set; }
        public string SoCCHN { get; set; }
        public string PhamViHoatDong { get; set; }
        public DateTime? ThoiGianDangKyKCB { get; set; }
        public int? ViTriChuyenMonID { get; set; }
    }
}
