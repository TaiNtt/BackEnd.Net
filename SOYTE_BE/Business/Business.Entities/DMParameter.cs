using Core.Common.Domain;

namespace Business.Entities
{
    public class DMParameter : EntityBase
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

    }
}