using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_HinhThucToChuc : EntityBase
    {
        public int HinhThucToChucID { get; set; }
        public string Ten { get; set; }
        public bool? Used { get; set; }
    }
}