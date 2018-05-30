using System;
using Core.Common.Domain;

namespace Business.Entities
{
    public class TTHC_DonVi:EntityBase
    {
        public string ThuTucHanhChinhID { get; set; }
        public string DonViID { get; set; }
        public bool? CongKhai { get; set; }
        public bool? DichVuCong { get; set; }
        public int? MucDo { get; set; }
        public bool? BuuChinhCongIch { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public DateTime? LastUpdDate { get; set; }
    }
}
