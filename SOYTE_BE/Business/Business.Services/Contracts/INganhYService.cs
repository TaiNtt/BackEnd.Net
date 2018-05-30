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
    public interface INganhYService
    {
        #region CheckExist
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/CheckExistSoChungChi?id={id}&val={val}")]
        bool CheckExistSoChungChi(string id, string val);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/CheckExistSoTiepNhanDangKyQuangCaoNganhY?id={id}&val={val}")]
        bool CheckExistSoTiepNhanDangKyQuangCaoNganhY(string id, string val);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/CheckExistSoGiayChungNhanATSH?id={id}&val={val}")]
        bool CheckExistSoGiayChungNhanATSH(string id, string val);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/CheckExistSoChungNhanLuongY?id={id}&val={val}")]
        bool CheckExistSoChungNhanLuongY(string id, string val);
        #endregion

        #region Load DS ChungChiY
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_ChungChiHanhNgheY_GetByHoSoID?HoSoID={HoSoID}")]
        ChungChiHanhNgheYSave NganhY_ChungChiHanhNgheY_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_ChungChiHanhNgheY_GetByID?ChungChiHanhNgheYId={ChungChiHanhNgheYId}")]
        ChungChiHanhNgheYSave NganhY_ChungChiHanhNgheY_GetByID(long ChungChiHanhNgheYId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_ChungChiHanhNgheY_GetBySoChungChi?SoChungChi={SoChungChi}")]
        ChungChiHanhNgheYSave NganhY_ChungChiHanhNgheY_GetBySoChungChi(string soChungChi);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_ChungChiHanhNgheY_Search?SoChungChi={SoChungChi}" +
                            "&tuNgay={tuNgay}" +
                            "&denNgay={denNgay}" +
                            "&HoTen={HoTen}" +
                            "&SoGiayTo={SoGiayTo}" +
                            "&lstTrangThai={lstTrangThai}" +
                            "&pageIndex={pageIndex}" +
                            "&pageSize={pageSize}")]
        PagedData<ChungChiHanhNgheYViewModel> NganhY_ChungChiHanhNgheY_Search(string SoChungChi, string tuNgay, string denNgay
            , string HoTen, string SoGiayTo, string lstTrangThai, int pageIndex, int pageSize);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_ChungChiHanhNgheY_Lst?SoChungChi={SoChungChi}" +
                          "&tuNgay={tuNgay}" +
                          "&denNgay={denNgay}" +
                          "&HoTen={HoTen}" +
                          "&SoGiayTo={SoGiayTo}" +
                          "&TrangThai={TrangThai}" +
                          "&pageIndex={pageIndex}" +
                          "&pageSize={pageSize}")]
        PagedData<ChungChiHanhNgheYViewModel> NganhY_ChungChiHanhNgheY_Lst(string SoChungChi, string tuNgay,
            string denNgay
            , string HoTen, string SoGiayTo, string TrangThai, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_ChungChiHanhNgheY_CapLai_GetByHoSoID?HoSoID={HoSoID}")]
        ChungChiHanhNgheYCapLaiSave NganhY_ChungChiHanhNgheY_CapLai_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_ChungChiHanhNgheY_DieuChinh_GetByHoSoID?HoSoID={HoSoID}")]
        ChungChiHanhNgheYDieuChinhSave NganhY_ChungChiHanhNgheY_DieuChinh_GetByHoSoID(long HoSoID);
        #endregion

        #region Cấp mới ChungChiY
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_ChungChiHanhNgheY_Save")]
        long NganhY_ChungChiHanhNgheY_Save(ChungChiHanhNgheYSave chungChiHanhNgheYSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_ChungChiHanhNgheY_UpdDaCap")]
        bool NganhY_ChungChiHanhNgheY_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "NY/NganhY_ChungChiHanhNgheY_DelByHoSoID")]
        bool NganhY_ChungChiHanhNgheY_DelByHoSoID(long HoSoID, long ChungChiHanhNgheYID);
        #endregion

        #region Cấp lại ChungChiY
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_ChungChiHanhNgheY_CapLai_Save")]
        long NganhY_ChungChiHanhNgheY_CapLai_Save(ChungChiHanhNgheYCapLaiSave chungChiHanhNgheYCapLaiSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_ChungChiHanhNgheY_CapLai_UpdDaCap")]
        bool NganhY_ChungChiHanhNgheY_CapLai_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "NY/NganhY_ChungChiHanhNgheY_CapLai_DelByHoSoID")]
        bool NganhY_ChungChiHanhNgheY_CapLai_DelByHoSoID(long HoSoID, long CapLaiID);
        #endregion

        #region Dieu Chinh ChungChiY
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_ChungChiHanhNgheY_DieuChinh_Save")]
        long NganhY_ChungChiHanhNgheY_DieuChinh_Save(ChungChiHanhNgheYDieuChinhSave chungChiHanhNgheYDieuChinhSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_ChungChiHanhNgheY_DieuChinh_UpdDaDieuChinh")]
        bool NganhY_ChungChiHanhNgheY_DieuChinh_UpdDaDieuChinh(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "NY/NganhY_ChungChiHanhNgheY_DieuChinh_DelByHoSoID")]
        bool NganhY_ChungChiHanhNgheY_DieuChinh_DelByHoSoID(long HoSoID, long DieuChinhID);
        #endregion

        #region Thu hồi
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_ChungChiHanhNgheY_ThuHoi_Save")]
        long NganhY_ChungChiHanhNgheY_ThuHoi_Save(ChungChiHanhNgheY_ThuHoi chungChiHanhNgheYThuHoiSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_ChungChiHanhNgheY_ThuHoi_UpdXoaThuHoi")]
        bool NganhY_ChungChiHanhNgheY_ThuHoi_UpdXoaThuHoi(long ChungChiHanhNgheYID);
        #endregion

        #region Rút chứng chỉ
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_ChungChiHanhNgheY_RutChungChi_Save")]
        long NganhY_ChungChiHanhNgheY_RutChungChi_Save(ChungChiHanhNgheY_RutChungChi chungChiHanhNgheYRutChungChiSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_ChungChiHanhNgheY_RutChungChi_UpdXoaRut")]
        bool NganhY_ChungChiHanhNgheY_RutChungChi_UpdXoaRut(long ChungChiHanhNgheYID);
        #endregion

        #region Đăng ký quảng cáo trang thiết bị
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_DangKyQCTrangThietBi_GetByHoSoID?HoSoID={HoSoID}")]
        DangKyQCTrangThietBi NganhY_DangKyQCTrangThietBi_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_DangKyQCTrangThietBi_GetByID?DangKyQCTrangThietBiID={DangKyQCTrangThietBiID}")]
        DangKyQCTrangThietBi NganhY_DangKyQCTrangThietBi_GetByID(long DangKyQCTrangThietBiID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_DangKyQCTrangThietBi_Search?SoTiepNhan={SoTiepNhan}" +
                            "&tuNgay={tuNgay}" +
                            "&denNgay={denNgay}" +
                            "&DichVuQuangCao={DichVuQuangCao}" +
                            "&DonViDK_Ten={DonViDK_Ten}" +
                            "&pageIndex={pageIndex}" +
                            "&pageSize={pageSize}")]
        PagedData<DangKyQCTrangThietBiViewModel> NganhY_DangKyQCTrangThietBi_Search(string SoTiepNhan, string tuNgay, string denNgay
            , string DichVuQuangCao, string DonViDK_Ten, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_DangKyQCTrangThietBi_Save")]
        long NganhY_DangKyQCTrangThietBi_Save(DangKyQCTrangThietBi dangKyQCTrangThietBiSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_DangKyQCTrangThietBi_UpdDaCap")]
        bool NganhY_DangKyQCTrangThietBi_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_DangKyQCTrangThietBi_DelByHoSoID")]
        bool NganhY_DangKyQCTrangThietBi_DelByHoSoID(long HoSoID);
        #endregion

        #region Cấp mới Giấy phép hoạt động CSKCB
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayPhepHoatDongKCB_GetByHoSoID?HoSoID={HoSoID}")]
        GiayPhepHoatDongKCBSave NganhY_GiayPhepHoatDongKCB_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayPhepHoatDongKCB_GetByID?GiayPhepKhamChuaBenhID={GiayPhepKhamChuaBenhID}")]
        GiayPhepHoatDongKCBSave NganhY_GiayPhepHoatDongKCB_GetByID(long GiayPhepKhamChuaBenhID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayPhepHoatDongKCB_GetBySoGiayPhep?SoGiayPhep={SoGiayPhep}")]
        GiayPhepHoatDongKCBSave NganhY_GiayPhepHoatDongKCB_GetBySoGiayPhep(string SoGiayPhep);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayPhepHoatDongKCB_Search?SoGiayPhep={SoGiayPhep}" +
                            "&tuNgay={tuNgay}" +
                            "&denNgay={denNgay}" +
                            "&CoSoDK_Ten={CoSoDK_Ten}" +
                            "&CoSoDK_HuyenID={CoSoDK_HuyenID}" +
                            "&CoSoDK_XaID={CoSoDK_XaID}" +
                            "&pageIndex={pageIndex}" +
                            "&pageSize={pageSize}")]
        PagedData<GiayPhepHoatDongKCBViewModel> NganhY_GiayPhepHoatDongKCB_Search(string SoGiayPhep, string tuNgay, string denNgay
            , string CoSoDK_Ten, string CoSoDK_HuyenID, string CoSoDK_XaID, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayPhepHoatDongKCB_Save")]
        long NganhY_GiayPhepHoatDongKCB_Save(GiayPhepHoatDongKCBSave giayPhepHoatDongKCBSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayPhepHoatDongKCB_UpdDaCap")]
        bool NganhY_GiayPhepHoatDongKCB_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "NY/NganhY_GiayPhepHoatDongKCB_DelByHoSoID")]
        bool NganhY_GiayPhepHoatDongKCB_DelByHoSoID(long HoSoID, long GiayPhepKhamChuaBenhID);
        #endregion

        #region Cấp lại Giấy phép hoạt động CSKCB
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayPhepHoatDongKCB_CapLai_GetByHoSoID?HoSoID={HoSoID}")]
        GiayPhepHoatDongKCBCapLaiSave NganhY_GiayPhepHoatDongKCB_CapLai_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayPhepHoatDongKCB_CapLai_Save")]
        long NganhY_GiayPhepHoatDongKCB_CapLai_Save(GiayPhepHoatDongKCBCapLaiSave giayPhepHoatDongKCBCapLaiSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayPhepHoatDongKCB_CapLai_UpdDaCap")]
        bool NganhY_GiayPhepHoatDongKCB_CapLai_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "NY/NganhY_GiayPhepHoatDongKCB_CapLai_DelByHoSoID")]
        bool NganhY_GiayPhepHoatDongKCB_CapLai_DelByHoSoID(long HoSoID, long CapLaiID);
        #endregion

        #region Giấy chứng nhận lương Y
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayChungNhanLuongY_GetByHoSoID?HoSoID={HoSoID}")]
        GiayChungNhanLuongYSave NganhY_GiayChungNhanLuongY_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayChungNhanLuongY_GetByID?GiayChungNhanLuongYID={GiayChungNhanLuongYID}")]
        GiayChungNhanLuongYSave NganhY_GiayChungNhanLuongY_GetByID(long GiayChungNhanLuongYID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayChungNhanLuongY_Search?SoGiayChungNhan={SoGiayChungNhan}" +
                    "&tuNgay={tuNgay}" +
                    "&denNgay={denNgay}" +
                    "&HoTen={HoTen}" +
                    "&SoGiayTo={SoGiayTo}" +
                    "&pageIndex={pageIndex}" +
                    "&pageSize={pageSize}")]
        PagedData<GiayChungNhanLuongYViewModel> NganhY_GiayChungNhanLuongY_Search(string SoGiayChungNhan, string tuNgay, string denNgay
           , string HoTen, string SoGiayTo, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayChungNhanLuongY_Save")]
        long NganhY_GiayChungNhanLuongY_Save(GiayChungNhanLuongYSave giayChungNhanLuongYSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayChungNhanLuongY_UpdDaCap")]
        bool NganhY_GiayChungNhanLuongY_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "NY/NganhY_GiayChungNhanLuongY_DelByHoSoID")]
        bool NganhY_GiayChungNhanLuongY_DelByHoSoID(long HoSoID, long GiayChungNhanLuongYID);
        #endregion

        #region Cấp mới Giấy chứng nhận ATSH
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayChungNhanATSH_GetByHoSoID?HoSoID={HoSoID}")]
        GiayChungNhanATSHSave NganhY_GiayChungNhanATSH_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayChungNhanATSH_GetByID?GiayChungNhanATSHID={GiayChungNhanATSHID}")]
        GiayChungNhanATSHSave NganhY_GiayChungNhanATSH_GetByID(long GiayChungNhanATSHID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayChungNhanATSH_GetBySoGiayChungNhan?SoGiayChungNhan={SoGiayChungNhan}")]
        GiayChungNhanATSHSave NganhY_GiayChungNhanATSH_GetBySoGiayChungNhan(string SoGiayChungNhan);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayChungNhanATSH_Search?SoGiayChungNhan={SoGiayChungNhan}" +
                            "&tuNgay={tuNgay}" +
                            "&denNgay={denNgay}" +
                            "&TenCoSo={TenCoSo}" +
                            "&TenPhongXetNghiem={TenPhongXetNghiem}" +
                            "&HuyenID={HuyenID}" +
                            "&pageIndex={pageIndex}" +
                            "&pageSize={pageSize}")]
        PagedData<GiayChungNhanATSHViewModel> NganhY_GiayChungNhanATSH_Search(string SoGiayChungNhan, string tuNgay, string denNgay
            , string TenCoSo, string TenPhongXetNghiem, string HuyenID, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayChungNhanATSH_Save")]
        long NganhY_GiayChungNhanATSH_Save(GiayChungNhanATSHSave giayChungNhanATSHSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayChungNhanATSH_UpdDaCap")]
        bool NganhY_GiayChungNhanATSH_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "NY/NganhY_GiayChungNhanATSH_DelByHoSoID")]
        bool NganhY_GiayChungNhanATSH_DelByHoSoID(long HoSoID, long GiayChungNhanATSHID);
        #endregion

        #region Cấp lại Giấy chứng nhận ATSH
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayChungNhanATSH_CapLai_GetByHoSoID?HoSoID={HoSoID}")]
        GiayChungNhanATSHCapLaiSave NganhY_GiayChungNhanATSH_CapLai_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayChungNhanATSH_CapLai_Save")]
        long NganhY_GiayChungNhanATSH_CapLai_Save(GiayChungNhanATSHCapLaiSave giayChungNhanATSHCapLaiSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayChungNhanATSH_CapLai_UpdDaCap")]
        bool NganhY_GiayChungNhanATSH_CapLai_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "NY/NganhY_GiayChungNhanATSH_CapLai_DelByHoSoID")]
        bool NganhY_GiayChungNhanATSH_CapLai_DelByHoSoID(long HoSoID, long CapLaiID);
        #endregion

        #region Cấp mới Giấy chứng nhận BTGT
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayChungNhanBTGT_GetByHoSoID?HoSoID={HoSoID}")]
        GiayChungNhanBTGTSave NganhY_GiayChungNhanBTGT_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayChungNhanBTGT_GetByID?GiayChungNhanBTGTID={GiayChungNhanBTGTID}")]
        GiayChungNhanBTGTSave NganhY_GiayChungNhanBTGT_GetByID(long GiayChungNhanBTGTID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayChungNhanBTGT_GetBySoGiayChungNhan?SoGiayChungNhan={SoGiayChungNhan}")]
        GiayChungNhanBTGTSave NganhY_GiayChungNhanBTGT_GetBySoGiayChungNhan(string SoGiayChungNhan);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayChungNhanBTGT_Search?SoGiayChungNhan={SoGiayChungNhan}" +
                            "&tuNgay={tuNgay}" +
                            "&denNgay={denNgay}" +
                            "&HoTen={HoTen}" +
                            "&TenBaiThuoc={TenBaiThuoc}" +
                            "&pageIndex={pageIndex}" +
                            "&pageSize={pageSize}")]
        PagedData<GiayChungNhanBTGTViewModel> NganhY_GiayChungNhanBTGT_Search(string SoGiayChungNhan, string tuNgay, string denNgay
            , string HoTen, string TenBaiThuoc, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayChungNhanBTGT_Save")]
        long NganhY_GiayChungNhanBTGT_Save(GiayChungNhanBTGTSave giayChungNhanBTGTSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayChungNhanBTGT_UpdDaCap")]
        bool NganhY_GiayChungNhanBTGT_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "NY/NganhY_GiayChungNhanBTGT_DelByHoSoID")]
        bool NganhY_GiayChungNhanBTGT_DelByHoSoID(long HoSoID, long GiayChungNhanBTGTID);
        #endregion

        #region Cấp lại Giấy chứng nhận BTGT
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayChungNhanBTGT_CapLai_GetByHoSoID?HoSoID={HoSoID}")]
        GiayChungNhanBTGTCapLaiSave NganhY_GiayChungNhanBTGT_CapLai_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayChungNhanBTGT_CapLai_Save")]
        long NganhY_GiayChungNhanBTGT_CapLai_Save(GiayChungNhanBTGTCapLaiSave giayChungNhanBTGTCapLaiSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayChungNhanBTGT_CapLai_UpdDaCap")]
        bool NganhY_GiayChungNhanBTGT_CapLai_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "NY/NganhY_GiayChungNhanBTGT_CapLai_DelByHoSoID")]
        bool NganhY_GiayChungNhanBTGT_CapLai_DelByHoSoID(long HoSoID, long CapLaiID);
        #endregion

        #region Giấy phép Đoàn KCB
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayPhepDoanKCB_GetByHoSoID?HoSoID={HoSoID}")]
        GiayPhepDoanKCBSave NganhY_GiayPhepDoanKCB_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayPhepDoanKCB_GetByID?GiayPhepDoanKCBID={GiayPhepDoanKCBID}")]
        GiayPhepDoanKCBSave NganhY_GiayPhepDoanKCB_GetByID(long GiayPhepDoanKCBID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayPhepDoanKCB_Search?SoGiayPhep={SoGiayPhep}" +
                            "&tuNgay={tuNgay}" +
                            "&denNgay={denNgay}" +
                            "&TenDoanKCB={TenDoanKCB}" +
                            "&tuNgayKCB={tuNgayKCB}" +
                            "&denNgayKCB={denNgayKCB}" +
                            "&NoiKCB_HuyenID={NoiKCB_HuyenID}" +
                            "&NoiKCB_XaID={NoiKCB_XaID}" +
                            "&pageIndex={pageIndex}" +
                            "&pageSize={pageSize}")]
        PagedData<GiayPhepDoanKCBViewModel> NganhY_GiayPhepDoanKCB_Search(string SoGiayPhep, string tuNgay, string denNgay
            , string TenDoanKCB, string tuNgayKCB, string denNgayKCB, string NoiKCB_HuyenID, string NoiKCB_XaID, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayPhepDoanKCB_Save")]
        long NganhY_GiayPhepDoanKCB_Save(GiayPhepDoanKCBSave giayPhepDoanKCBSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayPhepDoanKCB_UpdDaCap")]
        bool NganhY_GiayPhepDoanKCB_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "NY/NganhY_GiayPhepDoanKCB_DelByHoSoID")]
        bool NganhY_GiayPhepDoanKCB_DelByHoSoID(long HoSoID, long GiayPhepDoanKCBID);
        #endregion

        #region Cấp mới Giấy phép hoạt động Chu Thap Do
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayPhepHoatDongChuThapDo_GetByHoSoID?HoSoID={HoSoID}")]
        GiayPhepHoatDongChuThapDo NganhY_GiayPhepHoatDongChuThapDo_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayPhepHoatDongChuThapDo_GetByID?GiayPhepHoatDongChuThapDoID={GiayPhepHoatDongChuThapDoID}")]
        GiayPhepHoatDongChuThapDo NganhY_GiayPhepHoatDongChuThapDo_GetByID(long GiayPhepHoatDongChuThapDoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayPhepHoatDongChuThapDo_GetBySoGiayPhep?SoGiayPhep={SoGiayPhep}")]
        GiayPhepHoatDongChuThapDo NganhY_GiayPhepHoatDongChuThapDo_GetBySoGiayPhep(string SoGiayPhep);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NY/NganhY_GiayPhepHoatDongChuThapDo_Search?SoGiayPhep={SoGiayPhep}" +
                            "&tuNgay={tuNgay}" +
                            "&denNgay={denNgay}" +
                            "&TenDiem={TenDiem}" +
                            "&pageIndex={pageIndex}" +
                            "&pageSize={pageSize}")]
        PagedData<GiayPhepHoatDongChuThapDoViewModel> NganhY_GiayPhepHoatDongChuThapDo_Search(string SoGiayPhep, string tuNgay, string denNgay
            , string TenDiem, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayPhepHoatDongChuThapDo_Save")]
        long NganhY_GiayPhepHoatDongChuThapDo_Save(GiayPhepHoatDongChuThapDo giayPhepHoatDongChuThapDoSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayPhepHoatDongChuThapDo_UpdDaCap")]
        bool NganhY_GiayPhepHoatDongChuThapDo_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayPhepHoatDongChuThapDo_DelByHoSoID")]
        bool NganhY_GiayPhepHoatDongChuThapDo_DelByHoSoID(long HoSoID);
        #endregion

        #region Cấp lại Giấy phép hoạt động Chu Thap Do
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayPhepHoatDongChuThapDo_CapLai_GetByHoSoID?HoSoID={HoSoID}")]
        GiayPhepHoatDongChuThapDoCapLaiSave NganhY_GiayPhepHoatDongChuThapDo_CapLai_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayPhepHoatDongChuThapDo_CapLai_Save")]
        long NganhY_GiayPhepHoatDongChuThapDo_CapLai_Save(GiayPhepHoatDongChuThapDoCapLaiSave giayPhepHoatDongChuThapDoCapLaiSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "NY/NganhY_GiayPhepHoatDongChuThapDo_CapLai_UpdDaCap")]
        bool NganhY_GiayPhepHoatDongChuThapDo_CapLai_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "NY/NganhY_GiayPhepHoatDongChuThapDo_CapLai_DelByHoSoID")]
        bool NganhY_GiayPhepHoatDongChuThapDo_CapLai_DelByHoSoID(long HoSoID, long CapLaiID);
        #endregion
    }
}