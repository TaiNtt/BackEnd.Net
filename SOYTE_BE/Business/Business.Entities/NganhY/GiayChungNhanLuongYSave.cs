using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class GiayChungNhanLuongYSave : EntityBase
    {
        public GiayChungNhanLuongY giayChungNhanLuongY { get; set; }
        public List<GiayChungNhanLuongY_QTHanhNghe> lstgiayChungNhanLuongY_QTHanhNghe { get; set; }
    }
}