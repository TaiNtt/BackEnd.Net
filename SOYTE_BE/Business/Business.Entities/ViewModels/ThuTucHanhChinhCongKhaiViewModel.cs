using System.Collections.Generic;

namespace Business.Entities.ViewModels
{
    public class ThuTucHanhChinhCongKhaiViewModel
    {
        public TTHCCongKhai TTHCCongKhai { get; set; }
        public IEnumerable<ThanhPhanHoSo> ThanhPhanHoSos { get; set; }
        public IEnumerable<TTHC_LienThong> LienThongs { get; set; }
        public IEnumerable<DanhMuc> DonVis { get; set; }
        public IEnumerable<DanhMuc> ThuTucHanhChinhs { get; set; }
        public IEnumerable<DanhMuc> DvcTrucTuyens { get; set; }
    }
}
