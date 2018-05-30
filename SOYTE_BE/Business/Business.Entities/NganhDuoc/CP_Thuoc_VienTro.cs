using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class CP_Thuoc_VienTro : EntityBase
    {
        public long ThuocVienTroId { get; set; }
        public long? HoSoID { get; set; }
        public string SoBienNhan { get; set; }
        public string SoCongVanDeNghi { get; set; }
        public DateTime? NgayGui { get; set; }
        public string DonViGui { get; set; }
        public string SoTiepNhan { get; set; }
        public DateTime? NgayTiepNhan { get; set; }
        public string TenDonVi { get; set; }
        public string SoGPHD { get; set; }
        public int? TinhThanhDVId { get; set; }
        public string TinhThanhDV { get; set; }
        public int? QuanDVId { get; set; }
        public string QuanDV { get; set; }
        public int? PhuongDVId { get; set; }
        public string PhuongDV { get; set; }
        public string SoNhaDV { get; set; }
        public string DiaChiDV { get; set; }
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
