using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class CP_Thuoc_VienTroViewModel
    {
        public long? RowNo { get; set; }
        public long ThuocVienTroId { get; set; }
        public string SoTiepNhan { get; set; }
        public DateTime? NgayTiepNhan { get; set; }
        public string TenDonVi { get; set; }
        public string DiaChiDV { get; set; }
        public int? TotalItems { get; set; }
    }
}
