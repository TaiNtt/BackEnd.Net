using Core.Common.Domain;

namespace Business.Entities
{
    public class TTHC_BieuDoThongKe: EntityBase
    {
        public string Label { get; set; }

        public int Value { get; set; }

        public string ChartKey { get; set; }

        public string CreateDate { get; set; }

        public string ModifiedDate { get; set; }
    }
}
