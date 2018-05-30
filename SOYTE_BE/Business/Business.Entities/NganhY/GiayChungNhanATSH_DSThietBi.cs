using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class GiayChungNhanATSH_DSThietBi : EntityBase
    {
        public long ThietBiID { get; set; }
        public long? GiayChungNhanATSHID { get; set; }
        public string TenThietBi { get; set; }
        public string KyHieu { get; set; }
        public string HangSX { get; set; }
        public string NuocSX { get; set; }
        public string NamSX { get; set; }
        public string TinhTrangSuDung { get; set; }
        public string BaoDuong { get; set; }
        public string GhiChu { get; set; }
    }
}
