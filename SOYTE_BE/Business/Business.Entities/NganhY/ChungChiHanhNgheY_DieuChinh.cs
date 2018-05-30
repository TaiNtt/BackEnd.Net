using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class ChungChiHanhNgheY_DieuChinh : EntityBase
    {
        public long DieuChinhID { get; set; }
        public long? HoSoID { get; set; }
        public long? ChungChiHanhNgheYIDGoc { get; set; }
        public string SoChungChiCu { get; set; }
        public DateTime? NgayCapCu { get; set; }
        public string SoChungChi { get; set; }
        public DateTime? NgayCap { get; set; }
        public int? LanDieuChinh { get; set; }
        public int? LyDoDieuChinhID { get; set; }
        public bool? DaDieuChinh { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public DateTime? LastUpdDate { get; set; }
   
    }
}
