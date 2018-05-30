using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class GiayChungNhanBTGTViewModel
    {
        public long? RowNo { get; set; }
        public long GiayChungNhanBTGTID { get; set; }
        public string SoGiayChungNhan { get; set; }
        public DateTime? NgayCap { get; set; }
        public string TenBaiThuoc { get; set; }
        public string HoTen { get; set; }
        public string SoGiayTo { get; set; }
        public string DiaChi { get; set; }
        public int? TotalItems { get; set; }
    }
}
