using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class GiayPhepHoatDongChuThapDoViewModel
    {
        public long? RowNo { get; set; }
        public long GiayPhepHoatDongChuThapDoID { get; set; }
        public string SoGiayPhep { get; set; }
        public DateTime? NgayCap { get; set; }
        public string TenDiem { get; set; }
        public string DiaChi { get; set; }
        public string ThoiGianLamViec { get; set; }
        public string NguoiChiuTrachNhiem { get; set; }
        public int? TotalItems { get; set; }
    }
}
