using System.Collections.Generic;

namespace Microservice.DataAccess.Core.Entities
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IEnumerable<T> Results { get; set; }
    }
}
