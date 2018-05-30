using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Entities.HoSo;

namespace Business.Services.Contracts
{
    [ServiceContract]
    public interface IHoSoService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "HS/ChungChiY_SaveFullProcess")]
        KetQuaTraVe ChungChiY_SaveFullProcess(HoSoSaveFull hoSoTiepNhanInsFullProcess);
    }
}