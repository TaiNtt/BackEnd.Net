using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class CC_Duoc_CapLaiCT : EntityBase
    {
        public long ChiTietCapLaiID { get; set; }
        public long? CapLaiID { get; set; }
        public string NoiDungTruoc { get; set; }
        public string NoiDungSau { get; set; }
    }
}
