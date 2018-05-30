using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class ChungChiHanhNgheY_DieuChinhCT : EntityBase
    {
        public long ChiTietDieuChinhID { get; set; }
        public long? DieuChinhID { get; set; }
        public string NoiDungTruoc { get; set; }
        public string NoiDungSau { get; set; }
        public string FieldChange { get; set; }
    }
}
