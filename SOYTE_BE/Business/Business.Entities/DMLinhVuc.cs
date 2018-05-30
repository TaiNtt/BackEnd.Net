using Core.Common.Domain;

namespace Business.Entities
{
    public class DMLinhVuc : EntityBase
    {
        public int? ID_Goc { get; set; }
        public string TenLinhVuc { get; set; }
        public int? ParentID { get; set; }
        public long? TTHC_DonVi { get; set; }
        public string NgayDongBo { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedUserID { get; set; }
        public string CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public string LastUpdDate { get; set; }
    }
}
