using Business.Entities;
using Core.Common.Utilities;
using System.ServiceModel;
using System.ServiceModel.Web;
using Business.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;

namespace Business.Services.Contracts
{
    [ServiceContract]
    public interface IMotCuaService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_HoSoTiepNhan_GetByHoSoId?hoSoId={hoSoId}")]
        HoSoTiepNhan MotCua_HoSoTiepNhan_GetByHoSoId(long hoSoId);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "MC/MotCua_GenSoBienNhanByThuTucID?ThuTucID={ThuTucID}")]
        string MotCua_GenSoBienNhanByThuTucID(long ThuTucID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "MC/MotCua_KiemTraSoBienNhan?SoBienNhan={SoBienNhan}")]
        bool MotCua_KiemTraSoBienNhan(string SoBienNhan);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "MC/MotCua_HoSoTiepNhan_DelByHoSoID?hoSoId={hoSoId}"+
                         "&userDangNhapID={userDangNhapID}")]
        bool MotCua_HoSoTiepNhan_DelByHoSoID(long hoSoID,int userDangNhapID);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MC/MotCua_HoSoTiepNhan_Save")]
        long MotCua_HoSoTiepNhan_Save(HoSoTiepNhanSave hoSoTiepNhanIns);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MC/MotCua_HoSoTiepNhan_SaveFullProcess")]
        long MotCua_HoSoTiepNhan_SaveFullProcess(HoSoTiepNhanFullProcessSave hoSoTiepNhanInsFullProcess);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_HoSoTiepNhan_GetByCondition?linhVucID={linhVucID}" +
                            "&thuTucID={thuTucID}" +
                            "&soBienNhan={soBienNhan}" +
                            "&tuNgay={tuNgay}" +
                            "&denNgay={denNgay}" +
                            "&hoTenNguoiNop={hoTenNguoiNop}" +
                            "&soGiayTo={soGiayTo}" +
                            "&userDangNhapID={userDangNhapID}" +
                            "&trangThaiHoSoID={trangThaiHoSoID}" +
                            "&pageIndex={pageIndex}" +
                            "&pageSize={pageSize}")]
        PagedData<HoSoTiepNhanViewModel> MotCua_HoSoTiepNhan_GetByCondition(string linhVucID, string thuTucID, string soBienNhan,
            string tuNgay, string denNgay, string hoTenNguoiNop, string soGiayTo, string userDangNhapID, string trangThaiHoSoID, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "MC/MotCua_HoSoTiepNhan_XuatDanhSach?linhVucID={linhVucID}" +
                         "&thuTucID={thuTucID}" +
                         "&soBienNhan={soBienNhan}" +
                         "&tuNgay={tuNgay}" +
                         "&denNgay={denNgay}" +
                         "&hoTenNguoiNop={hoTenNguoiNop}" +
                         "&soGiayTo={soGiayTo}" +
                         "&userDangNhapID={userDangNhapID}" +
                         "&trangThaiHoSoID={trangThaiHoSoID}" +
                         "&listHoSoID={listHoSoID}")]
        DataTableViewModel MotCua_HoSoTiepNhan_XuatDanhSach(string linhVucID, string thuTucID, string soBienNhan,
         string tuNgay, string denNgay, string hoTenNguoiNop, string soGiayTo, string userDangNhapID, string trangThaiHoSoID, string listHoSoID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
      UriTemplate = "MC/MotCua_HoSoTiepNhan_InBienNhan?hoSoID={hoSoID}")]
        DataTableViewModel MotCua_HoSoTiepNhan_InBienNhan(long hoSoID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
   UriTemplate = "MC/MotCua_HoSoTiepNhan_XuatThongTinChiTietHoSo?hoSoID={hoSoID}")]
        DataTableViewModel MotCua_HoSoTiepNhan_XuatThongTinChiTietHoSo(long hoSoID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_WorkList_CountByTrangThaiHoSoIDId_UserID?UserID={UserID}")]
        IEnumerable<WorkListViewModel> MotCua_WorkList_CountByTrangThaiHoSoIDId_UserID(int UserID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "MC/MotCua_WorkList_CountByFilter?linhVucID={linhVucID}" +
                            "&thuTucID={thuTucID}" +
                            "&soBienNhan={soBienNhan}" +
                            "&tuNgay={tuNgay}" +
                            "&denNgay={denNgay}" +
                            "&hoTenNguoiNop={hoTenNguoiNop}" +
                            "&soGiayTo={soGiayTo}" + 
                            "&UserID={UserID}")]
        IEnumerable<WorkListViewModel> MotCua_WorkList_CountByFilter(string linhVucID, string thuTucID, string soBienNhan,
            string tuNgay, string denNgay, string hoTenNguoiNop, string soGiayTo, int UserID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_HoSoTiepNhan_Search?linhVucID={linhVucID}" +
                            "&thuTucID={thuTucID}" +
                            "&soBienNhan={soBienNhan}" +
                            "&tuNgay={tuNgay}" +
                            "&denNgay={denNgay}" +
                            "&hoTenNguoiNop={hoTenNguoiNop}" +
                            "&soGiayTo={soGiayTo}" +
                            "&trangThaiHoSoID={trangThaiHoSoID}" +
                            "&pageIndex={pageIndex}" +
                            "&pageSize={pageSize}")]
        PagedData<HoSoTiepNhanViewModel> MotCua_HoSoTiepNhan_Search(string linhVucID, string thuTucID, string soBienNhan,
            string tuNgay, string denNgay, string hoTenNguoiNop, string soGiayTo, string trangThaiHoSoID, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_HoSoTiepNhan_SearchFromHomePage?traCuu={traCuu}" +
                            "&pageIndex={pageIndex}" +
                            "&pageSize={pageSize}")]
        PagedData<HoSoTiepNhanViewModel> MotCua_HoSoTiepNhan_SearchFromHomePage(string traCuu, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MC/MotCua_HoSoTiepNhan_TransFullProcess")]
        bool MotCua_HoSoTiepNhan_TransFullProcess(HoSoTiepNhanFullProcessTrans hoSoTiepNhanFullProcessTrans);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MC/MotCua_HoSoTiepNhan_TransFullProcess_List")]
        int MotCua_HoSoTiepNhan_TransFullProcess_List(List<HoSoTiepNhanFullProcessTrans> lstHoSoTiepNhanFullProcessTrans);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MC/MotCua_HoSoTiepNhan_DelFullProcess")]
        bool MotCua_HoSoTiepNhan_DelFullProcess(HoSoTiepNhanFullProcessDel hoSoTiepNhanFullProcessDel);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_QuaTrinhXuLys_GetByHoSoID?hoSoId={hoSoId}")]
        IEnumerable<QuaTrinhXuLyViewModel> MotCua_QuaTrinhXuLys_GetByHoSoID(long hoSoId);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_QuaTrinhXuLys_XuatThongTinChiTietHoSo?hoSoID={hoSoID}")]
        DataTableViewModel MotCua_QuaTrinhXuLys_XuatThongTinChiTietHoSo(long hoSoID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_QuyTrinhs_GetByThuTucIDandTrangThaiHienTaiID?ThuTucID={ThuTucID}" +
                                                        "&TrangThaiHienTaiID={TrangThaiHienTaiID}")]
        IEnumerable<QuyTrinhViewModel> MotCua_QuyTrinhs_GetByThuTucIDandTrangThaiHienTaiID(int ThuTucID, int TrangThaiHienTaiID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
       UriTemplate = "MC/MotCua_QuyTrinhs_CheckByHoSoIDandTrangThaiTiepTheoID?HoSoID={HoSoID}" +
                                                   "&TrangThaiTiepTheoID={TrangThaiTiepTheoID}" +
                                                   "&NguoiNhanID={NguoiNhanID}")]
        bool MotCua_QuyTrinhs_CheckByHoSoIDandTrangThaiTiepTheoID(int HoSoID, int TrangThaiTiepTheoID, int NguoiNhanID);
        //Ho so theo doi
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MC/MotCua_HoSoTheoDoi_Save")]
        long MotCua_HoSoTheoDoi_Save(HoSoTheoDoi hosotheodoi);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "MC/MotCua_HoSoTheoDoi_Del")]
        bool MotCua_HoSoTheoDoi_Del(long HoSoID, long UserID);

        //DM_LinhVuc
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_DM_LinhVuc_GetAll")]
        IEnumerable<DM_LinhVuc> MotCua_DM_LinhVuc_GetAll();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_DM_LinhVuc_GetByLinhVucID?LinhVucID={LinhVucID}")]
        DM_LinhVuc MotCua_DM_LinhVuc_GetByLinhVucID(int LinhVucID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_DM_LinhVuc_List?tuKhoa={tuKhoa}" +
                            "&pageIndex={pageIndex}" +
                            "&pageSize={pageSize}")]
        PagedData<DM_LinhVucList> MotCua_DM_LinhVuc_List(string tuKhoa, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MC/MotCua_DM_LinhVuc_Save")]
        bool MotCua_DM_LinhVuc_Save(DM_LinhVuc dm_linhvuc);

        //DM_ThuTuc
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_DM_ThuTuc_GetByLinhVucID?LinhVucID={LinhVucID}")]
        List<DM_ThuTuc> MotCua_DM_ThuTuc_GetByLinhVucID(int LinhVucID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_DM_ThuTuc_GetByThuTucID?ThuTucID={ThuTucID}")]
        DM_ThuTuc MotCua_DM_ThuTuc_GetByThuTucID(int ThuTucID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_DM_ThuTuc_List?tuKhoa={tuKhoa}" +
                            "&pageIndex={pageIndex}" +
                            "&pageSize={pageSize}")]
        PagedData<DM_ThuTucList> MotCua_DM_ThuTuc_List(string tuKhoa, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MC/MotCua_DM_ThuTuc_Save")]
        bool MotCua_DM_ThuTuc_Save(DM_ThuTucSave model);

        //DM_QuyTrinh_Buoc + DM_QuyTrinh_Buoc_NguoiNhan
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_DM_QuyTrinh_Buoc_NguoiNhan_List?thuTucID={thuTucID}" +
                            "&pageIndex={pageIndex}" +
                            "&pageSize={pageSize}")]
        PagedData<DM_QuyTrinh_Buoc_NguoiNhanList> MotCua_DM_QuyTrinh_Buoc_NguoiNhan_List(int thuTucID, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_DM_QuyTrinh_Buoc_GetByBuocID?BuocID={BuocID}")]
        DM_QuyTrinh_Buoc MotCua_DM_QuyTrinh_Buoc_GetByBuocID(int BuocID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_DM_QuyTrinh_Buoc_NguoiNhan_GetByBuocID?BuocID={BuocID}")]
        DM_QuyTrinh_Buoc_NguoiNhan MotCua_DM_QuyTrinh_Buoc_NguoiNhan_GetByBuocID(int BuocID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_DM_QuyTrinh_Buoc_NguoiNhan_ListByBuocID?BuocID={BuocID}")]
        IEnumerable<DM_QuyTrinh_Buoc_NguoiNhan> MotCua_DM_QuyTrinh_Buoc_NguoiNhan_ListByBuocID(int BuocID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MC/MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Save")]
        bool MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Save(DM_QuyTrinh_Buoc_NguoiNhanSave model);
        //DM_ChungTuKeoTheo
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_DM_ChungTuKemTheo_GetByThuTucID?ThuTucID={ThuTucID}")]
        List<DM_ChungTuKemTheo> MotCua_DM_ChungTuKemTheo_GetByThuTucID(int ThuTucID);
        //ChungTuKeoTheo
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_ChungTuKemTheo_GetByHoSoID?HoSoID={HoSoID}")]
        List<ChungTuKemTheo> MotCua_ChungTuKemTheo_GetByHoSoID(int HoSoID);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MC/MotCua_ChungTuKemTheo_Ins")]
        bool MotCua_ChungTuKemTheo_Ins(ChungTuKemTheo chungtukemtheo);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MC/MotCua_ChungTuKemTheo_UpdID")]
        bool MotCua_ChungTuKemTheo_UpdID(ChungTuKemTheo chungtukemtheo);
        //E_TrangThaiHoSo
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "MC/MotCua_E_TrangThaiHoSo_GetAll")]
        List<E_TrangThaiHoSo> MotCua_E_TrangThaiHoSo_GetAll();
        //E_TrangThaiHoSo
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "MC/MotCua_E_NoiNhanKetQua_GetAll")]
        List<E_NoiNhanKetQua> MotCua_E_NoiNhanKetQua_GetAll();

        //MotCua_ListUsersRoles
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MC/MotCua_ListUsersRoles")]
        IEnumerable<MotCua_ListUsersRoles> MotCua_ListUsersRoles();
    }
}