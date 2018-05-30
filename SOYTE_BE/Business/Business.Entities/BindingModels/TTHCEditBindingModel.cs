using System.Collections.Generic;

namespace Business.Entities.BindingModels
{
    public class TTHCEditBindingModel
    {
        public ThuTucHanhChinhBindingModel ThucTucHanhChinh { get; set; }
        public List<TTHC_LienThong> LienThongs { get; set; }
        public List<TTHCMauDonToKhaiBindingModel> MauDons { get; set; }
        public List<TTHCHoSoKemTheoBinding> HoSoKemTheos { get; set; }
    }
}
