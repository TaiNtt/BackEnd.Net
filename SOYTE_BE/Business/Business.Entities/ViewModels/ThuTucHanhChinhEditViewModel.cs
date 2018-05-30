using System.Collections.Generic;

namespace Business.Entities.ViewModels
{
    public class ThuTucHanhChinhEditViewModel
    {
        public ThuTucHanhChinh ThuTucHanhChinh { get; set; }
        public IEnumerable<TTHC_MauDonToKhai> MauDons { get; set; }
        public IEnumerable<TTHC_LienThong> LienThongs { get; set; }
        public IEnumerable<DanhMuc> CapDonVis { get; set; }
        public IEnumerable<DanhMuc> DonVis { get; set; }
        public IEnumerable<DanhMuc> DoiTuongs { get; set; }
        public IEnumerable<DanhMuc> DvcTrucTuyens { get; set; }
        public IEnumerable<DanhMuc> LinhVucs { get; set; }

    }
}
