using Core.Common.Domain;

namespace Business.Entities
{
    public class DM_NoiCapChungChi : EntityBase
    {
        public int NoiCapChungChiID { get; set; }
        public string Ten { get; set; }
        public bool? Used { get; set; }
    }
}