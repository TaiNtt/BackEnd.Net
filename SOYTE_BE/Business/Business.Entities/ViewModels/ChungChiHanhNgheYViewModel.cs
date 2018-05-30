using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class ChungChiHanhNgheYViewModel
    {
        public long? RowNo { get; set; }
        public long ChungChiHanhNgheYID { get; set; }
        public string SoChungChi { get; set; }
        public DateTime? NgayCap { get; set; }
        public string HoTen { get; set; }
        public string SoGiayTo { get; set; }
        public string ChoO_DiaChi { get; set; }
        public string PhamViHoatDongChuyenMons { get; set; }
        public int? TrangThaiGiayPhepID { get; set; }
        public string TrangThaiGiayPhep { get; set; }
        public int? TotalItems { get; set; }
    }
}
