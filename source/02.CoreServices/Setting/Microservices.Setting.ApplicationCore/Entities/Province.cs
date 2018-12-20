using MongoDB.Bson;
using Ws4vn.Microservices.ApplicationCore.Entities;

namespace Microservices.Setting.ApplicationCore.Entities
{
    public class Province : ModelEntity<ObjectId>
    {
        public int AutoId { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public string IsoCode { get; set; }

        public int DisplayOrder { get; set; }

        public bool Published { get; set; }
    }
}
