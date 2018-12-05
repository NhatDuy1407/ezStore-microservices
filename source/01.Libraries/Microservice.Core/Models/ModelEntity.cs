using System;

namespace Microservice.Core.Models
{
    public class ModelEntity<T> : ViewModelEntity<T>
    {
        public ModelEntity()
        {
            CreatedDate = DateTime.Now;
        }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public bool Deleted { get; set; }
    }
}