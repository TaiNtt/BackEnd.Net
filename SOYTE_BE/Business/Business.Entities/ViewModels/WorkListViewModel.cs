using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
    public class WorkListViewModel
    {
        public long WorklistID { get; set; }
        public int? UserID { get; set; }
        public int? TrangThaiHoSoID { get; set; }
        public string TenTrangThaiHoSo { get; set; }
        public string TenMenu { get; set; }
        public string TenDanhSach { get; set; }
        public int? SoLuong { get; set; }
    }
}
