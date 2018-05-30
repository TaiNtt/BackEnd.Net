using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class PD_Thuoc_Methadone_TinhHinh : EntityBase
    {
        public long PDMethadoneTinhHinhId { get; set; }
        public long? PDMethadoneId { get; set; }
        public string TenDonVi { get; set; }
        public string TenThuoc { get; set; }
        public string DonViTinh { get; set; }
        public string SLTonKhoKyTruoc { get; set; }
        public string SLNhapTrongKy { get; set; }
        public string TongSo { get; set; }
        public string SLXuatTrongKy { get; set; }
        public string SLHaoHut { get; set; }
        public string SLDuThua { get; set; }
        public string TonKhoCuoiKy { get; set; }
        public string TongSoNguoiBenhThamGiaDieuTri { get; set; }
        public string SLNguoiBenhDuKienTangKyToi { get; set; }
        public string SLDuTruKyToi { get; set; }
        public string SLDuyetDuTru { get; set; }
        public string GhiChu { get; set; }
        public int? Active { get; set; }
        public long? DonViID { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
