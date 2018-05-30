using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class DangKyQCTrangThietBiViewModel
    {
        public long? RowNo { get; set; }
        public string SoTiepNhan { get; set; }
        public DateTime? NgayTiepNhan { get; set; }
        public string DichVuQuangCao { get; set; }
        public string DonViDK_Ten { get; set; }
        public string DonViDK_DiaChi { get; set; }
        public string NCTN_Ten { get; set; }
        public int? TotalItems { get; set; }
    }
}
