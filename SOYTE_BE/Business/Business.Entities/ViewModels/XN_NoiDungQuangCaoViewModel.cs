using Business.Entities;
using System;

namespace Business.Entities.ViewModels
{
	public class XN_NoiDungQuangCaoViewModel
    {
        public long? RowNo { get; set; }
        public long NoiDungQCId { get; set; }
        public string SoXacNhan { get; set; }
        public DateTime? NgayCapXacNhan { get; set; }
        public string TOCHUC_CANHAN { get; set; }
        public string DiaChi { get; set; }
        public int? TotalItems { get; set; }
    }
}
