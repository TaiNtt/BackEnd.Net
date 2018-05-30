using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_ThuTuc : EntityBase
    {
        public int ThuTucID { get; set; }
        public int? LinhVucID { get; set; }
        public string TenThuTuc { get; set; }
        public bool? Used { get; set; }
        public int? SoNgayGiaiQuyet { get; set; }
        public int? ThoiGianNhacDenHan { get; set; }
        public int? LoaiCapPhepID { get; set; }
        public double? LePhi { get; set; }
        public string MaThuTuc { get; set; }
        public string funcLoad { get; set; }
        public string funcSave { get; set; }
        public string MapURL { get; set; }        
    }
}