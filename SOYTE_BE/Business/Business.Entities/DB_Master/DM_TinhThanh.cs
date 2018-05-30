using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_TinhThanh : EntityBase
    {
        public int ID { get; set; }
        public string MaQuocGia { get; set; }
        public string MaTinh { get; set; }
        public string TenTinh { get; set; }
        public string MoTa { get; set; }
        public bool? Active { get; set; }
    }
}