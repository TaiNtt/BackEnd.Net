using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_QuyTrinh_Buoc : EntityBase
    {
        public int BuocID { get; set; }
        public int? ThuTucID { get; set; }
        public int? TrangThaiHienTaiID { get; set; }
        public int? TrangThaiTiepTheoID { get; set; }
        public bool? Used { get; set; }
    }
}