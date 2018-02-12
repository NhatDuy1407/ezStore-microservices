using System;
using RKSystem.DataAccess.MongoDB.Interfaces;

namespace RKSystem.UserService
{
    public class BaseService : IDisposable
    {
        protected IReadOnlyService Service;

        public BaseService(IReadOnlyService service)
        {
            Service = service;
        }

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (Service != null)
                    Service.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Dispose
    }
}
