using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class LichSuBienDongViewModel
    {
        public long LichSuBienDongID { get; set; }
        public int? LoaiBienDongID { get; set; }
        public string TenLoaiBienDong { get; set; }
        public long? GiayPhepID { get; set; }
        public int? LoaiCapPhepID { get; set; }
        public int? SoLan { get; set; }
        public DateTime? NgayBienDong { get; set; }
        public int? LyDoID { get; set; }
        public string LyDo { get; set; }
        public string GhiChu { get; set; }
    }
}
