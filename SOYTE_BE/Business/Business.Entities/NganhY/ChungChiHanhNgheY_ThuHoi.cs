using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class ChungChiHanhNgheY_ThuHoi : EntityBase
    {
        public long ThuHoiID { get; set; }
        public long? ChungChiHanhNgheYID { get; set; }
        public DateTime? NgayThuHoi { get; set; }
        public int? LyDoThuHoiID { get; set; }
        public bool? DaThuHoi { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public DateTime? LastUpdDate { get; set; }
    }
}
