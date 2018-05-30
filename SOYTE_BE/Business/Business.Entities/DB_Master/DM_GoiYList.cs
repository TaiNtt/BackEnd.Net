using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_GoiYList
    {
        public long? RowNo { get; set; }
        public int GoiYID { get; set; }
        public int? LoaiCapPhepID { get; set; }
        public string LoaiCapPhep { get; set; }
        public int? LoaiGoiYID { get; set; }
        public string LoaiGoiY { get; set; }
        public string Ten { get; set; }
        public bool? Used { get; set; }
        public int? TotalItems { get; set; }
    }
}