using Core.Common.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using Business.Entities;
using Business.Entities.ViewModels;
using Newtonsoft.Json;

namespace Module.Framework.UltimateClient
{
    public class NganhYServiceClient : BaseClient, IDisposable
    {
        private bool _isDisposed;

        public NganhYServiceClient() : base(AppSetting.NYApiBaseUrl)
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

        #region CheckExsit

        public IRestResponse CheckExistSoChungChi(string id, string val)
        {
            var request = new RestRequest("NY/CheckExistSoChungChi", Method.GET);
            request.AddParameter("id", id);
            request.AddParameter("val", val);
            return Execute(request);
        }

        public IRestResponse CheckExistSoTiepNhanDangKyQuangCaoNganhY(string id, string val)
        {
            var request = new RestRequest("NY/CheckExistSoTiepNhanDangKyQuangCaoNganhY", Method.GET);
            request.AddParameter("id", id);
            request.AddParameter("val", val);
            return Execute(request);
        }

        public IRestResponse CheckExistSoGiayChungNhanATSH(string id, string val)
        {
            var request = new RestRequest("NY/CheckExistSoGiayChungNhanATSH", Method.GET);
            request.AddParameter("id", id);
            request.AddParameter("val", val);
            return Execute(request);
        }

        public IRestResponse CheckExistSoChungNhanLuongY(string id, string val)
        {
            var request = new RestRequest("NY/CheckExistSoChungNhanLuongY", Method.GET);
            request.AddParameter("id", id);
            request.AddParameter("val", val);
            return Execute(request);
        }
        
        #endregion

        #region Load DS ChungChiY
        public IRestResponse<ChungChiHanhNgheYSave> NganhY_ChungChiHanhNgheY_GetBySoChungChi(string SoChungChi)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_GetBySoChungChi", Method.GET);
            request.AddParameter("SoChungChi", SoChungChi);
            var restResponse = Execute<ChungChiHanhNgheYSave>(request);
            return restResponse;
        }

        public IRestResponse<ChungChiHanhNgheYSave> NganhY_ChungChiHanhNgheY_GetByID(long ChungChiHanhNgheYId)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_GetByID", Method.GET);
            request.AddParameter("ChungChiHanhNgheYId", ChungChiHanhNgheYId);
            var restResponse = Execute<ChungChiHanhNgheYSave>(request);
            return restResponse;
        }

        public IRestResponse<PagedData<ChungChiHanhNgheYViewModel>> NganhY_ChungChiHanhNgheY_Search(string SoChungChi, string tuNgay, string denNgay
            , string HoTen, string SoGiayTo, string lstTrangThai, int pageIndex, int pageSize)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_Search", Method.GET);
            request.AddParameter("SoChungChi", SoChungChi);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("HoTen", HoTen);
            request.AddParameter("SoGiayTo", SoGiayTo);
            request.AddParameter("lstTrangThai", lstTrangThai);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<ChungChiHanhNgheYViewModel>>(request);
        }

        public IRestResponse<PagedData<ChungChiHanhNgheYViewModel>> NganhY_ChungChiHanhNgheY_Lst(string SoChungChi, string tuNgay, string denNgay
            , string HoTen, string SoGiayTo, string TrangThai, int pageIndex, int pageSize)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_Lst", Method.GET);
            request.AddParameter("SoChungChi", SoChungChi);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("HoTen", HoTen);
            request.AddParameter("SoGiayTo", SoGiayTo);
            request.AddParameter("TrangThai", TrangThai);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<ChungChiHanhNgheYViewModel>>(request);
        }

        public IRestResponse<ChungChiHanhNgheYSave> NganhY_ChungChiHanhNgheY_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<ChungChiHanhNgheYSave>(request);
            return restResponse;
        }

        public IRestResponse<ChungChiHanhNgheYCapLaiSave> NganhY_ChungChiHanhNgheY_CapLai_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_CapLai_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<ChungChiHanhNgheYCapLaiSave>(request);
            return restResponse;
        }
        //public IRestResponse<ChungChiHanhNgheYCapLaiSave> NganhY_ChungChiHanhNgheY_CapLai_GetNoiDungSauByHoSoID(long HoSoID)
        //{
        //    var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_CapLai_GetByHoSoID", Method.GET);
        //    request.AddParameter("HoSoID", HoSoID);
        //    var restResponse = Execute<ChungChiHanhNgheYCapLaiSave>(request);
        //    return restResponse;
        //}


        public IRestResponse<ChungChiHanhNgheYDieuChinhSave> NganhY_ChungChiHanhNgheY_DieuChinh_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_DieuChinh_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<ChungChiHanhNgheYDieuChinhSave>(request);
            return restResponse;
        }
        #endregion

        #region Cấp mới ChungChiY
        public IRestResponse NganhY_ChungChiHanhNgheY_Save(ChungChiHanhNgheYSave chungChiHanhNgheYSave)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(chungChiHanhNgheYSave, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);

            return Execute(request);
        }

        public IRestResponse NganhY_ChungChiHanhNgheY_UpdDaCap(List<long> HoSoID)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID });
            return Execute(request);
        }

        public IRestResponse NganhY_ChungChiHanhNgheY_DelByHoSoID(long HoSoID, long ChungChiHanhNgheYID)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, ChungChiHanhNgheYID });
            return Execute(request);
        }
        #endregion

        #region Cấp lại ChungChiY
        public IRestResponse NganhY_ChungChiHanhNgheY_CapLai_Save(ChungChiHanhNgheYCapLaiSave chungChiHanhNgheYCapLaiSave)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_CapLai_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(chungChiHanhNgheYCapLaiSave, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);

            return Execute(request);
        }

        public IRestResponse NganhY_ChungChiHanhNgheY_CapLai_UpdDaCap(List<long> HoSoID)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_CapLai_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID });
            return Execute(request);
        }

        public IRestResponse NganhY_ChungChiHanhNgheY_CapLai_DelByHoSoID(long HoSoID, long CapLaiID)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_CapLai_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, CapLaiID });
            return Execute(request);
        }
        #endregion

        #region Dieu Chinh ChungChiY
        public IRestResponse NganhY_ChungChiHanhNgheY_DieuChinh_Save(ChungChiHanhNgheYDieuChinhSave chungChiHanhNgheYDieuChinhSave)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_DieuChinh_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(chungChiHanhNgheYDieuChinhSave, settings);
            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }

        public IRestResponse NganhY_ChungChiHanhNgheY_DieuChinh_UpdDaDieuChinh(List<long> HoSoID)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_DieuChinh_UpdDaDieuChinh", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID });
            return Execute(request);
        }

        public IRestResponse NganhY_ChungChiHanhNgheY_DieuChinh_DelByHoSoID(long HoSoID, long DieuChinhID)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_DieuChinh_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, DieuChinhID });
            return Execute(request);
        }
        #endregion

        #region Thu hồi
        public IRestResponse NganhY_ChungChiHanhNgheY_ThuHoi_Save(ChungChiHanhNgheY_ThuHoi chungChiHanhNgheYThuHoiSave)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_ThuHoi_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { chungChiHanhNgheYThuHoiSave });
            return Execute(request);
        }

        public IRestResponse NganhY_ChungChiHanhNgheY_ThuHoi_UpdXoaThuHoi(long ChungChiHanhNgheYID)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_ThuHoi_UpdXoaThuHoi", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { ChungChiHanhNgheYID });
            return Execute(request);
        }
        #endregion

        #region Rút chứng chỉ
        public IRestResponse NganhY_ChungChiHanhNgheY_RutChungChi_Save(ChungChiHanhNgheY_RutChungChi chungChiHanhNgheYRutChungChiSave)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_ThuHoi_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { chungChiHanhNgheYRutChungChiSave });
            return Execute(request);
        }

        public IRestResponse NganhY_ChungChiHanhNgheY_RutChungChi_UpdXoaRut(long ChungChiHanhNgheYID)
        {
            var request = new RestRequest("NY/NganhY_ChungChiHanhNgheY_ThuHoi_UpdXoaThuHoi", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { ChungChiHanhNgheYID });
            return Execute(request);
        }

        #endregion

        #region Đăng ký quảng cáo trang thiết bị
        public IRestResponse<DangKyQCTrangThietBi> NganhY_DangKyQCTrangThietBi_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_DangKyQCTrangThietBi_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<DangKyQCTrangThietBi>(request);
            return restResponse;
        }

        public IRestResponse<DangKyQCTrangThietBi> NganhY_DangKyQCTrangThietBi_GetByID(long DangKyQCTrangThietBiID)
        {
            var request = new RestRequest("NY/NganhY_DangKyQCTrangThietBi_GetByID", Method.GET);
            request.AddParameter("DangKyQCTrangThietBiID", DangKyQCTrangThietBiID);
            var restResponse = Execute<DangKyQCTrangThietBi>(request);
            return restResponse;
        }

        public IRestResponse<PagedData<DangKyQCTrangThietBiViewModel>> NganhY_DangKyQCTrangThietBi_Search(string SoTiepNhan, string tuNgay, string denNgay
            , string DichVuQuangCao, string DonViDK_Ten, int pageIndex, int pageSize)
        {
            var request = new RestRequest("NY/NganhY_DangKyQCTrangThietBi_Search", Method.GET);
            request.AddParameter("SoChungChi", SoTiepNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("HoTen", DichVuQuangCao);
            request.AddParameter("SoGiayTo", DonViDK_Ten);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<DangKyQCTrangThietBiViewModel>>(request);
        }

        public IRestResponse NganhY_DangKyQCTrangThietBi_Save(DangKyQCTrangThietBi dangKyQCTrangThietBiSave)
        {
            var request = new RestRequest("NY/NganhY_DangKyQCTrangThietBi_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(dangKyQCTrangThietBiSave, settings);
            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }

        public IRestResponse NganhY_DangKyQCTrangThietBi_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("NY/NganhY_DangKyQCTrangThietBi_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }

        public IRestResponse NganhY_DangKyQCTrangThietBi_DelByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_DangKyQCTrangThietBi_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID });
            return Execute(request);
        }

        #endregion

        #region Cấp mới Giấy phép hoạt động CSKCB
        public IRestResponse<GiayPhepHoatDongKCBSave> NganhY_GiayPhepHoatDongKCB_GetBySoGiayPhep(string SoGiayPhep)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongKCB_GetBySoGiayPhep", Method.GET);
            request.AddParameter("SoGiayPhep", SoGiayPhep);
            var restResponse = Execute<GiayPhepHoatDongKCBSave>(request);
            return restResponse;
        }
        public IRestResponse<GiayPhepHoatDongKCBSave> NganhY_GiayPhepHoatDongKCB_GetByID(long GiayPhepKhamChuaBenhID)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongKCB_GetByID", Method.GET);
            request.AddParameter("GiayPhepKhamChuaBenhID", GiayPhepKhamChuaBenhID);
            var restResponse = Execute<GiayPhepHoatDongKCBSave>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<GiayPhepHoatDongKCBViewModel>> NganhY_GiayPhepHoatDongKCB_Search(string SoGiayPhep, string tuNgay, string denNgay
            , string CoSoDK_Ten, string CoSoDK_HuyenID, string CoSoDK_XaID, int pageIndex, int pageSize)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongKCB_Search", Method.GET);
            request.AddParameter("SoGiayPhep", SoGiayPhep);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("CoSoDK_Ten", CoSoDK_Ten);
            request.AddParameter("CoSoDK_HuyenID", CoSoDK_HuyenID);
            request.AddParameter("CoSoDK_XaID", CoSoDK_XaID);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<GiayPhepHoatDongKCBViewModel>>(request);
        }
        public IRestResponse<GiayPhepHoatDongKCBSave> NganhY_GiayPhepHoatDongKCB_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongKCB_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<GiayPhepHoatDongKCBSave>(request);
            return restResponse;
        }
        public IRestResponse NganhY_GiayPhepHoatDongKCB_Save(GiayPhepHoatDongKCBSave giayPhepHoatDongKCBSave)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongKCB_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { giayPhepHoatDongKCBSave });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayPhepHoatDongKCB_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongKCB_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayPhepHoatDongKCB_DelByHoSoID(long HoSoID, long GiayPhepKhamChuaBenhID)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongKCB_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, GiayPhepKhamChuaBenhID });
            return Execute(request);
        }
        #endregion

        #region Cấp lại Giấy phép hoạt động CSKCB
        public IRestResponse<GiayPhepHoatDongKCBCapLaiSave> NganhY_GiayPhepHoatDongKCB_CapLai_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongKCB_CapLai_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<GiayPhepHoatDongKCBCapLaiSave>(request);
            return restResponse;
        }
        public IRestResponse NganhY_GiayPhepHoatDongKCB_CapLai_Save(GiayPhepHoatDongKCBCapLaiSave giayPhepHoatDongKCBCapLaiSave)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongKCB_CapLai_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { giayPhepHoatDongKCBCapLaiSave });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayPhepHoatDongKCB_CapLai_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongKCB_CapLai_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayPhepHoatDongKCB_CapLai_DelByHoSoID(long HoSoID, long CapLaiID)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongKCB_CapLai_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, CapLaiID });
            return Execute(request);
        }
        #endregion

        #region Giấy chứng nhận lương Y
        public IRestResponse<GiayChungNhanLuongYSave> NganhY_GiayChungNhanLuongY_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanLuongY_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<GiayChungNhanLuongYSave>(request);
            return restResponse;
        }

        public IRestResponse<GiayChungNhanLuongYSave> NganhY_GiayChungNhanLuongY_GetByID(long GiayChungNhanLuongYID)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanLuongY_GetByID", Method.GET);
            request.AddParameter("GiayChungNhanLuongYID", GiayChungNhanLuongYID);
            var restResponse = Execute<GiayChungNhanLuongYSave>(request);
            return restResponse;
        }

        public IRestResponse<PagedData<GiayChungNhanLuongYViewModel>> NganhY_GiayChungNhanLuongY_Search(string SoGiayChungNhan, string tuNgay, string denNgay
            , string HoTen, string SoGiayTo, int pageIndex, int pageSize)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanLuongY_Search", Method.GET);
            request.AddParameter("SoGiayChungNhan", SoGiayChungNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("HoTen", HoTen);
            request.AddParameter("SoGiayTo", SoGiayTo);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<GiayChungNhanLuongYViewModel>>(request);
        }

        public IRestResponse NganhY_GiayChungNhanLuongY_Save(GiayChungNhanLuongYSave giayChungNhanLuongYSave)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanLuongY_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(giayChungNhanLuongYSave, settings);
            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }

        public IRestResponse NganhY_GiayChungNhanLuongY_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanLuongY_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }

        public IRestResponse NganhY_GiayChungNhanLuongY_DelByHoSoID(long HoSoID, long GiayChungNhanLuongYID)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanLuongY_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, GiayChungNhanLuongYID });
            return Execute(request);
        }
        #endregion

        #region Cấp mới Giấy chứng nhận ATSH
        public IRestResponse<GiayChungNhanATSHSave> NganhY_GiayChungNhanATSH_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanATSH_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<GiayChungNhanATSHSave>(request);
            return restResponse;
        }
        public IRestResponse<GiayChungNhanATSHSave> NganhY_GiayChungNhanATSH_GetByID(long GiayChungNhanATSHID)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanATSH_GetByID", Method.GET);
            request.AddParameter("GiayChungNhanATSHID", GiayChungNhanATSHID);
            var restResponse = Execute<GiayChungNhanATSHSave>(request);
            return restResponse;
        }
        public IRestResponse<GiayChungNhanATSHSave> NganhY_GiayChungNhanATSH_GetBySoGiayChungNhan(string SoGiayChungNhan)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanATSH_GetBySoGiayChungNhan", Method.GET);
            request.AddParameter("SoGiayChungNhan", SoGiayChungNhan);
            var restResponse = Execute<GiayChungNhanATSHSave>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<GiayChungNhanATSHViewModel>> NganhY_GiayChungNhanATSH_Search(string SoGiayChungNhan, string tuNgay, string denNgay
            , string TenCoSo, string TenPhongXetNghiem, string HuyenID, int pageIndex, int pageSize)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanATSH_Search", Method.GET);
            request.AddParameter("SoGiayChungNhan", SoGiayChungNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("TenCoSo", TenCoSo);
            request.AddParameter("TenPhongXetNghiem", TenPhongXetNghiem);
            request.AddParameter("HuyenID", HuyenID);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<GiayChungNhanATSHViewModel>>(request);
        }
        public IRestResponse NganhY_GiayChungNhanATSH_Save(GiayChungNhanATSHSave giayChungNhanATSHSave)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanATSH_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(giayChungNhanATSHSave, settings);
            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }
        public IRestResponse NganhY_GiayChungNhanATSH_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanATSH_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayChungNhanATSH_DelByHoSoID(long HoSoID, long GiayChungNhanATSHID)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanATSH_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, GiayChungNhanATSHID });
            return Execute(request);
        }
        #endregion

        #region Cấp lại Giấy chứng nhận ATSH
        public IRestResponse<GiayChungNhanATSHCapLaiSave> NganhY_GiayChungNhanATSH_CapLai_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanATSH_CapLai_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<GiayChungNhanATSHCapLaiSave>(request);
            return restResponse;
        }
        public IRestResponse NganhY_GiayChungNhanATSH_CapLai_Save(GiayChungNhanATSHCapLaiSave giayChungNhanATSHCapLaiSave)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanATSH_CapLai_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(giayChungNhanATSHCapLaiSave, settings);
            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }
        public IRestResponse NganhY_GiayChungNhanATSH_CapLai_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanATSH_CapLai_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayChungNhanATSH_CapLai_DelByHoSoID(long HoSoID, long CapLaiID)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanATSH_CapLai_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, CapLaiID });
            return Execute(request);
        }
        #endregion

        #region Cấp mới Giấy chứng nhận BTGT
        public IRestResponse<GiayChungNhanBTGTSave> NganhY_GiayChungNhanBTGT_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanBTGT_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<GiayChungNhanBTGTSave>(request);
            return restResponse;
        }
        public IRestResponse<GiayChungNhanBTGTSave> NganhY_GiayChungNhanBTGT_GetByID(long GiayChungNhanBTGTID)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanBTGT_GetByID", Method.GET);
            request.AddParameter("GiayChungNhanBTGTID", GiayChungNhanBTGTID);
            var restResponse = Execute<GiayChungNhanBTGTSave>(request);
            return restResponse;
        }
        public IRestResponse<GiayChungNhanBTGTSave> NganhY_GiayChungNhanBTGT_GetBySoGiayChungNhan(string SoGiayChungNhan)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanBTGT_GetBySoGiayChungNhan", Method.GET);
            request.AddParameter("SoGiayChungNhan", SoGiayChungNhan);
            var restResponse = Execute<GiayChungNhanBTGTSave>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<GiayChungNhanBTGTViewModel>> NganhY_GiayChungNhanBTGT_Search(string SoGiayChungNhan, string tuNgay, string denNgay
            , string HoTen, string TenBaiThuoc, int pageIndex, int pageSize)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanBTGT_Search", Method.GET);
            request.AddParameter("SoGiayChungNhan", SoGiayChungNhan);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("HoTen", HoTen);
            request.AddParameter("TenBaiThuoc", TenBaiThuoc);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<GiayChungNhanBTGTViewModel>>(request);
        }
        public IRestResponse NganhY_GiayChungNhanBTGT_Save(GiayChungNhanBTGTSave giayChungNhanBTGTSave)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanBTGT_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { giayChungNhanBTGTSave });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayChungNhanBTGT_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanBTGT_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayChungNhanBTGT_DelByHoSoID(long HoSoID, long GiayChungNhanBTGTID)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanBTGT_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, GiayChungNhanBTGTID });
            return Execute(request);
        }
        #endregion

        #region Cấp lại Giấy chứng nhận BTGT
        public IRestResponse<GiayChungNhanBTGTCapLaiSave> NganhY_GiayChungNhanBTGT_CapLai_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanBTGT_CapLai_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<GiayChungNhanBTGTCapLaiSave>(request);
            return restResponse;
        }
        public IRestResponse NganhY_GiayChungNhanBTGT_CapLai_Save(GiayChungNhanBTGTCapLaiSave giayChungNhanBTGTCapLaiSave)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanBTGT_CapLai_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { giayChungNhanBTGTCapLaiSave });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayChungNhanBTGT_CapLai_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanBTGT_CapLai_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayChungNhanBTGT_CapLai_DelByHoSoID(long HoSoID, long CapLaiID)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanBTGT_CapLai_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, CapLaiID });
            return Execute(request);
        }
        #endregion

        #region Giấy phép Đoàn KCB
        public IRestResponse<GiayPhepDoanKCBSave> NganhY_GiayPhepDoanKCB_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepDoanKCB_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<GiayPhepDoanKCBSave>(request);
            return restResponse;
        }
        public IRestResponse<GiayPhepDoanKCBSave> NganhY_GiayPhepDoanKCB_GetByID(long GiayPhepDoanKCBID)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepDoanKCB_GetByID", Method.GET);
            request.AddParameter("GiayPhepDoanKCBID", GiayPhepDoanKCBID);
            var restResponse = Execute<GiayPhepDoanKCBSave>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<GiayPhepDoanKCBViewModel>> NganhY_GiayPhepDoanKCB_Search(string SoGiayPhep, string tuNgay, string denNgay
            , string TenDoanKCB, string tuNgayKCB, string denNgayKCB, string NoiKCB_HuyenID, string NoiKCB_XaID, int pageIndex, int pageSize)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepDoanKCB_Search", Method.GET);
            request.AddParameter("SoGiayPhep", SoGiayPhep);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("TenDoanKCB", TenDoanKCB);
            request.AddParameter("tuNgayKCB", tuNgayKCB);
            request.AddParameter("denNgayKCB", denNgayKCB);
            request.AddParameter("NoiKCB_HuyenID", NoiKCB_HuyenID);
            request.AddParameter("NoiKCB_XaID", NoiKCB_XaID);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<GiayPhepDoanKCBViewModel>>(request);
        }
        public IRestResponse NganhY_GiayPhepDoanKCB_Save(GiayPhepDoanKCBSave giayPhepDoanKCBSave)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepDoanKCB_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { giayPhepDoanKCBSave });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayPhepDoanKCB_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepDoanKCB_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayPhepDoanKCB_DelByHoSoID(long HoSoID, long GiayPhepDoanKCBID)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepDoanKCB_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, GiayPhepDoanKCBID });
            return Execute(request);
        }
        #endregion

        #region Cấp mới Giấy phép hoạt động Chu Thap Do
        public IRestResponse<GiayPhepHoatDongChuThapDo> NganhY_GiayPhepHoatDongChuThapDo_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongChuThapDo_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<GiayPhepHoatDongChuThapDo>(request);
            return restResponse;
        }
        public IRestResponse<GiayPhepHoatDongChuThapDo> NganhY_GiayPhepHoatDongChuThapDo_GetByID(long GiayPhepHoatDongChuThapDoID)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongChuThapDo_GetByID", Method.GET);
            request.AddParameter("GiayPhepHoatDongChuThapDoID", GiayPhepHoatDongChuThapDoID);
            var restResponse = Execute<GiayPhepHoatDongChuThapDo>(request);
            return restResponse;
        }
        public IRestResponse<GiayPhepHoatDongChuThapDo> NganhY_GiayPhepHoatDongChuThapDo_GetBySoGiayPhep(string SoGiayPhep)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongChuThapDo_GetBySoGiayPhep", Method.GET);
            request.AddParameter("SoGiayPhep", SoGiayPhep);
            var restResponse = Execute<GiayPhepHoatDongChuThapDo>(request);
            return restResponse;
        }
        public IRestResponse<PagedData<GiayPhepHoatDongChuThapDoViewModel>> NganhY_GiayPhepHoatDongChuThapDo_Search(string SoGiayPhep, string tuNgay, string denNgay
            , string TenDiem, int pageIndex, int pageSize)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongChuThapDo_Search", Method.GET);
            request.AddParameter("SoGiayPhep", SoGiayPhep);
            request.AddParameter("tuNgay", tuNgay);
            request.AddParameter("denNgay", denNgay);
            request.AddParameter("TenDiem", TenDiem);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<GiayPhepHoatDongChuThapDoViewModel>>(request);
        }
        public IRestResponse NganhY_GiayPhepHoatDongChuThapDo_Save(GiayPhepHoatDongChuThapDo giayPhepHoatDongChuThapDoSave)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongChuThapDo_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { giayPhepHoatDongChuThapDoSave });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayPhepHoatDongChuThapDo_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongChuThapDo_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayPhepHoatDongChuThapDo_DelByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_GiayChungNhanBTGT_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID });
            return Execute(request);
        }
        #endregion

        #region Cấp lại Giấy phép hoạt động Chu Thap Do
        public IRestResponse<GiayPhepHoatDongChuThapDoCapLaiSave> NganhY_GiayPhepHoatDongChuThapDo_CapLai_GetByHoSoID(long HoSoID)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongChuThapDo_CapLai_GetByHoSoID", Method.GET);
            request.AddParameter("HoSoID", HoSoID);
            var restResponse = Execute<GiayPhepHoatDongChuThapDoCapLaiSave>(request);
            return restResponse;
        }
        public IRestResponse NganhY_GiayPhepHoatDongChuThapDo_CapLai_Save(GiayPhepHoatDongChuThapDoCapLaiSave giayPhepHoatDongChuThapDoCapLaiSave)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongChuThapDo_CapLai_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { giayPhepHoatDongChuThapDoCapLaiSave });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayPhepHoatDongChuThapDo_CapLai_UpdDaCap(List<long> HoSoIDs)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongChuThapDo_CapLai_UpdDaCap", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoIDs });
            return Execute(request);
        }
        public IRestResponse NganhY_GiayPhepHoatDongChuThapDo_CapLai_DelByHoSoID(long HoSoID, long CapLaiID)
        {
            var request = new RestRequest("NY/NganhY_GiayPhepHoatDongChuThapDo_CapLai_DelByHoSoID", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { HoSoID, CapLaiID });
            return Execute(request);
        }
        #endregion


    }
}
