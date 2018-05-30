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
    public interface INganhDuocService
    {
        #region Đăng ký hội thảo giới thiệu thuốc
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByHoSoID?HoSoID={HoSoID}")]
        DK_HoiThaoGioiThieuThuocSave NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhY_GiayChungNhanLuongY_GetByID?HoiThaoThuocID={HoiThaoThuocID}")]
        DK_HoiThaoGioiThieuThuocSave NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByID(long HoiThaoThuocID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_DK_HoiThaoGioiThieuThuoc_Search?SoTiepNhan={SoTiepNhan}" +
                    "&tuNgay={tuNgay}" +
                    "&denNgay={denNgay}" +
                    "&TenDonVi={TenDonVi}" +
                    "&HoTen={HoTen}" +
                    "&pageIndex={pageIndex}" +
                    "&pageSize={pageSize}")]
        PagedData<DK_HoiThaoGioiThieuThuocViewModel> NganhDuoc_DK_HoiThaoGioiThieuThuoc_Search(string SoTiepNhan, string tuNgay, string denNgay
            , string TenDonVi, string HoTen, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_DK_HoiThaoGioiThieuThuoc_Save")]
        long NganhDuoc_DK_HoiThaoGioiThieuThuoc_Save(DK_HoiThaoGioiThieuThuocSave dk_HoiThaoGioiThieuThuocSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_DK_HoiThaoGioiThieuThuoc_UpdDaCap")]
        bool NganhDuoc_DK_HoiThaoGioiThieuThuoc_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "ND/NganhDuoc_DK_HoiThaoGioiThieuThuoc_DelByHoSoID")]
        bool NganhDuoc_DK_HoiThaoGioiThieuThuoc_DelByHoSoID(long HoSoID, long HoiThaoThuocID);
        #endregion

        #region GDP
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "ND/NganhDuoc_CN_GDP_DSKho_GetByTHTGDPId?THTGDPId={THTGDPId}")]
        List<CN_GDP_DSKho> NganhDuoc_CN_GDP_DSKho_GetByTHTGDPId(long THTGDPId);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_CN_GDP_GetByHoSoID?HoSoID={HoSoID}")]
        CN_GDPSave NganhDuoc_CN_GDP_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_CN_GDP_GetByID?THTGDPId={THTGDPId}")]
        CN_GDPSave NganhDuoc_CN_GDP_GetByID(long THTGDPId);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_CN_GDP_Save")]
        long NganhDuoc_CN_GDP_Save(CN_GDPSave cN_GDPSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_CN_GDP_UpdDaCap")]
        bool NganhDuoc_CN_GDP_UpdDaCap(List<long> HoSoIDs);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "ND/NganhDuoc_CN_GDP_Search?SoGiayChungNhan={SoGiayChungNhan}" +
                 "&tuNgay={tuNgay}" +
                 "&denNgay={denNgay}" +
                 "&TenCoSo={TenCoSo}" +
                 "&SoDKKD={SoDKKD}" +
                 "&pageIndex={pageIndex}" +
                 "&pageSize={pageSize}")]
        PagedData<CN_GDPViewModel> NganhDuoc_CN_GDP_Search(string SoGiayChungNhan, string tuNgay, string denNgay
            , string TenCoSo, string SoDKKD, int pageIndex, int pageSize);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json
           , UriTemplate = "ND/NganhDuoc_CN_GDP_DelByHoSoID")]
        bool NganhDuoc_CN_GDP_DelByHoSoID(long HoSoID);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json
        , UriTemplate = "ND/NganhDuoc_CN_GDP_DelByTHTGDPID")]
        bool NganhDuoc_CN_GDP_DelByTHTGDPID(long THTGDPID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "ND/NganhDuoc_CN_GDP_InDeXuat?Id={Id}")]
        DataTableViewModel NganhDuoc_CN_GDP_InDeXuat(long Id);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "ND/NganhDuoc_CN_GDP_InChungChi?Id={Id}")]
        DataTableViewModel NganhDuoc_CN_GDP_InChungChi(long Id);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
       UriTemplate = "ND/NganhDuoc_CN_GDP_XuatDanhSach?SoGiayChungNhan={SoGiayChungNhan}" +
               "&tuNgay={tuNgay}" +
               "&denNgay={denNgay}" +
               "&TenCoSo={TenCoSo}" +
               "&SoDKKD={SoDKKD}")]
        DataTableViewModel NganhDuoc_CN_GDP_XuatDanhSach(string SoGiayChungNhan, string tuNgay, string denNgay
       , string TenCoSo, string SoDKKD);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "ND/NganhDuoc_CN_GDP_CongBoWebsite?SoGiayChungNhan={SoGiayChungNhan}" +
                   "&tuNgay={tuNgay}" +
                   "&denNgay={denNgay}" +
                   "&TenCoSo={TenCoSo}" +
                   "&SoDKKD={SoDKKD}")]
        DataTableViewModel NganhDuoc_CN_GDP_CongBoWebsite(string SoGiayChungNhan, string tuNgay, string denNgay
           , string TenCoSo, string SoDKKD);
        #endregion

        #region GPP
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_CN_GPP_GetByHoSoID?HoSoID={HoSoID}")]
        CN_GPP NganhDuoc_CN_GPP_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_CN_GPP_GetByID?THTGPPId={THTGPPId}")]
        CN_GPP NganhDuoc_CN_GPP_GetByID(long THTGPPId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_CN_GPP_Search?SoGiayChungNhan={SoGiayChungNhan}" +
                    "&tuNgay={tuNgay}" +
                    "&denNgay={denNgay}" +
                    "&TenCoSo={TenCoSo}" +
                    "&SoDKKD={SoDKKD}" +
                    "&pageIndex={pageIndex}" +
                    "&pageSize={pageSize}")]
        PagedData<CN_GPPViewModel> NganhDuoc_CN_GPP_Search(string SoGiayChungNhan, string tuNgay, string denNgay
            , string TenCoSo, string SoDKKD, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_CN_GPP_Save")]
        long NganhDuoc_CN_GPP_Save(CN_GPP cN_GPPSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_CN_GPP_UpdDaCap")]
        bool NganhDuoc_CN_GPP_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json 
            , UriTemplate = "ND/NganhDuoc_CN_GPP_DelByHoSoID")]
        bool NganhDuoc_CN_GPP_DelByHoSoID(long HoSoID);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json
        , UriTemplate = "ND/NganhDuoc_CN_GPP_DelByTHTGPPID")]
        bool NganhDuoc_CN_GPP_DelByTHTGPPID(long THTGPPID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "ND/NganhDuoc_CN_GPP_InDeXuat?Id={Id}")]
        DataTableViewModel NganhDuoc_CN_GPP_InDeXuat(long Id);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "ND/NganhDuoc_CN_GPP_InChungChi?Id={Id}")]
        DataTableViewModel NganhDuoc_CN_GPP_InChungChi(long Id);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
       UriTemplate = "ND/NganhDuoc_CN_GPP_XuatDanhSach?SoGiayChungNhan={SoGiayChungNhan}" +
               "&tuNgay={tuNgay}" +
               "&denNgay={denNgay}" +
               "&TenCoSo={TenCoSo}" +
               "&SoDKKD={SoDKKD}")]
        DataTableViewModel NganhDuoc_CN_GPP_XuatDanhSach(string SoGiayChungNhan, string tuNgay, string denNgay
       , string TenCoSo, string SoDKKD);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "ND/NganhDuoc_CN_GPP_CongBoWebsite?SoGiayChungNhan={SoGiayChungNhan}" +
                   "&tuNgay={tuNgay}" +
                   "&denNgay={denNgay}" +
                   "&TenCoSo={TenCoSo}" +
                   "&SoDKKD={SoDKKD}")]
        DataTableViewModel NganhDuoc_CN_GPP_CongBoWebsite(string SoGiayChungNhan, string tuNgay, string denNgay
           , string TenCoSo, string SoDKKD);
        #endregion

        #region Cho phép tổ chức, cá nhân xuất khẩu/nhập khẩu thuốc theo đường phi mậu dịch
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByHoSoID?HoSoID={HoSoID}")]
        CV_XNKThuoc_PhiMauDichSave NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByID?XNKThuocPhiMauDichId={XNKThuocPhiMauDichId}")]
        CV_XNKThuoc_PhiMauDichSave NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByID(long XNKThuocPhiMauDichId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_CV_XNKThuoc_PhiMauDich_Search?SoCongVan={SoCongVan}" +
                    "&tuNgay={tuNgay}" +
                    "&denNgay={denNgay}" +
                    "&HoTenNguoiNhanThuoc={HoTenNguoiNhanThuoc}" +
                    "&pageIndex={pageIndex}" +
                    "&pageSize={pageSize}")]
        PagedData<CV_XNKThuoc_PhiMauDichViewModel> NganhDuoc_CV_XNKThuoc_PhiMauDich_Search(string SoCongVan, string tuNgay, string denNgay
            , string HoTenNguoiNhanThuoc, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_CV_XNKThuoc_PhiMauDich_Save")]
        long NganhDuoc_CV_XNKThuoc_PhiMauDich_Save(CV_XNKThuoc_PhiMauDichSave cV_XNKThuoc_PhiMauDichSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_CV_XNKThuoc_PhiMauDich_UpdDaCap")]
        bool NganhDuoc_CV_XNKThuoc_PhiMauDich_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "ND/NganhDuoc_CV_XNKThuoc_PhiMauDich_DelByHoSoID")]
        bool NganhDuoc_CV_XNKThuoc_PhiMauDich_DelByHoSoID(long HoSoID, long XNKThuocPhiMauDichId);
        #endregion

        #region Thẩm định kế hoạch đấu thầu vật tư y tế tiêu hao và hóa chất
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_TD_KeHoachDauThau_GetByHoSoID?HoSoID={HoSoID}")]
        TD_KeHoachDauThauSave NganhDuoc_TD_KeHoachDauThau_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_TD_KeHoachDauThau_GetByID?KeHoachDauThauId={KeHoachDauThauId}")]
        TD_KeHoachDauThauSave NganhDuoc_TD_KeHoachDauThau_GetByID(long KeHoachDauThauId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_TD_KeHoachDauThau_Search?SoQuyetDinh={SoQuyetDinh}" +
                    "&tuNgay={tuNgay}" +
                    "&denNgay={denNgay}" +
                    "&ChuDauTu={ChuDauTu}" +
                    "&pageIndex={pageIndex}" +
                    "&pageSize={pageSize}")]
        PagedData<TD_KeHoachDauThauViewModel> NganhDuoc_TD_KeHoachDauThau_Search(string SoQuyetDinh, string tuNgay, string denNgay
            , string ChuDauTu, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_TD_KeHoachDauThau_Save")]
        long NganhDuoc_TD_KeHoachDauThau_Save(TD_KeHoachDauThauSave tD_KeHoachDauThauSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_TD_KeHoachDauThau_UpdDaCap")]
        bool NganhDuoc_TD_KeHoachDauThau_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "ND/NganhDuoc_TD_KeHoachDauThau_DelByHoSoID")]
        bool NganhDuoc_TD_KeHoachDauThau_DelByHoSoID(long HoSoID, long KeHoachDauThauId);
        #endregion

        #region Duyệt dự trù thuốc thành phẩm gây nghiện, hướng tâm thần
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_PD_Thuoc_GN_HTT_GetByHoSoID?HoSoID={HoSoID}")]
        PD_Thuoc_GN_HTTSave NganhDuoc_PD_Thuoc_GN_HTT_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_PD_Thuoc_GN_HTT_GetByID?PDThuocGNHTTId={PDThuocGNHTTId}")]
        PD_Thuoc_GN_HTTSave NganhDuoc_PD_Thuoc_GN_HTT_GetByID(long PDThuocGNHTTId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_PD_Thuoc_GN_HTT_Search?SoPheDuyet={SoPheDuyet}" +
                    "&tuNgay={tuNgay}" +
                    "&denNgay={denNgay}" +
                    "&TenDonVi={TenDonVi}" +
                    "&TenCongTyCungUng={TenCongTyCungUng}" +
                    "&pageIndex={pageIndex}" +
                    "&pageSize={pageSize}")]
        PagedData<PD_Thuoc_GN_HTTViewModel> NganhDuoc_PD_Thuoc_GN_HTT_Search(string SoPheDuyet, string tuNgay, string denNgay
            , string TenDonVi, string TenCongTyCungUng, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_PD_Thuoc_GN_HTT_Save")]
        long NganhDuoc_PD_Thuoc_GN_HTT_Save(PD_Thuoc_GN_HTTSave pD_Thuoc_GN_HTTSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_PD_Thuoc_GN_HTT_UpdDaCap")]
        bool NganhDuoc_PD_Thuoc_GN_HTT_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "ND/NganhDuoc_PD_Thuoc_GN_HTT_DelByHoSoID")]
        bool NganhDuoc_PD_Thuoc_GN_HTT_DelByHoSoID(long HoSoID, long PDThuocGNHTTId);
        #endregion

        #region Duyệt dự trù và phân phối thuốc Methadone
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_PD_Thuoc_Methadone_GetByHoSoID?HoSoID={HoSoID}")]
        PD_Thuoc_MethadoneSave NganhDuoc_PD_Thuoc_Methadone_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_PD_Thuoc_Methadone_GetByID?PDMethadoneId={PDMethadoneId}")]
        PD_Thuoc_MethadoneSave NganhDuoc_PD_Thuoc_Methadone_GetByID(long PDMethadoneId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_PD_Thuoc_Methadone_Search?SoPheDuyet={SoPheDuyet}" +
                    "&tuNgay={tuNgay}" +
                    "&denNgay={denNgay}" +
                    "&TenDonVi={TenDonVi}" +
                    "&pageIndex={pageIndex}" +
                    "&pageSize={pageSize}")]
        PagedData<PD_Thuoc_MethadoneViewModel> NganhDuoc_PD_Thuoc_Methadone_Search(string SoPheDuyet, string tuNgay, string denNgay
            , string TenDonVi, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_PD_Thuoc_Methadone_Save")]
        long NganhDuoc_PD_Thuoc_Methadone_Save(PD_Thuoc_MethadoneSave pD_Thuoc_MethadoneSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_PD_Thuoc_Methadone_UpdDaCap")]
        bool NganhDuoc_PD_Thuoc_Methadone_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "ND/NganhDuoc_PD_Thuoc_Methadone_DelByHoSoID")]
        bool NganhDuoc_PD_Thuoc_Methadone_DelByHoSoID(long HoSoID, long PDMethadoneId);
        #endregion

        #region Cấp phép nhập khẩu thuốc viện trợ, viện trợ nhân đạo
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_CP_Thuoc_VienTro_GetByHoSoID?HoSoID={HoSoID}")]
        CP_Thuoc_VienTroSave NganhDuoc_CP_Thuoc_VienTro_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_CP_Thuoc_VienTro_GetByID?ThuocVienTroId={ThuocVienTroId}")]
        CP_Thuoc_VienTroSave NganhDuoc_CP_Thuoc_VienTro_GetByID(long ThuocVienTroId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_CP_Thuoc_VienTro_Search?SoTiepNhan={SoTiepNhan}" +
                    "&tuNgay={tuNgay}" +
                    "&denNgay={denNgay}" +
                    "&TenDonVi={TenDonVi}" +
                    "&pageIndex={pageIndex}" +
                    "&pageSize={pageSize}")]
        PagedData<CP_Thuoc_VienTroViewModel> NganhDuoc_CP_Thuoc_VienTro_Search(string SoTiepNhan, string tuNgay, string denNgay
            , string TenDonVi, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_CP_Thuoc_VienTro_Save")]
        long NganhDuoc_CP_Thuoc_VienTro_Save(CP_Thuoc_VienTroSave cP_Thuoc_VienTroSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_CP_Thuoc_VienTro_UpdDaCap")]
        bool NganhDuoc_CP_Thuoc_VienTro_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "ND/NganhDuoc_CP_Thuoc_VienTro_DelByHoSoID")]
        bool NganhDuoc_CP_Thuoc_VienTro_DelByHoSoID(long HoSoID, long ThuocVienTroId);
        #endregion

        #region Cấp giấy xác nhận nội dung quảng cáo mỹ phẩm
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_XN_NoiDungQuangCao_GetByHoSoID?HoSoID={HoSoID}")]
        XN_NoiDungQuangCaoSave NganhDuoc_XN_NoiDungQuangCao_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_XN_NoiDungQuangCao_GetByID?NoiDungQCId={NoiDungQCId}")]
        XN_NoiDungQuangCaoSave NganhDuoc_XN_NoiDungQuangCao_GetByID(long NoiDungQCId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_XN_NoiDungQuangCao_Search?SoXacNhan={SoXacNhan}" +
                    "&tuNgay={tuNgay}" +
                    "&denNgay={denNgay}" +
                    "&TOCHUC_CANHAN={TOCHUC_CANHAN}" +
                    "&pageIndex={pageIndex}" +
                    "&pageSize={pageSize}")]
        PagedData<XN_NoiDungQuangCaoViewModel> NganhDuoc_XN_NoiDungQuangCao_Search(string SoXacNhan, string tuNgay, string denNgay
            , string TOCHUC_CANHAN, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_XN_NoiDungQuangCao_Save")]
        long NganhDuoc_XN_NoiDungQuangCao_Save(XN_NoiDungQuangCaoSave xN_NoiDungQuangCaoSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_XN_NoiDungQuangCao_UpdDaCap")]
        bool NganhDuoc_XN_NoiDungQuangCao_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "ND/NganhDuoc_XN_NoiDungQuangCao_DelByHoSoID")]
        bool NganhDuoc_XN_NoiDungQuangCao_DelByHoSoID(long HoSoID, long NoiDungQCId);
        #endregion

        #region Cấp số tiếp nhận phiếu công bố sản phẩm mỹ phẩm sản xuất tại Việt Nam
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_P_CongBoMyPham_GetByHoSoID?HoSoID={HoSoID}")]
        P_CongBoMyPhamSave NganhDuoc_P_CongBoMyPham_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_P_CongBoMyPham_GetByID?CongBoSPMyPhamId={CongBoSPMyPhamId}")]
        P_CongBoMyPhamSave NganhDuoc_P_CongBoMyPham_GetByID(long CongBoSPMyPhamId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_P_CongBoMyPham_Search?SoCongBo={SoCongBo}" +
                    "&ThoiHanTu={ThoiHanTu}" +
                    "&ThoiHanDen={ThoiHanDen}" +
                    "&NhanHang={NhanHang}" +
                    "&TenSanPham={TenSanPham}" +
                    "&TenNhaSanXuat={TenNhaSanXuat}" +
                    "&pageIndex={pageIndex}" +
                    "&pageSize={pageSize}")]
        PagedData<P_CongBoMyPhamViewModel> NganhDuoc_P_CongBoMyPham_Search(string SoCongBo, string ThoiHanTu, string ThoiHanDen
            , string NhanHang, string TenSanPham, string TenNhaSanXuat, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_P_CongBoMyPham_Save")]
        long NganhDuoc_P_CongBoMyPham_Save(P_CongBoMyPhamSave p_CongBoMyPhamSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_P_CongBoMyPham_UpdDaCap")]
        bool NganhDuoc_P_CongBoMyPham_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "ND/NganhDuoc_P_CongBoMyPham_DelByHoSoID")]
        bool NganhDuoc_P_CongBoMyPham_DelByHoSoID(long HoSoID, long CongBoSPMyPhamId);
        #endregion

        #region Lưu hành mỹ phẩm
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_CN_LuuHanhMyPham_GetByHoSoID?HoSoID={HoSoID}")]
        CN_LuuHanhMyPhamSave NganhDuoc_CN_LuuHanhMyPham_GetByHoSoID(long HoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_CN_LuuHanhMyPham_GetByID?LuuHanhMyPhamId={LuuHanhMyPhamId}")]
        CN_LuuHanhMyPhamSave NganhDuoc_CN_LuuHanhMyPham_GetByID(long LuuHanhMyPhamId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ND/NganhDuoc_CN_LuuHanhMyPham_Search?SoChungNhan={SoChungNhan}" +
                    "&tuNgay={tuNgay}" +
                    "&denNgay={denNgay}" +
                    "&TenCongTy={TenCongTy}" +
                    "&pageIndex={pageIndex}" +
                    "&pageSize={pageSize}")]
        PagedData<CN_LuuHanhMyPhamViewModel> NganhDuoc_CN_LuuHanhMyPham_Search(string SoChungNhan, string tuNgay, string denNgay
            , string TenCongTy, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_CN_LuuHanhMyPham_Save")]
        long NganhDuoc_CN_LuuHanhMyPham_Save(CN_LuuHanhMyPhamSave cN_LuuHanhMyPhamSave);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_CN_LuuHanhMyPham_UpdDaCap")]
        bool NganhDuoc_CN_LuuHanhMyPham_UpdDaCap(List<long> HoSoIDs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest
            , UriTemplate = "ND/NganhDuoc_CN_LuuHanhMyPham_DelByHoSoID")]
        bool NganhDuoc_CN_LuuHanhMyPham_DelByHoSoID(long HoSoID, long LuuHanhMyPhamId);
        #endregion

        #region Cấp chứng chỉ hành nghề dược 
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_CC_Duoc_Save")]
        long NganhDuoc_CC_Duoc_Save(CC_DuocSave cC_DuocSave);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "ND/NganhDuoc_CC_Duoc_QTTH_GetByChungChiDuocID?ChungChiDuocID={ChungChiDuocID}")]
        List<CC_Duoc_QTTH> NganhDuoc_CC_Duoc_QTTH_GetByChungChiDuocID(long ChungChiDuocID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
     UriTemplate = "ND/NganhDuoc_CC_Duoc_TDCM_GetByChungChiDuocID?ChungChiDuocID={ChungChiDuocID}")]
        List<CC_Duoc_TDCM> NganhDuoc_CC_Duoc_TDCM_GetByChungChiDuocID(long ChungChiDuocID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
  UriTemplate = "ND/NganhDuoc_CC_Duoc_GetByHoSoID?HoSoID={HoSoID}")]
        CC_DuocSave NganhDuoc_CC_Duoc_GetByHoSoID(long HoSoID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
  UriTemplate = "ND/NganhDuoc_CC_Duoc_GetByID?ChungChiDuocID={ChungChiDuocID}")]
        CC_DuocSave NganhDuoc_CC_Duoc_GetByID(long ChungChiDuocID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "ND/NganhDuoc_CC_Duoc_GetBySoChungChi?soChungChi={soChungChi}")]
        CC_DuocSave NganhDuoc_CC_Duoc_GetBySoChungChi(string soChungChi);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "ND/NganhDuoc_CC_Duoc_Lst?SoChungChi={SoChungChi}" +
                       "&tuNgay={tuNgay}" +
                       "&denNgay={denNgay}" +
                       "&HoTen={HoTen}" +
                       "&SoGiayTo={SoGiayTo}" +
                       "&TrangThai={TrangThai}" +
                       "&pageIndex={pageIndex}" +
                       "&pageSize={pageSize}")]
        PagedData<CC_DuocViewModel> NganhDuoc_CC_Duoc_Lst(string SoChungChi, string tuNgay,
          string denNgay
          , string HoTen, string SoGiayTo, string TrangThai, int pageIndex, int pageSize);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ND/NganhDuoc_CC_Duoc_DelByChungChiDuocId")]
        bool NganhDuoc_CC_Duoc_DelByChungChiDuocId(long ChungChiDuocId);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
UriTemplate = "ND/NganhDuoc_CC_Duoc_InDeXuat?Id={Id}")]
        DataTableViewModel NganhDuoc_CC_Duoc_InDeXuat(long Id);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
UriTemplate = "ND/NganhDuoc_CC_Duoc_InChungChi?Id={Id}")]
        DataTableViewModel NganhDuoc_CC_Duoc_InChungChi(long Id);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "ND/NganhDuoc_CC_Duoc_XuatDanhSach?SoChungChi={SoChungChi}" +
                      "&tuNgay={tuNgay}" +
                      "&denNgay={denNgay}" +
                      "&HoTen={HoTen}" +
                      "&SoGiayTo={SoGiayTo}" +
                      "&TrangThai={TrangThai}")]
        DataTableViewModel NganhDuoc_CC_Duoc_XuatDanhSach(string SoChungChi, string tuNgay, string denNgay
       , string HoTen, string SoGiayTo, string TrangThai);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "ND/NganhDuoc_CC_Duoc_CongBoWebsite?SoChungChi={SoChungChi}" +
                      "&tuNgay={tuNgay}" +
                      "&denNgay={denNgay}" +
                      "&HoTen={HoTen}" +
                      "&SoGiayTo={SoGiayTo}" +
                      "&TrangThai={TrangThai}")]
        DataTableViewModel NganhDuoc_CC_Duoc_CongBoWebsite(string SoChungChi, string tuNgay, string denNgay
       , string HoTen, string SoGiayTo, string TrangThai);
        #endregion

        #region Cấp lai chứng chỉ hành nghề dược 
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
UriTemplate = "ND/NganhDuoc_CC_Duoc_CapLai_GetByHoSoID?hoSoId={hoSoId}")]
        CC_Duoc_CapLaiSave NganhDuoc_CC_Duoc_CapLai_GetByHoSoID(long hoSoId);
        #endregion
        #region func Dùng chung
        #endregion

    }
}