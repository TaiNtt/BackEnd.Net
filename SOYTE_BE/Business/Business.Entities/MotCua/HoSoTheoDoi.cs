using Core.Common.Domain;
using System;

namespace Business.Entities
{
    public class HoSoTheoDoi : EntityBase
    {
        public long HoSoTheoDoiID { get; set; }
        public long? HoSoID { get; set; }
        public long? UserID { get; set; }
        public long? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}