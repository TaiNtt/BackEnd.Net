using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class CN_GDP_DSKho : EntityBase
    {
        public long THTGDPDSKhoId { get; set; }
        public long? THTGDPId { get; set; }
        public string TenKho { get; set; }
        public string DiaChiKho { get; set; }
        public int? Active { get; set; }
        public string GhiChu { get; set; }
        public long? DonViID { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
