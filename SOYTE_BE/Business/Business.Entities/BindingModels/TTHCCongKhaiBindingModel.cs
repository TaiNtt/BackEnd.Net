using Core.Common.Domain;

namespace Business.Entities.BindingModels
{
    public class TTHCCongKhaiBindingModel:EntityBase
    {
        public bool? CongKhai { get; set; }
        public bool? IsUpdate { get; set; }
    }
}
