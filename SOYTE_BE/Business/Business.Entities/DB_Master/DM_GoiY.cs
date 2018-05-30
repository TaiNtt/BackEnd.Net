using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_GoiY : EntityBase
    {
        public int GoiYID { get; set; }
        public int? LoaiCapPhepID { get; set; }
        public int LoaiGoiYID { get; set; }
        public string Ten { get; set; }
        public bool? Used { get; set; }
    }
    public class DM_GoiYSave : EntityBase
    {
        public int GoiYID { get; set; }
        public int? LoaiCapPhepID { get; set; }
        public int? ThuTucID { get; set; }
        public int LoaiGoiYID { get; set; }
        public string Ten { get; set; }
        public bool? Used { get; set; }
    }
}