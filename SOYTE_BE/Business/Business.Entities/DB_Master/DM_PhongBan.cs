using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_PhongBan : EntityBase
    {
        public int PhongBanID { get; set; }
        public string MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public bool? Used { get; set; }
    }
}