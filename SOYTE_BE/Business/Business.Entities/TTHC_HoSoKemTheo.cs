using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class TTHC_HoSoKemTheo:EntityBase
    {
        public string ThuTucHanhChinhID { get; set; }
        public string HoSoKemTheoID { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public DateTime? LastUpdDate { get; set; }
    }
}
