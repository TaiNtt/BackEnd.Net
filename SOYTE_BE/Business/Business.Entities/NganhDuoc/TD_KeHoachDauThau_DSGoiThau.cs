using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class TD_KeHoachDauThau_DSGoiThau : EntityBase
    {
        public long KHDTDSGoiThauId { get; set; }
        public long? KeHoachDauThauId { get; set; }
        public string TenGoiThau { get; set; }
        public string GiaGoiThau { get; set; }
        public string HinhThucLuaChon { get; set; }
        public string PhuongThucLuaChon { get; set; }
        public string ThoiGianBatDauLuaChon { get; set; }
        public string LoaiHopDong { get; set; }
        public string ThoiGianThucHienHD { get; set; }
        public string GhiChu { get; set; }
        public int? Active { get; set; }
        public long? DonViID { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
