using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class DK_HoiThaoGioiThieuThuocViewModel
    {
        public long? RowNo { get; set; }
        public long HoiThaoThuocId { get; set; }
        public string SoTiepNhan { get; set; }
        public DateTime? NgayTiepNhan { get; set; }
        public string TenDonVi { get; set; }
        public string DiaDiemToChuc { get; set; }
        public DateTime? ThoiGianToChuc { get; set; }
        public string HoTen { get; set; }
        public int? TotalItems { get; set; }
    }
}
