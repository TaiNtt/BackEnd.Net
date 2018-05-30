using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class GiayPhepHoatDongChuThapDo : EntityBase
    {
        public long GiayPhepHoatDongChuThapDoID { get; set; }
        public long? HoSoID { get; set; }
        public string SoGiayPhep { get; set; }
        public DateTime? NgayCap { get; set; }
        public string SoBienBanThamDinh { get; set; }
        public DateTime? NgayThamDinh { get; set; }
        public string TenDiem { get; set; }
        public long? TinhID { get; set; }
        public long? HuyenID { get; set; }
        public long? XaID { get; set; }
        public string SoNha { get; set; }
        public string DiaChi { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string SoQDThanhLap { get; set; }
        public DateTime? NgayCapQDThanhLap { get; set; }
        public string NoiCapQDThanhLap { get; set; }
        public int? HinhThucToChucID { get; set; }
        public string PhamViHoatDong { get; set; }
        public string ThoiGianLamViec { get; set; }
        public string NguoiChiuTrachNhiem { get; set; }
        public int? TrangThaiGiayPhepID { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public DateTime? LastUpdDate { get; set; }
    }
}
