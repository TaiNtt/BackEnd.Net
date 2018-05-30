using Core.Common.Domain;
using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class DanhMucs
    {
        public List<MTDanhMuc> lstnoiCapChungChi { get; set; }
        public List<MTDanhMuc> lstphamViHoatDongChuyenMon { get; set; }
        //public List<DM_LinhVuc> lstlinhvuc { get; set; }
        public List<MTDanhMuc> lstdudieukienhanhnghe { get; set; }
        public List<MTDanhMuc> lsttinhthanh { get; set; }
        public List<DanhMucParentID> lstquanhuyen { get; set; }
        public List<DanhMucParentID> lstphuongxa { get; set; }
        public List<MTDanhMuc> lsttrinhdochuyenmon { get; set; }
        public List<MTDanhMuc> lstphamViKinhDoanh { get; set; }
    }
}