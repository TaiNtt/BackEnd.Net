using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class TamNgungThamDinh : EntityBase
    {
        public long TamNgungThamDinhID { get; set; }
        public long? QuaTrinhXuLyID { get; set; }
        public DateTime? NgayYeuCauTamNgung { get; set; }
        public string LyDoTamNgung { get; set; }
    }
}