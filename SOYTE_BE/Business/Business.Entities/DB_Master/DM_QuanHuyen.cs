using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_QuanHuyen : EntityBase
    {
        public int ID { get; set; }
        public string MaQuan { get; set; }
        public string TenQuan { get; set; }
        public int? TinhThanhID { get; set; }
        public string MoTa { get; set; }
        public bool? Active { get; set; }
    }
}