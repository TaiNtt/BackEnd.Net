using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_PhuongXa : EntityBase
    {
        public int ID { get; set; }
        public string MaPhuongXa { get; set; }
        public string TenPhuongXa { get; set; }
        public int? QuanID { get; set; }
        public string MoTa { get; set; }
        public bool? Active { get; set; }
    }
}