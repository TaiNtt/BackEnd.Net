using Core.Common.Domain;

namespace Business.Entities
{
    public class TTHC_LienThong:EntityBase
    {
        public string ThuTucHanhChinhID { get; set; }
        
        public string DonViID { get; set; }
       
        public string DonViLienThongID { get; set; }
      
        public string TenThuTucHanhChinhLienThong { get; set; }
    }
}
