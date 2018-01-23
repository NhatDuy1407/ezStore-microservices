using System;
using RKSystem.DataAccess.MongoDB.Interfaces;

namespace RKSystem.UserService.WriteSide
{
    public class BaseService : IDisposable
    {
        protected IWriteUnitOfWork UnitOfWork;

        public BaseService()
        {
        }

        public BaseService(IWriteUnitOfWork unitOfWork)
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
