using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class CC_DuocSave : EntityBase
    {
        public CC_Duoc cC_Duoc { get; set; }
        public List<CC_Duoc_QTTH> lstCC_Duoc_QTTH { get; set; }
        public List<CC_Duoc_TDCM> lstCC_Duoc_TDCM { get; set; }        
    }
}