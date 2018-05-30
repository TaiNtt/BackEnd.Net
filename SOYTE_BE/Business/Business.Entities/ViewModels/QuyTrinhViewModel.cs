using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class QuyTrinhViewModel
    {
        public int BuocID { get; set; }
        public int? TrangThaiHienTaiID { get; set; }
        public int? TrangThaiTiepTheoID { get; set; }
        public int? NguoiNhanID { get; set; }
        public string Displayname { get; set; }
        public string TenTrangThaiHoSo { get; set; }
    }
}
