using Core.Common.Domain;

namespace Business.Entities
{
    public class DMDuongDiQuyTrinh : EntityBase
    {
        public string ChucNangHienTai { get; set; }
        public string ChucNangKeTiep { get; set; }
        public string TenChucNangHienTai { get; set; }
        public string TenChucNangKeTiep { get; set; }
        public long? TinhTrangID { get; set; }
    }
}
