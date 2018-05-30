using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class GiayChungNhanATSH : EntityBase
    {
        public long GiayChungNhanATSHID { get; set; }
        public long? HoSoID { get; set; }
        public int? Cap { get; set; }
        public string SoGiayChungNhan { get; set; }
        public DateTime? NgayCap { get; set; }
        public int? ThoiHan { get; set; }
        public string TenCoSo { get; set; }
        public string TenPhongXetNghiem { get; set; }
        public long? TinhID { get; set; }
        public long? HuyenID { get; set; }
        public long? XaID { get; set; }
        public string SoNha { get; set; }
        public string DiaChi { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
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
