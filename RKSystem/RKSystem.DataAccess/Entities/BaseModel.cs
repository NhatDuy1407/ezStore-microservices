using System;
using System.Collections.Generic;
using System.Text;

namespace RKSystem.DataAccess.Entities
{
    public class BaseModel
    {
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public bool Deleted { get; set; }
    }
}
