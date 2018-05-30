using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class DK_HoiThaoGioiThieuThuoc : EntityBase
    {
        public long HoiThaoThuocID { get; set; }
        public long? HoSoID { get; set; }
        public string SoBienNhan { get; set; }
        public string SoGiayDangKy { get; set; }
        public string SoTiepNhan { get; set; }
        public DateTime? NgayTiepNhan { get; set; }
        public string TenDonVi { get; set; }
        public string SoGPHD { get; set; }
        public int? TinhThanhId { get; set; }
        public string TinhThanh { get; set; }
        public int? QuanId { get; set; }
        public string Quan { get; set; }
        public int? PhuongId { get; set; }
        public string Phuong { get; set; }
        public string SoNha { get; set; }
        public string Duong { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string ThangSinh { get; set; }
        public string NamSinh { get; set; }
        public DateTime? NgaySinhDayDu { get; set; }
        public int? GioiTinh { get; set; }
        public int? LoaiGiayToId { get; set; }
        public string SoGiayTo { get; set; }
        public DateTime? NgayCapGiayTo { get; set; }
        public int? NoiCapGiayToId { get; set; }
        public string NoiCapGiayTo { get; set; }
        public string SoDienThoaiNCTN { get; set; }
        public string EmailNCTN { get; set; }
        public string DiaDiemToChuc { get; set; }
        public DateTime? ThoiGianToChuc { get; set; }
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
