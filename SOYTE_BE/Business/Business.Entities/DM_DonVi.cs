using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class DM_DonVi : EntityBase
    {
        public int? STT { get; set; }
                
        public string Ten { get; set; }

        public string TenUnu { get; set; }

        public string CapDonViID { get; set; }

        public string ParentId { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedUserID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? LastUpdUserID { get; set; }

        public DateTime? LastUpdDate { get; set; }
    }
}
