using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class KhongPheDuyet : EntityBase
    {
        public long KhongPheDuyetID { get; set; }
        public long? QuaTrinhXuLyID { get; set; }
        public string LyDoKhongPheDuyet { get; set; }
    }
}