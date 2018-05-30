using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_PhamViKinhDoanh: EntityBase
    {
        public int PhamViKinhDoanhID { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public bool? Used { get; set; }
    }
}