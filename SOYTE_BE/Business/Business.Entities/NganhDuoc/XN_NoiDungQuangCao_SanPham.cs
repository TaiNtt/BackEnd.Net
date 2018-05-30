using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class XN_NoiDungQuangCao_SanPham : EntityBase
    {
        public long NDQC_SPId { get; set; }
        public long? NoiDungQCId { get; set; }
        public string TenSanPham { get; set; }
        public long? PhieuCongBoId { get; set; }
        public string HinhThucQuangCao { get; set; }
        public string GhiChu { get; set; }
        public int? Active { get; set; }
        public long? DonViID { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
