using Microservices.Setting.ApplicationCore.Entities;
using MongoDB.Bson;
using System.Linq;
using Ws4vn.Microservices.ApplicationCore.Entities;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace Microservices.Setting.ApplicationCore.SettingAggregate
{
    public class LocationDomain : AggregateRoot
    {
        public LocationDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }

        public void CreateCountry(string name, string isoCode, int displayOrder, bool published = false)
        {
            var newCountry = new Country() { Name = name, IsoCode = isoCode, DisplayOrder = displayOrder, Published = published };
            _dataAccessService.Repository<Country>().Insert(newCountry);
        }

        public void UpdateCountry(string id, string name, string isoCode, int displayOrder, bool published = false)
        {
            var country = _dataAccessService.Repository<Country>().Get(i => i.Id == ObjectId.Parse(id)).FirstOrDefault();
            if (country != null)
            {
                country.Name = name;
                country.IsoCode = isoCode;
                country.DisplayOrder = displayOrder;
                country.Published = published;
            }
        }

        public void DeleteCountry(string id)
        {
            var country = _dataAccessService.Repository<Country>().Get(i => i.Id == ObjectId.Parse(id)).FirstOrDefault();
            if (country != null)
            {
                _dataAccessService.Repository<Country>().Delete(i => i.Id == ObjectId.Parse(id));
            }
        }
    }
}
