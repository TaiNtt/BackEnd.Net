using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class GiayPhepDoanKCB : EntityBase
    {
        public long GiayPhepDoanKCBID { get; set; }
        public long? HoSoID { get; set; }
        public string SoGiayPhep { get; set; }
        public DateTime? NgayCap { get; set; }
        public string TenDoanKCB { get; set; }
        public DateTime? NgayKCB { get; set; }
        public long? NoiKCB_HuyenID { get; set; }
        public long? NoiKCB_XaID { get; set; }
        public int? SoNguoiDuocKham { get; set; }
        public decimal? KinhPhi { get; set; }
        public string DonViDeNghi_Ten { get; set; }
        public long? DonViDeNghi_TinhID { get; set; }
        public long? DonViDeNghi_HuyenID { get; set; }
        public long? DonViDeNghi_XaID { get; set; }
        public string DonViDeNghi_SoNha { get; set; }
        public string DonViDeNghi_DiaChi { get; set; }
        public string DonViDeNghi_NguoiXinPhep { get; set; }
        public string DonViDeNghi_Phone { get; set; }
        public string DonViDeNghi_Email { get; set; }
        public string NCTN_HoTen { get; set; }
        public string NCTN_NgaySinh { get; set; }
        public int? NCTN_GioiTinhID { get; set; }
        public int? NCTN_LoaiGiayToID { get; set; }
        public string NCTN_SoGiayTo { get; set; }
        public DateTime? NCTN_NgayCapGiayTo { get; set; }
        public string NCTN_NoiCapGiayTo { get; set; }
        public string YKien { get; set; }
        public int? TrangThaiGiayPhepID { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public DateTime? LastUpdDate { get; set; }
    }
}
