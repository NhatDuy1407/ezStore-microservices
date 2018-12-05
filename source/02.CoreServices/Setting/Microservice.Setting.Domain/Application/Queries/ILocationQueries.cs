using Microservice.Setting.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.Setting.Domain.Application.Queries
{
    public interface ILocationQueries 
    {
        Task<CountryDto> GetCountry(string id);

        Task<IEnumerable<CountryDto>> GetCountries();
    }
}
