﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Microservice.Core.DataAccess.Entities
{
    public class BaseEntity<T>
    {
        protected BaseEntity()
        {
            if (Id is Guid)
            {
                if (this is BaseEntity<Guid> obj)
                    obj.Id = Guid.NewGuid();
            }
        }

        private T _idField;

        public virtual T Id
        {
            get => _idField;
            set => _idField = value;
        }

        public DateTime CreatedDate { get; set; }

        [Required] [StringLength(128)] public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(128)] public string UpdatedBy { get; set; }

        public bool Deleted { get; set; }

        protected void UpdateId(object dataId, string userId)
        {
            if (dataId == null)
            {
                CreatedBy = userId;
                CreatedDate = DateTime.Now;
            }

            UpdatedBy = userId;
            UpdatedDate = DateTime.Now;
        }

        protected void RemoveChildrenItems<TEntity>(ICollection<TEntity> list) where TEntity : class
        {
            //var service = ApplicationDependencyResolver.ServiceDependencyResolver.GetScope()
            //    .Resolve<IRepositoryFactory>();
            //var list2Delete = list.ToList();
            //foreach (var item in list2Delete)
            //    service.Repository<TEntity>().Delete(item);
        }
    }
}