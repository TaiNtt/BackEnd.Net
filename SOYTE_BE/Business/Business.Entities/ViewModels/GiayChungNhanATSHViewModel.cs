using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class GiayChungNhanATSHViewModel
    {
        public long? RowNo { get; set; }
        public long GiayChungNhanATSHID { get; set; }
        public string SoGiayChungNhan { get; set; }
        public DateTime? NgayCap { get; set; }
        public string TenPhongXetNghiem { get; set; }
        public string TenCoSo { get; set; }
        public string DiaChi { get; set; }
        public int? Cap { get; set; }
        public int? TotalItems { get; set; }
    }
}
