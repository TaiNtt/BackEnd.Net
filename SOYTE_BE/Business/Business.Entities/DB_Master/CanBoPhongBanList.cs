using Core.Common.Domain;

namespace Business.Entities
{
    public class CanBoPhongBanList
    {
        public int CanBoID { get; set; }
        public string DisplayName { get; set; }
        public int PhongBanID { get; set; }
        public string TenPhongBan { get; set; }
    }
}