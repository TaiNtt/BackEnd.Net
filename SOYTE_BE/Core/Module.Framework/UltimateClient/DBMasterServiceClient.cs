using Core.Common.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using Business.Entities;
using Business.Entities.ViewModels;
using Newtonsoft.Json;

namespace Module.Framework.UltimateClient
{
    public class DBMasterServiceClient : BaseClient, IDisposable
    {
        private bool _isDisposed;

        public DBMasterServiceClient() : base(AppSetting.MTApiBaseUrl)
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

        #region Danh mục ngành y
        public IRestResponse<DanhMucs> DBMaster_DM_GetAll()
        {
            var request = new RestRequest("MT/DBMaster_DM_GetAll", Method.GET);
            var restResponse = Execute<DanhMucs>(request);
            return restResponse;
        }
        #endregion
        public IRestResponse<List<MTDanhMuc>> DBMaster_DM_TinhThanh_GetAll()
        {
            var request = new RestRequest("MT/DBMaster_DM_TinhThanh_GetAll", Method.GET);
            var restResponse = Execute<List<MTDanhMuc>>(request);
            return restResponse;
        }
        public IRestResponse<List<DanhMucParentID>> DBMaster_DM_QuanHuyen_GetByTinhID(int TinhThanhID)
        {
            var request = new RestRequest("MT/DBMaster_DM_QuanHuyen_GetByTinhID", Method.GET);
            request.AddParameter("TinhThanhID", TinhThanhID);
            var restResponse = Execute<List<DanhMucParentID>>(request);
            return restResponse;
        }
        public IRestResponse<List<DanhMucParentID>> DBMaster_DM_PhuongXa_GetByQuanID(int QuanID)
        {
            var request = new RestRequest("MT/DBMaster_DM_PhuongXa_GetByQuanID", Method.GET);
            request.AddParameter("QuanID", QuanID);
            var restResponse = Execute<List<DanhMucParentID>>(request);
            return restResponse;
        }
        public IRestResponse<List<MTDanhMuc>> DBMaster_DM_TrinhDoChuyenMon_GetAll()
        {
            var request = new RestRequest("MT/DBMaster_DM_TrinhDoChuyenMon_GetAll", Method.GET);
            var restResponse = Execute<List<MTDanhMuc>>(request);
            return restResponse;
        }
        //DM_HinhThucToChuc
        public IRestResponse<List<MTDanhMuc>> DBMaster_DM_HinhThucToChuc_GetAll()
        {
            var request = new RestRequest("MT/DBMaster_DM_HinhThucToChuc_GetAll", Method.GET);
            //request.AddParameter("hoSoId", hoSoId);
            var restResponse = Execute<List<MTDanhMuc>>(request);
            return restResponse;
        }
        //CanBoPhongBanList
        public IRestResponse<List<CanBoPhongBanList>> DBMaster_ListCanBo_PhongBan()
        {
            var request = new RestRequest("MT/DBMaster_ListCanBo_PhongBan", Method.GET);
            //request.AddParameter("hoSoId", hoSoId);
            var restResponse = Execute<List<CanBoPhongBanList>>(request);
            return restResponse;
        }

        //E_LoaiCapPhep
        public IRestResponse<List<E_LoaiCapPhep>> DBMaster_E_LoaiCapPhep_GetAll()
        {
            var request = new RestRequest("MT/DBMaster_E_LoaiCapPhep_GetAll", Method.GET);
            //request.AddParameter("hoSoId", hoSoId);
            var restResponse = Execute<List<E_LoaiCapPhep>>(request);
            return restResponse;
        }
        //DM_GoiY
        public IRestResponse<List<DM_GoiY>> DBMaster_DM_GoiY_GetByLoaiGoiYID(int loaiGoiYID, int thuTucId, string search)
        {
            var request = new RestRequest("MT/DBMaster_DM_GoiY_GetByLoaiGoiYID", Method.GET);
            request.AddParameter("loaiGoiYID", loaiGoiYID);
            request.AddParameter("thuTucId", thuTucId);
            request.AddParameter("search", search);
            var restResponse = Execute<List<DM_GoiY>>(request);
            return restResponse;
        }
        //DM_GoiY
        public IRestResponse DBMaster_DM_GoiY_PopupUpd(DM_GoiYSave dM_GoiYSave)
        {
            var request = new RestRequest("MT/DBMaster_DM_GoiY_PopupUpd", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(dM_GoiYSave, settings);
            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }
        public IRestResponse DBMaster_DM_GoiY_PopupDel(int GoiYID)
        {
            var request = new RestRequest("MT/DBMaster_DM_GoiY_PopupDel", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(GoiYID, settings);
            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }

        //DM_LyDo
        public IRestResponse<PagedData<DM_LyDoList>> DBMaster_DM_LyDo_List(string LoaiCapPhepID, string LoaiLyDoID, string tuKhoa, int pageIndex, int pageSize)
        {
            var request = new RestRequest("MT/DBMaster_DM_LyDo_List", Method.GET);
            request.AddParameter("LoaiCapPhepID", LoaiCapPhepID);
            request.AddParameter("LoaiLyDoID", LoaiLyDoID);
            request.AddParameter("tuKhoa", tuKhoa);            
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<DM_LyDoList>>(request);
        }
        public IRestResponse<DM_LyDo> DBMaster_DM_LyDo_GetByLyDoID(int LyDoID)
        {
            var request = new RestRequest("MT/DBMaster_DM_LyDo_GetByLyDoID", Method.GET);
            request.AddParameter("LyDoID", LyDoID);
            var restResponse = Execute<DM_LyDo>(request);
            return restResponse;
        }
        public IRestResponse DBMaster_DM_LyDo_Save(DM_LyDo dm_lydo)
        {
            var request = new RestRequest("MT/DBMaster_DM_LyDo_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(dm_lydo, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }

        //E_LoaiLyDo
        public IRestResponse<List<E_LoaiLyDo>> DBMaster_E_LoaiLyDo_GetAll()
        {
            var request = new RestRequest("MT/DBMaster_E_LoaiLyDo_GetAll", Method.GET);
            var restResponse = Execute<List<E_LoaiLyDo>>(request);
            return restResponse;
        }


        //E_LoaiGoiY
        public IRestResponse<List<E_LoaiGoiY>> DBMaster_E_LoaiGoiY_GetAll()
        {
            var request = new RestRequest("MT/DBMaster_E_LoaiGoiY_GetAll", Method.GET);
            var restResponse = Execute<List<E_LoaiGoiY>>(request);
            return restResponse;
        }

        //DM_GoiY
        public IRestResponse<PagedData<DM_GoiYList>> DBMaster_DM_GoiY_List(string LoaiCapPhepID, string LoaiGoiYID, string tuKhoa, int pageIndex, int pageSize)
        {
            var request = new RestRequest("MT/DBMaster_DM_GoiY_List", Method.GET);
            request.AddParameter("LoaiCapPhepID", LoaiCapPhepID);
            request.AddParameter("LoaiGoiYID", LoaiGoiYID);
            request.AddParameter("tuKhoa", tuKhoa);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return Execute<PagedData<DM_GoiYList>>(request);
        }
        public IRestResponse<DM_GoiY> DBMaster_DM_GoiY_GetByGoiYID(int GoiYID)
        {
            var request = new RestRequest("MT/DBMaster_DM_GoiY_GetByGoiYID", Method.GET);
            request.AddParameter("GoiYID", GoiYID);
            var restResponse = Execute<DM_GoiY>(request);
            return restResponse;
        }
        public IRestResponse DBMaster_DM_GoiY_Save(DM_GoiY dm_goiy)
        {
            var request = new RestRequest("MT/DBMaster_DM_GoiY_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };
            var settings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var json = JsonConvert.SerializeObject(dm_goiy, settings);

            request.AddParameter("application/json", json, null, ParameterType.RequestBody);
            return Execute(request);
        }
    }
}
