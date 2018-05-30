using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class CN_LuuHanhMyPham : EntityBase
    {
        public long LuuHanhMyPhamId { get; set; }
        public long? HoSoID { get; set; }
        public string SoBienNhan { get; set; }
        public string SoChungNhan { get; set; }
        public DateTime? NgayCapChungNhan { get; set; }
        public string SoQuyetDinh { get; set; }
        public DateTime? NgayQuyetDinh { get; set; }
        public string TenCongTy { get; set; }
        public string SoDKKD { get; set; }
        public string TenNhaSanXuat { get; set; }
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
