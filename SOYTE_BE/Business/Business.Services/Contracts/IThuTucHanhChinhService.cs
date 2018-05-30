using System.Collections.Generic;
using Business.Entities;
using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Entities.BindingModels;
using Business.Entities.ViewModels;
using Core.Common.Utilities;

namespace Business.Services.Contracts
{
    [ServiceContract]
    public interface IThuTucHanhChinhService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "TTHC/AddTTHCByPaging")]
        bool AddTTHCByPaging(List<ThuTucHanhChinhBo> items);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "TTHC/AddLinhVucByPaging")]
        bool AddLinhVucByPaging(List<DMLinhVuc> items);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "TTHC/GetThuTucHanhChinhById?id={id}")]
        ThuTucHanhChinhEditViewModel GetThuTucHanhChinhById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "TTHC/GetBieuDoThongKe?ChartKey={ChartKey}")]
        IEnumerable<TTHC_BieuDoThongKe> GetBieuDoThongKe(string chartKey);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "TTHC/GetThuTucHanhChinhByDongBoPaged?tenThuTuc={tenThuTuc}" +
                          "&conHieuLuc={conHieuLuc}" +
                          "&hetHieuLuc={hetHieuLuc}" +
                          "&congKhai={congKhai}" +
                          "&khongCongKhai={khongCongKhai}" +
                          "&tthcDacThu={tthcDacThu}" +
                          "&coQuanThucHien={coQuanThucHien}" +
                          "&linhVucId={linhVucId}" +
                          "&pageIndex={pageIndex}" +
                          "&pageSize={pageSize}")]
        PagedData<ThuTucHanhChinhDongBoViewModel> GetThuTucHanhChinhByDongBoPaged(string tenThuTuc, string conHieuLuc,
            string hetHieuLuc, string congKhai, string khongCongKhai, string tthcDacThu, string coQuanThucHien,
            string linhVucId, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "TTHC/GetHoSoKemTheoByPaged?tenHoSoKemTheo={tenHoSoKemTheo}" +
                          "&linhVucId={linhVucId}" +
                          "&pageSize={pageSize}" +
                          "&pageIndex={pageIndex}")]
        PagedData<HoSoKemTheoViewModel> GetHoSoKemTheoByPaged(string tenHoSoKemTheo, string linhVucId, int pageSize,
            int pageIndex);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "TTHC/GetThuTucHanhChinhByLinhVucId?id={id}")]
        EnumerableData<DanhMuc> GetThuTucHanhChinhByLinhVucId(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "TTHC/GetThuTucHanhChinhByDonViId?id={id}")]
        EnumerableData<DanhMuc> GetThuTucHanhChinhByDonViId(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "TTHC/GetDonViByCapDonViId?id={id}")]
        EnumerableData<DanhMuc> GetDonViByCapDonViId(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "TTHC/InsThuTucHanhChinh")]
        string InsThuTucHanhChinh(TTHCEditBindingModel model);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "TTHC/GetLinhVucByDonViId?id={id}")]
        EnumerableData<DanhMuc> GetLinhVucByDonViId(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "TTHC/GetThuTucHanhChinhByUserDonViPaged?tenThuTuc={tenThuTuc}" +
                          "&congKhai={congKhai}" +
                          "&khongCongKhai={khongCongKhai}" +
                          "&buuChinhCongIch={buuChinhCongIch}" +
                          "&dichVuCongCap={dichVuCongCap}" +
                          "&linhVucId={linhVucId}" +
                          "&userId={userId}" +
                          "&pageIndex={pageIndex}" +
                          "&pageSize={pageSize}")]
        PagedData<ThuTucHanhChinhDongBoViewModel> GetThuTucHanhChinhByUserDonViPaged(string tenThuTuc, string congKhai,
            string khongCongKhai, string buuChinhCongIch, string dichVuCongCap, string linhVucId, string userId,
            int pageIndex,
            int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "TTHC/UpdThuTucHanhChinhCongKhai")]
        int UpdThuTucHanhChinhCongKhai(List<TTHC_DonVi> model);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "TTHC/GetThuTucHanhChinhMoiByDongBoPaged?tenThuTuc={tenThuTuc}" +
                          "&capDonVi={capDonVi}" +
                          "&coQuanThucHien={coQuanThucHien}" +
                          "&linhVucId={linhVucId}" +
                          "&pageIndex={pageIndex}" +
                          "&pageSize={pageSize}")]
        PagedData<ThuTucHanhChinhDongBoViewModel> GetThuTucHanhChinhMoiByDongBoPaged(string tenThuTuc, string capDonVi,
            string coQuanThucHien, string linhVucId, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "TTHC/UpdTTHCSoQuyetDinh")]
        int UpdTTHCSoQuyetDinh(List<TTHCUpdSoQuyetDinhBindingModel> model);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "TTHC/UpdThuTucHanhChinhBuuChinhCongIch")]
        int UpdThuTucHanhChinhBuuChinhCongIch(List<TTHC_DonVi> model);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "TTHC/CongKhaiThuTucHanhByLstId")]
        int CongKhaiThuTucHanhByLstId(string thuTucHCIds, int userId);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "TTHC/GetThuTucHanhChinhCongKhaiById?id={id}")]
        ThuTucHanhChinhCongKhaiViewModel GetThuTucHanhChinhCongKhaiById(string id);

    }
}
