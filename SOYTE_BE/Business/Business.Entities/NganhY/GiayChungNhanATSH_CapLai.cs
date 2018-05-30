using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class GiayChungNhanATSH_CapLai : EntityBase
    {
        public long CapLaiID { get; set; }
        public long? HoSoID { get; set; }
        public int? Cap { get; set; }
        public long? GiayChungNhanATSHIDGoc { get; set; }
        public string SoGiayChungNhanCu { get; set; }
        public DateTime? NgayCapCu { get; set; }
        public int? ThoiHanCu { get; set; }
        public string SoGiayChungNhan { get; set; }
        public DateTime? NgayCap { get; set; }
        public int? ThoiHan { get; set; }
        public int? LanCapLai { get; set; }
        public int? LyDoCapLaiID { get; set; }
        public bool? DaCapLai { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public DateTime? LastUpdDate { get; set; }
    }
}
