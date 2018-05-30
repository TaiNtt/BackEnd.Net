using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class ThuTucHanhChinh : EntityBase
    {
        public string TenThuTuc { get; set; }
        public string MaTTHC { get; set; }
        public string MaTTHC_Bo { get; set; }
        public string CapDonViID { get; set; }
        public string DonViID { get; set; }
        public string TenDonVi { get; set; }
        public string LinhVucID { get; set; }
        public string LinhVuc { get; set; }
        public bool? CongKhai { get; set; }
        public bool? TTHCDacThu { get; set; }
        public string CoQuanThucHien { get; set; }
        public string CoQuanQD { get; set; }
        public string CoQuanPhoiHop { get; set; }
        public string CoQuanUyQuyen { get; set; }
        public string DiaChiTiepNhan { get; set; }
        public string CachThucTH { get; set; }
        public string ThanhPhanHoSo { get; set; }
        public string DoiTuongThucHien { get; set; }
        public string ThoiHanGiaiQuyet { get; set; }
        public string TrinhTuThucHien { get; set; }
        public string PhamVi { get; set; }
        public string KetQuaThucHien { get; set; }
        public string LePhi { get; set; }
        public string SoQuyetDinh { get; set; }
        public DateTime? NgayQuyetDinh { get; set; }
        public string SoBoHS { get; set; }
        public string LVBiSuaBoSungKey { get; set; }
        public string LVBiSuaBoSungName { get; set; }
        public string TTHCBiSuaBoSungKey { get; set; }
        public string TTHCBiSuaBoSungName { get; set; }
        public string LVHienTaiKey { get; set; }
        public string LVHienTaiName { get; set; }
        public string TTHCHienTaiKey { get; set; }
        public string TTHCHienTaiName { get; set; }
        public string LVSuaBoSungKey { get; set; }
        public string LVSuaBoSungName { get; set; }
        public string TTHCSuaBoSungKey { get; set; }
        public string TTHCSuaBoSungName { get; set; }
        public string LVBiThayTheKey { get; set; }
        public string LVBiThayTheName { get; set; }
        public string TTHCBiThayTheKey { get; set; }
        public string TTHCBiThayTheName { get; set; }
        public string LVThayTheKey { get; set; }
        public string LVThayTheName { get; set; }
        public string TTHCThayTheKey { get; set; }
        public string TTHCThayTheName { get; set; }
        public string CanCuPhapLy { get; set; }
        public string YeuCauDieuKien { get; set; }
        public DateTime? NgayCoHieuLuc { get; set; }
        public DateTime? NgayHetHieuLuc { get; set; }
        public bool? DVBCCongIch { get; set; }
        public bool? CongKhaiCongTT { get; set; }
        public int? DVCTrucTuyen { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public DateTime? LastUpdDate { get; set; }
        public bool? IsUpdate { get; set; }
        public bool? IsDinhKem { get; set; }
        public string NguoiKy { get; set; }
        public string OriginalName { get; set; }
        public string UploadName { get; set; }
        public string PathName { get; set; }
        public string TenThuTucNguon { get; set; }
    }
}
