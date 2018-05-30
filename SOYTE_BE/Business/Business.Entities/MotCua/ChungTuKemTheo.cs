using Core.Common.Domain;

namespace Business.Entities
{
    public class ChungTuKemTheo : EntityBase
    {
        public int STT { get; set; }
        public int ChungTuKemTheoID { get; set; }
        public int HoSoID { get; set; }
        public string TenChungTu { get; set; }
        public int SLBanChinh { get; set; }
        public int SLBanSao { get; set; }
        public int SLPhoto { get; set; }
        public string GhiChu { get; set; }
        public string AttachFile { get; set; }
    }
}