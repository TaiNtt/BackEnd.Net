using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class DangKyQCTrangThietBi : EntityBase
    {
        public long DangKyQCTrangThietBiID { get; set; }
        public long? HoSoID { get; set; }
        public string SoGiayDangKy { get; set; }
        public string SoTiepNhan { get; set; }
        public DateTime? NgayTiepNhan { get; set; }
        public string DichVuQuangCao { get; set; }
        public string DonViDK_Ten { get; set; }
        public string DonViDK_MaDoanhNghiep { get; set; }
        public long? DonViDK_TinhID { get; set; }
        public long? DonViDK_HuyenID { get; set; }
        public long? DonViDK_XaID { get; set; }
        public string DonViDK_SoNha { get; set; }
        public string DonViDK_DiaChi { get; set; }
        public string DonViDK_Phone { get; set; }
        public string DonViDK_Email { get; set; }
        public string NCTN_Ten { get; set; }
        public string NCTN_NgaySinh { get; set; }
        public int? NCTN_GioiTinhID { get; set; }
        public int? NCTN_LoaiGiayToID { get; set; }
        public string NCTN_SoGiayTo { get; set; }
        public DateTime? NCTN_NgayCap { get; set; }
        public string NCTN_NoiCap { get; set; }
        public string NCTN_Phone { get; set; }
        public string NCTN_Email { get; set; }
        public int? TrangThaiGiayPhepID { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public DateTime? LastUpdDate { get; set; }
        public bool? IsDauKy { get; set; }
        public string SoBienNhanDauKy { get; set; }
        public DateTime? NgayNhanDauKy { get; set; }
        public DateTime? NgayHenTraDauKy { get; set; }

    }
}
