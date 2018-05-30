using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class TTHC_MauDonToKhai : EntityBase
    {
        public string ThuTucHanhChinhID { get; set; }

        public string TenMauDonToKhai { get; set; }

        public string URL { get; set; }

        public int? CreatedUserID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? LastUpdUserID { get; set; }

        public DateTime? LastUpdDate { get; set; }
    }
}
