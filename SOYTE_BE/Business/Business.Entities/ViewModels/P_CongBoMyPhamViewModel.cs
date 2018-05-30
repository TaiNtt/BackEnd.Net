using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class P_CongBoMyPhamViewModel
    {
        public long? RowNo { get; set; }
        public long CongBoSPMyPhamId { get; set; }
        public string SoCongBo { get; set; }
        public string ThoiHan { get; set; }
        public string NhanHang { get; set; }
        public string TenSanPham { get; set; }
        public string DangSanPhams { get; set; }
        public string TenNhaSanXuat { get; set; }
        public int? TotalItems { get; set; }
    }
}
