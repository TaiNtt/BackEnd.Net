using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_TrinhDoChuyenMon : EntityBase
    {
        public int TrinhDoChuyenMonID { get; set; }
        public string Ten { get; set; }
        public bool? Used { get; set; }
    }
}