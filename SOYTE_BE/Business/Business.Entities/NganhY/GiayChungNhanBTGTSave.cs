using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class GiayChungNhanBTGTSave// : EntityBase
    {
        public GiayChungNhanBTGT giayChungNhanBTGT { get; set; }
        public List<GiayChungNhanBTGT_ThanhPhan> lstGiayChungNhanBTGT_ThanhPhan { get; set; }
    }
}