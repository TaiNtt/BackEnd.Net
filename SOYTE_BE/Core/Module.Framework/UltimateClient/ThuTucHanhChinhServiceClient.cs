using Business.Entities;
using Core.Common.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.Entities.BindingModels;
using Business.Entities.ViewModels;

namespace Module.Framework.UltimateClient
{
    public class ThuTucHanhChinhServiceClient : BaseClient, IDisposable
    {
        private bool _isDisposed;

        public ThuTucHanhChinhServiceClient() : base(AppSetting.TTHCApiBaseUrl)
        {
        }

        public IRestResponse AddLinhVucByPaging(List<DMLinhVuc> items, int page, int pageSize)
        {
            var request = new RestRequest("TTHC/AddLinhVucByPaging", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };

            request.AddBody(new { items = items.Skip(page * pageSize).Take(pageSize) });
            return Execute(request);
        }

        public IRestResponse<List<TTHC_BieuDoThongKe>> GetBieuDoThongKe(string chartKey)
        {
            var request = new RestRequest("TTHC/GetBieuDoThongKe", Method.GET);
            request.AddParameter("ChartKey", chartKey);
            var restResponse = Execute<List<TTHC_BieuDoThongKe>>(request);
            return restResponse;
        }

        public IRestResponse<PagedData<ThuTucHanhChinhDongBoViewModel>> GetThuTucHanhChinhByDongBoPaged(string tenThuTuc, string conHieuLuc,
            string hetHieuLuc, string congKhai, string khongCongKhai, string tthcDacThu, string coQuanThucHien, string linhVucId, int pageIndex, int pageSize)
        {
            var request = new RestRequest("TTHC/GetThuTucHanhChinhByDongBoPaged", Method.GET);
            request.AddParameter("tenThuTuc", tenThuTuc);
            request.AddParameter("conHieuLuc", conHieuLuc);
            request.AddParameter("hetHieuLuc", hetHieuLuc);
            request.AddParameter("congKhai", congKhai);
            request.AddParameter("khongCongKhai", khongCongKhai);
            request.AddParameter("tthcDacThu", tthcDacThu);
            request.AddParameter("coQuanThucHien", coQuanThucHien);
            request.AddParameter("linhVucId", linhVucId);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);

            return Execute<PagedData<ThuTucHanhChinhDongBoViewModel>>(request);
        }

        public IRestResponse<ThuTucHanhChinhEditViewModel> GetThuTucHanhChinhById(string id)
        {
            var request = new RestRequest("TTHC/GetThuTucHanhChinhById", Method.GET);
            request.AddParameter("id", id);
            return Execute<ThuTucHanhChinhEditViewModel>(request);
        }

        public IRestResponse<PagedData<DM_HoSoKemTheo>> GetHoSoKemTheoByPaged(string tenHoSoKemTheo,string linhVucId, int pageSize, int pageIndex)
        {
            var request=new RestRequest("TTHC/GetHoSoKemTheoByPaged", Method.GET);
            request.AddParameter("tenHoSoKemTheo", tenHoSoKemTheo);
            request.AddParameter("linhVucId", linhVucId);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("pageIndex", pageIndex);
            return Execute<PagedData<DM_HoSoKemTheo>>(request);
        }

        public IRestResponse<EnumerableData<DanhMuc>> GetThuTucHanhChinhByLinhVucId(string id)
        {
            var request = new RestRequest("TTHC/GetThuTucHanhChinhByLinhVucId", Method.GET);
            request.AddParameter("id", id);
            return Execute<EnumerableData<DanhMuc>>(request);
        }

        public IRestResponse<EnumerableData<DanhMuc>> GetThuTucHanhChinhByDonViId(string id)
        {
            var request = new RestRequest("TTHC/GetThuTucHanhChinhByDonViId", Method.GET);
            request.AddParameter("id", id);
            return Execute<EnumerableData<DanhMuc>>(request);
        }

        public IRestResponse<EnumerableData<DanhMuc>> GetDonViByCapDonViId(string id)
        {
            var request = new RestRequest("TTHC/GetDonViByCapDonViId", Method.GET);
            request.AddParameter("id", id);
            return Execute<EnumerableData<DanhMuc>>(request);
        }

        public IRestResponse InsThuTucHanhChinh(TTHCEditBindingModel model)
        {
            var request = new RestRequest("TTHC/InsThuTucHanhChinh", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { model });
            return Execute(request);
        }
        
        public IRestResponse<EnumerableData<DanhMuc>> GetLinhVucByDonViId(string id)
        {
            var request = new RestRequest("TTHC/GetLinhVucByDonViId", Method.GET);
            request.AddParameter("id", id);
            return Execute<EnumerableData<DanhMuc>>(request);
        }

        public IRestResponse<PagedData<ThuTucHanhChinhDongBoViewModel>> GetThuTucHanhChinhByUserDonViPaged(string tenThuTuc, string congKhai,
            string khongCongKhai, string buuChinhCongIch, string dichVuCongCap, string linhVucId, string userId,
            int pageIndex,
            int pageSize)
        {
            var request = new RestRequest("TTHC/GetThuTucHanhChinhByUserDonViPaged", Method.GET);
            request.AddParameter("tenThuTuc", tenThuTuc);
            request.AddParameter("congKhai", congKhai);
            request.AddParameter("khongCongKhai", khongCongKhai);
            request.AddParameter("buuChinhCongIch", buuChinhCongIch);
            request.AddParameter("dichVuCongCap", dichVuCongCap);
            request.AddParameter("linhVucId", linhVucId);
            request.AddParameter("userId", userId);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<ThuTucHanhChinhDongBoViewModel>>(request);
        }

        public IRestResponse UpdThuTucHanhChinhCongKhai(List<TTHC_DonVi> model)
        {
            var request = new RestRequest("TTHC/UpdThuTucHanhChinhCongKhai", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { model });
            return Execute(request);
        }
        public IRestResponse<PagedData<ThuTucHanhChinhDongBoViewModel>> GetThuTucHanhChinhMoiByDongBoPaged(string tenThuTuc, string capDonVi,
             string coQuanThucHien, string linhVucId, int pageIndex, int pageSize)
        {
            var request = new RestRequest("TTHC/GetThuTucHanhChinhMoiByDongBoPaged", Method.GET);
            request.AddParameter("tenThuTuc", tenThuTuc);
            request.AddParameter("capDonVi", capDonVi);
            request.AddParameter("coQuanThucHien", coQuanThucHien);
            request.AddParameter("linhVucId", linhVucId);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);

            return Execute<PagedData<ThuTucHanhChinhDongBoViewModel>>(request);
        }

        public IRestResponse UpdTTHCSoQuyetDinh(List<TTHCUpdSoQuyetDinhBindingModel> model)
        {
            var request = new RestRequest("TTHC/UpdTTHCSoQuyetDinh", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { model });
            return Execute(request);
        }

        public IRestResponse UpdThuTucHanhChinhBuuChinhCongIch(List<TTHC_DonVi> model)
        {
            var request = new RestRequest("TTHC/UpdThuTucHanhChinhBuuChinhCongIch", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { model });
            return Execute(request);
        }

        public IRestResponse CongKhaiThuTucHanhByLstId(string thuTucHCIds, int userId)
        {
            var request = new RestRequest("TTHC/CongKhaiThuTucHanhByLstId", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            request.AddBody(new { thuTucHCIds, userId });
            return Execute(request);
        }

        public IRestResponse<ThuTucHanhChinhCongKhaiViewModel> GetThuTucHanhChinhCongKhaiById(string id)
        {
            var request = new RestRequest("TTHC/GetThuTucHanhChinhCongKhaiById", Method.GET);
            request.AddParameter("id", id);
            return Execute<ThuTucHanhChinhCongKhaiViewModel>(request);
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
    }
}
