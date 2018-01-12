using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RKSystem.DataAccess.Entities
{
    public class BaseEntity<T>
    {
        protected BaseEntity()
        {
            if (Id is Guid)
            {
                var obj = this as BaseEntity<Guid>;
                if (obj != null)
                    obj.Id = Guid.NewGuid();
            }
        }

        public virtual T Id { get; set; }

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
            //var unitOfWork = ApplicationDependencyResolver.ServiceDependencyResolver.GetScope()
            //    .Resolve<IRepositoryFactory>();
            //var list2Delete = list.ToList();
            //foreach (var item in list2Delete)
            //    unitOfWork.Repository<TEntity>().Delete(item);
        }
    }
}