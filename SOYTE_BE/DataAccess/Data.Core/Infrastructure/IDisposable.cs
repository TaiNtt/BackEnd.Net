﻿using System;

namespace Data.Core.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        public Disposable()
        {
            Dispose(false);
        }

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
    }
}
