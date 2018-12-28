using System.Threading.Tasks;
using Microservices.FileSystem.ApplicationCore.Interfaces;

namespace Microservices.FileSystem.Infrastructure
{
    public class FSRepository : IFSRepository
    {
        protected readonly MongoFsDbContext _context;

        public FSRepository(MongoFsDbContext context)
        {
            _context = context;
        }

        public Task<byte[]> GetFile(string id)
        {
            return Task.FromResult(_context.GetFS().DownloadAsBytesAsync(new MongoDB.Bson.ObjectId(id)).Result);
        }

        public Task<string> UploadFile(string filename, byte[] source)
        {
            var id = _context.GetFS().UploadFromBytesAsync(filename, source).Result;
            return Task.FromResult(id.ToString());
        }
    }
}
