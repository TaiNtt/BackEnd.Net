using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class TD_KeHoachDauThauViewModel
    {
        public long? RowNo { get; set; }
        public long KeHoachDauThauId { get; set; }
        public string SoQuyetDinh { get; set; }
        public DateTime? NgayQuyetDinh { get; set; }
        public string ChuDauTu { get; set; }
        public string TieuDe { get; set; }
        public string TongChiPhi { get; set; }
        public string NguonVon { get; set; }
        public int? TotalItems { get; set; }
    }
}
