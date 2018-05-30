using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class CC_Duoc_TDCM : EntityBase
    {
        public long TrinhDoID { get; set; }
        public long? ChungChiDuocID { get; set; }
        public int? TrinhDoChuyenMonID { get; set; }
        public string TrinhDoChuyenMon { get; set; }
        public string NamTotNghiep { get; set; }
        public string TenTruongDaoTao { get; set; }
    }
}
