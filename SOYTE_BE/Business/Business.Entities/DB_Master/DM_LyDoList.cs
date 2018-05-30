using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_LyDoList
    {
        public long? RowNo { get; set; }
        public int LyDoID { get; set; }
        public int? LoaiCapPhepID { get; set; }
        public string LoaiCapPhep { get; set; }
        public int? LoaiLyDoID { get; set; }
        public string LoaiLyDo { get; set; }
        public string Ten { get; set; }
        public bool? Used { get; set; }
        public int? TotalItems { get; set; }
    }
}