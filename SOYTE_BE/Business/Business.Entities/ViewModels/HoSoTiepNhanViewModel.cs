using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class HoSoTiepNhanViewModel
	{
        public long? RowNo { get; set; }
        public long HoSoID { get; set; }
        public string SoBienNhan { get; set; }
        public DateTime? NgayNhan { get; set; }
        public string TenLinhVuc { get; set; }
        public int? LinhVucID { get; set; }
        public string TenThuTuc { get; set; }
        public int? ThuTucID { get; set; }
        public string HoTenNguoiNop { get; set; }
        public string TenTrangThaiHoSo { get; set; }
        public DateTime? NgayHenTra { get; set; }
        public string NoiDungXuLy { get; set; }
        public bool Star { get; set; }
        public int? Alert { get; set; }
        public int? TotalItems { get; set; }
    }
}
