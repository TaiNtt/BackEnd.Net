using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class PD_Thuoc_MethadoneViewModel
    {
        public long? RowNo { get; set; }
        public long PDMethadoneId { get; set; }
        public string SoPheDuyet { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public DateTime? ThoiHan { get; set; }
        public string TenDonViTH { get; set; }
        public int? TotalItems { get; set; }
    }
}
