using Microservice.Core.DomainService.Models;
using Microservice.Setting.Infrastructure.Entities;
using System.Linq;
using Microservice.DataAccess.Core.Interfaces;

namespace Microservice.Setting.Domain.SettingAggregate
{
    public class LocationDomain : AggregateRoot
    {
        private readonly IDataAccessWriteService writeService;

        public LocationDomain(IDataAccessWriteService writeService)
        {
            this.writeService = writeService;
        }

        public void CreateCountry(string name, string isoCode, int displayOrder, bool published = false)
        {
            var newCountry = new Country() { Name = name, IsoCode = isoCode, DisplayOrder = displayOrder, Published = published };
            writeService.Repository<Country>().Insert(newCountry);
            writeService.SaveChanges();
        }

        public void UpdateCountry(string id, string name, string isoCode, int displayOrder, bool published = false)
        {
            var country = writeService.Repository<Country>().Get(i => i.CountryId == id).FirstOrDefault();
            if (country != null)
            {
                country.Name = name;
                country.IsoCode = isoCode;
                country.DisplayOrder = displayOrder;
                country.Published = published;
                writeService.SaveChanges();
            }
        }

        public void DeleteCountry(string id)
        {
            var country = writeService.Repository<Country>().Get(i => i.CountryId == id).FirstOrDefault();
            if (country != null)
            {
                writeService.Repository<Country>().Delete(i => i.CountryId == id);
                writeService.SaveChanges();
            }
        }
    }
}
