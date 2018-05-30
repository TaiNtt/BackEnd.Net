using Business.Entities;
using Core.Common.Utilities;
using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Entities.ViewModels;
using System;
using System.Collections.Generic;

namespace Business.Services.Contracts
{
    [ServiceContract]
    public interface IDBMasterService
    {
        #region Danh mục
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_DM_GetAll")]
        DanhMucs DBMaster_DM_GetAll();
        #endregion

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "MT/DBMaster_DM_TinhThanh_GetAll")]
        IEnumerable<MTDanhMuc> DBMaster_DM_TinhThanh_GetAll();
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_DM_QuanHuyen_GetByTinhID?TinhThanhID={TinhThanhID}")]
        IEnumerable<DanhMucParentID> DBMaster_DM_QuanHuyen_GetByTinhID(int TinhThanhID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_DM_PhuongXa_GetByQuanID?QuanID={QuanID}")]
        IEnumerable<DanhMucParentID> DBMaster_DM_PhuongXa_GetByQuanID(int QuanID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_DM_TrinhDoChuyenMon_GetAll")]
        IEnumerable<MTDanhMuc> DBMaster_DM_TrinhDoChuyenMon_GetAll();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_DM_HinhThucToChuc_GetAll")]
        IEnumerable<MTDanhMuc> DBMaster_DM_HinhThucToChuc_GetAll();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_ListCanBo_PhongBan")]
        IEnumerable<CanBoPhongBanList> DBMaster_ListCanBo_PhongBan();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_E_LoaiCapPhep_GetAll")]
        List<E_LoaiCapPhep> DBMaster_E_LoaiCapPhep_GetAll();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_DM_GoiY_GetByLoaiGoiYID?loaiGoiYID={loaiGoiYID}"
                    + "&thuTucId={thuTucId}&search={search}")]
        IEnumerable<DM_GoiY> DBMaster_DM_GoiY_GetByLoaiGoiYID(int loaiGoiYID, int thuTucId, string search);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_DM_GoiY_PopupUpd")]
        int DBMaster_DM_GoiY_PopupUpd(DM_GoiYSave dM_GoiYSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_DM_GoiY_PopupDel")]
        bool DBMaster_DM_GoiY_PopupDel(int GoiYID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_E_LoaiLyDo_GetAll")]
        List<E_LoaiLyDo> DBMaster_E_LoaiLyDo_GetAll();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_E_LoaiGoiY_GetAll")]
        List<E_LoaiGoiY> DBMaster_E_LoaiGoiY_GetAll();

        //DM_LyDo
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_DM_LyDo_List?LoaiCapPhepID={LoaiCapPhepID}" +
                            "&LoaiLyDoID={LoaiLyDoID}" +
                            "&tuKhoa={tuKhoa}" +
                            "&pageIndex={pageIndex}" +
                            "&pageSize={pageSize}")]
        PagedData<DM_LyDoList> DBMaster_DM_LyDo_List(string LoaiCapPhepID, string LoaiLyDoID, string tuKhoa, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_DM_LyDo_GetByLyDoID?LyDoID={LyDoID}")]
        DM_LyDo DBMaster_DM_LyDo_GetByLyDoID(int LyDoID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MT/DBMaster_DM_LyDo_Save")]
        bool DBMaster_DM_LyDo_Save(DM_LyDo dm_lydo);

        //DM_GoiY
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_DM_GoiY_List?LoaiCapPhepID={LoaiCapPhepID}" +
                            "&LoaiGoiYID={LoaiGoiYID}" +
                            "&tuKhoa={tuKhoa}" +
                            "&pageIndex={pageIndex}" +
                            "&pageSize={pageSize}")]
        PagedData<DM_GoiYList> DBMaster_DM_GoiY_List(string LoaiCapPhepID, string LoaiGoiYID, string tuKhoa, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MT/DBMaster_DM_GoiY_GetByGoiYID?GoiYID={GoiYID}")]
        DM_GoiY DBMaster_DM_GoiY_GetByGoiYID(int GoiYID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MT/DBMaster_DM_GoiY_Save")]
        bool DBMaster_DM_GoiY_Save(DM_GoiY dm_goiy);
    }
}