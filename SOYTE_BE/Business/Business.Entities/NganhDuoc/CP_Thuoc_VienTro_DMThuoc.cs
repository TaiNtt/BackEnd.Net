using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class CP_Thuoc_VienTro_DMThuoc : EntityBase
    {
        public long DMThuocVienTroId { get; set; }
        public long? ThuocVienTroId { get; set; }
        public string TenThuoc { get; set; }
        public string DonViTinh { get; set; }
        public string SoLuong { get; set; }
        public string HoatChatChinh { get; set; }
        public string HanDung { get; set; }
        public string TenCongTySX { get; set; }
        public string GhiChu { get; set; }
        public int? Active { get; set; }
        public long? DonViID { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
