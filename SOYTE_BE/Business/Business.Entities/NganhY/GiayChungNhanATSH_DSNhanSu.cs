using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class GiayChungNhanATSH_DSNhanSu : EntityBase
    {
        public long NhanSuID { get; set; }
        public long? GiayChungNhanATSHID { get; set; }
        public string HoTen { get; set; }
        public string ChucDanh { get; set; }
        public int? TrinhDoChuyenMonID { get; set; }
        public string CongViecPhuTrach { get; set; }
    }
}
