using Core.Common.Domain;

namespace Business.Entities
{
    public class DanhMucParentID
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public int? ParentID { get; set; }
    }
}