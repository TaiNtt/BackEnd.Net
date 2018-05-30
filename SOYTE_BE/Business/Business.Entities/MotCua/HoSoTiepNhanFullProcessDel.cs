using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class HoSoTiepNhanFullProcessDel : EntityBase
    {
        public long HoSoID { get; set; }
        public int? UserId { get; set; }
        public int? TrangThaiHoSoId { get; set; }
    }
}