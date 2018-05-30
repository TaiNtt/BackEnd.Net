using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class PD_Thuoc_GN_HTT_DSThuoc : EntityBase
    {
        public long PDThuocGNHTTDSThuocId { get; set; }
        public long? PDThuocGNHTTId { get; set; }
        public string TenThuoc { get; set; }
        public string DonViTinh { get; set; }
        public string SLTonKhoKyTruoc { get; set; }
        public string SLNhapTrongKy { get; set; }
        public string TongSo { get; set; }
        public string TongSoXuatTrongKy { get; set; }
        public string TonKhoCuoiKy { get; set; }
        public string SLDuTru { get; set; }
        public string Duyet { get; set; }
        public string GhiChu { get; set; }
        public int? Active { get; set; }
        public long? DonViID { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
