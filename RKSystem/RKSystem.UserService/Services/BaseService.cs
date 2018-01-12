using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RKSystem.DataAccess.MongoDB.Interfaces;

namespace RKSystem.UserService.Services
{
    public class BaseService : IDisposable
    {
        protected IUnitOfWork UnitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
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
