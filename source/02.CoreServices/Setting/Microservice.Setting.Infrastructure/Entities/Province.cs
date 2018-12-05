using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using Microservice.Core.Models;

namespace Microservice.Setting.Infrastructure.Entities
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
