using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class GiayChungNhanBTGT_ThanhPhan : EntityBase
    {
        public long ThanhPhanID { get; set; }
        public long? GiayChungNhanBTGTID { get; set; }
        public string TenViThuoc { get; set; }
        public string LieuLuong { get; set; }
    }
}
