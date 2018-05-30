using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class LichSuBienDong : EntityBase
    {
        public long LichSuBienDongID { get; set; }
        public int? LoaiBienDongID { get; set; }
        public long? GiayPhepID { get; set; }
        public int? LoaiCapPhepID { get; set; }
        public int? SoLan { get; set; }
        public DateTime? NgayBienDong { get; set; }
        public int? LyDoID { get; set; }
        public string GhiChu { get; set; }
    }
}
