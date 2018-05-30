using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_LinhVucList
    {
        public long? RowNo { get; set; }
        public int LinhVucID { get; set; }
        public string TenLinhVuc { get; set; }
        public string MoTa { get; set; }
        public bool? Used { get; set; }
        public int? TotalItems { get; set; }
        public string MaLinhVuc { get; set; }
    }
}