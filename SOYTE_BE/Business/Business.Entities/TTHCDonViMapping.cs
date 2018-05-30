using Core.Common.Domain;

namespace Business.Entities
{
    public class TTHCDonViMapping : EntityBase
    {
        public string TenDonVi_QG { get; set; }
        public string CapDonViID { get; set; }
        public string DonViID { get; set; }
        public string TenDonVi_TPHCM { get; set; }
        public string LinhVucID { get; set; }
        public string TenLinhVuc { get; set; }
        public string TTHC_IDGOC { get; set; }
    }
}
