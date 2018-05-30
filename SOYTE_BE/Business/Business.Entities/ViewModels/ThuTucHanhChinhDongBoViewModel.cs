using System;
using System.Runtime;

namespace Business.Entities.ViewModels
{
    public class ThuTucHanhChinhDongBoViewModel
    {
        public string Id { get; set; }
        public string TenThuTuc { get; set; }
        public string CapDonViID { get; set; }
        public string DonViID { get; set; }
        public string TenDonVi { get; set; }
        public string LinhVucID { get; set; }
        public string LinhVuc { get; set; }
        public string SoQuyetDinh { get; set; }
        public bool CongKhai { get; set; }
        public DateTime? NgayQuyetDinh { get; set; }
        public DateTime? NgayCoHieuLuc { get; set; }
        public DateTime? NgayHetHieuLuc { get; set; }
        public int TotalItemsByLinhVuc { get; set; }
        public int TotalItemsByDonVi { get; set; }
        public int TotalItems { get; set; }
    }
}
