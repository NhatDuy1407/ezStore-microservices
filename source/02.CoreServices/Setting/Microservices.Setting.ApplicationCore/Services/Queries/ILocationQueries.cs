using Microservices.Setting.ApplicationCore.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Setting.ApplicationCore.Services.Queries
{
    public interface ILocationQueries 
    {
        Task<CountryDto> GetCountry(int id);

        Task<IEnumerable<CountryDto>> GetCountries();
    }
}
