using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class GiayPhepDoanKCBViewModel
    {
        public long? RowNo { get; set; }
        public long GiayPhepDoanKCBID { get; set; }
        public string SoGiayPhep { get; set; }
        public DateTime? NgayCap { get; set; }
        public string TenDoanKCB { get; set; }
        public DateTime? NgayKCB { get; set; }
        public string NoiKham { get; set; }
        public string NCTN_HoTen { get; set; }
        public int? SoNguoiDuocKham { get; set; }
        public int? TotalItems { get; set; }
    }
}
