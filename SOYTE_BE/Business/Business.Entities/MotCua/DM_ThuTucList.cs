using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_ThuTucList
    {
        public long? RowNo { get; set; }
        public int ThuTucID { get; set; }
        public int? LinhVucID { get; set; }
        public string TenLinhVuc { get; set; }
        public string TenThuTuc { get; set; }
        public int? SoNgayGiaiQuyet { get; set; }
        public int? ThoiGianNhacDenHan { get; set; }
        public bool? Used { get; set; }
        public int? LoaiCapPhepID { get; set; }
        public double? LePhi { get; set; }
        public string MaThuTuc { get; set; }
        public int? TotalItems { get; set; }
    }
}