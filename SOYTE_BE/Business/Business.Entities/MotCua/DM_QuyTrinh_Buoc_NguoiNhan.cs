using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_QuyTrinh_Buoc_NguoiNhan : EntityBase
    {
        public int BuocNguoiNhanID { get; set; }
        public int? BuocID { get; set; }
        public int? NguoiNhanID { get; set; }
    }
}