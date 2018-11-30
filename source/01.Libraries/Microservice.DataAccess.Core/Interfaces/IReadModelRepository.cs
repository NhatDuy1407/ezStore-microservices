﻿namespace Microservice.DataAccess.Core.Interfaces
{
    public interface IReadModelRepository
    {
        void Write<TEntity>(string key, TEntity data) where TEntity : class;

        TEntity Read<TEntity>(string key) where TEntity : class;
    }
}