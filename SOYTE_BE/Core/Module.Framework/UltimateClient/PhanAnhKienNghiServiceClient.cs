using Core.Common.Utilities;
using System;

namespace Module.Framework.UltimateClient
{
    public class PhanAnhKienNghiServiceClient : BaseClient, IDisposable
    {
        private bool _isDisposed;

        public PhanAnhKienNghiServiceClient() : base(AppSetting.PAGYApiBaseUrl)
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
    }
}
