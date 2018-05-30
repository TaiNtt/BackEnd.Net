using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class GiayChungNhanLuongY_QTHanhNghe : EntityBase
    {
        public long QuaTrinhID { get; set; }
        public long? GiayChungNhanLuongYID { get; set; }
        public string ThoiGian { get; set; }
        public string PhamViHoatDong { get; set; }
        public string NoiLamViec { get; set; }
        public string ChucVu { get; set; }
    }
}
