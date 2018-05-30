using Core.Common.Domain;

namespace Business.Entities
{
    public class E_LoaiCapPhep : EntityBase
    {
        public int LoaiCapPhepID { get; set; }
        public int NganhID { get; set; }
        public string Ten { get; set; }
    }
}