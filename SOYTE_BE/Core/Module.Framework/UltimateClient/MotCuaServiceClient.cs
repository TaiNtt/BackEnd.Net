using Core.Common.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using Business.Entities;
using Business.Entities.ViewModels;
using Newtonsoft.Json;
using System.Data;
//using System.Web.Script.Serialization;

namespace Module.Framework.UltimateClient
{
    public class MotCuaServiceClient : BaseClient, IDisposable
    {
        private bool _isDisposed;

        public MotCuaServiceClient() : base(AppSetting.MCApiBaseUrl)
        {

        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        }

        #endregion
        public IRestResponse<HoSoTiepNhan> MotCua_HoSoTiepNhan_GetByHoSoId(long hoSoId)
        {
            var request = new RestRequest("MC/MotCua_HoSoTiepNhan_GetByHoSoId", Method.GET);
            request.AddParameter("hoSoId", hoSoId);
            var restResponse = Execute<HoSoTiepNhan>(request);
            return restResponse;
        }
        public IRestResponse MotCua_GenSoBienNhanByThuTucID(long ThuTucID)
        {
            var request = new RestRequest("MC/MotCua_GenSoBienNhanByThuTucID", Method.GET);
            request.AddParameter("ThuTucID", ThuTucID);
            var restResponse = Execute(request);
            return restResponse;
        }
        public IRestResponse MotCua_KiemTraSoBienNhan(string SoBienNhan)
        {
            var request = new RestRequest("MC/MotCua_KiemTraSoBienNhan", Method.GET);
            request.AddParameter("SoBienNhan", SoBienNhan);
            var restResponse = Execute(request);
            return restResponse;
        }
        public IRestResponse MotCua_HoSoTiepNhan_DelByHoSoID(long hoSoId, int UserID)
        {
            var request = new RestRequest("MC/MotCua_HoSoTiepNhan_DelByHoSoID", Method.GET);
            request.AddParameter("hoSoId", hoSoId);
            request.AddParameter("UserID", UserID);
            var restResponse = Execute(request);
            return restResponse;
        }
        public IRestResponse MotCua_HoSoTiepNhan_Save(HoSoTiepNhanSave hoSoTiepNhanSave)
        {
            var request = new RestRequest("MC/MotCua_HoSoTiepNhan_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(hoSoTiepNhanSave, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);

            return Execute(request);
        }

        public IRestResponse MotCua_HoSoTiepNhan_SaveFullProcess(HoSoTiepNhanFullProcessSave hoSoTiepNhanInsFullProcess)
        {
            var request = new RestRequest("MC/MotCua_HoSoTiepNhan_SaveFullProcess", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer(),

            };
            //request.AddBody(new { hoSoTiepNhanInsFullProcess.hosotiepnhan , hoSoTiepNhanInsFullProcess.quatrinhxuly });
            request.AddBody(new
            {
                hoSoTiepNhanInsFullProcess.hosotiepnhan,
                hoSoTiepNhanInsFullProcess.quatrinhxuly,
                hoSoTiepNhanInsFullProcess.worklist,
                hoSoTiepNhanInsFullProcess.UserId,
                hoSoTiepNhanInsFullProcess.TrangThaiHoSoId,
                hoSoTiepNhanInsFullProcess.TrangThaiCapNhat
            });
            return Execute(request);
        }
        public IRestResponse<PagedData<HoSoTiepNhanViewModel>> MotCua_HoSoTiepNhan_GetByCondition(string linhVucID, string thuTucID, string soBienNhan,
            string tuNgay, string denNgay, string hoTenNguoiNop, string soGiayTo, string userDangNhapID, string trangThaiHoSoID, int pageIndex, int pageSize)
        {
            var request = new RestRequest("MC/MotCua_HoSoTiepNhan_GetByCondition", Method.GET);
            request.AddParameter("linhVucID", linhVucID);
            request.AddParameter("thuTucID", thuTucID);
            request.AddParameter("soBienNhan", soBienNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("hoTenNguoiNop", hoTenNguoiNop);
            request.AddParameter("soGiayTo", soGiayTo);
            request.AddParameter("userDangNhapID", userDangNhapID);
            request.AddParameter("trangThaiHoSoID", trangThaiHoSoID);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<HoSoTiepNhanViewModel>>(request);
        }
        public IRestResponse<DataTableViewModel> MotCua_HoSoTiepNhan_XuatDanhSach(string linhVucID, string thuTucID, string soBienNhan,
           string tuNgay, string denNgay, string hoTenNguoiNop, string soGiayTo, string userDangNhapID, string trangThaiHoSoID, string listHoSoID)
        {
            var request = new RestRequest("MC/MotCua_HoSoTiepNhan_XuatDanhSach", Method.GET);
            request.AddParameter("linhVucID", linhVucID);
            request.AddParameter("thuTucID", thuTucID);
            request.AddParameter("soBienNhan", soBienNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("hoTenNguoiNop", hoTenNguoiNop);
            request.AddParameter("soGiayTo", soGiayTo);
            request.AddParameter("userDangNhapID", userDangNhapID);
            request.AddParameter("trangThaiHoSoID", trangThaiHoSoID);
            request.AddParameter("listHoSoID", listHoSoID);
            var restResponse = Execute<DataTableViewModel>(request);
            return restResponse;
        }
        public IRestResponse<DataTableViewModel> MotCua_HoSoTiepNhan_InBienNhan(long hoSoID)
        {
            var request = new RestRequest("MC/MotCua_HoSoTiepNhan_InBienNhan", Method.GET);

            request.AddParameter("hoSoID", hoSoID);
            var restResponse = Execute<DataTableViewModel>(request);
            return restResponse;
        }
        public IRestResponse<DataTableViewModel> MotCua_HoSoTiepNhan_XuatThongTinChiTietHoSo(long hoSoID)
        {
            var request = new RestRequest("MC/MotCua_HoSoTiepNhan_XuatThongTinChiTietHoSo", Method.GET);

            request.AddParameter("hoSoID", hoSoID);
            var restResponse = Execute<DataTableViewModel>(request);
            return restResponse;
        }
        public IRestResponse<List<WorkListViewModel>> MotCua_WorkList_CountByTrangThaiHoSoIDId_UserID(int UserID)
        {
            var request = new RestRequest("MC/MotCua_WorkList_CountByTrangThaiHoSoIDId_UserID", Method.GET);
            request.AddParameter("UserID", UserID);
            var restResponse = Execute<List<WorkListViewModel>>(request);
            return restResponse;
        }
        public IRestResponse<List<WorkListViewModel>> MotCua_WorkList_CountByFilter(string linhVucID, string thuTucID, string soBienNhan,
            string tuNgay, string denNgay, string hoTenNguoiNop, string soGiayTo, int UserID)
        {
            var request = new RestRequest("MC/MotCua_WorkList_CountByFilter", Method.GET);
            request.AddParameter("linhVucID", linhVucID);
            request.AddParameter("thuTucID", thuTucID);
            request.AddParameter("soBienNhan", soBienNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("hoTenNguoiNop", hoTenNguoiNop);
            request.AddParameter("soGiayTo", soGiayTo);
            request.AddParameter("UserID", UserID);
            var restResponse = Execute<List<WorkListViewModel>>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<HoSoTiepNhanViewModel>> MotCua_HoSoTiepNhan_Search(string linhVucID, string thuTucID, string soBienNhan,
            string tuNgay, string denNgay, string hoTenNguoiNop, string soGiayTo, string trangThaiHoSoID, int pageIndex, int pageSize)
        {
            var request = new RestRequest("MC/MotCua_HoSoTiepNhan_Search", Method.GET);
            request.AddParameter("linhVucID", linhVucID);
            request.AddParameter("thuTucID", thuTucID);
            request.AddParameter("soBienNhan", soBienNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("hoTenNguoiNop", hoTenNguoiNop);
            request.AddParameter("soGiayTo", soGiayTo);
            request.AddParameter("trangThaiHoSoID", trangThaiHoSoID);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<HoSoTiepNhanViewModel>>(request);
        }
        public IRestResponse<PagedData<HoSoTiepNhanViewModel>> MotCua_HoSoTiepNhan_SearchFromHomePage(string traCuu, int pageIndex, int pageSize)
        {
            var request = new RestRequest("MC/MotCua_HoSoTiepNhan_SearchFromHomePage", Method.GET);
            request.AddParameter("traCuu", traCuu);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<HoSoTiepNhanViewModel>>(request);
        }
        public IRestResponse MotCua_HoSoTiepNhan_TransFullProcess(HoSoTiepNhanFullProcessTrans hoSoTiepNhanFullProcessTrans)
        {
            var request = new RestRequest("MC/MotCua_HoSoTiepNhan_TransFullProcess", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(hoSoTiepNhanFullProcessTrans, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);

            return Execute(request);
        }
        public IRestResponse MotCua_HoSoTiepNhan_TransFullProcess_List(List<HoSoTiepNhanFullProcessTrans> lstHoSoTiepNhanFullProcessTrans)
        {
            var request = new RestRequest("MC/MotCua_HoSoTiepNhan_TransFullProcess_List", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { lstHoSoTiepNhanFullProcessTrans });
            return Execute(request);
        }
        public IRestResponse MotCua_HoSoTiepNhan_DelFullProcess(HoSoTiepNhanFullProcessDel hoSoTiepNhanFullProcessDel)
        {
            var request = new RestRequest("MC/MotCua_HoSoTiepNhan_DelFullProcess", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(hoSoTiepNhanFullProcessDel, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }
        public IRestResponse<List<QuaTrinhXuLyViewModel>> MotCua_QuaTrinhXuLys_GetByHoSoID(long hoSoId)
        {
            var request = new RestRequest("MC/MotCua_QuaTrinhXuLys_GetByHoSoID", Method.GET);
            request.AddParameter("hoSoId", hoSoId);
            var restResponse = Execute<List<QuaTrinhXuLyViewModel>>(request);
            return restResponse;
        }
        public IRestResponse<DataTableViewModel> MotCua_QuaTrinhXuLys_XuatThongTinChiTietHoSo(long hoSoID)
        {
            var request = new RestRequest("MC/MotCua_QuaTrinhXuLys_XuatThongTinChiTietHoSo", Method.GET);

            request.AddParameter("hoSoID", hoSoID);
            var restResponse = Execute<DataTableViewModel>(request);
            return restResponse;
        }
        public IRestResponse<List<QuyTrinhViewModel>> MotCua_QuyTrinhs_GetByThuTucIDandTrangThaiHienTaiID(int ThuTucID, int TrangThaiHienTaiID)
        {
            var request = new RestRequest("MC/MotCua_QuyTrinhs_GetByThuTucIDandTrangThaiHienTaiID", Method.GET);
            request.AddParameter("ThuTucID", ThuTucID);
            request.AddParameter("TrangThaiHienTaiID", TrangThaiHienTaiID);
            var restResponse = Execute<List<QuyTrinhViewModel>>(request);
            return restResponse;
        }
        public IRestResponse MotCua_QuyTrinhs_CheckByHoSoIDandTrangThaiTiepTheoID(long HoSoID, int TrangThaiTiepTheoID, int NguoiNhanID)
        {
            var request = new RestRequest("MC/MotCua_QuyTrinhs_CheckByHoSoIDandTrangThaiTiepTheoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            request.AddParameter("TrangThaiTiepTheoID", TrangThaiTiepTheoID);
            request.AddParameter("NguoiNhanID", NguoiNhanID);
            var restResponse = Execute(request);
            return restResponse;
        }
        //Ho so theo doi
        public IRestResponse MotCua_HoSoTheoDoi_Save(HoSoTheoDoi hosotheodoi)
        {
            var request = new RestRequest("MC/MotCua_HoSoTheoDoi_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer(),
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(hosotheodoi, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }
        public IRestResponse MotCua_HoSoTheoDoi_Del(long HoSoID, long UserID)
        {
            var request = new RestRequest("MC/MotCua_HoSoTheoDoi_Del", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, UserID });
            return Execute(request);
        }
        //DM_LinhVuc
        public IRestResponse<List<DM_LinhVuc>> MotCua_DM_LinhVuc_GetAll()
        {
            var request = new RestRequest("MC/MotCua_DM_LinhVuc_GetAll", Method.GET);
            //request.AddParameter("hoSoId", hoSoId);
            var restResponse = Execute<List<DM_LinhVuc>>(request);
            return restResponse;
        }
        public IRestResponse<DM_LinhVuc> MotCua_DM_LinhVuc_GetByLinhVucID(int LinhVucID)
        {
            var request = new RestRequest("MC/MotCua_DM_LinhVuc_GetByLinhVucID", Method.GET);
            request.AddParameter("LinhVucID", LinhVucID);
            var restResponse = Execute<DM_LinhVuc>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<DM_LinhVucList>> MotCua_DM_LinhVuc_List(string tuKhoa, int pageIndex, int pageSize)
        {
            var request = new RestRequest("MC/MotCua_DM_LinhVuc_List", Method.GET);
            request.AddParameter("tuKhoa", tuKhoa);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<DM_LinhVucList>>(request);
        }
        public IRestResponse MotCua_DM_LinhVuc_Save(DM_LinhVuc dm_linhvuc)
        {
            var request = new RestRequest("MC/MotCua_DM_LinhVuc_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(dm_linhvuc, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            //var request = new RestRequest("MC/MotCua_DM_LinhVuc_Save", Method.POST)
            //{
            //    RequestFormat = DataFormat.Json,
            //    JsonSerializer = new JsonSerializer(),
            //};
            //request.AddBody(new
            //{
            //    dm_linhvuc
            //});
            return Execute(request);
        }
        //DM_ThuTuc
        public IRestResponse<List<DM_ThuTuc>> MotCua_DM_ThuTuc_GetByLinhVucID(int LinhVucID)
        {
            var request = new RestRequest("MC/MotCua_DM_ThuTuc_GetByLinhVucID", Method.GET);
            request.AddParameter("LinhVucID", LinhVucID);
            var restResponse = Execute<List<DM_ThuTuc>>(request);
            return restResponse;
        }
        public IRestResponse<DM_ThuTuc> MotCua_DM_ThuTuc_GetByThuTucID(int ThuTucID)
        {
            var request = new RestRequest("MC/MotCua_DM_ThuTuc_GetByThuTucID", Method.GET);
            request.AddParameter("ThuTucID", ThuTucID);
            var restResponse = Execute<DM_ThuTuc>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<DM_ThuTucList>> MotCua_DM_ThuTuc_List(string tuKhoa, int pageIndex, int pageSize)
        {
            var request = new RestRequest("MC/MotCua_DM_ThuTuc_List", Method.GET);
            request.AddParameter("tuKhoa", tuKhoa);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<DM_ThuTucList>>(request);
        }
        public IRestResponse MotCua_DM_ThuTuc_Save(DM_ThuTucSave model)
        {
            //var request = new RestRequest("MC/MotCua_DM_ThuTuc_Save", Method.POST)
            //{
            //    RequestFormat = DataFormat.Json,
            //    JsonSerializer = new JsonSerializer(),
            //};
            //request.AddBody(new
            //{
            //    model
            //});
            //return Execute(request);

            var request = new RestRequest("MC/MotCua_DM_ThuTuc_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(model, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);

        }
        //DM_QuyTrinh_Buoc + DM_QuyTrinh_Buoc_NguoiNhan
        public IRestResponse<PagedData<DM_QuyTrinh_Buoc_NguoiNhanList>> MotCua_DM_QuyTrinh_Buoc_NguoiNhan_List(int thuTucID, int pageIndex, int pageSize)
        {
            var request = new RestRequest("MC/MotCua_DM_QuyTrinh_Buoc_NguoiNhan_List", Method.GET);
            request.AddParameter("thuTucID", thuTucID);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<DM_QuyTrinh_Buoc_NguoiNhanList>>(request);
        }
        public IRestResponse<DM_QuyTrinh_Buoc> MotCua_DM_QuyTrinh_Buoc_GetByBuocID(int BuocID)
        {
            var request = new RestRequest("MC/MotCua_DM_QuyTrinh_Buoc_GetByBuocID", Method.GET);
            request.AddParameter("BuocID", BuocID);
            var restResponse = Execute<DM_QuyTrinh_Buoc>(request);
            return restResponse;
        }
        public IRestResponse<DM_QuyTrinh_Buoc_NguoiNhan> MotCua_DM_QuyTrinh_Buoc_NguoiNhan_GetByBuocID(int BuocID)
        {
            var request = new RestRequest("MC/MotCua_DM_QuyTrinh_Buoc_NguoiNhan_GetByBuocID", Method.GET);
            request.AddParameter("BuocID", BuocID);
            var restResponse = Execute<DM_QuyTrinh_Buoc_NguoiNhan>(request);
            return restResponse;
        }
        public IRestResponse<List<DM_QuyTrinh_Buoc_NguoiNhan>> MotCua_DM_QuyTrinh_Buoc_NguoiNhan_ListByBuocID(int BuocID)
        {
            var request = new RestRequest("MC/MotCua_DM_QuyTrinh_Buoc_NguoiNhan_ListByBuocID", Method.GET);
            request.AddParameter("BuocID", BuocID);
            var restResponse = Execute<List<DM_QuyTrinh_Buoc_NguoiNhan>>(request);
            return restResponse;
        }
        public IRestResponse MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Save(DM_QuyTrinh_Buoc_NguoiNhanSave model)
        {
            //var request = new RestRequest("MC/MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Save", Method.POST)
            //{
            //    RequestFormat = DataFormat.Json,
            //    JsonSerializer = new JsonSerializer(),
            //};
            //request.AddBody(new
            //{
            //    model.dm_QuyTrinh_Buoc,
            //    model.lstDM_QuyTrinh_Buoc_NguoiNhan
            //});
            //return Execute(request);

            var request = new RestRequest("MC/MotCua_DM_QuyTrinh_Buoc_NguoiNhan_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(model, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }

        //DMChungTuKemTheo
        public IRestResponse<List<DM_ChungTuKemTheo>> MotCua_DM_ChungTuKemTheo_GetByThuTucID(int ThuTucID)
        {
            var request = new RestRequest("MC/MotCua_DM_ChungTuKemTheo_GetByThuTucID", Method.GET);
            request.AddParameter("ThuTucID", ThuTucID);
            var restResponse = Execute<List<DM_ChungTuKemTheo>>(request);
            return restResponse;
        }

        //Chung Tu Kem Theo
        public IRestResponse<List<ChungTuKemTheo>> MotCua_ChungTuKemTheo_GetByHoSoID(int HoSoID)
        {
            var request = new RestRequest("MC/MotCua_ChungTuKemTheo_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<List<ChungTuKemTheo>>(request);
            return restResponse;
        }
        public IRestResponse MotCua_ChungTuKemTheo_Ins(ChungTuKemTheo model)
        {
            var request = new RestRequest("MC/MotCua_ChungTuKemTheo_Ins", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer(),
            };
            request.AddBody(new
            {
                chungtukemtheo = model
            });
            return Execute<bool>(request);
        }
        public IRestResponse MotCua_ChungTuKemTheo_UpdID(ChungTuKemTheo model)
        {
            var request = new RestRequest("MC/MotCua_ChungTuKemTheo_UpdID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer(),
            };
            request.AddBody(new
            {
                chungtukemtheo = model
            });
            return Execute<bool>(request);
        }

        //E_TrangThaiHoSo
        public IRestResponse<List<E_TrangThaiHoSo>> MotCua_E_TrangThaiHoSo_GetAll()
        {
            var request = new RestRequest("MC/MotCua_E_TrangThaiHoSo_GetAll", Method.GET);
            //request.AddParameter("hoSoId", hoSoId);
            var restResponse = Execute<List<E_TrangThaiHoSo>>(request);
            return restResponse;
        }

        //E_NoiNhanKetQua
        public IRestResponse<List<E_NoiNhanKetQua>> MotCua_E_NoiNhanKetQua_GetAll()
        {
            var request = new RestRequest("MC/MotCua_E_NoiNhanKetQua_GetAll", Method.GET);
            //request.AddParameter("hoSoId", hoSoId);
            var restResponse = Execute<List<E_NoiNhanKetQua>>(request);
            return restResponse;
        }

        //MotCua_ListUsersRoles
        public IRestResponse<List<MotCua_ListUsersRoles>> MotCua_ListUsersRoles()
        {
            var request = new RestRequest("MC/MotCua_ListUsersRoles", Method.GET);
            //request.AddParameter("hoSoId", hoSoId);
            var restResponse = Execute<List<MotCua_ListUsersRoles>>(request);
            return restResponse;
        }
    }
}