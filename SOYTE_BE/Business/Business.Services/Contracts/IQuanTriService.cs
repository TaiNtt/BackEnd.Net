using Business.Entities;
using Core.Common.Utilities;
using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Entities.ViewModels;

namespace Business.Services.Contracts
{
    [ServiceContract]
    public interface IQuanTriService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "QT/GetParameterByKey?key={key}")]
        DMParameter GetParameterByKey(string key);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "QT/AddOrUpdateDMParameter")]
        int InsParameter(DMParameter item);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, 
            UriTemplate = "QT/GetDanhMucLinhVucPaging?keySearch={keySearch}&pageSize={pageSize}&pageIndex={pageIndex}")]
        PagedData<DMLinhVuc> GetDanhMucLinhVucPaging(string keySearch, int pageSize, int pageIndex);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "QT/GetDMCapDonViConditionByPaged?ten={ten}&isActive={isActive}&pageSize={pageSize}&pageIndex={pageIndex}")]
        PagedData<DanhMuc> GetDMCapDonViConditionByPaged(string ten, string isActive, int pageSize, int pageIndex);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "QT/GetDMLinhVucByPaging?keySearch={keySearch}&pageSize={pageSize}&pageIndex={pageIndex}")]
        PagedData<DanhMuc> GetDMLinhVucByPaging(string keySearch, int pageSize, int pageIndex);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "QT/GetTTHCDonViByPaged?keySearch={keySearch}&capDonViId={capDonViId}&pageSize={pageSize}&pageIndex={pageIndex}")]
        PagedData<DanhMuc> GetTTHCDonViByPaged(string keySearch, string capDonViId, int pageSize, int pageIndex);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "QT/GetDMDonViConditionByPaged?ten={ten}&capDonViId={capDonViId}&isActive={isActive}&pageSize={pageSize}&pageIndex={pageIndex}")]
        PagedData<DanhMuc> GetDMDonViConditionByPaged(string ten, string capDonViId, string isActive, int pageSize,
            int pageIndex);

	    [OperationContract]
	    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
		    UriTemplate = "QT/GetDMHoSoKemTheoditionByPaged?hoSoMoi={hoSoMoi}&linhVucId={linhVucId}&hoSoKemTheo={hoSoKemTheo}&pageSize={pageSize}&pageIndex={pageIndex}")]
	    PagedData<HoSoKemTheoViewModel> GetDMHoSoKemTheoditionByPaged(bool hoSoMoi, string linhVucId, string hoSoKemTheo,
		    int pageSize, int pageIndex);

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "QT/AddDMHoSoKemTheo")]
		string AddDMHoSoKemTheo(DM_HoSoKemTheo item);

    }
}