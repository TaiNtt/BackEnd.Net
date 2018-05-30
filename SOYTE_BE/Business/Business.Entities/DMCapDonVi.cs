using Core.Common.Domain;

namespace Business.Entities
{
    public class DMCapDonVi : EntityBase
    {
        public int STT { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string TenUnu { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedUserID { get; set; }
        public string CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public string LastUpdDate { get; set; }
    }
}
