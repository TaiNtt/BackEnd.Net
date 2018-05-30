using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class GiayPhepHoatDongKCB : EntityBase
    {
        public long GiayPhepKhamChuaBenhID { get; set; }
        public long? HoSoID { get; set; }
        public string SoGiayPhep { get; set; }
        public DateTime? NgayCap { get; set; }
        public string CoSoDK_Ten { get; set; }
        public string CoSoDK_MaDoanhNghiep { get; set; }
        public string CoSoDK_HinhThucToChucID { get; set; }
        public string HinhThucToChucs { get; set; }
        public long? CoSoDK_TinhID { get; set; }
        public long? CoSoDK_HuyenID { get; set; }
        public long? CoSoDK_XaID { get; set; }
        public string CoSoDK_SoNha { get; set; }
        public string CoSoDK_DiaChi { get; set; }
        public string CoSoDK_Phone { get; set; }
        public string CoSoDK_Email { get; set; }
        public long? NCTN_ChungChiHanhNgheYID { get; set; }
        public string NCTN_HoTen { get; set; }
        public string NCTN_NgaySinh { get; set; }
        public int? NCTN_GioiTinhID { get; set; }
        public int? NCTN_LoaiGiayToID { get; set; }
        public string NCTN_SoGiayTo { get; set; }
        public DateTime? NCTN_NgayCapGiayTo { get; set; }
        public string NCTN_NoiCapGiayTo { get; set; }
        public string ThoiGianLamViec { get; set; }
        public string PhamViHoatDongID { get; set; }
        public string PhamViHoatDongs { get; set; }
        public int? TrangThaiGiayPhepID { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public DateTime? LastUpdDate { get; set; }
    }
}
