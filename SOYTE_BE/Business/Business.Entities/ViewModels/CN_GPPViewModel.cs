using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class CN_GPPViewModel
    {
        public long? RowNo { get; set; }
        public long THTGPPId { get; set; }
        public string SoGiayChungNhan { get; set; }
        public DateTime? NgayCapChungNhan { get; set; }
        public string TenCoSo { get; set; }
        public string DiaChiCS { get; set; }
        public string NguoiPTCM { get; set; }
        public string PhamViKinhDoanhs { get; set; }
        public string SoChungChi { get; set; }
        public string SoDKKD { get; set; }
        public int? TotalItems { get; set; }
    }
}
