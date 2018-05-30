using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class PD_Thuoc_GN_HTTSave : EntityBase
    {
        public PD_Thuoc_GN_HTT thuocGNHTT { get; set; }
        public List<PD_Thuoc_GN_HTT_DSThuoc> lstthuocGNHTT_DSThuoc { get; set; }
    }
}