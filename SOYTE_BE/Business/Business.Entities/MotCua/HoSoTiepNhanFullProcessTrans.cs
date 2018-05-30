using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class HoSoTiepNhanFullProcessTrans : EntityBase
    {
        public HoSoTiepNhan hosotiepnhan { get; set; }
        public long HoSoID { get; set; }
        public int? NguoiXuLyHienTaiID { get; set; }
        public int? NguoiXuLyTiepTheoID { get; set; }
        public int? TrangThaiHienTaiID { get; set; }
        public int? TrangThaiTiepTheoID { get; set; }
        public string TenTrangThaiTiepTheo { get; set; }
        public WorkList worklist { get; set; }
        public YeuCauBoSung yeucaubosung { get; set; }
        public KhongGiaiQuyet khonggiaiquyet { get; set; }
        public KhongPheDuyet khongpheduyet { get; set; }
        public TamNgungThamDinh tamngungthamdinh { get; set; }
        public int? userIdOld { get; set; }
        public int? TrangThaiHoSoIdOld { get; set; }
        public int? userIdNew { get; set; }
        public int? TrangThaiHoSoIdNew { get; set; }
        //public int? TrangThaiCapNhat { get; set; }
    }
}