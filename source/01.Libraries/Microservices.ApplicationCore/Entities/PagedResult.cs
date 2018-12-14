using System.Collections.Generic;

namespace Microservices.DataAccess.Core.Entities
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IEnumerable<T> Results { get; set; }
    }
}
