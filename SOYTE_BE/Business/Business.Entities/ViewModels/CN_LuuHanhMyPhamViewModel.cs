using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class CN_LuuHanhMyPhamViewModel
    {
        public long? RowNo { get; set; }
        public long LuuHanhMyPhamId { get; set; }
        public string SoChungNhan { get; set; }
        public DateTime? NgayCapChungNhan { get; set; }
        public string TenCongTy { get; set; }
        public string DiaChi { get; set; }
        public int? TotalItems { get; set; }
    }
}
