using System;

namespace Ws4vn.Microservices.ApplicationCore.Entities
{
    public class ViewModelEntity<T>
    {
        public ViewModelEntity()
        {
            UpdatedDate = DateTime.Now;
        }

        public T Id { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}