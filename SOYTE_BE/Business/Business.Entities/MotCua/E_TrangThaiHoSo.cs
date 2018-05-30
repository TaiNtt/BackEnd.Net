using Core.Common.Domain;

namespace Business.Entities
{
    public class E_TrangThaiHoSo : EntityBase
    {
        public int TrangThaiHoSoID { get; set; }
        public string MaTrangThaiHoSo { get; set; }
        public string TenTrangThaiHoSo { get; set; }
    }
}