using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class CN_LuuHanhMyPham_SanPham : EntityBase
    {
        public long LHMP_SanPhamId { get; set; }
        public long? LuuHanhMyPhamId { get; set; }
        public string TenSanPham { get; set; }
        public string SoChungNhan { get; set; }
        public string SoHieuTieuChuan { get; set; }
        public string ThanhPhan { get; set; }
        public string NuocNhapKhau { get; set; }
        public string GhiChu { get; set; }
        public int? Active { get; set; }
        public long? DonViID { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
