using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class CV_XNKThuoc_PhiMauDichViewModel
    {
        public long? RowNo { get; set; }
        public long XNKThuocPhiMauDichId { get; set; }
        public string SoCongVan { get; set; }
        public DateTime? NgayBanHanh { get; set; }
        public string ThoiHan { get; set; }
        public string HoTenNguoiNhanThuoc { get; set; }
        public string DiaChiHTNguoiNhanThuoc { get; set; }
        public string HoTenNguoiSDThuoc { get; set; }
        public int? TotalItems { get; set; }
    }
}
