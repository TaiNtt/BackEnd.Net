using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class DK_HoiThaoGioiThieuThuoc_DMThuoc : EntityBase
    {
        public long HoiThaoDMThuocID { get; set; }
        public long? HoiThaoThuocID { get; set; }
        public string TenThuoc { get; set; }
        public string SoDangKy { get; set; }
        public string DoiTuongDuHoiThao { get; set; }
        public string LanThu { get; set; }
        public string GhiChu { get; set; }
        public int? Active { get; set; }
        public long? DonViID { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
