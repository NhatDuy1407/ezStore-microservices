using Microservice.Setting.ApplicationCore.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.Setting.ApplicationCore.Application.Queries
{
    public interface ILocationQueries 
    {
        Task<CountryDto> GetCountry(string id);

        Task<IEnumerable<CountryDto>> GetCountries();
    }
}
