using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class GiayChungNhanATSHSave : EntityBase
    {
        public GiayChungNhanATSH giayChungNhanATSH { get; set; }
        public List<GiayChungNhanATSH_DSNhanSu> lstGiayChungNhanATSH_DSNhanSu { get; set; }
        public List<GiayChungNhanATSH_DSThietBi> lstGiayChungNhanATSH_DSThietBi { get; set; }        
    }
}