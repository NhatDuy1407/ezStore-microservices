using System.Collections.Generic;

namespace Microservice.Core.DataAccess.Entities
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IEnumerable<T> Results { get; set; }
    }
}
