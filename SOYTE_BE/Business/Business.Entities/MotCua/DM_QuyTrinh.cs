using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_QuyTrinh : EntityBase
    {
        public int QuyTrinhID { get; set; }
        public string MaQuyTrinh { get; set; }
        public int? ThuTucID { get; set; }
        public bool? Used { get; set; }
    }
}