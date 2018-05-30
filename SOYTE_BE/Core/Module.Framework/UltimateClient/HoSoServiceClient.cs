using Core.Common.Utilities;
using RestSharp;
using System;
using Business.Entities.HoSo;

//using System.Web.Script.Serialization;

namespace Module.Framework.UltimateClient
{
    public class HoSoServiceClient : BaseClient, IDisposable
    {
        private bool _isDisposed;

        public HoSoServiceClient() : base(AppSetting.HSApiBaseUrl)
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
      
        public IRestResponse ChungChiY_SaveFullProcess(HoSoSaveFull hoSoFullSave)
        {
            var request = new RestRequest("HS/ChungChiY_SaveFullProcess", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()

            };
            request.AddBody(new
            {
                hoSoFullSave.HoSoTiepNhan
          ,
                hoSoFullSave.ChungChiHanhNgheY
            });
            return Execute(request);
        }
       
      
    }
}