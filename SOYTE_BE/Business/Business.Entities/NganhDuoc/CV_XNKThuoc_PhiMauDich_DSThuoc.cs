using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class CV_XNKThuoc_PhiMauDich_DSThuoc : EntityBase
    {
        public long XNKThuocPMDDSThuocId { get; set; }
        public long? XNKThuocPhiMauDichId { get; set; }
        public string TenThuoc { get; set; }
        public string TinhChatThuoc { get; set; }
        public string QuyCachDongGoi { get; set; }
        public string SoLuong { get; set; }
        public string GhiChu { get; set; }
        public int? Active { get; set; }
        public long? DonViID { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
