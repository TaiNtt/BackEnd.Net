using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_QuyTrinh_Buoc_NguoiNhanList
    {
        public long? RowNo { get; set; }
        public int BuocID { get; set; }
        public int? TrangThaiHienTaiID { get; set; }
        public string TrangThaiHienTai { get; set; }
        public int? TrangThaiTiepTheoID { get; set; }
        public string TrangThaiTiepTheo { get; set; }
        public string NguoiXuLyTiepTheo { get; set; }
        public bool? Used { get; set; }
        public int? TotalItems { get; set; }
    }
}