using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class QuaTrinhXuLyViewModel
    {
        public string TenTrangThaiHoSo { get; set; }
        public string DisplayName { get; set; }
        public DateTime? NgayNhan { get; set; }
        public DateTime? NgayChuyen { get; set; }
        public string NoiDungXuLy { get; set; }
    }
}
