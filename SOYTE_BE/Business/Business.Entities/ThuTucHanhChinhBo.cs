using Core.Common.Domain;

namespace Business.Entities
{
    public class ThuTucHanhChinhBo : EntityBase
    {
        public string TenThuTuc { get; set; }
        public string MSTTHC { get; set; }
        public string CapBanHanh { get; set; }
        public string CoQuanBanHanh { get; set; }
        public string CoQuanThucHien { get; set; }
        public string CachThucTH { get; set; }
        public string CoQuanQD { get; set; }
        public string CoQuanPhoiHop { get; set; }
        public string TrinhTuThucHien { get; set; }
        public string ThanhPhanHS { get; set; }
        public string ThoiHanGiaiQuyet { get; set; }
        public string KetQuaThucHien { get; set; }
        public string YeuCauDieuKien { get; set; }
        public string SoBoHS { get; set; }
        public long? LinhVucID { get; set; }
        public string LinhVuc { get; set; }
        public string DoiTuongTH { get; set; }
        public string LePhi { get; set; }
        public string NgayCoHieuLuc { get; set; }
        public string NgayHetHieuLuc { get; set; }
        public string NgayDongBo { get; set; }
        public bool? Active { get; set; }
        public long? CreatedUserID { get; set; }
        public string CreatedDate { get; set; }
        public long? LastUpdUserID { get; set; }
        public string LastUpdDate { get; set; }
    }
}
