using Core.Common.Domain;

namespace Business.Entities
{
    public class WorkList : EntityBase
    {
        public long WorklistID { get; set; }
        public int? UserID { get; set; }
        public int? TrangThaiHoSoID { get; set; }
        public int? SoLuong { get; set; }
    }
}