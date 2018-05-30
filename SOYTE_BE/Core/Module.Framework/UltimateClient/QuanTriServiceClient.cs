using Core.Common.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using Business.Entities;
using Business.Entities.ViewModels;
using Newtonsoft.Json;

namespace Module.Framework.UltimateClient
{
    public class QuanTriServiceClient : BaseClient, IDisposable
    {
        private bool _isDisposed;

        public QuanTriServiceClient() : base(AppSetting.QTApiBaseUrl)
        {
        }

        public DMParameter GetParameterByKey(string key)
        {
            var request = new RestRequest("QT/GetParameterByKey", Method.GET);
            request.AddParameter("key", key);
            var restResponse = Get<DMParameter>(request);
            return restResponse;
        }

        public IRestResponse<List<DMLinhVuc>> GetDanhMucLinhVuc(string keySearch, int pageSize, int pageIndex)
        {
            var request = new RestRequest("QT/GetDanhMucLinhVuc", Method.GET);
            request.AddParameter("keySearch", keySearch);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("pageIndex", pageIndex);
            var restResponse = Execute<List<DMLinhVuc>>(request);
            return restResponse;
        }

        public IRestResponse<List<DMCapDonVi>> GetDanhMucCapDonVi(int? pageSize, int? pageIndex)
        {
            var request = new RestRequest("QT/GetDanhMucCapDonVi", Method.GET);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("pageIndex", pageIndex);
            var restResponse = Execute<List<DMCapDonVi>>(request);
            return restResponse;
        }

        public IRestResponse<DMParameter> GetParameter(string key)
        {
            var request = new RestRequest("QT/GetParameterByKey", Method.GET);
            request.AddParameter("key", key);
            var restResponse = Execute<DMParameter>(request);
            return restResponse;
        }

        public IRestResponse InsParameter(DMParameter item)
        {
            var request = new RestRequest("QT/AddOrUpdateDMParameter", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };

            request.AddBody(new { item });
            return Execute(request);
        }

        public IRestResponse<PagedData<DanhMuc>> GetDMCapDonViConditionByPaged(string ten, string isActive, int pageSize, int pageIndex)
        {
            var request = new RestRequest("QT/GetDMCapDonViConditionByPaged", Method.GET);
            request.AddParameter("ten", ten);
            request.AddParameter("isActive", isActive);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("pageIndex", pageIndex);
            var restResponse = Execute<PagedData<DanhMuc>>(request);
            return restResponse;
        }

        public IRestResponse<PagedData<DanhMuc>> GetDMLinhVucByPaging(string keySearch, int pageSize, int pageIndex)
        {
            var request = new RestRequest("QT/GetDMLinhVucByPaging", Method.GET);
            request.AddParameter("keySearch", keySearch);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("pageIndex", pageIndex);
            var restResponse = Execute<PagedData<DanhMuc>>(request);
            return restResponse;
        }

        public IRestResponse<PagedData<DanhMuc>> GetTTHCDonViByPaged(string keySearch, string capDonViId, int pageSize, int pageIndex)
        {
            var request = new RestRequest("QT/GetTTHCDonViByPaged", Method.GET);
            request.AddParameter("keySearch", keySearch);
            request.AddParameter("capDonViId", capDonViId);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("pageIndex", pageIndex);
            var restResponse = Execute<PagedData<DanhMuc>>(request);
            return restResponse;
        }

        public IRestResponse<PagedData<DanhMuc>> GetDMDonViConditionByPaged(string ten, string capDonViId, string isActive, int pageSize, int pageIndex)
        {
            var request = new RestRequest("QT/GetDMDonViConditionByPaged", Method.GET);
            request.AddParameter("ten", ten);
            request.AddParameter("capDonViId", capDonViId);
            request.AddParameter("isActive", isActive);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("pageIndex", pageIndex);
            var restResponse = Execute<PagedData<DanhMuc>>(request);
            return restResponse;
        }

		public IRestResponse<PagedData<HoSoKemTheoViewModel>> GetHoSoKemTheoByPaged(bool? hoSoMoi, string linhVucId,string hoSoKemTheo,
			int pageSize, int pageIndex)
		{
			var request = new RestRequest("QT/GetDMHoSoKemTheoditionByPaged", Method.GET);
			request.AddParameter("hoSoMoi", hoSoMoi);
			request.AddParameter("linhVucId", linhVucId);
			request.AddParameter("hoSoKemTheo", hoSoKemTheo);
			request.AddParameter("pageSize", pageSize);
			request.AddParameter("pageIndex", pageIndex);
			var restResponse = Execute<PagedData<HoSoKemTheoViewModel>>(request);
			return restResponse;
		}

		public IRestResponse AddDMHoSoKemTheo(DM_HoSoKemTheo item)
		{
			var request = new RestRequest("QT/AddDMHoSoKemTheo", Method.POST)
			{
				RequestFormat = DataFormat.Json,
				JsonSerializer = new JsonSerializer()
			};

			request.AddBody(item);
			return Execute(request);
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
