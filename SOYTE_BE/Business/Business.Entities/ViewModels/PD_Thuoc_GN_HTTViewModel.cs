using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class PD_Thuoc_GN_HTTViewModel
    {
        public long? RowNo { get; set; }
        public long PDThuocGNHTTId { get; set; }
        public string SoPheDuyet { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public DateTime? ThoiHan { get; set; }
        public string TenDonVi { get; set; }
        public string DiaChiDV { get; set; }
        public string TenCongTyCungUng { get; set; }
        public int? TotalItems { get; set; }
    }
}
