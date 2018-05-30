using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class HoSoTiepNhanFullProcessSave : EntityBase
    {
        public HoSoTiepNhan hosotiepnhan { get; set; }
        public QuaTrinhXuLy quatrinhxuly { get; set; }
        public WorkList worklist { get; set; }
        public int? UserId { get; set; }
        public int? TrangThaiHoSoId { get; set; }
        public int? TrangThaiCapNhat { get; set; }
    }
}