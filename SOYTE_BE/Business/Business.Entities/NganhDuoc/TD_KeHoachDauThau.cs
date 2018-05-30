using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class TD_KeHoachDauThau : EntityBase
    {
        public long KeHoachDauThauId { get; set; }
        public long? HoSoID { get; set; }
        public string SoBienNhan { get; set; }
        public string DonViTrinh { get; set; }
        public string SoToTrinh { get; set; }
        public DateTime? NgayTrinh { get; set; }
        public string SoQuyetDinh { get; set; }
        public DateTime? NgayQuyetDinh { get; set; }
        public string TieuDe { get; set; }
        public string ChuDauTu { get; set; }
        public string TongChiPhi { get; set; }
        public string NguonVon { get; set; }
        public string NhanXet { get; set; }
        public string KetLuan { get; set; }
        public string TapTinDinhKem { get; set; }
        public string TapTinDinhKemGoc { get; set; }
        public int? Active { get; set; }
        public string GhiChu { get; set; }
        public int? TrangThaiGiayPhepID { get; set; }
        public long? DonViID { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
