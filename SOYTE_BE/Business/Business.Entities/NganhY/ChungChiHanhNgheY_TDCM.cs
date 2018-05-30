using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class ChungChiHanhNgheY_TDCM : EntityBase
    {
        public long TrinhDoID { get; set; }
        public long? ChungChiHanhNgheYID { get; set; }
        public int? TrinhDoChuyenMonID { get; set; }
        public string NamTotNghiep { get; set; }
        public string TenTruongDaoTao { get; set; }
    }
}
