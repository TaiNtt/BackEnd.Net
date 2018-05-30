using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_LyDo : EntityBase
    {
        public int LyDoID { get; set; }
        public int? LoaiCapPhepID { get; set; }
        public int? LoaiLyDoID { get; set; }
        public string Ten { get; set; }
        public bool? Used { get; set; }
    }
}