using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class PD_Thuoc_Methadone : EntityBase
    {
        public long PDMethadoneId { get; set; }
        public long? HoSoID { get; set; }
        public string SoBienNhan { get; set; }
        public DateTime? NgayHoanThanhBaoCao { get; set; }
        public string SoPheDuyet { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public DateTime? ThoiHan { get; set; }
        public string TenDonViTH { get; set; }
        public int? Active { get; set; }
        public string GhiChu { get; set; }
        public int? TrangThaiGiayPhepID { get; set; }
        public long? DonViID { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
