using Core.Common.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using Business.Entities;
using Business.Entities.ViewModels;
using Newtonsoft.Json;

namespace Module.Framework.UltimateClient
{
    public class BaoCaoThongKeServiceClient : BaseClient, IDisposable
    {
        private bool _isDisposed;

        public BaoCaoThongKeServiceClient() : base(AppSetting.BCApiBaseUrl)
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

        public IRestResponse<List<LichSuBienDongViewModel>> BaoCaoThongKe_LichSuBienDong_GetByGiayPhepID(long GiayPhepID, int LoaiCapPhepID)
        {
            var request = new RestRequest("BC/BaoCaoThongKe_LichSuBienDong_GetByGiayPhepID", Method.GET);
            request.AddParameter("GiayPhepID", GiayPhepID);
            request.AddParameter("LoaiCapPhepID", LoaiCapPhepID);
            var restResponse = Execute<List<LichSuBienDongViewModel>>(request);
            return restResponse;
        }
        public IRestResponse BaoCaoThongKe_LichSuBienDong_Save(LichSuBienDong lichSuBienDong)
        {
            var request = new RestRequest("BC/BaoCaoThongKe_LichSuBienDong_Save", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer(),
            };
            request.AddBody(new
            {
                lichSuBienDong
            });
            return Execute(request);
        }
    }
}
