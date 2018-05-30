using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class CV_XNKThuoc_PhiMauDich : EntityBase
    {
        public long XNKThuocPhiMauDichId { get; set; }
        public long? HoSoID { get; set; }
        public string SoBienNhan { get; set; }
        public DateTime? NgayLamDonDeNghi { get; set; }
        public string SoCongVan { get; set; }
        public DateTime? NgayBanHanh { get; set; }
        public string ThoiHan { get; set; }
        public string HoTenNguoiNhanThuoc { get; set; }
        public string NgaySinhNguoiNhanThuoc { get; set; }
        public string ThangSinhNguoiNhanThuoc { get; set; }
        public string NamSinhNguoiNhanThuoc { get; set; }
        public DateTime? NgaySinhDayDuNguoiNhanThuoc { get; set; }
        public int? GioiTinhNguoiNhanThuoc { get; set; }
        public int? LoaiGiayToNguoiNhanThuocId { get; set; }
        public string SoGiayToNguoiNhanThuoc { get; set; }
        public DateTime? NgayCapGiayToNguoiNhanThuoc { get; set; }
        public int? NoiCapGiayToNguoiNhanThuocId { get; set; }
        public string NoiCapGiayToNguoiNhanThuoc { get; set; }
        public int? TinhThanhTTNguoiNhanThuocId { get; set; }
        public string TinhThanhTTNguoiNhanThuoc { get; set; }
        public int? QuanTTNguoiNhanThuocId { get; set; }
        public string QuanTTNguoiNhanThuoc { get; set; }
        public int? PhuongTTNguoiNhanThuocId { get; set; }
        public string PhuongTTNguoiNhanThuoc { get; set; }
        public string SoNhaTTNguoiNhanThuoc { get; set; }
        public string DuongTTNguoiNhanThuoc { get; set; }
        public string DiaChiTTNguoiNhanThuoc { get; set; }
        public int? TinhThanhHTNguoiNhanThuocId { get; set; }
        public string TinhThanhHTNguoiNhanThuoc { get; set; }
        public int? QuanHTNguoiNhanThuocId { get; set; }
        public string QuanHTNguoiNhanThuoc { get; set; }
        public int? PhuongHTNguoiNhanThuocId { get; set; }
        public string PhuongHTNguoiNhanThuoc { get; set; }
        public string SoNhaHTNguoiNhanThuoc { get; set; }
        public string DuongHTNguoiNhanThuoc { get; set; }
        public string DiaChiHTNguoiNhanThuoc { get; set; }
        public string SoDienThoaiNguoiNhanThuoc { get; set; }
        public string EmailNguoiNhanThuoc { get; set; }
        public string TGSongTaiVN { get; set; }
        public bool? LaNguoiSuDung { get; set; }
        public string HoTenNguoiSDThuoc { get; set; }
        public string NgaySinhNguoiSDThuoc { get; set; }
        public string ThangSinhNguoiSDThuoc { get; set; }
        public string NamSinhNguoiSDThuoc { get; set; }
        public DateTime? NgaySinhDayDuNguoiSDThuoc { get; set; }
        public int? TinhThanhTTNguoiSDThuocId { get; set; }
        public string TinhThanhTTNguoiSDThuoc { get; set; }
        public int? QuanTTNguoiSDThuocId { get; set; }
        public string QuanTTNguoiSDThuoc { get; set; }
        public int? PhuongTTNguoiSDThuocId { get; set; }
        public string PhuongTTNguoiSDThuoc { get; set; }
        public string SoNhaTTNguoiSDThuoc { get; set; }
        public string DuongTTNguoiSDThuoc { get; set; }
        public string DiaChiTTNguoiSDThuoc { get; set; }
        public int? TinhThanhHTNguoiSDThuocId { get; set; }
        public string TinhThanhHTNguoiSDThuoc { get; set; }
        public int? QuanHTNguoiSDThuocId { get; set; }
        public string QuanHTNguoiSDThuoc { get; set; }
        public int? PhuongHTNguoiSDThuocId { get; set; }
        public string PhuongHTNguoiSDThuoc { get; set; }
        public string SoNhaHTNguoiSDThuoc { get; set; }
        public string DuongHTNguoiSDThuoc { get; set; }
        public string DiaChiHTNguoiSDThuoc { get; set; }
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
