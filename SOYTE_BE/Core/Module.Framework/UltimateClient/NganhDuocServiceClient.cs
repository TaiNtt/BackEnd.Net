using Core.Common.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using Business.Entities;
using Business.Entities.ViewModels;
using Newtonsoft.Json;

namespace Module.Framework.UltimateClient
{
    public class NganhDuocServiceClient : BaseClient, IDisposable
    {
        private bool _isDisposed;

        public NganhDuocServiceClient() : base(AppSetting.NDApiBaseUrl)
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

        #region Đăng ký hội thảo giới thiệu thuốc
        public IRestResponse<DK_HoiThaoGioiThieuThuocSave> NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("ND/NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<DK_HoiThaoGioiThieuThuocSave>(request);
            return restResponse;
        }
        public IRestResponse<DK_HoiThaoGioiThieuThuocSave> NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByID(long HoiThaoThuocID)
        {
            var request = new RestRequest("ND/NganhDuoc_DK_HoiThaoGioiThieuThuoc_GetByID", Method.GET);
            request.AddParameter("HoiThaoThuocID", HoiThaoThuocID);
            var restResponse = Execute<DK_HoiThaoGioiThieuThuocSave>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<DK_HoiThaoGioiThieuThuocViewModel>> NganhDuoc_DK_HoiThaoGioiThieuThuoc_Search(string SoTiepNhan, string tuNgay, string denNgay
            , string TenDonVi, string HoTen, int pageIndex, int pageSize)
        {
            var request = new RestRequest("ND/NganhDuoc_DK_HoiThaoGioiThieuThuoc_Search", Method.GET);
            request.AddParameter("SoTiepNhan", SoTiepNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("TenDonVi", TenDonVi);
            request.AddParameter("HoTen", HoTen);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<DK_HoiThaoGioiThieuThuocViewModel>>(request);
        }
        public IRestResponse NganhDuoc_DK_HoiThaoGioiThieuThuoc_Save(DK_HoiThaoGioiThieuThuocSave dk_HoiThaoGioiThieuThuocSave)
        {
            var request = new RestRequest("ND/NganhDuoc_DK_HoiThaoGioiThieuThuoc_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { dk_HoiThaoGioiThieuThuocSave });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_DK_HoiThaoGioiThieuThuoc_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("ND/NganhDuoc_DK_HoiThaoGioiThieuThuoc_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_DK_HoiThaoGioiThieuThuoc_DelByHoSoID(long HoSoID, long HoiThaoThuocID)
        {
            var request = new RestRequest("ND/NganhDuoc_DK_HoiThaoGioiThieuThuoc_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, HoiThaoThuocID });
            return Execute(request);
        }
        #endregion

        #region GDP
        public IRestResponse<List<CN_GDP_DSKho>> NganhDuoc_CN_GDP_DSKho_GetByTHTGDPId(long THTGDPId)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GDP_DSKho_GetByTHTGDPId", Method.GET);
            request.AddParameter("THTGDPId", THTGDPId);
            var restResponse = Execute<List<CN_GDP_DSKho>>(request);
            return restResponse;
        }
        public IRestResponse<CN_GDPSave> NganhDuoc_CN_GDP_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GDP_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<CN_GDPSave>(request);
            return restResponse;
        }
        public IRestResponse<CN_GDPSave> NganhDuoc_CN_GDP_GetByID(long THTGDPId)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GDP_GetByID", Method.GET);
            request.AddParameter("THTGDPId", THTGDPId);
            var restResponse = Execute<CN_GDPSave>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<CN_GDPViewModel>> NganhDuoc_CN_GDP_Search(string SoGiayChungNhan, string tuNgay, string denNgay
            , string TenCoSo, string SoDKKD, int pageIndex, int pageSize)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GDP_Search", Method.GET);
            request.AddParameter("SoGiayChungNhan", SoGiayChungNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("TenCoSo", TenCoSo);
            request.AddParameter("SoDKKD", SoDKKD);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<CN_GDPViewModel>>(request);
        }
        public IRestResponse NganhDuoc_CN_GDP_Save(CN_GDPSave cN_GDPSave)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GDP_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(cN_GDPSave, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }
        public IRestResponse NganhDuoc_CN_GDP_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GDP_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(HoSoIDs, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }
        public IRestResponse NganhDuoc_CN_GDP_DelByHoSoID(long HoSoID)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GDP_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(HoSoID, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }
        public IRestResponse<DataTableViewModel> NganhDuoc_CN_GDP_InDeXuat(long Id)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GDP_InDeXuat", Method.GET);

            request.AddParameter("Id", Id);
            var restResponse = Execute<DataTableViewModel>(request);
            return restResponse;
        }
        public IRestResponse<DataTableViewModel> NganhDuoc_CN_GDP_InChungChi(long Id)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GDP_InChungChi", Method.GET);

            request.AddParameter("Id", Id);
            var restResponse = Execute<DataTableViewModel>(request);
            return restResponse;
        }
        public IRestResponse NganhDuoc_CN_GDP_DelByTHTGDPID(long THTGDPID)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GDP_DelByTHTGDPID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(THTGDPID, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }
        public IRestResponse<DataTableViewModel> NganhDuoc_CN_GDP_XuatDanhSach(string SoGiayChungNhan, string tuNgay, string denNgay
          , string TenCoSo, string SoDKKD)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GDP_XuatDanhSach", Method.GET);
            request.AddParameter("SoGiayChungNhan", SoGiayChungNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("TenCoSo", TenCoSo);
            request.AddParameter("SoDKKD", SoDKKD);
            return Execute<DataTableViewModel>(request);
        }
        public IRestResponse<DataTableViewModel> NganhDuoc_CN_GDP_CongBoWebsite(string SoGiayChungNhan, string tuNgay, string denNgay
         , string TenCoSo, string SoDKKD)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GDP_CongBoWebsite", Method.GET);
            request.AddParameter("SoGiayChungNhan", SoGiayChungNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("TenCoSo", TenCoSo);
            request.AddParameter("SoDKKD", SoDKKD);
            return Execute<DataTableViewModel>(request);
        }
        #endregion

        #region GPP
        public IRestResponse<CN_GPP> NganhDuoc_CN_GPP_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GPP_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<CN_GPP>(request);
            return restResponse;
        }
        public IRestResponse<CN_GPP> NganhDuoc_CN_GPP_GetByID(long THTGPPId)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GPP_GetByID", Method.GET);
            request.AddParameter("THTGPPId", THTGPPId);
            var restResponse = Execute<CN_GPP>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<CN_GPPViewModel>> NganhDuoc_CN_GPP_Search(string SoGiayChungNhan, string tuNgay, string denNgay
            , string TenCoSo, string SoDKKD, int pageIndex, int pageSize)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GPP_Search", Method.GET);
            request.AddParameter("SoGiayChungNhan", SoGiayChungNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("TenCoSo", TenCoSo);
            request.AddParameter("SoDKKD", SoDKKD);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<CN_GPPViewModel>>(request);
        }
        public IRestResponse NganhDuoc_CN_GPP_Save(CN_GPP cN_GPPSave)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GPP_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(cN_GPPSave, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }
        public IRestResponse NganhDuoc_CN_GPP_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GPP_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(HoSoIDs, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }
        public IRestResponse NganhDuoc_CN_GPP_DelByHoSoID(long HoSoID)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GPP_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(HoSoID, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }
        public IRestResponse<DataTableViewModel> NganhDuoc_CN_GPP_InDeXuat(long Id)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GPP_InDeXuat", Method.GET);

            request.AddParameter("Id", Id);
            var restResponse = Execute<DataTableViewModel>(request);
            return restResponse;
        }
        public IRestResponse<DataTableViewModel> NganhDuoc_CN_GPP_InChungChi(long Id)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GPP_InChungChi", Method.GET);

            request.AddParameter("Id", Id);
            var restResponse = Execute<DataTableViewModel>(request);
            return restResponse;
        }
        public IRestResponse NganhDuoc_CN_GPP_DelByTHTGPPID(long THTGPPID)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GPP_DelByTHTGPPID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(THTGPPID, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }
        public IRestResponse<DataTableViewModel> NganhDuoc_CN_GPP_XuatDanhSach(string SoGiayChungNhan, string tuNgay, string denNgay
          , string TenCoSo, string SoDKKD)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GPP_XuatDanhSach", Method.GET);
            request.AddParameter("SoGiayChungNhan", SoGiayChungNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("TenCoSo", TenCoSo);
            request.AddParameter("SoDKKD", SoDKKD);
            return Execute<DataTableViewModel>(request);
        }
        public IRestResponse<DataTableViewModel> NganhDuoc_CN_GPP_CongBoWebsite(string SoGiayChungNhan, string tuNgay, string denNgay
         , string TenCoSo, string SoDKKD)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_GPP_CongBoWebsite", Method.GET);
            request.AddParameter("SoGiayChungNhan", SoGiayChungNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("TenCoSo", TenCoSo);
            request.AddParameter("SoDKKD", SoDKKD);
            return Execute<DataTableViewModel>(request);
        }
        #endregion

        #region Cho phép tổ chức, cá nhân xuất khẩu/nhập khẩu thuốc theo đường phi mậu dịch
        public IRestResponse<CV_XNKThuoc_PhiMauDichSave> NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("ND/NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<CV_XNKThuoc_PhiMauDichSave>(request);
            return restResponse;
        }
        public IRestResponse<CV_XNKThuoc_PhiMauDichSave> NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByID(long XNKThuocPhiMauDichId)
        {
            var request = new RestRequest("ND/NganhDuoc_CV_XNKThuoc_PhiMauDich_GetByID", Method.GET);
            request.AddParameter("XNKThuocPhiMauDichId", XNKThuocPhiMauDichId);
            var restResponse = Execute<CV_XNKThuoc_PhiMauDichSave>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<CV_XNKThuoc_PhiMauDichViewModel>> NganhDuoc_CV_XNKThuoc_PhiMauDich_Search(string SoCongVan, string tuNgay, string denNgay
            , string HoTenNguoiNhanThuoc, int pageIndex, int pageSize)
        {
            var request = new RestRequest("ND/NganhDuoc_CV_XNKThuoc_PhiMauDich_Search", Method.GET);
            request.AddParameter("SoCongVan", SoCongVan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("HoTenNguoiNhanThuoc", HoTenNguoiNhanThuoc);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<CV_XNKThuoc_PhiMauDichViewModel>>(request);
        }
        public IRestResponse NganhDuoc_CV_XNKThuoc_PhiMauDich_Save(CV_XNKThuoc_PhiMauDichSave cV_XNKThuoc_PhiMauDichSave)
        {
            var request = new RestRequest("ND/NganhDuoc_CV_XNKThuoc_PhiMauDich_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { cV_XNKThuoc_PhiMauDichSave });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_CV_XNKThuoc_PhiMauDich_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("ND/NganhDuoc_CV_XNKThuoc_PhiMauDich_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_CV_XNKThuoc_PhiMauDich_DelByHoSoID(long HoSoID, long XNKThuocPhiMauDichId)
        {
            var request = new RestRequest("ND/NganhDuoc_CV_XNKThuoc_PhiMauDich_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, XNKThuocPhiMauDichId });
            return Execute(request);
        }
        #endregion

        #region Thẩm định kế hoạch đấu thầu vật tư y tế tiêu hao và hóa chất
        public IRestResponse<TD_KeHoachDauThauSave> NganhDuoc_TD_KeHoachDauThau_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("ND/NganhDuoc_TD_KeHoachDauThau_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<TD_KeHoachDauThauSave>(request);
            return restResponse;
        }
        public IRestResponse<TD_KeHoachDauThauSave> NganhDuoc_TD_KeHoachDauThau_GetByID(long KeHoachDauThauId)
        {
            var request = new RestRequest("ND/NganhDuoc_TD_KeHoachDauThau_GetByID", Method.GET);
            request.AddParameter("KeHoachDauThauId", KeHoachDauThauId);
            var restResponse = Execute<TD_KeHoachDauThauSave>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<TD_KeHoachDauThauViewModel>> NganhDuoc_TD_KeHoachDauThau_Search(string SoQuyetDinh, string tuNgay, string denNgay
            , string ChuDauTu, int pageIndex, int pageSize)
        {
            var request = new RestRequest("ND/NganhDuoc_TD_KeHoachDauThau_Search", Method.GET);
            request.AddParameter("SoQuyetDinh", SoQuyetDinh);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("ChuDauTu", ChuDauTu);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<TD_KeHoachDauThauViewModel>>(request);
        }
        public IRestResponse NganhDuoc_TD_KeHoachDauThau_Save(TD_KeHoachDauThauSave tD_KeHoachDauThauSave)
        {
            var request = new RestRequest("ND/NganhDuoc_TD_KeHoachDauThau_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { tD_KeHoachDauThauSave });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_TD_KeHoachDauThau_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("ND/NganhDuoc_TD_KeHoachDauThau_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_TD_KeHoachDauThau_DelByHoSoID(long HoSoID, long KeHoachDauThauId)
        {
            var request = new RestRequest("ND/NganhDuoc_TD_KeHoachDauThau_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, KeHoachDauThauId });
            return Execute(request);
        }
        #endregion

        #region Duyệt dự trù thuốc thành phẩm gây nghiện, hướng tâm thần
        public IRestResponse<PD_Thuoc_GN_HTTSave> NganhDuoc_PD_Thuoc_GN_HTT_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("ND/NganhDuoc_PD_Thuoc_GN_HTT_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<PD_Thuoc_GN_HTTSave>(request);
            return restResponse;
        }
        public IRestResponse<PD_Thuoc_GN_HTTSave> NganhDuoc_PD_Thuoc_GN_HTT_GetByID(long PDThuocGNHTTId)
        {
            var request = new RestRequest("ND/NganhDuoc_PD_Thuoc_GN_HTT_GetByID", Method.GET);
            request.AddParameter("PDThuocGNHTTId", PDThuocGNHTTId);
            var restResponse = Execute<PD_Thuoc_GN_HTTSave>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<PD_Thuoc_GN_HTTViewModel>> NganhDuoc_PD_Thuoc_GN_HTT_Search(string SoPheDuyet, string tuNgay, string denNgay
            , string TenDonVi, string TenCongTyCungUng, int pageIndex, int pageSize)
        {
            var request = new RestRequest("ND/NganhDuoc_PD_Thuoc_GN_HTT_Search", Method.GET);
            request.AddParameter("SoPheDuyet", SoPheDuyet);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("TenDonVi", TenDonVi);
            request.AddParameter("TenCongTyCungUng", TenCongTyCungUng);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<PD_Thuoc_GN_HTTViewModel>>(request);
        }
        public IRestResponse NganhDuoc_PD_Thuoc_GN_HTT_Save(PD_Thuoc_GN_HTTSave pD_Thuoc_GN_HTTSave)
        {
            var request = new RestRequest("ND/NganhDuoc_PD_Thuoc_GN_HTT_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { pD_Thuoc_GN_HTTSave });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_PD_Thuoc_GN_HTT_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("ND/NganhDuoc_PD_Thuoc_GN_HTT_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_PD_Thuoc_GN_HTT_DelByHoSoID(long HoSoID, long PDThuocGNHTTId)
        {
            var request = new RestRequest("ND/NganhDuoc_PD_Thuoc_GN_HTT_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, PDThuocGNHTTId });
            return Execute(request);
        }
        #endregion

        #region Duyệt dự trù và phân phối thuốc Methadone
        public IRestResponse<PD_Thuoc_MethadoneSave> NganhDuoc_PD_Thuoc_Methadone_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("ND/NganhDuoc_PD_Thuoc_Methadone_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<PD_Thuoc_MethadoneSave>(request);
            return restResponse;
        }
        public IRestResponse<PD_Thuoc_MethadoneSave> NganhDuoc_PD_Thuoc_Methadone_GetByID(long PDMethadoneId)
        {
            var request = new RestRequest("ND/NganhDuoc_PD_Thuoc_Methadone_GetByID", Method.GET);
            request.AddParameter("PDMethadoneId", PDMethadoneId);
            var restResponse = Execute<PD_Thuoc_MethadoneSave>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<PD_Thuoc_MethadoneViewModel>> NganhDuoc_PD_Thuoc_Methadone_Search(string SoPheDuyet, string tuNgay, string denNgay
            , string TenDonVi, int pageIndex, int pageSize)
        {
            var request = new RestRequest("ND/NganhDuoc_PD_Thuoc_Methadone_Search", Method.GET);
            request.AddParameter("SoPheDuyet", SoPheDuyet);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("TenDonVi", TenDonVi);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<PD_Thuoc_MethadoneViewModel>>(request);
        }
        public IRestResponse NganhDuoc_PD_Thuoc_Methadone_Save(PD_Thuoc_MethadoneSave pD_Thuoc_MethadoneSave)
        {
            var request = new RestRequest("ND/NganhDuoc_PD_Thuoc_Methadone_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { pD_Thuoc_MethadoneSave });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_PD_Thuoc_Methadone_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("ND/NganhDuoc_PD_Thuoc_Methadone_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_PD_Thuoc_Methadone_DelByHoSoID(long HoSoID, long PDMethadoneId)
        {
            var request = new RestRequest("ND/NganhDuoc_PD_Thuoc_Methadone_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, PDMethadoneId });
            return Execute(request);
        }
        #endregion

        #region Cấp phép nhập khẩu thuốc viện trợ, viện trợ nhân đạo
        public IRestResponse<CP_Thuoc_VienTroSave> NganhDuoc_CP_Thuoc_VienTro_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("ND/NganhDuoc_CP_Thuoc_VienTro_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<CP_Thuoc_VienTroSave>(request);
            return restResponse;
        }
        public IRestResponse<CP_Thuoc_VienTroSave> NganhDuoc_CP_Thuoc_VienTro_GetByID(long ThuocVienTroId)
        {
            var request = new RestRequest("ND/NganhDuoc_CP_Thuoc_VienTro_GetByID", Method.GET);
            request.AddParameter("ThuocVienTroId", ThuocVienTroId);
            var restResponse = Execute<CP_Thuoc_VienTroSave>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<CP_Thuoc_VienTroViewModel>> NganhDuoc_CP_Thuoc_VienTro_Search(string SoTiepNhan, string tuNgay, string denNgay
            , string TenDonVi, int pageIndex, int pageSize)
        {
            var request = new RestRequest("ND/NganhDuoc_PD_Thuoc_Methadone_Search", Method.GET);
            request.AddParameter("SoTiepNhan", SoTiepNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("TenDonVi", TenDonVi);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<CP_Thuoc_VienTroViewModel>>(request);
        }
        public IRestResponse NganhDuoc_CP_Thuoc_VienTro_Save(CP_Thuoc_VienTroSave cP_Thuoc_VienTroSave)
        {
            var request = new RestRequest("ND/NganhDuoc_CP_Thuoc_VienTro_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { cP_Thuoc_VienTroSave });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_CP_Thuoc_VienTro_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("ND/NganhDuoc_CP_Thuoc_VienTro_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_CP_Thuoc_VienTro_DelByHoSoID(long HoSoID, long ThuocVienTroId)
        {
            var request = new RestRequest("ND/NganhDuoc_CP_Thuoc_VienTro_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, ThuocVienTroId });
            return Execute(request);
        }
        #endregion

        #region Cấp giấy xác nhận nội dung quảng cáo mỹ phẩm
        public IRestResponse<XN_NoiDungQuangCaoSave> NganhDuoc_XN_NoiDungQuangCao_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("ND/NganhDuoc_XN_NoiDungQuangCao_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<XN_NoiDungQuangCaoSave>(request);
            return restResponse;
        }
        public IRestResponse<XN_NoiDungQuangCaoSave> NganhDuoc_XN_NoiDungQuangCao_GetByID(long NoiDungQCId)
        {
            var request = new RestRequest("ND/NganhDuoc_XN_NoiDungQuangCao_GetByID", Method.GET);
            request.AddParameter("NoiDungQCId", NoiDungQCId);
            var restResponse = Execute<XN_NoiDungQuangCaoSave>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<XN_NoiDungQuangCaoViewModel>> NganhDuoc_XN_NoiDungQuangCao_Search(string SoXacNhan, string tuNgay, string denNgay
            , string TOCHUC_CANHAN, int pageIndex, int pageSize)
        {
            var request = new RestRequest("ND/NganhDuoc_XN_NoiDungQuangCao_Search", Method.GET);
            request.AddParameter("SoXacNhan", SoXacNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("TOCHUC_CANHAN", TOCHUC_CANHAN);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<XN_NoiDungQuangCaoViewModel>>(request);
        }
        public IRestResponse NganhDuoc_XN_NoiDungQuangCao_Save(XN_NoiDungQuangCaoSave xN_NoiDungQuangCaoSave)
        {
            var request = new RestRequest("ND/NganhDuoc_XN_NoiDungQuangCao_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { xN_NoiDungQuangCaoSave });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_XN_NoiDungQuangCao_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("ND/NganhDuoc_XN_NoiDungQuangCao_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_XN_NoiDungQuangCao_DelByHoSoID(long HoSoID, long NoiDungQCId)
        {
            var request = new RestRequest("ND/NganhDuoc_XN_NoiDungQuangCao_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, NoiDungQCId });
            return Execute(request);
        }
        #endregion

        #region Cấp số tiếp nhận phiếu công bố sản phẩm mỹ phẩm sản xuất tại Việt Nam
        public IRestResponse<P_CongBoMyPhamSave> NganhDuoc_P_CongBoMyPham_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("ND/NganhDuoc_P_CongBoMyPham_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<P_CongBoMyPhamSave>(request);
            return restResponse;
        }
        public IRestResponse<P_CongBoMyPhamSave> NganhDuoc_P_CongBoMyPham_GetByID(long CongBoSPMyPhamId)
        {
            var request = new RestRequest("ND/NganhDuoc_P_CongBoMyPham_GetByID", Method.GET);
            request.AddParameter("CongBoSPMyPhamId", CongBoSPMyPhamId);
            var restResponse = Execute<P_CongBoMyPhamSave>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<P_CongBoMyPhamViewModel>> NganhDuoc_P_CongBoMyPham_Search(string SoCongBo, string ThoiHanTu, string ThoiHanDen
            , string NhanHang, string TenSanPham, string TenNhaSanXuat, int pageIndex, int pageSize)
        {
            var request = new RestRequest("ND/NganhDuoc_P_CongBoMyPham_Search", Method.GET);
            request.AddParameter("SoCongBo", SoCongBo);
            request.AddParameter("ThoiHanTu", ThoiHanTu);
            request.AddParameter("ThoiHanDen", ThoiHanDen);
            request.AddParameter("NhanHang", NhanHang);
            request.AddParameter("TenSanPham", TenSanPham);
            request.AddParameter("TenNhaSanXuat", TenNhaSanXuat);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<P_CongBoMyPhamViewModel>>(request);
        }
        public IRestResponse NganhDuoc_P_CongBoMyPham_Save(P_CongBoMyPhamSave p_CongBoMyPhamSave)
        {
            var request = new RestRequest("ND/NganhDuoc_P_CongBoMyPham_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { p_CongBoMyPhamSave });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_P_CongBoMyPham_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("ND/NganhDuoc_P_CongBoMyPham_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_P_CongBoMyPham_DelByHoSoID(long HoSoID, long CongBoSPMyPhamId)
        {
            var request = new RestRequest("ND/NganhDuoc_P_CongBoMyPham_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, CongBoSPMyPhamId });
            return Execute(request);
        }
        #endregion

        #region Lưu hành mỹ phẩm
        public IRestResponse<CN_LuuHanhMyPhamSave> NganhDuoc_CN_LuuHanhMyPham_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_LuuHanhMyPham_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<CN_LuuHanhMyPhamSave>(request);
            return restResponse;
        }
        public IRestResponse<CN_LuuHanhMyPhamSave> NganhDuoc_CN_LuuHanhMyPham_GetByID(long LuuHanhMyPhamId)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_LuuHanhMyPham_GetByID", Method.GET);
            request.AddParameter("LuuHanhMyPhamId", LuuHanhMyPhamId);
            var restResponse = Execute<CN_LuuHanhMyPhamSave>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<CN_LuuHanhMyPhamViewModel>> NganhDuoc_CN_LuuHanhMyPham_Search(string SoChungNhan, string tuNgay, string denNgay
            , string TenCongTy, int pageIndex, int pageSize)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_LuuHanhMyPham_Search", Method.GET);
            request.AddParameter("SoChungNhan", SoChungNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("TenCongTy", TenCongTy);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<CN_LuuHanhMyPhamViewModel>>(request);
        }
        public IRestResponse NganhDuoc_CN_LuuHanhMyPham_Save(CN_LuuHanhMyPhamSave cN_LuuHanhMyPhamSave)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_LuuHanhMyPham_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { cN_LuuHanhMyPhamSave });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_CN_LuuHanhMyPham_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_LuuHanhMyPham_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhDuoc_CN_LuuHanhMyPham_DelByHoSoID(long HoSoID, long LuuHanhMyPhamId)
        {
            var request = new RestRequest("ND/NganhDuoc_CN_LuuHanhMyPham_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, LuuHanhMyPhamId });
            return Execute(request);
        }
        #endregion
        #region Cấp chứng chỉ hành nghề dược 
        public IRestResponse NganhDuoc_CC_Duoc_Save(CC_DuocSave cC_DuocSave)
        {
            var request = new RestRequest("ND/NganhDuoc_CC_Duoc_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(cC_DuocSave, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);

            return Execute(request);
        }
        public IRestResponse<List<CC_Duoc_QTTH>> NganhDuoc_CC_Duoc_QTTH_GetByChungChiDuocID(long ChungChiDuocID)
        {
            var request = new RestRequest("ND/NganhDuoc_CC_Duoc_QTTH_GetByChungChiDuocID", Method.GET);
            request.AddParameter("ChungChiDuocID", ChungChiDuocID);
            var restResponse = Execute<List<CC_Duoc_QTTH>>(request);
            return restResponse;
        }
        public IRestResponse<List<CC_Duoc_TDCM>> NganhDuoc_CC_Duoc_TDCM_GetByChungChiDuocID(long ChungChiDuocID)
        {
            var request = new RestRequest("ND/NganhDuoc_CC_Duoc_TDCM_GetByChungChiDuocID", Method.GET);
            request.AddParameter("ChungChiDuocID", ChungChiDuocID);
            var restResponse = Execute<List<CC_Duoc_TDCM>>(request);
            return restResponse;
        }
        public IRestResponse<CC_DuocSave> NganhDuoc_CC_Duoc_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("ND/NganhDuoc_CC_Duoc_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<CC_DuocSave>(request);
            return restResponse;
        }
        public IRestResponse<CC_DuocSave> NganhDuoc_CC_Duoc_GetByID(long ChungChiDuocID)
        {
            var request = new RestRequest("ND/NganhDuoc_CC_Duoc_GetByID", Method.GET);
            request.AddParameter("ChungChiDuocID", ChungChiDuocID);
            var restResponse = Execute<CC_DuocSave>(request);
            return restResponse;
        }
        public IRestResponse<CC_DuocSave> NganhDuoc_CC_Duoc_GetBySoChungChi(string SoChungChi)
        {
            var request = new RestRequest("ND/NganhDuoc_CC_Duoc_GetBySoChungChi", Method.GET);
            request.AddParameter("SoChungChi", SoChungChi);
            var restResponse = Execute<CC_DuocSave>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<CC_DuocViewModel>> NganhDuoc_CC_Duoc_Lst(string SoChungChi, string tuNgay, string denNgay
         , string HoTen, string SoGiayTo, string TrangThai, int pageIndex, int pageSize)
        {
            var request = new RestRequest("ND/NganhDuoc_CC_Duoc_Lst", Method.GET);
            request.AddParameter("SoChungChi", SoChungChi);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("HoTen", HoTen);
            request.AddParameter("SoGiayTo", SoGiayTo);
            request.AddParameter("TrangThai", TrangThai);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<CC_DuocViewModel>>(request);
        }
        public IRestResponse NganhDuoc_CC_Duoc_DelByChungChiDuocId(long ChungChiDuocId)
        {
            var request = new RestRequest("ND/NganhDuoc_CC_Duoc_DelByChungChiDuocId", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(ChungChiDuocId, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);

            return Execute(request);
        }
        public IRestResponse<DataTableViewModel> NganhDuoc_CC_Duoc_InDeXuat(long Id)
        {
            var request = new RestRequest("ND/NganhDuoc_CC_Duoc_InDeXuat", Method.GET);
            request.AddParameter("Id", Id);
            var restResponse = Execute<DataTableViewModel>(request);
            return restResponse;
        }
        public IRestResponse<DataTableViewModel> NganhDuoc_CC_Duoc_InChungChi(long Id)
        {
            var request = new RestRequest("ND/NganhDuoc_CC_Duoc_InChungChi", Method.GET);
            request.AddParameter("Id", Id);
            var restResponse = Execute<DataTableViewModel>(request);
            return restResponse;
        }
        public IRestResponse<DataTableViewModel> NganhDuoc_CC_Duoc_XuatDanhSach(string SoChungChi, string tuNgay, string denNgay
      , string HoTen, string SoGiayTo, string TrangThai)
        {
            var request = new RestRequest("ND/NganhDuoc_CC_Duoc_XuatDanhSach", Method.GET);
            request.AddParameter("SoChungChi", SoChungChi);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("HoTen", HoTen);
            request.AddParameter("SoGiayTo", SoGiayTo);
            request.AddParameter("TrangThai", TrangThai);
            return Execute<DataTableViewModel>(request);
        }
        public IRestResponse<DataTableViewModel> NganhDuoc_CC_Duoc_CongBoWebsite(string SoChungChi, string tuNgay, string denNgay
      , string HoTen, string SoGiayTo, string TrangThai)
        {
            var request = new RestRequest("ND/NganhDuoc_CC_Duoc_CongBoWebsite", Method.GET);
            request.AddParameter("SoChungChi", SoChungChi);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("HoTen", HoTen);
            request.AddParameter("SoGiayTo", SoGiayTo);
            request.AddParameter("TrangThai", TrangThai);
            return Execute<DataTableViewModel>(request);
        }
        public IRestResponse<CC_Duoc_CapLaiSave>  NganhDuoc_CC_Duoc_CapLai_GetByHoSoID(long hoSoId)
        {
            var request = new RestRequest("ND/NganhDuoc_CC_Duoc_CapLai_GetByHoSoID", Method.GET);
            request.AddParameter("hoSoId", hoSoId);
            return Execute<CC_Duoc_CapLaiSave>(request);
        }
        #endregion
        #region func Dùng chung
        #endregion
    }
}
