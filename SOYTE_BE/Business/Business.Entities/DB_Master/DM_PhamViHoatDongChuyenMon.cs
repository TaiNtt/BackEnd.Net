using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_PhamViHoatDongChuyenMon : EntityBase
    {
        public int PhamViHoatDongID { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public bool? Used { get; set; }
    }
}