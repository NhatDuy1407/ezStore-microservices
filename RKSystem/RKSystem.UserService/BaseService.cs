using System;
using RKSystem.DataAccess.MongoDB.Interfaces;

namespace RKSystem.UserService
{
    public class BaseService : IDisposable
    {
        protected IReadOnlyUnitOfWork UnitOfWork;

        public BaseService(IReadOnlyUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (UnitOfWork != null)
                    UnitOfWork.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Dispose
    }
}
