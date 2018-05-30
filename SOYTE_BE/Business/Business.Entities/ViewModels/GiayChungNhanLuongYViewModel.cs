using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class GiayChungNhanLuongYViewModel
    {
        public long? RowNo { get; set; }
        public long GiayChungNhanLuongYID { get; set; }
        public string SoGiayChungNhan { get; set; }
        public DateTime? NgayCap { get; set; }
        public string HoTen { get; set; }
        public string SoGiayTo { get; set; }
        public string ChoO_DiaChi { get; set; }
        public string PhamViHoatDongChuyenMons { get; set; }
        public int? TotalItems { get; set; }
    }
}
