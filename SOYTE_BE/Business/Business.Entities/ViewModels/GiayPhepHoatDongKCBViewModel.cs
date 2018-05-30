using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class GiayPhepHoatDongKCBViewModel
    {
        public long? RowNo { get; set; }
        public long GiayPhepKhamChuaBenhID { get; set; }
        public string SoGiayPhep { get; set; }
        public DateTime? NgayCap { get; set; }
        public string CoSoDK_Ten { get; set; }
        public string NCTN_HoTen { get; set; }
        public string CoSoDK_DiaChi { get; set; }
        public string PhamViHoatDongChuyenMons { get; set; }
        public int? TotalItems { get; set; }
    }
}
