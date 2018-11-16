using Microservice.Core.Models;
using MongoDB.Bson;

namespace Microservice.Setting.Infrastructure.Entities
{
    public class Country : ModelEntity<ObjectId>
    {
        public string CountryId
        {
            get
            {
                return Id.ToString();
            }
        }

        public string Name { get; set; }

        public string IsoCode { get; set; }

        public int DisplayOrder { get; set; }

        public bool Published { get; set; }
    }
}
