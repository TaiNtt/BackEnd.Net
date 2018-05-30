using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class QuaTrinhXuLy : EntityBase
    {
        public long QuaTrinhXuLyID { get; set; }
        public long HoSoID { get; set; }
        public DateTime? NgayNhan { get; set; }
        public int? NguoiXuLyHienTaiID { get; set; }
        public DateTime? NgayChuyen { get; set; }
        public int? NguoiXuLyTiepTheoID { get; set; }
        public int? TrangThaiHienTaiID { get; set; }
        public int? TrangThaiTiepTheoID { get; set; }
        public bool? IsQuaTrinhHienTai { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdUserID { get; set; }
        public DateTime? LastUpdDate { get; set; }
    }
}