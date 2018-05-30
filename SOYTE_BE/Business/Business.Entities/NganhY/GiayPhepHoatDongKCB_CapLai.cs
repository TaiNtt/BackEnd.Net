using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class GiayPhepHoatDongKCB_CapLai : EntityBase
    {
        public long CapLaiID { get; set; }
        public long? HoSoID { get; set; }
        public long? GiayPhepKhamChuaBenhIDGoc { get; set; }
        public string SoGiayPhepCu { get; set; }
        public DateTime? NgayCapCu { get; set; }
        public string SoGiayPhep { get; set; }
        public DateTime? NgayCap { get; set; }
        public int? LanCapLai { get; set; }
        public int? LyDoCapLaiID { get; set; }
        public bool? DaCapLai { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public DateTime? LastUpdDate { get; set; }
    }
}
