using System.Threading.Tasks;
using Microservices.FileSystem.ApplicationCore.Interfaces;

namespace Microservices.FileSystem.Infrastructure
{
    public class FSRepository: IFSRepository
    {
        protected readonly MongoDbContext _context;

        public FSRepository(MongoDbContext context)
        {
            _context = context;
        }

        public Task<string> UploadFile(string filename, byte[] source)
        {
            var id = _context.GetFS().UploadFromBytesAsync(filename, source).Result;
            return Task.FromResult(id.ToString());
        }
    }
}
