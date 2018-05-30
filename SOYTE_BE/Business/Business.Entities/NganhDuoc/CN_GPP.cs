using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class CN_GPPFull : EntityBase
    {
        public CN_GPP gPP { get; set; }
        HoSoTiepNhan hoSoTiepNhan { get; set; }
        CC_Duoc cCDuoc { get; set; }
    }
    public class CN_GPP : EntityBase
    {
        public long THTGPPId { get; set; }
        public long? HoSoID { get; set; }
        public string SoBienNhan { get; set; }
        public string SoGiayChungNhan { get; set; }
        public DateTime? NgayCapChungNhan { get; set; }
        public string ThoiHan { get; set; }
        public string SoQuyetDinh { get; set; }
        public DateTime? NgayQuyetDinh { get; set; }
        public string NguoiKyQuyetDinh { get; set; }
        public string TenCoSo { get; set; }
        public string SoDKKD { get; set; }
        public string TrucThuoc { get; set; }
        public int? TinhThanhCSId { get; set; }
        public string TinhThanhCS { get; set; }
        public int? QuanCSId { get; set; }
        public string QuanCS { get; set; }
        public int? PhuongCSId { get; set; }
        public string PhuongCS { get; set; }
        public string SoNhaCS { get; set; }
        public string DiaChiCS { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public long? ChungChiDuocId { get; set; }
        public string SoChungChi { get; set; }
        public string PhamViKinhDoanhIds { get; set; }
        public string PhamViKinhDoanhs { get; set; }
        public string TruongDoanKiemTra { get; set; }
        public DateTime? NgayKiemTra { get; set; }
        public string UuDiem { get; set; }
        public string TonTai { get; set; }
        public string KetLuan { get; set; }
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
