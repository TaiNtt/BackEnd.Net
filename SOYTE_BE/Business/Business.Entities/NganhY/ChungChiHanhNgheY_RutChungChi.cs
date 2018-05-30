using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class ChungChiHanhNgheY_RutChungChi : EntityBase
    {
        public long RutChungChiID { get; set; }
        public long? ChungChiHanhNgheYID { get; set; }
        public DateTime? NgayRut { get; set; }
        public int? LyDoRutID { get; set; }
        public bool? DaRut { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public DateTime? LastUpdDate { get; set; }
    }
}
