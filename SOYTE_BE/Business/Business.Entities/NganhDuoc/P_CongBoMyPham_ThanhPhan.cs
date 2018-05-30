using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class P_CongBoMyPham_ThanhPhan : EntityBase
    {
        public long SPMP_ThanhPhanId { get; set; }
        public long? CongBoSPMyPhamId { get; set; }
        public string TenThanhPhan { get; set; }
        public string TyLe { get; set; }
        public string GhiChu { get; set; }
        public int? Active { get; set; }
        public long? DonViID { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
