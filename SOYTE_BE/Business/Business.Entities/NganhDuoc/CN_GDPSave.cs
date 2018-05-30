using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class CN_GDPSave : EntityBase
    {
        public CN_GDP gDP { get; set; }
        public List<CN_GDP_DSKho> lstgDP_DSKho { get; set; }
    }
}