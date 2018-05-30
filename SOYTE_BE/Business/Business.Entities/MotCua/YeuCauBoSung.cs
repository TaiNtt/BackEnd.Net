using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class YeuCauBoSung : EntityBase
    {
        public long YeuCauBoSungID { get; set; }
        public long? QuaTrinhXuLyID { get; set; }
        public DateTime? NgayYeuCauBoSung { get; set; }
        public string ThongTinYeuCau { get; set; }
        public bool? DaBoSung { get; set; }
    }
}