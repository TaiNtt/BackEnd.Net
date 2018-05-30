using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_ChungTuKemTheo : EntityBase
    {
        public int ChungTuID { get; set; }
        public int ThuTucID { get; set; }
        public string TenChungTu { get; set; }
        public int? SLBanChinh { get; set; }
        public int? SLBanSao { get; set; }
        public int? SLPhoto { get; set; }
    }
}