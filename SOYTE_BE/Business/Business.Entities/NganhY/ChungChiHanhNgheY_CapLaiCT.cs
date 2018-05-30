using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class ChungChiHanhNgheY_CapLaiCT : EntityBase
    {
        public long ChiTietCapLaiID { get; set; }
        public long? CapLaiID { get; set; }
        public string NoiDungTruoc { get; set; }
        public string NoiDungSau { get; set; }
    }
}
