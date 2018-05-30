using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class HoSoTiepNhanSave : EntityBase
    {
        public HoSoTiepNhan HoSoTiepNhan { get; set;}
        public List<ChungTuKemTheo> lstChungTuKemTheo { get; set; }
    }
    public class HoSoTiepNhan : EntityBase
    {
        public long HoSoID { get; set; }
        public string SoBienNhan { get; set; }
        public DateTime? NgayNhan { get; set; }
        public DateTime? NgayHenTra { get; set; }
        public int? LinhVucID { get; set; }
        public string TenLinhVuc { get; set; }
        public int? ThuTucID { get; set; }
        public string TenThuTuc { get; set; }
        public string HoTenNguoiNop { get; set; }
        public int? GioiTinhID { get; set; }
        public string NgaySinh { get; set; }
        public long? TinhThanhID { get; set; }
        public string TenTinhThanh { get; set; }
        public long? QuanHuyenID { get; set; }
        public string TenQuanHuyen { get; set; }
        public long? PhuongXaID { get; set; }
        public string TenPhuongXa { get; set; }
        public string SoNha { get; set; }
        public int? LoaiGiayToID { get; set; }
        public string TenLoaiGiayTo { get; set; }
        public string SoGiayTo { get; set; }
        public DateTime? NgayCapGiayTo { get; set; }
        public string NoiCapGiayTo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? TrangThaiHoSoID { get; set; }
        public string TenTrangThaiHoSo { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public DateTime? LastUpdDate { get; set; }
        public long? QuaTrinhXuLyHienTaiID { get; set; }
        public long? HienNayTinhThanhID { get; set; }
        public string HienNayTenTinhThanh { get; set; }
        public long? HienNayQuanHuyenID { get; set; }
        public string HienNayTenQuanHuyen { get; set; }
        public long? HienNayPhuongXaID { get; set; }
        public string HienNayTenPhuongXa { get; set; }
        public string HienNaySoNha { get; set; }
        public long? LePhi { get; set; }
        public string GhiChu { get; set; }
        public int? TrinhDoChuyenMonID { get; set; }
        public string TenTrinhDoChuyenMon { get; set; }
        public int? HinhThucToChucID { get; set; }
        public string TenHinhThucToChuc { get; set; }
        public int? NoiNhanKetQuaID { get; set; }

    }
}