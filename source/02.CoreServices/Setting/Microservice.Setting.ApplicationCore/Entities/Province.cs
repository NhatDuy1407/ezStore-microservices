using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using Ws4vn.Microservices.ApplicationCore.Entities;

namespace Microservice.Setting.ApplicationCore.Entities
{
    public class Province : ModelEntity<ObjectId>
    {
        public string Name { get; set; }

        public ObjectId CountryId { get; set; }

        public string IsoCode { get; set; }

        public int DisplayOrder { get; set; }

        public bool Published { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }
    }
}
