using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class GiayChungNhanBTGT : EntityBase
    {
        public long GiayChungNhanBTGTID { get; set; }
        public long? HoSoID { get; set; }
        public string SoGiayChungNhan { get; set; }
        public DateTime? NgayCap { get; set; }
        public string SoQuyetDinh { get; set; }
        public DateTime? NgayQuyetDinh { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        public int? LoaiGiayTo { get; set; }
        public string SoGiayTo { get; set; }
        public DateTime? NgayCapGiayTo { get; set; }
        public string NoiCapGiayTo { get; set; }
        public long? TinhID { get; set; }
        public long? HuyenID { get; set; }
        public long? XaID { get; set; }
        public string SoNha { get; set; }
        public string DiaChi { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TenBaiThuoc { get; set; }
        public string ChiDinh { get; set; }
        public string CachDung { get; set; }
        public string LieuDung { get; set; }
        public string DangThuoc { get; set; }
        public string ChongChiDinh { get; set; }
        public string HanSuDung { get; set; }
        public int? TrangThaiGiayPhepID { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public DateTime? LastUpdDate { get; set; }
    }
}
