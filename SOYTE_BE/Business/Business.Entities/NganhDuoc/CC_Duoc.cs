using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class CC_Duoc : EntityBase
    {
        public long ChungChiDuocId { get; set; }
        public long? HoSoID { get; set; }
        public string DotHoiDong { get; set; }
        public DateTime? NgayHoiDong { get; set; }
        public DateTime? NgayTrinhCap { get; set; }
        public string SoChungChi { get; set; }
        public DateTime? NgayCap { get; set; }
        public int? NoiCapChungChiID { get; set; }
        public string NoiCapChungChi { get; set; }
        public string SoQuyetDinh { get; set; }
        public DateTime? NgayQuyetDinh { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        public int? LoaiGiayTo { get; set; }
        public string SoGiayTo { get; set; }
        public DateTime? NgayCapGiayTo { get; set; }
        public string NoiCapGiayTo { get; set; }
        public long? ThuongTru_TinhID { get; set; }
        public long? ThuongTru_HuyenID { get; set; }
        public long? ThuongTru_XaID { get; set; }
        public string ThuongTru_SoNha { get; set; }
        public string ThuongTru_DiaChi { get; set; }
        public long? ChoO_TinhID { get; set; }
        public long? ChoO_HuyenID { get; set; }
        public long? ChoO_XaID { get; set; }
        public string ChoO_SoNha { get; set; }
        public string ChoO_DiaChi { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string HinhAnh { get; set; }
        public string PhamViHoatDongID { get; set; }
        public string PhamViHoatDongs { get; set; }
        public string DuDieuKienHanhNghe { get; set; }
        public string DuDieuKienHanhNghes { get; set; }
        public string AttachOriginalName { get; set; }
        public string AttachUploadName { get; set; }
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
