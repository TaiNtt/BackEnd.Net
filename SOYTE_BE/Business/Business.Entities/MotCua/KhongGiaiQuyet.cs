using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class KhongGiaiQuyet : EntityBase
    {
        public long KhongGiaiQuyetID { get; set; }
        public long? QuaTrinhXuLyID { get; set; }
        public string LyDoKhongGiaiQuyet { get; set; }
    }
}