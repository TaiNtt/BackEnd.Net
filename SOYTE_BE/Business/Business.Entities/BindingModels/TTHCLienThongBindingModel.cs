using System.Collections.Generic;

namespace Business.Entities.BindingModels
{
    public class TTHCLienThongBindingModel
    {
        public TTHC_DonVi TTHCDonVi { get; set; }
        public List<TTHC_LienThong> LienThongs { get; set; }
    }
}
